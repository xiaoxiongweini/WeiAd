using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Threading;
using DN.WeiAd.Models;
using DN.WeiAd.Business;

namespace ConsoleApp.Service
{
    public class IpHelper
    {
        public static void UpdateIp()
        {
            HashSet<string> m_Ips = new HashSet<string>();

            var list = DN.WeiAd.Business.LogIpInfoBLL.Instance.GetModels(new LogIpInfoPara());
            foreach (var item in list)
            {
                if (!m_Ips.Contains(item.Ip))
                {
                    m_Ips.Add(item.Ip);
                }
            }

            string cmd = "select distinct(clientip) ip from [LogBrowse] ";

            DataTable table = DN.WeiAd.Business.ChartBLL.Instance.GetTable(cmd);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                try
                {


                    string ip = table.Rows[i][0].ToString();
                    var tlist = ip.Split(',');
                    if (tlist.Length == 1)
                    {
                        ip = tlist[0];
                    }
                    if (ip == "127.0.0.1")
                    {
                        continue;
                    }

                    if (!m_Ips.Contains(ip))
                    {
                        string url = string.Format("http://ip.taobao.com/service/getIpInfo.php?ip={0}", ip);
                        string json = DN.Framework.Utility.WebClientHelper.GetSend(url);

                        IpInfo info = DN.Framework.Utility.Serializer.DeserializeObject<IpInfo>(json);
                        Console.WriteLine(json);
                        LogIpInfoVO log = new LogIpInfoVO();
                        log.Ip = ip;
                        log.CreateDate = DateTime.Now;
                        if (info.code == 0)
                        {
                            log.area = info.data.area;
                            log.city = info.data.city;
                            log.country = info.data.country;
                            log.county = info.data.county;
                            log.Ip = info.data.ip;
                            log.isp = info.data.isp;
                            log.region = info.data.region;
                        }
                        LogIpInfoBLL.Instance.Add(log);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                //Thread.Sleep(600);
            }

            Console.ReadKey();
        }
    }

    public class Data
    {
        /// <summary>
        /// 
        /// </summary>
        public string ip { get; set; }
        /// <summary>
        /// 中国
        /// </summary>
        public string country { get; set; }
        /// <summary>
        /// 华北
        /// </summary>
        public string area { get; set; }
        /// <summary>
        /// 北京市
        /// </summary>
        public string region { get; set; }
        /// <summary>
        /// 北京市
        /// </summary>
        public string city { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string county { get; set; }
        /// <summary>
        /// 电信
        /// </summary>
        public string isp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string country_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string area_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string region_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string city_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string county_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string isp_id { get; set; }
    }

    public class IpInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Data data { get; set; }
    }
}
