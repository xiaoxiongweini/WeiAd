using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DN.WeiAd.Models;
using DN.WeiAd.Business;

namespace AdApp.Services
{
    /// <summary>
    /// SendWeiXin 的摘要说明
    /// </summary>
    public class SendWeiXin : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string weixin = context.Request.Params["weixin"] ?? "";
            string css = context.Request.Params["css"] ?? "";
            string url = context.Request.Params["_url"] ?? "";

            //还没有做完

            try
            {
                DN.Framework.Utility.LogHelper.Write(string.Format("weixin={0},css={1}", weixin, css));

                LogQcodeInfoVO log = new LogQcodeInfoVO();

                log.CopyText = weixin;
                log.Url = url;
                log.BrowseType = DN.Framework.Utility.ClientHelper.GetUserAgent();
                log.ClientIp = DN.Framework.Utility.ClientHelper.ClientIP();
                log.CreateDate = DateTime.Now;
                log.IsMoney = 0;
                log.Time = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
                log.ClientId = GetClentId(context.Request, context.Response);
                log.IsMobile = DN.Framework.Utility.ClientHelper.GetIsMobileDevice() ? 1 : 0;
                log.ReferrerUrl = context.Request.UrlReferrer == null ? "" : context.Request.UrlReferrer.AbsoluteUri;
                log.OsName = DN.Framework.Utility.ClientHelper.GetOsName();
                log.BrowseName = DN.Framework.Utility.ClientHelper.GetBrowseName();
                log.BrowseVersion = DN.Framework.Utility.ClientHelper.GetBrowseVersion();

                var ipinfo = DN.WeiAd.Business.Services.IpTaoBaoHelper.GetIpResult(log.ClientIp);

                if (ipinfo != null && ipinfo.code == 0 && ipinfo.data != null)
                {
                    log.Country = ipinfo.data.country;
                    log.Area = ipinfo.data.area;
                    log.City = ipinfo.data.city;
                    log.Region = ipinfo.data.region;
                    log.County = ipinfo.data.county;
                    log.Isp = ipinfo.data.isp;
                }

                LogQcodeInfoBLL.Instance.Add(log);
            }
            catch (Exception)
            {
                 
            }

            context.Response.ClearContent();
            context.Response.End();

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