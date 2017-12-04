using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.WeiAd.Business.Config
{
    /// <summary>
    /// 配置信息
    /// </summary>
    public partial class AppConfig
    {
        //切换成敏捷的阿里云帐户
        //const string accessKeyId = "LTAIfQHdApgdhfh3";
        //const string accessKeySecret = "gWVnAh1Yomm0LrWopwnDuWAavQtpiq";
        //const string endpoint = "http://oss-cn-beijing.aliyuncs.com";
        //const string domain = "zx268.oss-cn-shanghai.aliyuncs.com";

        private const string accessKeyId = "LTAILcOHnhaZQegc";
        private const string accessKeySecret = "kqNRcw73QTNcTGFco4cC7y5UIWv144";
        private const string endpoint = "http://oss-cn-shanghai.aliyuncs.com";
        private const string domain = "jmtu.oss-cn-shanghai.aliyuncs.com";

        /// <summary>
        /// 是否启用阿里云OSS
        /// </summary>
        public static bool AliYunIsSave
        {
            get
            {
                bool appname = false;
                if (System.Configuration.ConfigurationManager.AppSettings["AliYunIsSave"] != null)
                {
                    appname = bool.Parse(System.Configuration.ConfigurationManager.AppSettings["AliYunIsSave"]);
                }
                return appname;
            }
        }

        /// <summary>
        /// AccessKeyId
        /// </summary>
        public static string AliYunAccessKeyId
        {
            get
            {
                string appname = "LTAILcOHnhaZQegc";
                if (System.Configuration.ConfigurationManager.AppSettings["AliYunAccessKeyId"] != null)
                {
                    appname = System.Configuration.ConfigurationManager.AppSettings["AliYunAccessKeyId"];
                }
                return appname;
            }
        }

        /// <summary>
        /// AccessKeySecret
        /// </summary>
        public static string AliYunAccessKeySecret
        {
            get
            {
                string appname = "kqNRcw73QTNcTGFco4cC7y5UIWv144";
                if (System.Configuration.ConfigurationManager.AppSettings["AliYunAccessKeySecret"] != null)
                {
                    appname = System.Configuration.ConfigurationManager.AppSettings["AliYunAccessKeySecret"];
                }
                return appname;
            }
        }

        /// <summary>
        /// OSS服务器地址
        /// </summary>
        public static string AliYunEndpoint
        {
            get
            {
                string appname = "http://oss-cn-shanghai.aliyuncs.com";
                if (System.Configuration.ConfigurationManager.AppSettings["AliYunEndpoint"] != null)
                {
                    appname = System.Configuration.ConfigurationManager.AppSettings["AliYunEndpoint"];
                }
                return appname;
            }
        }

        /// <summary>
        /// 阿里云域名
        /// </summary>
        public static string AliYunDomain
        {
            get
            {
                string appname = "http://jmtu.oss-cn-shanghai.aliyuncs.com/";
                if (System.Configuration.ConfigurationManager.AppSettings["AliYunDomain"] != null)
                {
                    appname = System.Configuration.ConfigurationManager.AppSettings["AliYunDomain"];
                }
                return appname;
            }
        }

        /// <summary>
        /// Bucket名称
        /// </summary>
        public static string AliYunBucketName
        {
            get
            {
                string appname = "jmtu";
                if (System.Configuration.ConfigurationManager.AppSettings["AliYunBucketName"] != null)
                {
                    appname = System.Configuration.ConfigurationManager.AppSettings["AliYunBucketName"];
                }
                return appname;
            }
        }

    }
}
