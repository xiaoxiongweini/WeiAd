using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainApp
{
    /// <summary>
    /// 配置信息
    /// </summary>
   public class AppConfig
    {
        /// <summary>
        /// 服务器名称
        /// </summary>
        public static string Name
        {
            get
            {
                string appname = "";
                if (System.Configuration.ConfigurationManager.AppSettings["Name"] != null)
                {
                    appname = System.Configuration.ConfigurationManager.AppSettings["Name"];
                }
                return appname;
            }
        }

        /// <summary>
        /// 站点主域名
        /// </summary>
        public static string MasterDomain
        {
            get
            {
                string appname = "";
                if (System.Configuration.ConfigurationManager.AppSettings["MasterDomain"] != null)
                {
                    appname = System.Configuration.ConfigurationManager.AppSettings["MasterDomain"];
                }
                return appname;
            }
        }
        
        /// <summary>
        /// 程序目录地址
        /// </summary>
        public static string WebPath
        {
            get
            {
                string appname = "";
                if (System.Configuration.ConfigurationManager.AppSettings["WebPath"] != null)
                {
                    appname = System.Configuration.ConfigurationManager.AppSettings["WebPath"];
                }
                return appname;
            }
        }

        /// <summary>
        /// 主服务器
        /// </summary>
        public static string SerDomain
        {
            get
            {
                string appname = "";
                if (System.Configuration.ConfigurationManager.AppSettings["SerDomain"] != null)
                {
                    appname = System.Configuration.ConfigurationManager.AppSettings["SerDomain"];
                }
                return appname;
            }
        }

        /// <summary>
        /// 同步时间，单位（秒）
        /// </summary>
        public static int SynchroTime
        {
            get
            {
                int appname = 10;
                if (System.Configuration.ConfigurationManager.AppSettings["SynchroTime"] != null)
                {
                    appname = int.Parse(System.Configuration.ConfigurationManager.AppSettings["SynchroTime"]);
                }

                return appname;
            }
        }
    }
}
