using DN.WeiAd.Business.AdData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Services.WebSite
{
    public class MultilineRowBLL
    {
        /// <summary>
        /// 多行数据，多个网页
        /// </summary>
        public static int Id
        {
            get
            {
                return 7;
            }
        }

        public static string Start(AdDataItem info)
        {
            string html = "0";
            string shtml = DN.Framework.Utility.WebClientHelper.GetSend(info.ClientUrl, info.Encoding, info.Encoding);

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(shtml);
            string xpath = "//tr/td[2]";
            if (!string.IsNullOrEmpty(info.XPath))
            {
                xpath = info.XPath;
            }

            int count = 0;
            var list = info.ClientUrl.Split(',');
            foreach (var item in list)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    count = count + GetUrl(item, xpath);
                }
            }
            html = count.ToString();

            return html;
        }

        static int GetUrl(string url, string xpath = "//tr/td[2]")
        {
            int count = 0;

            string html = DN.Framework.Utility.WebClientHelper.GetSend(url);

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);
            var list = doc.DocumentNode.SelectNodes(xpath);

            for (int i = 0; i < list.Count; i++)
            {
                int tcount = 0;
                int.TryParse(list[i].InnerText, out tcount);
                count = count + tcount;
            }
            return count;
        }
    }
}