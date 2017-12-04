using DN.WeiAd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.IO;

namespace DN.WeiAd.Business
{
    /// <summary>
    /// 生成中间页
    /// </summary>
    public partial class AdPageInfoBLL
    {
        /// <summary>
        /// 获取中间页
        /// </summary>
        /// <param name="middle"></param>
        /// <returns></returns>
        public string GetMiddlePage(object middle)
        {
            string url = string.Format("{0}{1}", Config.AppConfig.AdDomain, middle);
            return url;
        }

        /// <summary>
        /// 生成中间页
        /// </summary>
        /// <param name="info"></param>
        public string CreateMiddlePage(AdPageInfoVO info)
        {
            string pagename = Guid.NewGuid().ToString();
            pagename = pagename.Substring(0, pagename.IndexOf("-"));
            if(!string.IsNullOrEmpty(info.MiddlePage))
            {
                pagename = info.MiddlePage;
                pagename = pagename.Replace("/Mp/", "").Replace(".html", "");
            }
            string html = GetMiddlePageTemplate();
            html = ReplaceMiddlePageHtml(html, info);

            string path = Path.Combine(HttpContext.Current.Server.MapPath("~/"), "Mp", pagename + ".html");

            using (StreamWriter writer = new StreamWriter(path,false))
            {
                writer.Write(html);
                writer.Flush();
                writer.Close();
            }

            return string.Format("/Mp/{0}.html", pagename);
        }

        private string ReplaceMiddlePageHtml(string html,AdPageInfoVO info)
        {
            //有效域名
            DomainInfoPara dp = new DomainInfoPara();
            dp.IsAuth = 1;
            dp.IsState = 0;
            var list = DomainInfoBLL.Instance.GetModels(dp);

            StringBuilder sbDomain = new StringBuilder();
            foreach (var item in list)
            {
                sbDomain.AppendFormat("\"{0}\",", item.Domain);
            }
            if (sbDomain.Length != 0)
            {
                sbDomain = sbDomain.Remove(sbDomain.Length - 1, 1);
            }

            //有效页面
            AdUserPagePara aup = new AdUserPagePara();
            aup.AdPageId = info.Id;
            var plist = AdUserPageBLL.Instance.GetModels(aup);
            
            StringBuilder sbPage = new StringBuilder();
            foreach (var item in plist)
            {
                sbPage.AppendFormat("\"{0}\",", item.PageName);
            }
            sbPage.AppendFormat("\"{0}\"", info.ViewPage);

            html = html
                .Replace("$domains$", sbDomain.ToString())
                .Replace("$pages$", sbPage.ToString());
            return html;
        }

        /// <summary>
        /// 获取中间页内容
        /// </summary>
        /// <returns></returns>
        private string GetMiddlePageTemplate()
        {
            string html = "";
            string path = HttpContext.Current.Server.MapPath("/Resources/MiddlePage/MinddlePage.html");
            using (StreamReader reader = new StreamReader(path))
            {
                html = reader.ReadToEnd();
            }

            return html;
        }
    }
}
