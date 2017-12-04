using DN.WeiAd.Business.AdData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Services.WebSite
{
    public class WeiYouZhiJiaBLL
    {
        public static int Id
        {
            get
            {
                return 10;
            }
        }

        public static int Start(AdDataItem data)
        {
            int count = 0;

            var list = data.ClientUrl.Split(',');
            foreach (var item in list)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    count = count + GetUrl(data, item);
                }
            }

            return count;

        }

        static int GetUrl(AdDataItem info,string url)
        {
            int result = 0;

            string shtml = DN.Framework.Utility.WebClientHelper.GetSend(url, info.Encoding, info.Encoding);
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(shtml);
            string xpath = "//tbody/tr/td[4]";
            if (!string.IsNullOrEmpty(info.XPath))
            {
                xpath = info.XPath;
            }
            var node = doc.DocumentNode.SelectNodes(xpath);
            if (node != null)
            {
                foreach (var item in node)
                {
                    int count = 0;
                    var list = item.InnerText.Split('/')[0];
                    int.TryParse(list, out count);
                    result += count;
                }

            }

            return result;
        }
    }
}