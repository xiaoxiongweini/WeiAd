using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Services.WebSite
{
    /// <summary>
    /// 快转，玉米，番薯，快转，雪梨
    /// </summary>
    public class kuaizhuanBLL
    {
        public static int Id
        {
            get
            {
                return 2;
            }
        }

        public static int GetCount(string urllist)
        {
            int count = 0;
            var list = urllist.Split(',');
            foreach (var item in list)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    count = count + GetUrl(item);
                }
            }

            return count;
        }

        static int GetUrl(string url)
        {
            int count = 0;

            string html = DN.Framework.Utility.WebClientHelper.GetSend(url);

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);
            var list = doc.DocumentNode.SelectNodes("//tr/td[2]");

            for (int i = 1; i < list.Count; i++)
            {
                int tcount = 0;
                int.TryParse(list[i].InnerText, out tcount);
                count = count + tcount;
            }
            return count;
        }
    }
}