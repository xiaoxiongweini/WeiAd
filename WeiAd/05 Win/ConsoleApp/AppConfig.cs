using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class AppConfig
    {
        /// <summary>
        /// 刷新地址
        /// </summary>
        public static string OpenUrl
        {
            get
            {
                string appname = "";
                if (System.Configuration.ConfigurationManager.AppSettings["OpenUrl"] != null)
                {
                    appname = System.Configuration.ConfigurationManager.AppSettings["OpenUrl"];
                }
                return appname;
            }
        }

        /// <summary>
        /// 同步时间，单位（秒）
        /// </summary>
        public static int TimeSpan
        {
            get
            {
                int appname = 10;
                if (System.Configuration.ConfigurationManager.AppSettings["TimeSpan"] != null)
                {
                    appname = int.Parse(System.Configuration.ConfigurationManager.AppSettings["TimeSpan"]);
                }

                return appname;
            }
        }
    }
}
