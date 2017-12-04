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
        /// <summary>
        /// 水印透明度，0不启用该功能。1-100之间
        /// </summary>
        public static int ImgQuality
        {
            get
            {
                int appname = 0;
                if (System.Configuration.ConfigurationManager.AppSettings["ImgQuality"] != null)
                {
                    appname = int.Parse(System.Configuration.ConfigurationManager.AppSettings["ImgQuality"]);
                }
                return appname;
            }
        }

        /// <summary>
        /// 水印文字
        /// </summary>
        public static string ImgWenZhi
        {
            get
            {
                string appname = "网易认证";
                if (System.Configuration.ConfigurationManager.AppSettings["ImgWenZhi"] != null)
                {
                    appname = System.Configuration.ConfigurationManager.AppSettings["ImgWenZhi"];
                }
                return appname;
            }
        }

        public static string AppName
        {
            get
            {
                string appname = "测试程序";
                if (System.Configuration.ConfigurationManager.AppSettings["AppName"] != null)
                {
                    appname = System.Configuration.ConfigurationManager.AppSettings["AppName"];
                }
                return appname;
            }
        }

        /// <summary>
        /// 模版名称
        /// </summary>
        public static string TemplateName
        {
            get
            {
                string appname = "AdViewWx1.aspx";
                if (System.Configuration.ConfigurationManager.AppSettings["AdTemp"] != null)
                {
                    appname = System.Configuration.ConfigurationManager.AppSettings["AdTemp"];
                }
                return appname;
            }
        }

        /// <summary>
        /// 模版文件地址
        /// </summary>
        public static string TemplatePath
        {
            get
            {
                string appname = "";
                if (System.Configuration.ConfigurationManager.AppSettings["TemplatePath"] != null)
                {
                    appname = System.Configuration.ConfigurationManager.AppSettings["TemplatePath"];
                }
                return appname;
            }
        }

        /// <summary>
        /// 动态替换模版
        /// </summary>
        public static string TemplatePathDynamic
        {
            get
            {
                string appname = "";
                if (System.Configuration.ConfigurationManager.AppSettings["TemplatePathDynamic"] != null)
                {
                    appname = System.Configuration.ConfigurationManager.AppSettings["TemplatePathDynamic"];
                }
                return appname;
            }
        }
        
        /// <summary>
        /// 是否显示新闻,0空白页，1随机新闻
        /// </summary>
        public static int IsArticleView
        {
            get
            {
                string appname = "0";
                if (System.Configuration.ConfigurationManager.AppSettings["IsArticleView"] != null)
                {
                    appname = System.Configuration.ConfigurationManager.AppSettings["IsArticleView"];
                }
                return int.Parse(appname);
            }
        }

        /// <summary>
        /// 是否启用文件记录浏览信息,0数据库，1文件日志
        /// </summary>
        public static int IsLogBrowse
        {
            get
            {
                string appname = "0";
                if (System.Configuration.ConfigurationManager.AppSettings["IsLogBrowse"] != null)
                {
                    appname = System.Configuration.ConfigurationManager.AppSettings["IsLogBrowse"];
                }
                return int.Parse(appname);
            }
        }

        /// <summary>
        /// 是否启用SQL日志
        /// </summary>
        public static int IsSqlLog
        {
            get
            {
                int appname = 0;
                if (System.Configuration.ConfigurationManager.AppSettings["IsLogBrowse"] != null)
                {
                    appname = int.Parse(System.Configuration.ConfigurationManager.AppSettings["IsLogBrowse"]);
                }
                return appname;
            }
        }

        /// <summary>
        /// 广告域名，后期可能换成动态域名
        /// </summary>
        public static string AdDomain
        {
            get
            {
                string appname = "http://test.weizhuan178.com";
                if (System.Configuration.ConfigurationManager.AppSettings["AdDomain"] != null)
                {
                    appname = System.Configuration.ConfigurationManager.AppSettings["AdDomain"];
                }
                return appname;
            }
        }

        /// <summary>
        /// 服务主域名
        /// </summary>
        public static string AdServiceDomain
        {
            get
            {
                string appname = "http://test.weizhuan178.com";
                if (System.Configuration.ConfigurationManager.AppSettings["AdServiceDomain"] != null)
                {
                    appname = System.Configuration.ConfigurationManager.AppSettings["AdServiceDomain"];
                }
                return appname;
            }
        }

        /// <summary>
        /// 是否限制IP地址
        /// </summary>
        public static int IsIpArea
        {
            get
            {
                int appname = 0;
                if (System.Configuration.ConfigurationManager.AppSettings["IsIpArea"] != null)
                {
                    appname = int.Parse(System.Configuration.ConfigurationManager.AppSettings["IsIpArea"]);
                }
                return appname;
            }
        }

        /// <summary>
        /// 限制区域，逗号分隔多个区域，如：腾讯，北京，上海，广州
        /// </summary>
        public static List<string> IpAreas
        {
            get
            {
                List<string> list = new List<string>();
                string appname = "";
                if (System.Configuration.ConfigurationManager.AppSettings["IpAreas"] != null)
                {
                    appname = System.Configuration.ConfigurationManager.AppSettings["IpAreas"];
                }

                var tlist = appname.Split(',');
                if(tlist!= null)
                {
                    foreach (var item in tlist)
                    {
                        list.Add(item);
                    }
                }

                return list;
            }
        }

        public static string Version
        {
            get
            {
                return "V.0.0.1";
            }
        }
    }
}
