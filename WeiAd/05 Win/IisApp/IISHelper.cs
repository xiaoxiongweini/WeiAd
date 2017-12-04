using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Web.Administration;
using System.IO;
using System.Threading;

namespace IisApp
{
    /// <summary>
    /// IISHelper
    /// </summary>
    public class IISHelper
    {
        ServerManager iisManager = new ServerManager();

        public void Start(string pathname = "")
        {
            string sitepath = pathname;

            if (string.IsNullOrEmpty(sitepath))
            {
                sitepath = AppDomain.CurrentDomain.BaseDirectory;
            }

            Console.Write(AppDomain.CurrentDomain.BaseDirectory);


            var dirlist = Directory.GetDirectories(sitepath);
            foreach (var item in dirlist)
            {
                string domain = item.Replace(sitepath, "");
                if (AppConfig.IsRunType == "0")
                {

                    CreateWebSite(domain, item, "80");
                }
                else if (AppConfig.IsRunType == "1")
                {
                    DelWebSite(domain);
                }
                Console.WriteLine(domain);
            }

            Console.WriteLine("新建站点完成。");
        }

        /// <summary>
        /// 重启IIS
        /// </summary>
        public void RestartIIS()
        {
            if (!File.Exists(AppConfig.IisFileRestart))
            {
                Console.WriteLine(string.Format("时间：{0},文件：{1}不存在。", DateTime.Now, AppConfig.IisFileRestart));
                return;
            }

            int SleepTime = 60;
            try
            {
                var list = iisManager.ApplicationPools;
                foreach (var item in list)
                {
                    string AppPoolName = item.Name;
                    string WebSiteName = item.Name;

                    var pool = iisManager.ApplicationPools[AppPoolName];
                    pool.Stop();
                    if (pool != null && pool.State == ObjectState.Stopped)
                    {
                        WriteLog("检测到应用池" + AppPoolName + "停止服务");
                        WriteLog("正在启动应用池" + AppPoolName);
                        if (pool.Start() == ObjectState.Started)
                        {
                            WriteLog("成功启动应用池" + AppPoolName);
                        }
                        else
                        {
                            WriteLog("启动应用池" + AppPoolName + "失败. " + SleepTime / 60 + "秒后重试启动");
                        }
                    }

                    var site = iisManager.Sites[WebSiteName];
                    if (site != null && site.State == ObjectState.Stopped)
                    {
                        WriteLog("检测到网站" + WebSiteName + "停止服务");
                        WriteLog("正在启动网站" + WebSiteName);
                        if (site.Start() == ObjectState.Started)
                        {
                            WriteLog("成功启动网站" + WebSiteName);
                        }
                        else
                        {
                            WriteLog("启动网站" + WebSiteName + "失败. " + SleepTime / 60 + "秒后重试启动");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                WriteLog(ex.Message.ToString());
            }

            if (File.Exists(AppConfig.IisFileRestart))
            {
                File.Delete(AppConfig.IisFileRestart);
                Console.WriteLine(string.Format("时间：{0},删除文件：{1}", DateTime.Now, AppConfig.IisFileRestart));
            }
        }

        static void WriteLog(string msg)
        {
            Console.WriteLine(msg);
        }

        /// <summary>
        /// create web site in IIS
        /// </summary>
        /// <param name="websiteName">站点名使用域名</param>
        /// <param name="physicsPath">物理路径</param>
        /// <param name="ip">ip地址</param>
        /// <param name="port">端口号</param>
        /// <param name="domain">域名</param>
        /// <param name="poolver">应用程序池的DOTNET FRAMEWORK版本</param>
        /// <param name="binding">使用的协议</param>
        public void CreateWebSite(string websiteName, string physicsPath,
            string port, string ip = "*", string poolver = "v4.0", string binding = "http")
        {
            try
            {
                string fullIP = ip + ":" + port + ":" + websiteName;
                ApplicationPool newPool = iisManager.ApplicationPools.Add(websiteName);
                newPool.ManagedRuntimeVersion = poolver;

                Site mySide = iisManager.Sites.Add(websiteName, binding, fullIP, physicsPath);

                mySide.Applications[0].ApplicationPoolName = websiteName;
                newPool.ProcessModel.MaxProcesses = 5;
                iisManager.CommitChanges();
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
        }

        private List<string> GetWebSites()
        {
            var list = iisManager.Sites;

            List<string> dlist = new List<string>();

            foreach (var item in list)
            {
                if (CheckName(item.Name))
                {
                    dlist.Add(item.Name);
                }
            }

            return dlist;
        }

        private bool CheckName(string name)
        {
            if (string.IsNullOrEmpty(AppConfig.DelLikeName))
            {
                return false;
            }

            var list = AppConfig.DelLikeName.Split(',');

            foreach (var item in list)
            {
                if (name.IndexOf(item) != -1)
                {
                    return true;
                }
            }

            return false;
        }

        private List<string> GetAppliction()
        {
            List<string> dlist = new List<string>();

            var list = iisManager.ApplicationPools;
            StringBuilder sb = new StringBuilder();

            foreach (var item in list)
            {
                if (CheckName(item.Name))
                {
                    dlist.Add(item.Name);
                    sb.AppendLine(item.Name);
                    for (int i = 0; i < item.Attributes.Count; i++)
                    {
                        string name = item.Attributes[i].Name;
                        string val = item.GetAttributeValue(name).ToString();
                    }
                }
            }
            return dlist;
        }

        /// <summary>
        /// 删除域名
        /// </summary>
        /// <param name="domain"></param>
        public void Del(string domain)
        {
            var slist = GetWebSites();
            var alist = GetAppliction();

            foreach (var item in slist)
            {
                if (item == domain)
                {
                    DelWebSite(item);
                }
            }
            foreach (var item in alist)
            {
                if (item == domain)
                {
                    DelAppliction(item);
                }
            }

        }

        /// <summary>
        /// 删除相关站点和应用池
        /// </summary>
        public void Del()
        {
            var slist = GetWebSites();
            var alist = GetAppliction();

            foreach (var item in slist)
            {
                DelWebSite(item);
            }
            foreach (var item in alist)
            {
                DelAppliction(item);
            }

            Console.WriteLine("删除完成。");
        }

        private void DelAppliction(string name)
        {
            var app = iisManager.ApplicationPools[name];
            Console.WriteLine(string.Format("正在删除应用程序池：{0}", name));
            iisManager.ApplicationPools.Remove(app);
            iisManager.CommitChanges();
        }

        private void DelWebSite(string name)
        {
            Site item = iisManager.Sites[name];
            item.Applications.Remove(item.Applications[0]);
            Console.WriteLine(string.Format("正在删除站点：{0}", name));
            iisManager.Sites.Remove(item);
            iisManager.CommitChanges();
        }


        /// <summary>
        /// 创建主域名，并且批量添加域名解析
        /// </summary>
        /// <param name="websiteName">主域名</param>
        /// <param name="domains">其它域名集合</param>
        /// <param name="physicsPath">路径</param>
        /// <param name="port"></param>
        /// <param name="ip"></param>
        /// <param name="poolver"></param>
        /// <param name="binding"></param>
        public void CreateWebSite(string websiteName, List<string> domains, string physicsPath,
            string port = "80", string ip = "*", string poolver = "v4.0", string binding = "http")
        {
            try
            {
                Console.WriteLine(websiteName);

                string appname = websiteName.Replace("*.", "");
                string fullIP = ip + ":" + port + ":" + websiteName;

                var pool = iisManager.ApplicationPools[websiteName];
                Site mySide = null;
                if (pool == null)
                {
                    ApplicationPool newPool = iisManager.ApplicationPools.Add(appname);
                    newPool.ManagedRuntimeVersion = poolver;
                    newPool.ProcessModel.MaxProcesses = 5;
                    mySide = iisManager.Sites.Add(appname, binding, fullIP, physicsPath);
                }
                else
                {
                    mySide = iisManager.Sites[appname];
                }

                mySide.Applications[0].ApplicationPoolName = appname;

                List<string> sitedomain = new List<string>();
                foreach (var doitem in mySide.Bindings)
                {
                    sitedomain.Add(doitem.BindingInformation);
                }

                foreach (var item in domains)
                {
                    if (!string.IsNullOrEmpty(item))
                    {
                        Console.WriteLine(item);

                        string fullIPs = ip + ":" + port + ":" + item;

                        if (!sitedomain.Contains(fullIPs))
                        {
                            mySide.Bindings.Add(fullIPs, binding);
                        }
                    }
                }

                iisManager.CommitChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
