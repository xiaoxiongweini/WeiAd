﻿using System;
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
    /// 豆赚平台
    /// </summary>
    public class douzhuanBLL
    {
        public static int Id
        {
            get
            {
                return 4;
            }
        }

        public static string GetCount(string xpath = "")
        {
            string url = "http://guanggao-pv.uicp.cn/bzcx/logout.do";
            string rurl = "http://guanggao-pv.uicp.cn/bzcx/loginsys.do";
            string purl = "http://guanggao-pv.uicp.cn/bzcx/loginsys.do?loginname=rg&pwd=rg";
            string html = PostLogin(purl);
            string count = "0";
            string shtml = "";
            int tcoun = 0;
            int tmcount = 0;
            if (html.Length > 10)
            {
                shtml = GetDate("http://guanggao-pv.uicp.cn/bzcx/commonQuery/dtquery.do?sqlname=SQL_Zq_Advvist_Today_Stat.advlist");

                var list = shtml.Replace("\"","").Split(',');

                for (int i = 0; i < list.Length; i++)
                {
                    var item = list[i].Split(':');
                    if(item.Length ==2)
                    {
                        if(item[0]== "ips")
                        {
                            count = item[1];
                            int.TryParse(count, out tcoun);
                            tmcount = tmcount + tcoun;
                        }
                    }
                }

                shtml = GetDate("http://guanggao-pv.uicp.cn/bzcx/commonQuery/dtquery.do?sqlname=SQL_Zq_Advvist_Today_Stat.advhistorylist");
                var list1 = shtml.Replace("\"", "").Split(',');

                for (int i = 0; i < list1.Length; i++)
                {
                    var item = list1[i].Split(':');
                    if (item.Length == 2)
                    {
                        if (item[0] == "ips")
                        {
                            count = item[1];
                            int.TryParse(count, out tcoun);
                            tmcount = tmcount + tcoun;
                        }
                    }
                }

                Console.WriteLine(tmcount.ToString());
            }

            return tmcount.ToString();
        }

        /// <summary>
        /// 获得post请求后响应的数据
        /// </summary>
        /// <param name="postUrl">请求地址</param>
        /// <param name="referUrl">请求引用地址</param>
        /// <param name="data">请求带的数据</param>
        /// <returns>响应内容</returns>
        static string GetDate(string postUrl)
        {
            string result = "";
            try
            {

                //命名空间System.Net下的HttpWebRequest类
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(postUrl);
                //参照浏览器的请求报文 封装需要的参数 这里参照ie9
                //浏览器可接受的MIME类型
                request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";
                //包含一个URL，用户从该URL代表的页面出发访问当前请求的页面
                //浏览器类型，如果Servlet返回的内容与浏览器类型有关则该值非常有用
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3112.78 Safari/537.36";
                //请求方式
                request.Method = "GET";
                //是否保持常连接
                request.KeepAlive = false;
                request.Headers.Add("Accept-Encoding", "gzip, deflate");
                request.ContentType = "text/json;charset=UTF-8";


                CookieContainer cc = new CookieContainer();
                cc.Add(new System.Uri("http://guanggao-pv.uicp.cn"), new Cookie("JSESSIONID", "2BD0C987CCA11F9BD1908F41C4D033CB"));

                //var ck = request.CookieContainer.GetCookies(new Uri("http://guanggao-pv.uicp.cn/"));
                //for (int i = 0; i < ck.Count; i++)
                //{
                //   string tk = ck[i].Value;
                //}

                request.CookieContainer = cc;

                //request.CookieContainer = new CookieContainer();
                //request.CookieContainer.Add(new Cookie() { Name = "PHPSESSID", Value = "n0gkc0ia2vvokvg8nqsik513c2" });
                //响应
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                //string JSESSIONID = response.Cookies["JSESSIONID"].ToString();

                //判断响应的信息是否为压缩信息 若为压缩信息解压后返回
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("utf-8")))
                {
                    result = reader.ReadToEnd();
                }


                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        /// <summary>
        /// 获得post请求后响应的数据
        /// </summary>
        /// <param name="postUrl">请求地址</param>
        /// <param name="referUrl">请求引用地址</param>
        /// <param name="data">请求带的数据</param>
        /// <returns>响应内容</returns>
        static string PostLogin(string postUrl)
        {
            string result = "";
            try
            {

                //命名空间System.Net下的HttpWebRequest类
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(postUrl);
                //参照浏览器的请求报文 封装需要的参数 这里参照ie9
                //浏览器可接受的MIME类型
                request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";
                //包含一个URL，用户从该URL代表的页面出发访问当前请求的页面
                //浏览器类型，如果Servlet返回的内容与浏览器类型有关则该值非常有用
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3112.78 Safari/537.36";
                //请求方式
                request.Method = "GET";
                //是否保持常连接
                request.KeepAlive = false;
                request.Headers.Add("Accept-Encoding", "gzip, deflate");
                request.ContentType = "text/html;charset=UTF-8";
                

                CookieContainer cc = new CookieContainer();
                cc.Add(new System.Uri("http://guanggao-pv.uicp.cn"), new Cookie("JSESSIONID", "7067C35F1917168ED143F7B248AC4A94"));

                //var ck = request.CookieContainer.GetCookies(new Uri("http://guanggao-pv.uicp.cn/"));
                //for (int i = 0; i < ck.Count; i++)
                //{
                //   string tk = ck[i].Value;
                //}

                request.CookieContainer = cc;

                //request.CookieContainer = new CookieContainer();
                //request.CookieContainer.Add(new Cookie() { Name = "PHPSESSID", Value = "n0gkc0ia2vvokvg8nqsik513c2" });
                //响应
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                //string JSESSIONID = response.Cookies["JSESSIONID"].ToString();

                //判断响应的信息是否为压缩信息 若为压缩信息解压后返回
                using (StreamReader reader = new StreamReader(response.GetResponseStream(),Encoding.GetEncoding("utf-8")))
                {
                    result = reader.ReadToEnd();
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


    class DzDataItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string adv_pid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string adv_name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string pvs { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ips { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string adv_price { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string amount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string detail { get; set; }
    }

    class DzRoot
    {
        /// <summary>
        /// 
        /// </summary>
        public string iTotalRecords { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string iTotalDisplayRecords { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<DzDataItem> data { get; set; }
    }
}