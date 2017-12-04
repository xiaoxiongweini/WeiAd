using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdApp.Controllers
{
    public class AdViewController : Controller
    {
        private string GetClentId(HttpRequestBase Request, HttpResponseBase Response)
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

        public ActionResult s1ad(string adid)
        {
            int aid = 162;
            var info = DN.WeiAd.Business.AdPageInfoBLL.Instance.GetSingle(new DN.WeiAd.Models.AdPageInfoPara() { Id = aid });


            DN.WeiAd.Models.LogBrowseVO log = new DN.WeiAd.Models.LogBrowseVO();
            
            if (info!= null)
            {
                ViewBag.Title = info.Title;
                ViewBag.Content = info.Content;
                log.AdUserId = info.UserId;
                log.Money = info.Money;
            }
            log.BrowseType = DN.Framework.Utility.ClientHelper.GetUserAgent();
            log.ClientIp = DN.Framework.Utility.ClientHelper.ClientIP();
            log.CreateDate = DateTime.Now;
            log.AdUrl = Request.Url.ToString();
            log.IsMoney = 0;
            log.AdId = aid;
            log.Time = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
            log.ClientId = GetClentId(Request, Response);
            log.IsMobile = DN.Framework.Utility.ClientHelper.GetIsMobileDevice() ? 1 : 0;
            log.ReferrerUrl = Request.UrlReferrer == null ? "" : Request.UrlReferrer.AbsoluteUri;
            log.OsName = DN.Framework.Utility.ClientHelper.GetOsName();
            log.BrowseName = DN.Framework.Utility.ClientHelper.GetBrowseName();
            log.BrowseVersion = DN.Framework.Utility.ClientHelper.GetBrowseVersion();
            log.Url = Request.Url.ToString();
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

            DN.WeiAd.Business.LogBrowseBLL.Instance.Add(log);

            return View();
        }

        public ActionResult s2ad(string adid)
        {
            int aid = 163;
            var info = DN.WeiAd.Business.AdPageInfoBLL.Instance.GetSingle(new DN.WeiAd.Models.AdPageInfoPara() { Id = aid });

            DN.WeiAd.Models.LogBrowseVO log = new DN.WeiAd.Models.LogBrowseVO();

            if (info != null)
            {
                ViewBag.Title = info.Title;
                ViewBag.Content = info.Content;
                log.AdUserId = info.UserId;
                log.Money = info.Money;
            }
            log.BrowseType = DN.Framework.Utility.ClientHelper.GetUserAgent();
            log.ClientIp = DN.Framework.Utility.ClientHelper.ClientIP();
            log.CreateDate = DateTime.Now;
            log.AdUrl = Request.Url.ToString();
            log.IsMoney = 0;
            log.AdId = aid;
            log.Money = 0;
            log.Time = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
            log.ClientId = GetClentId(Request, Response);
            log.IsMobile = DN.Framework.Utility.ClientHelper.GetIsMobileDevice() ? 1 : 0;
            log.ReferrerUrl = Request.UrlReferrer == null ? "" : Request.UrlReferrer.AbsoluteUri;
            log.OsName = DN.Framework.Utility.ClientHelper.GetOsName();
            log.BrowseName = DN.Framework.Utility.ClientHelper.GetBrowseName();
            log.BrowseVersion = DN.Framework.Utility.ClientHelper.GetBrowseVersion();
            log.Url = Request.Url.ToString();
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

            DN.WeiAd.Business.LogBrowseBLL.Instance.Add(log);

            return View();
        }

        public ActionResult s3ad(string adid)
        {
            int aid = 164;
            var info = DN.WeiAd.Business.AdPageInfoBLL.Instance.GetSingle(new DN.WeiAd.Models.AdPageInfoPara() { Id = aid });

            DN.WeiAd.Models.LogBrowseVO log = new DN.WeiAd.Models.LogBrowseVO();

            if (info != null)
            {
                ViewBag.Title = info.Title;
                ViewBag.Content = info.Content;
                log.AdUserId = info.UserId;
                log.Money = info.Money;
            }

            log.BrowseType = DN.Framework.Utility.ClientHelper.GetUserAgent();
            log.ClientIp = DN.Framework.Utility.ClientHelper.ClientIP();
            log.CreateDate = DateTime.Now;
            log.AdUrl = Request.Url.ToString();
            log.IsMoney = 0;
            log.AdId = aid;
            log.Time = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
            log.ClientId = GetClentId(Request, Response);
            log.IsMobile = DN.Framework.Utility.ClientHelper.GetIsMobileDevice() ? 1 : 0;
            log.ReferrerUrl = Request.UrlReferrer == null ? "" : Request.UrlReferrer.AbsoluteUri;
            log.OsName = DN.Framework.Utility.ClientHelper.GetOsName();
            log.BrowseName = DN.Framework.Utility.ClientHelper.GetBrowseName();
            log.BrowseVersion = DN.Framework.Utility.ClientHelper.GetBrowseVersion();
            log.Url = Request.Url.ToString();
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

            DN.WeiAd.Business.LogBrowseBLL.Instance.Add(log);

            return View();
        }

        public ActionResult vc(string adid)
        {
            int aid = int.Parse(adid);
            var info = DN.WeiAd.Business.AdPageInfoBLL.Instance.GetSingle(new DN.WeiAd.Models.AdPageInfoPara() { Id = aid });

            DN.WeiAd.Models.LogBrowseVO log = new DN.WeiAd.Models.LogBrowseVO();

            if (info != null)
            {
                ViewBag.Title = info.Title;
                ViewBag.Content = info.Content;
                log.AdUserId = info.UserId;
                log.Money = info.Money;

            }
            log.BrowseType = DN.Framework.Utility.ClientHelper.GetUserAgent();
            log.ClientIp = DN.Framework.Utility.ClientHelper.ClientIP();
            log.CreateDate = DateTime.Now;
            log.AdUrl = Request.Url.ToString();
            log.IsMoney = 0;
            log.AdId = aid;
            log.Time = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
            log.ClientId = GetClentId(Request, Response);
            log.IsMobile = DN.Framework.Utility.ClientHelper.GetIsMobileDevice() ? 1 : 0;
            log.ReferrerUrl = Request.UrlReferrer == null ? "" : Request.UrlReferrer.AbsoluteUri;
            log.OsName = DN.Framework.Utility.ClientHelper.GetOsName();
            log.BrowseName = DN.Framework.Utility.ClientHelper.GetBrowseName();
            log.BrowseVersion = DN.Framework.Utility.ClientHelper.GetBrowseVersion();
            log.Url = Request.Url.ToString();
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

            DN.WeiAd.Business.LogBrowseBLL.Instance.Add(log);

            return View();
        }
    }
}