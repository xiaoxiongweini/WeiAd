using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DN.WeiAd.Models;
using DN.WeiAd.Business;
using System.IO;

namespace WebApp.Services
{
    /// <summary>
    /// GetDetail 的摘要说明
    /// </summary>
    public class GetDetail : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            articleinfo tinfo = new articleinfo();
            LogBrowseVO log = new LogBrowseVO();
            tinfo.title = "我的标题";
            tinfo.content = "我喜欢你";

            try
            {
                context.Response.ContentType = "text/json";
                string pname = context.Request.Params["_pname"] ?? "";
                string curl = context.Request.Params["_curl"] ?? "";
                string hisurl = context.Request.Params["_hisurl"] ?? "";
                string adid = context.Request.Params["id"] ?? "0";

                string filepath = Path.GetFileName(pname);
                string PageName = filepath;
                int last = PageName.IndexOf("?");
                if (last != -1)
                {
                    PageName = PageName.Substring(0, last);
                }

                log.BrowseType = DN.Framework.Utility.ClientHelper.GetUserAgent();
                log.ClientIp = DN.Framework.Utility.ClientHelper.ClientIP();
                log.CreateDate = DateTime.Now;
                log.AdUrl = pname;
                log.IsMoney = 0;
                log.Money = 0;
                log.Time = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
                log.ClientId = GetClentId(context.Request, context.Response);
                log.IsMobile = DN.Framework.Utility.ClientHelper.GetIsMobileDevice() ? 1 : 0;
                log.ReferrerUrl = hisurl;
                log.OsName = DN.Framework.Utility.ClientHelper.GetOsName();
                log.BrowseName = DN.Framework.Utility.ClientHelper.GetBrowseName();
                log.BrowseVersion = DN.Framework.Utility.ClientHelper.GetBrowseVersion();
                log.Url = curl;
                var ipinfo = DN.WeiAd.Business.Services.IpTaoBaoHelper.GetIpResult(log.ClientIp);
                if (ipinfo.code == 0 && ipinfo.data != null)
                {
                    log.Country = ipinfo.data.country;
                    log.Area = ipinfo.data.area;
                    log.City = ipinfo.data.city;
                    log.Region = ipinfo.data.region;
                    log.County = ipinfo.data.county;
                    log.Isp = ipinfo.data.isp;
                }

                bool ispass = true;

                if (DN.WeiAd.Business.Config.AppConfig.IsIpArea == 1)
                {
                    if (DN.WeiAd.Business.Config.AppConfig.IpAreas.Count != 0)
                    {
                        foreach (var item in DN.WeiAd.Business.Config.AppConfig.IpAreas)
                        {
                            if (log.Region.IndexOf(item) != -1)
                            {
                                ispass = false;
                                break;
                            }
                        }
                    }
                }

                //检查ISP
                if (log.Isp.IndexOf("腾讯") != -1)
                {
                    ispass = false;
                }

                //是否通过
                if (ispass)
                {
                    var adinfo = AdPageInfoBLL.Instance.GetModelById(int.Parse(adid));
                    if (adinfo == null)
                    {
                        adinfo = AdPageInfoBLL.Instance.GetModelById(int.Parse(adid));
                    }
                    if (adinfo != null)
                    {
                        log.AdUserId = adinfo.UserId;
                        log.AdId = adinfo.Id;
                    }

                    string content = string.Empty;
                    string title = string.Empty;
                    if (adinfo != null)
                    {
                        content = GetContent(adinfo, context);
                        title = adinfo.Title;
                    }
                    tinfo.title = title;
                    tinfo.content = content;
                }
                else
                {
                    var info = ArticleInfoBLL.Instance.GetRandModel();
                    if (info != null)
                    {
                        tinfo.title = info.Title;
                        tinfo.content = DN.Framework.Utility.HtmlHelper.DecodeHtml(info.Content);
                    }
                }

                if (DN.WeiAd.Business.Config.AppConfig.IsLogBrowse == 1)
                {
                    ErrorBLL.Add<LogBrowseVO>(log);
                }
            }
            catch (Exception ex)
            {
                ErrorBLL.Add<LogBrowseVO>(ex, log);
                DN.Framework.Utility.LogHelper.Write(ex.Message, "error");
            }

            LogBrowseBLL.Instance.Add(log);

            string json = DN.Framework.Utility.Serializer.SerializeObject(tinfo);
            context.Response.ClearContent();
            context.Response.Write(json);
            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        class articleinfo
        {
            public string title { get; set; }

            public string content { get; set; }
        }

        private string GetContent(AdPageInfoVO info, HttpContext context)
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
            if (!string.IsNullOrEmpty(info.UserCode))
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
                }
                else
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
    }
}