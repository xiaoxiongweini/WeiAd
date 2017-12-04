using DN.WeiAd.Business.AdData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Services.WebSite
{
    public class dadaBLL
    {
        /// <summary>
        /// 多行数据，多个网页
        /// </summary>
        public static int Id
        {
            get
            {
                return 8;
            }
        }


        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static string Start(AdDataItem info)
        {
            string html = "0";

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
                var node = doc.DocumentNode.SelectSingleNode(xpath);
                if (node != null)
                {
                    var list = node.InnerText.Replace("<em>", "@").Split('@');

                    if (list.Length >= 2)
                    {
                        html = list[2].Substring(0, list[2].IndexOf("</em>"));
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