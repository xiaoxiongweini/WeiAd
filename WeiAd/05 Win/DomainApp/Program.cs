using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DN.WeiAd.Models;

namespace DomainApp
{
    class Program
    {
        static void Main(string[] args)
        {

            SendServ();

            //10秒请求一次
            int sleep = AppConfig.SynchroTime;

            while (true)
            {
                GetDomain();
                Console.WriteLine(string.Format("{0}同步服务器", DateTime.Now));

                //睡眠时间
                Thread.Sleep(sleep * 1000);
            }

            Console.WriteLine("结束");
            Console.ReadKey();
        }

        /// <summary>
        /// 上报服务器
        /// </summary>
        static void SendServ()
        {
            try
            {
                string url = AppConfig.SerDomain + "/Services/SerAdd.ashx?sname=" + AppConfig.Name;
                string json = DN.Framework.Utility.WebClientHelper.PostSend(url, "", "utf-8", "utf-8");
                if (!string.IsNullOrEmpty(json))
                {
                    ApiResult result = new ApiResult();
                    result = DN.Framework.Utility.Serializer.DeserializeObject<ApiResult>(json);
                    Console.WriteLine(json);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 同步域名
        /// </summary>
        static void GetDomain()
        {
            try
            {
                IISHelper helper = new IISHelper();
                string url = AppConfig.SerDomain + "/Services/SerGetDomain.ashx?sname=" + AppConfig.Name;
                string json = DN.Framework.Utility.WebClientHelper.PostSend(url, "", "utf-8", "utf-8");
                if (!string.IsNullOrEmpty(json))
                {
                    ApiResult result = new ApiResult();
                    result = DN.Framework.Utility.Serializer.DeserializeObject<ApiResult>(json);
                    if (result.code == 1)
                    {
                        List<DomainSynchroHistoryVO> list = DN.Framework.Utility.Serializer.DeserializeObject<List<DomainSynchroHistoryVO>>(result.datajson);
                        foreach (var item in list)
                        {
                            string maindoam = item.MainDomain;

                            List<string> dolist = new List<string>();
                            if (!string.IsNullOrEmpty(item.Domains))
                            {
                                var dlist = item.Domains.Split(new char[] { '\r', '\t', '\n' });
                                foreach (var domain in dlist)
                                {
                                    if (!string.IsNullOrEmpty(domain))
                                    {
                                        dolist.Add(domain);
                                    }
                                }
                            }

                            if (item.OperType == 0)
                            {
                                helper.CreateWebSite(maindoam, dolist, AppConfig.WebPath);
                                Console.WriteLine(string.Format("{0}添加域名服务。", DateTime.Now));
                            }
                            else if (item.OperType == 1)
                            {
                                //删除域名
                                helper.DelDoamin(maindoam, dolist);
                                Console.WriteLine(string.Format("{0}删除域名服务。", DateTime.Now));
                            }
                            else if (item.OperType == 2)
                            {
                                //删除主域名
                                helper.DelWebSite(maindoam);
                                helper.DelAppliction(maindoam);
                                Console.WriteLine(string.Format("{0}删除主域名服务。", DateTime.Now));
                            }

                        }
                    }
                    Console.WriteLine(result.msg);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
