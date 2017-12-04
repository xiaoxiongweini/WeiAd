using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DN.WeiAd.Models;
using DN.WeiAd.Business;
using System.IO;

namespace AdApp.Services
{
    /// <summary>
    /// GetLog 的摘要说明
    /// </summary>
    public class GetLog : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            LogBrowseVO log = new LogBrowseVO();

            try
            {
                context.Response.ContentType = "text/plain";
                string pname = context.Request.Params["_pname"] ?? "";
                string curl = context.Request.Params["_curl"] ?? "";
                string hisurl = context.Request.Params["_hisurl"] ?? "";
                string adid = context.Request.Params["adid"] ?? "";
                string aduserid = context.Request.Params["aduserid"] ?? "";

                string filepath = Path.GetFileName(pname);
                //string fileExt = Path.GetExtension(filepath);

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
                int aid = 0;
                int auserid = 0;
                int.TryParse(adid, out aid);
                int.TryParse(aduserid, out auserid);
                log.AdId = aid;
                log.AdUserId = auserid;

                //var userpage = AdUserPageBLL.Instance.GetModelByPageName(PageName);
                //if (userpage != null)
                //{
                //    var info = AdPageInfoBLL.Instance.GetModelById(userpage.AdPageId);
                //    if (info != null)
                //    {
                //        //访问日志
                //        log.AdUserId = info.UserId;
                //        log.AdId = info.Id;

                //        if (userpage != null)
                //        {
                //            log.FlowUserId = userpage.FlowUserId;
                //        }
                //    }
                //}
                //else
                //{
                //    var info = AdPageInfoBLL.Instance.GetModelByViewPage(PageName);
                //    if (info != null)
                //    {
                //        log.AdId = info.Id;
                //        log.AdUserId = info.UserId;
                //    }
                //}
                if (DN.WeiAd.Business.Config.AppConfig.IsLogBrowse == 0)
                {
                    LogBrowseBLL.Instance.Add(log);
                }
                else
                {
                    ErrorBLL.Add<LogBrowseVO>(log);
                }
            }
            catch (Exception ex)
            {
                ErrorBLL.Add<LogBrowseVO>(ex, log);
                DN.Framework.Utility.LogHelper.Write(ex.Message, "errorlogbrow");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
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