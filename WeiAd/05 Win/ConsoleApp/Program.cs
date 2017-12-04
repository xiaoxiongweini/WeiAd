using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web;
using System.Net;
using System.Text.RegularExpressions;
using System.Drawing;
using DN.WeiAd.Models;
using DN.WeiAd.Business;
using DN.WeiAd.Business.AdData;
using DN.Framework.Utility;
using System.IO.Compression;
using WebApp.Services.WebSite;

namespace ConsoleApp
{
    class Program
    {
        /// <summary>
        /// 自动刷数据
        /// </summary>
        static void VirAddBrowse()
        {
            int ptime = AppConfig.TimeSpan;
            string url = AppConfig.OpenUrl;
            while (true)
            {
                WebClient client = new WebClient();
                client.DownloadString(url);
                Console.WriteLine(string.Format("时间：{0}--地址：{1}", DateTime.Now, url));
                System.Threading.Thread.Sleep(ptime * 1000);
            }
        }

        static void Main(string[] args)
        { 
             //{
             //            "AdId": 131,
             //"UserId": 55,
             //"ClientUrl": "http://ggz.reux.com.cn/advince/ipdetail/14247110",
             //"Encoding": "UTF-8",
             //"XPath": "/html/body/div[1]/div/div/div/div[6]/div[2]/em",
             //"App": 0
             //}

             AdDataItem info = new AdDataItem();
            info.ClientUrl = "http://admin.weiyouzj.com:8088/marticletask/customelistRelate?customeName=xiaochuang";
            info.XPath = "//tbody/tr/td[4]";
            info.Encoding = "UTF-8";
            //WebSite.dadaBLL.GetCount(info);
           string open= douzhuanDfBLL.GetCount();
            //string resutl = GetCount(info); 
            Console.WriteLine("数据更新完成。");
            Console.ReadKey();
        }


        public static string GetCount(AdDataItem info)
        {
            string rhtml = "";

            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {
                URL = "http://guanggao-pv.uicp.cn/dfcx/advlist.do",//URL     必需项  
                Method = "GET",//URL     可选项 默认为Get  
                Timeout = 100000,//连接超时时间     可选项默认为100000  
                ReadWriteTimeout = 30000,//写入Post数据超时时间     可选项默认为30000  
                IsToLower = false,//得到的HTML代码是否转成小写     可选项默认转小写  
                Cookie = "",//字符串Cookie     可选项  
                UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:18.0) Gecko/20100101 Firefox/18.0",//用户的浏览器类型，版本，操作系统     可选项有默认值  
                Accept = "text/html, application/xhtml+xml, */*",//    可选项有默认值  
                ContentType = "text/html",//返回类型    可选项有默认值  
                Referer = "http://guanggao-pv.uicp.cn",//来源URL     可选项  
                Allowautoredirect = false,//是否根据３０１跳转     可选项  
                                          //AutoRedirectCookie = false,//是否自动处理Cookie     可选项  
                                          //CerPath = "d:\123.cer",//证书绝对路径     可选项不需要证书时可以不写这个参数  
                                          //Connectionlimit = 1024,//最大连接数     可选项 默认为1024  
                Postdata = "loginname=duonian&pwd=duonian",//Post数据     可选项GET时不需要写  
                                                           //ProxyIp = "192.168.1.105：2020",//代理服务器ID     可选项 不需要代理 时可以不设置这三个参数  
                                                           //ProxyPwd = "123456",//代理服务器密码     可选项  
                                                           //ProxyUserName = "administrator",//代理服务器账户名     可选项  
                ResultType = ResultType.String,//返回数据类型，是Byte还是String  
            };
            HttpResult result = http.GetHtml(item);
            string html = result.Html;
            string cookie = result.Cookie;
            rhtml = GetDb(info, cookie); 
            return rhtml;
        }
         

        public static string GetDb(AdDataItem info,string cookie)
        {
            string scookie = cookie.Split(';')[0];
            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {
                URL = "http://guanggao-pv.uicp.cn/dfcx/commonQuery/dtquery.do?sqlname=SQL_Zq_Advvist_Today_Stat.advlist",//URL     必需项  
                Method = "GET",//URL     可选项 默认为Get  
                Timeout = 100000,//连接超时时间     可选项默认为100000  
                ReadWriteTimeout = 30000,//写入Post数据超时时间     可选项默认为30000  
                IsToLower = false,//得到的HTML代码是否转成小写     可选项默认转小写  
                Cookie = scookie,//"JSESSIONID,=38837539686B1D31F3D8BD0AFA67A972",//字符串Cookie     可选项  
                UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:18.0) Gecko/20100101 Firefox/18.0",//用户的浏览器类型，版本，操作系统     可选项有默认值  
                Accept = "text/html, application/xhtml+xml, */*",//    可选项有默认值  
                ContentType = "text/json",//返回类型    可选项有默认值  
                Referer = "http://guanggao-pv.uicp.cn",//来源URL     可选项  
                Allowautoredirect = false,//是否根据３０１跳转     可选项  
                //AutoRedirectCookie = False,//是否自动处理Cookie     可选项  
                                           //CerPath = "d:\123.cer",//证书绝对路径     可选项不需要证书时可以不写这个参数  
                                           //Connectionlimit = 1024,//最大连接数     可选项 默认为1024  
                Postdata = "loginname=duonian&pwd=duonian",//Post数据     可选项GET时不需要写  
                                                           //ProxyIp = "192.168.1.105：2020",//代理服务器ID     可选项 不需要代理 时可以不设置这三个参数  
                                                           //ProxyPwd = "123456",//代理服务器密码     可选项  
                                                           //ProxyUserName = "administrator",//代理服务器账户名     可选项  
                ResultType = ResultType.String,//返回数据类型，是Byte还是String  
            };
            HttpResult result = http.GetHtml(item);
            string html = result.Html;

            return html;

        }
    }
}
