using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DN.WeiAd.Models;
using DN.WeiAd.Business;

namespace WebApp.Services
{
    /// <summary>
    /// GetAdView 的摘要说明
    /// </summary>
    public class GetAdView : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";
            string adid = context.Request.Params["id"] ?? "0";

            articleinfo tinfo = new articleinfo();
            try
            {
                var info = AdPageInfoBLL.Instance.GetModelById(int.Parse(adid));
                string content = string.Empty;
                string title = string.Empty;
                if (info != null)
                {
                    string clientip = DN.Framework.Utility.ClientHelper.ClientIP();
                    var ipinfo = DN.WeiAd.Business.Services.IpTaoBaoHelper.GetIpResult(clientip);
                    string isp = "";
                    if (ipinfo.code == 0 && ipinfo.data != null)
                    {
                        isp = ipinfo.data.isp;
                    }
                    if (isp.IndexOf("腾讯") != -1)
                    {
                        var ainfo = ArticleInfoBLL.Instance.GetRandModel();
                        if (ainfo != null)
                        {
                            tinfo.title = ainfo.Title;
                            tinfo.content = DN.Framework.Utility.HtmlHelper.DecodeHtml(ainfo.Content);
                        }
                    }
                    else
                    {
                        content = GetContent(info, context);
                        title = info.Title;
                    }
                }
                tinfo.title = title;
                tinfo.content = content;
            }
            catch (Exception ex)
            {
                DN.Framework.Utility.LogHelper.Write(ex.Message, "error");
            }

            string json = DN.Framework.Utility.Serializer.SerializeObject(tinfo);

            context.Response.Write(json);
            context.Response.End();

        }

        class articleinfo
        {
            public string title { get; set; }

            public string content { get; set; }
        }

        private string GetContent(AdPageInfoVO info,HttpContext context)
        {
            string curl = context.Request.Params["_curl"] ?? "";
            string html = DN.Framework.Utility.HtmlHelper.DecodeHtml(info.Content);
            LogAdQcodeVO log = new LogAdQcodeVO();
            log.AdId = info.Id;
            log.AdUserId = info.UserId;
            log.BrowseName = DN.Framework.Utility.ClientHelper.GetBrowseName();
            log.BrowseType = DN.Framework.Utility.ClientHelper.GetUserAgent();
            log.BrowseVersion = DN.Framework.Utility.ClientHelper.GetBrowseVersion();
            log.ClientId = GetClentId(context.Request, context.Response);
            log.ClientIp = DN.Framework.Utility.ClientHelper.ClientIP();
            log.CreateDate = DateTime.Now;
            log.IsMobile = DN.Framework.Utility.ClientHelper.GetIsMobileDevice() ? 1 : 0;
            log.OsName = DN.Framework.Utility.ClientHelper.GetOsName();
            log.QcodeId = 0;
            log.ReferrerUrl = DN.Framework.Utility.ClientHelper.GetReferer();
            log.Time = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
            log.Url = curl;            

            //获取统计代码
            if(!string.IsNullOrEmpty(info.UserCode))
            {
                html = html + DN.Framework.Utility.HtmlHelper.DecodeHtml(info.UserCode);
            }

            //配置的二维码信息
            if (!string.IsNullOrEmpty(info.QcodeImg))
            {
                var qcode = AdQcodeInfoBLL.Instance.GetRandQcode(info.Id);
                if (qcode != null)
                {
                    log.QcodeId = qcode.Id;
                    string url = qcode.QcodeUrl;
                    if (!string.IsNullOrEmpty(url))
                    {
                        var list = info.QcodeImg.Split(',');
                        foreach (var item in list)
                        {
                            if (!string.IsNullOrEmpty(item))
                            {
                                html = html.Replace(item, url);
                            }
                        }

                        html = html.Replace("$QcodeUrl$", url);    //替换微信相关内容
                    }
                }else
                {
                    if (!string.IsNullOrEmpty(info.DefaultQcode))
                    {
                        var list = info.QcodeImg.Split(',');
                        foreach (var item in list)
                        {
                            if (!string.IsNullOrEmpty(item))
                            {
                                html = html.Replace(item, info.DefaultQcode);
                            }
                        }
                    }
                }                
            }

            //如果没有配置相关内容，替换相关内容
            html = html.Replace("$QcodeUrl$", "");

            try
            {
                if (DN.WeiAd.Business.Config.AppConfig.IsLogBrowse == 0)
                {
                    LogAdQcodeBLL.Instance.Add(log);
                }
                else
                {
                    ErrorBLL.Add<LogAdQcodeVO>(log);
                }
            }
            catch (Exception ex)
            {
                ErrorBLL.Add<LogAdQcodeVO>(ex, log);
                DN.Framework.Utility.LogHelper.Write(ex.Message, "errorqcode");
            }

            return html;
        }
        private string GetClentId(HttpRequest Request, HttpResponse Response)
        {
            string client = string.Empty;
            HttpCookie cookie = Request.Cookies.Get("_adclientid");
            if (cookie == null)
            {
                client = Guid.NewGuid().ToString();
                cookie = new HttpCookie("_adclientid");
                cookie.Value = Guid.NewGuid().ToString();
                cookie.Expires = DateTime.MaxValue;
                Response.Cookies.Add(cookie);
            }
            else
            {
                client = cookie.Value;
            }

            return client;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}