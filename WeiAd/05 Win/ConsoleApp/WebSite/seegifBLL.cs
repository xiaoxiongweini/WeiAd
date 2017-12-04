using ConsoleApp.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.WebSite
{
    public class seegifBLL
    {
        /// <summary>
        /// 获得post请求后响应的数据
        /// </summary>
        /// <param name="postUrl">请求地址</param>
        /// <param name="referUrl">请求引用地址</param>
        /// <param name="data">请求带的数据</param>
        /// <returns>响应内容</returns>
        public static string PostLogin(string postUrl)
        {
            string html = "";
            try
            {
                HttpHelper http = new HttpHelper();
                HttpItem item = new HttpItem()
                {
                    URL = "http://post.seegif.com/admin/login/sign_accept",//URL     必需项
                    Method = "POST",//URL     可选项 默认为Get
                    Timeout = 100000,//连接超时时间     可选项默认为100000
                    ReadWriteTimeout = 30000,//写入Post数据超时时间     可选项默认为30000
                    IsToLower = false,//得到的HTML代码是否转成小写     可选项默认转小写
                    Cookie = "",//字符串Cookie     可选项
                    UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:18.0) Gecko/20100101 Firefox/18.0",//用户的浏览器类型，版本，操作系统     可选项有默认值
                    Accept = "text/html, application/xhtml+xml, */*",//    可选项有默认值
                    ContentType = "application/x-www-form-urlencoded",//返回类型    可选项有默认值
                    Referer = "http://post.seegif.com",//来源URL     可选项
                                                       //CerPath = "d:\123.cer",//证书绝对路径     可选项不需要证书时可以不写这个参数
                                                       //Connectionlimit = 1024,//最大连接数     可选项 默认为1024
                    Postdata = "phone_number=409920451&password=700100501",//Post数据     可选项GET时不需要写
                                                                           //ProxyIp = "192.168.1.105：2020",//代理服务器ID     可选项 不需要代理 时可以不设置这三个参数
                                                                           //ProxyPwd = "123456",//代理服务器密码     可选项
                                                                           //ProxyUserName = "administrator",//代理服务器账户名     可选项
                    ResultType = ResultType.String,//返回数据类型，是Byte还是String
                };
                HttpResult result = http.GetHtml(item);
                html = result.Html;
                string cookie = result.Cookie;

                html = GetCount(cookie);

                return html;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return html;
        }

        public static string GetDate(string cookie)
        {
            string html = "";
            try
            {
                HttpHelper http = new HttpHelper();
                HttpItem item = new HttpItem()
                {
                    URL = "http://post.seegif.com/admin/ad/index",//URL     必需项
                    Method = "POST",//URL     可选项 默认为Get
                    Timeout = 100000,//连接超时时间     可选项默认为100000
                    ReadWriteTimeout = 30000,//写入Post数据超时时间     可选项默认为30000
                    IsToLower = false,//得到的HTML代码是否转成小写     可选项默认转小写
                    Cookie = cookie,//字符串Cookie     可选项
                    UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:18.0) Gecko/20100101 Firefox/18.0",//用户的浏览器类型，版本，操作系统     可选项有默认值
                    Accept = "text/html, application/xhtml+xml, */*",//    可选项有默认值
                    ContentType = "application/x-www-form-urlencoded",//返回类型    可选项有默认值
                    Referer = "http://post.seegif.com",//来源URL     可选项
                                                       //CerPath = "d:\123.cer",//证书绝对路径     可选项不需要证书时可以不写这个参数
                                                       //Connectionlimit = 1024,//最大连接数     可选项 默认为1024
                    Postdata = "phone_number=409920451&password=700100501",//Post数据     可选项GET时不需要写
                                                                           //ProxyIp = "192.168.1.105：2020",//代理服务器ID     可选项 不需要代理 时可以不设置这三个参数
                                                                           //ProxyPwd = "123456",//代理服务器密码     可选项
                                                                           //ProxyUserName = "administrator",//代理服务器账户名     可选项
                    ResultType = ResultType.String,//返回数据类型，是Byte还是String
                };
                HttpResult result = http.GetHtml(item);
                html = result.Html;



                return html;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return html;
        }

        private static string GetCount(string cookice)
        {
            string html = "0";
            try
            {
                HttpHelper http = new HttpHelper();
                HttpItem item = new HttpItem()
                {
                    URL = "http://post.seegif.com/admin/ad-stat/index?u=409920451",//URL     必需项  
                    Method = "POST",//URL     可选项 默认为Get  
                    Timeout = 100000,//连接超时时间     可选项默认为100000  
                    ReadWriteTimeout = 30000,//写入Post数据超时时间     可选项默认为30000  
                    IsToLower = false,//得到的HTML代码是否转成小写     可选项默认转小写  
                    Cookie = cookice,//字符串Cookie     可选项  
                    UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:18.0) Gecko/20100101 Firefox/18.0",//用户的浏览器类型，版本，操作系统     可选项有默认值  
                    Accept = "text/html, application/xhtml+xml, */*",//    可选项有默认值  
                    ContentType = "application/x-www-form-urlencoded",//返回类型    可选项有默认值  
                    Referer = "http://post.seegif.com",//来源URL     可选项  
                                               //CerPath = "d:\123.cer",//证书绝对路径     可选项不需要证书时可以不写这个参数  
                                               //Connectionlimit = 1024,//最大连接数     可选项 默认为1024  
                    Postdata = "phone_number=409920451&password=700100501",//Post数据     可选项GET时不需要写  
                                                                           //ProxyIp = "192.168.1.105：2020",//代理服务器ID     可选项 不需要代理 时可以不设置这三个参数  
                                                                           //ProxyPwd = "123456",//代理服务器密码     可选项  
                                                                           //ProxyUserName = "administrator",//代理服务器账户名     可选项  
                    ResultType = ResultType.String,//返回数据类型，是Byte还是String  
                };
                HttpResult result = http.GetHtml(item);
                string thtml = result.Html;

                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(thtml);

                var tds = doc.DocumentNode.SelectNodes("/html/body/div[4]/div/div[2]/div/dl[3]/dd/table/tr/td[2]");

                int count = 0;
                foreach (var td in tds)
                {
                    string t = td.InnerText;
                    int tc = 0;
                    int.TryParse(t, out tc);
                    count += tc;
                }

                html = count.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return html;
            
        }
    }
}
