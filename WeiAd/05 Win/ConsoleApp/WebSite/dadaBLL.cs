using DN.WeiAd.Business.AdData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.WebSite
{
    public class dadaBLL
    {
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static string GetCount(AdDataItem info)
        {
            string html = "0";
            int result = 0;
            try
            {
                string shtml = DN.Framework.Utility.WebClientHelper.GetSend(info.ClientUrl, info.Encoding, info.Encoding);
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(shtml);
                string xpath = "//script[@id='tpl_home']";
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

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return html;
        }
    }
}
