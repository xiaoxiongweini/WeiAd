using DN.Framework.Utility;
using DN.WeiAd.Business.AdData;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace WebApp.Services.WebSite
{
    /// <summary>
    /// 爱分享
    /// </summary>
    public class ifengxiangBLL
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

            string html = post(info.ClientUrl);

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);
            var list = doc.DocumentNode.SelectNodes("//tr/td");

            foreach (var item in list)
            {

            }

            return html;
        }
        static string post(string postUrl)
        {
            string result = "";
            try
            {
                //命名空间System.Net下的HttpWebRequest类
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(postUrl);
                //参照浏览器的请求报文 封装需要的参数 这里参照ie9
                //浏览器可接受的MIME类型
                request.Accept = "text/plain, */*; q=0.8";
                //包含一个URL，用户从该URL代表的页面出发访问当前请求的页面
                request.Referer = "http://www.aol3d.cn/login.php";
                //浏览器类型，如果Servlet返回的内容与浏览器类型有关则该值非常有用
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.3; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36";
                request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                //请求方式
                request.Method = "POST";
                //是否保持常连接
                request.KeepAlive = false;
                request.Headers.Add("Accept-Encoding", "gzip, deflate, sdch");

                CookieContainer cc = new CookieContainer();
                cc.Add(new System.Uri("http://www.aol3d.cn"), new Cookie("PHPSESSID", "l5uukenhohpu5uchg8et06auf6"));

                request.CookieContainer = cc;

                //request.CookieContainer = new CookieContainer();
                //request.CookieContainer.Add(new Cookie() { Name = "PHPSESSID", Value = "n0gkc0ia2vvokvg8nqsik513c2" });
                //表示请求消息正文的长度

                //响应
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                //判断响应的信息是否为压缩信息 若为压缩信息解压后返回
                if (response.ContentEncoding == "gzip")
                {
                    MemoryStream ms = new MemoryStream();
                    GZipStream zip = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
                    byte[] buffer = new byte[1024];
                    int l = zip.Read(buffer, 0, buffer.Length);
                    while (l > 0)
                    {
                        ms.Write(buffer, 0, l);
                        l = zip.Read(buffer, 0, buffer.Length);
                    }
                    ms.Dispose();
                    zip.Dispose();
                    result = Encoding.UTF8.GetString(ms.ToArray());
                }
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }
    }
}