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
    public class beijingfengchuankejiBLL
    {
        public static int Id
        {
            get
            {
                return 3;
            }
        }

        public static string Start(AdDataItem date)
        {
            string url = "http://admin.beijingfengchuankeji.com/member.php/Public/checkLogin.html";
            //string url = "http://ads.k4884.com/index.php/Public/checkLogin";
            string rurl = "http://admin.beijingfengchuankeji.com/member.php/Index/index.html";
            string purl = "username=momo123&password=123456";

            if (!string.IsNullOrEmpty(date.Purl))
            {
                purl = date.Purl;
            }
            string html = PostLogin(url, rurl, purl);
            string count = "0";
            string shtml = "";
            
            if (html.IndexOf("/member.php/Index/index.html") != -1)
            {
                shtml = post(rurl);

                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(shtml);

                string sxpath = "//*[@id=\"marqueebox0\"]/li/div[5]";
                if (!string.IsNullOrEmpty(date.XPath))
                {
                    sxpath = date.XPath;
                }
             

                var node = doc.DocumentNode.SelectSingleNode(sxpath);
                count = node.InnerText;
                count = count.Replace("&nbsp;", "").Replace("\t", "").Replace("\n", "").Replace("\r", "").Replace(" ", "");
                Console.WriteLine(count);
            }

            return count;

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
                request.Referer = "http://admin.beijingfengchuankeji.com/member.php/Public/checkLogin.html";
                //浏览器类型，如果Servlet返回的内容与浏览器类型有关则该值非常有用
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.3; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36";
                request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                //请求方式
                request.Method = "POST";
                //是否保持常连接
                request.KeepAlive = false;
                request.Headers.Add("Accept-Encoding", "gzip, deflate, sdch");

                CookieContainer cc = new CookieContainer();
                cc.Add(new System.Uri("http://admin.beijingfengchuankeji.com"), new Cookie("PHPSESSID", "8n3sj8f3t6h8lp3gekd768btn2"));

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

        static string PostLogin(string postUrl, string referUrl, string data)
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
                request.Referer = referUrl;
                //浏览器类型，如果Servlet返回的内容与浏览器类型有关则该值非常有用
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.3; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36";
                request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                //请求方式
                request.Method = "POST";
                //是否保持常连接
                request.KeepAlive = false;
                request.Headers.Add("Accept-Encoding", "gzip, deflate, sdch");

                CookieContainer cc = new CookieContainer();
                cc.Add(new System.Uri("http://admin.beijingfengchuankeji.com"), new Cookie("PHPSESSID", "8n3sj8f3t6h8lp3gekd768btn2"));

                request.CookieContainer = cc;

                //request.CookieContainer = new CookieContainer();
                //request.CookieContainer.Add(new Cookie() { Name = "PHPSESSID", Value = "n0gkc0ia2vvokvg8nqsik513c2" });
                //表示请求消息正文的长度
                request.ContentLength = data.Length;

                Stream postStream = request.GetRequestStream();
                byte[] postData = Encoding.UTF8.GetBytes(data);
                //将传输的数据，请求正文写入请求流
                postStream.Write(postData, 0, postData.Length);
                postStream.Dispose();
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