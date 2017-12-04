using Microsoft.Web.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinIIS
{
    public class IISHelper
    {
        ServerManager iisManager = new ServerManager();

        /// <summary>
        /// 获取站点
        /// </summary>
        /// <returns></returns>
        public List<string> GetWebSites()
        {
            var list = iisManager.Sites;

            List<string> dlist = new List<string>();

            foreach (var item in list)
            {
                dlist.Add(item.Name);
            }

            return dlist;
        }

        public List<string> GetAppliction()
        {
            List<string> dlist = new List<string>();

            var list = iisManager.ApplicationPools;
            StringBuilder sb = new StringBuilder();

            foreach (var item in list)
            {
                dlist.Add(item.Name);
                sb.AppendLine(item.Name);
                for (int i = 0; i < item.Attributes.Count; i++)
                {
                    string name = item.Attributes[i].Name;
                    string val = item.GetAttributeValue(name).ToString();
                }
            }
            return dlist;
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
