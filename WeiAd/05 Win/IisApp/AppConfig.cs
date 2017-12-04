using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IisApp
{
    class AppConfig
    {
        /// <summary>
        /// 该目录下以文件夹的形式命名站点
        /// </summary>
        public static string SiteDir
        {
            get
            {
                string val = "";
                if (System.Configuration.ConfigurationManager.AppSettings["DomainPath"] != null)
                {
                    val = System.Configuration.ConfigurationManager.AppSettings["DomainPath"];
                }
                return val;
            }
        }

        /// <summary>
        /// 要删除的值
        /// </summary>
        public static string DelLikeName
        {
            get
            {
                string val = "";
                if (System.Configuration.ConfigurationManager.AppSettings["DelLikeName"] != null)
                {
                    val = System.Configuration.ConfigurationManager.AppSettings["DelLikeName"];
                }
                return val;
            }
        }

        /// <summary>
        /// 运行方法,0新建站点，1删除站点
        /// </summary>
        public static string IsRunType
        {
            get
            {
                string val = "0";
                if (System.Configuration.ConfigurationManager.AppSettings["IsRunType"] != null)
                {
                    val = System.Configuration.ConfigurationManager.AppSettings["IsRunType"];
                }
                return val;
            }
        }

        /// <summary>
        /// 重启IIS时的指令文件，如果文件存在，则重启IIS，并且删除文件，如果不存在则不处理
        /// </summary>
        public static string IisFileRestart
        {
            get
            {
                string val = "";
                if (System.Configuration.ConfigurationManager.AppSettings["IisFileRestart"] != null)
                {
                    val = System.Configuration.ConfigurationManager.AppSettings["IisFileRestart"];
                }
                return val;
            }
        }

        /// <summary>
        /// 主站点域名
        /// </summary>
        public static string MainDomain
        {
            get
            {
                string appname = "";
                if (System.Configuration.ConfigurationManager.AppSettings["MainDomain"] != null)
                {
                    appname = System.Configuration.ConfigurationManager.AppSettings["MainDomain"];
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
    }
}
