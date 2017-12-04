using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp
{
    public class HtmlHelper
    {
        public static void Replace(string path,string url)
        {
            string html = "";
            using (StreamReader reader = new StreamReader(path))
            {
                html = reader.ReadToEnd();
            }

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);

            var list = doc.DocumentNode.SelectNodes("//a");

            foreach (var item in list)
            {
                if (item.Attributes.Contains("href"))
                {
                    string href = item.Attributes["href"].Value;
                    html = html.Replace(href, url);
                    Console.WriteLine(href);
                }
            }

            int l = html.Length;
        }
    }
}
