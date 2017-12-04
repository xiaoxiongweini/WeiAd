using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace ConsoleApp
{
    /// <summary>
    /// 图片下载工具
    /// </summary>
    public class ImageDownloadHelper
    {
        public static void SaveImg(string filepath)
        {
            string html = "";
            using (StreamReader reader = new StreamReader(filepath))
            {
                html = reader.ReadToEnd();
            }

            var list = html.Split(new string[] { "\r\n" }, StringSplitOptions.None);

            WebClient client = new WebClient();

            string dir = @"E:\temp\ad58\";

            for (int i = 0; i < list.Length; i++)
            {
                string item = list[i];
                if (!string.IsNullOrEmpty(item))
                {
                    item = item.Replace("\t", "");
                    string url = item.Replace("<img src=", "").Replace("/>", "").Replace("\"", "");
                    string ftype = Path.GetExtension(url);
                    Console.WriteLine(url);
                    client.DownloadFile(url, dir + i.ToString() + ftype);
                }
            }    
        }
    }
}
