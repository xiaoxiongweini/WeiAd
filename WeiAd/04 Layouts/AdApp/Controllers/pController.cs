using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DN.WeiAd.Models;
using DN.WeiAd.Business;

namespace AdApp.Controllers
{
    public class pController : BaseVewController

    {
        /// <summary>
        /// 带退弹功能的界面
        /// </summary>
        /// <param name="p"></param>
        /// <param name="td"></param>
        /// <returns></returns>
        public ActionResult td(string p, string td)
        {
            CommonViewProducte(p, td);
            #region 原代码

            //int pid = 1;
            //if (!string.IsNullOrEmpty(p))
            //{
            //    int.TryParse(p, out pid);
            //}
            ////var pinfo = ProductBLL.GetProducts().SingleOrDefault(tp => tp.Id == pid);
            //var pinfo = ProductInfoBLL.Instance.GetProductById(pid);

            //ViewBag.ProductPrice = pinfo.Price;
            //ViewBag.ProductId = pinfo.Id;
            //ViewBag.AttrJson = DN.Framework.Utility.Serializer.SerializeObject(pinfo.Attr);
            //ViewBag.ProductName = pinfo.Name;

            //int aid = pinfo.AdId;
            //int aduserid = 0;
            //var info = DN.WeiAd.Business.AdPageInfoBLL.Instance.GetSingle(new DN.WeiAd.Models.AdPageInfoPara() { Id = aid });

            //DN.WeiAd.Models.LogBrowseVO log = new DN.WeiAd.Models.LogBrowseVO();

            //if (info != null)
            //{
            //    ViewBag.Title = info.Title;
            //    ViewBag.Content = info.Content;
            //    ViewBag.StaticContent = "<span></span>";
            //    if (!string.IsNullOrEmpty(info.StaticContent))
            //    {
            //        ViewBag.StaticContent = info.StaticContent;
            //    }
            //    ViewBag.UserCode = "<span></span>";
            //    if (!string.IsNullOrEmpty(info.UserCode))
            //    {
            //        ViewBag.UserCode = info.UserCode;
            //    }
            //    aduserid = info.UserId;
            //    log.Money = info.Money;
            //}

            //log.BrowseType = DN.Framework.Utility.ClientHelper.GetUserAgent();
            //log.ClientIp = DN.Framework.Utility.ClientHelper.ClientIP();
            //log.CreateDate = DateTime.Now;
            //log.AdUrl = Request.Url.ToString();
            //log.IsMoney = 0;
            //log.AdId = aid;
            //log.AdUserId = aduserid;
            //log.Time = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
            //log.ClientId = GetClentId(Request, Response);
            //log.IsMobile = DN.Framework.Utility.ClientHelper.GetIsMobileDevice() ? 1 : 0;
            //log.ReferrerUrl = Request.UrlReferrer == null ? "" : Request.UrlReferrer.AbsoluteUri;
            //log.OsName = DN.Framework.Utility.ClientHelper.GetOsName();
            //log.BrowseName = DN.Framework.Utility.ClientHelper.GetBrowseName();
            //log.BrowseVersion = DN.Framework.Utility.ClientHelper.GetBrowseVersion();
            //log.Url = Request.Url.ToString();
            //var ipinfo = DN.WeiAd.Business.Services.IpTaoBaoHelper.GetIpResult(log.ClientIp);
            //if (ipinfo != null && ipinfo.code == 0 && ipinfo.data != null)
            //{
            //    log.Country = ipinfo.data.country;
            //    log.Area = ipinfo.data.area;
            //    log.City = ipinfo.data.city;
            //    log.Region = ipinfo.data.region;
            //    log.County = ipinfo.data.county;
            //    log.Isp = ipinfo.data.isp;

            //    if (!string.IsNullOrEmpty(log.Isp))
            //    {
            //        if (log.Isp.IndexOf("腾讯") != -1)
            //        {
            //            ViewBag.Content = "";
            //            ViewBag.Title = "";
            //        }
            //    }
            //}

            //if (!string.IsNullOrEmpty(td))
            //{
            //    var ainfo = ArticleInfoBLL.Instance.GetSingle(new ArticleInfoPara() { Id = int.Parse(td) });
            //    if (ainfo != null)
            //    {
            //        ViewBag.ArticleTitle = ainfo.Title;
            //        ViewBag.ArticleContent = ainfo.Content;

            //        if (string.IsNullOrEmpty(ViewBag.Title))
            //        {
            //            ViewBag.Title = ainfo.Title;
            //        }
            //    }
            //}

            //ViewBag.AdId = aid;
            //ViewBag.AdUserId = aduserid;


            //DN.WeiAd.Business.LogBrowseBLL.Instance.Add(log);

            #endregion

            return View();
        }

        /// <summary>
        /// 购物界面
        /// </summary>
        /// <param name="p"></param>
        /// <param name="td"></param>
        /// <returns></returns>
        public ActionResult ss(string p, string td)
        {
            CommonViewProducte(p, td);

            return View();
        }

        /// <summary>
        /// 带表单提交的页面
        /// </summary>
        /// <param name="p"></param>
        /// <param name="td"></param>
        /// <returns></returns>
        public ActionResult s(string p, string td)
        {
            CommonViewProducte(p, td);

            #region 原代码
            //int pid = 1;
            //if(!string.IsNullOrEmpty(p))
            //{
            //    int.TryParse(p, out pid);
            //}
            ////var pinfo = ProductBLL.GetProducts().SingleOrDefault(tp => tp.Id == pid);
            //var pinfo = ProductInfoBLL.Instance.GetProductById(pid);

            //ViewBag.ProductPrice = pinfo.Price;
            //ViewBag.ProductId = pinfo.Id;
            //ViewBag.AttrJson = DN.Framework.Utility.Serializer.SerializeObject(pinfo.Attr);
            //ViewBag.ProductName = pinfo.Name;

            //int aid = pinfo.AdId;
            //int aduserid = 0;
            //var info = DN.WeiAd.Business.AdPageInfoBLL.Instance.GetSingle(new DN.WeiAd.Models.AdPageInfoPara() { Id = aid });

            //DN.WeiAd.Models.LogBrowseVO log = new DN.WeiAd.Models.LogBrowseVO();

            //if (info != null)
            //{
            //    ViewBag.Title = info.Title;
            //    ViewBag.Content = info.Content;
            //    ViewBag.StaticContent = "<span></span>";
            //    if (!string.IsNullOrEmpty(info.StaticContent))
            //    {
            //        ViewBag.StaticContent = info.StaticContent;
            //    }
            //    ViewBag.UserCode = "<span></span>";
            //    if (!string.IsNullOrEmpty(info.UserCode))
            //    {
            //        ViewBag.UserCode = info.UserCode;
            //    }
            //    aduserid = info.UserId;
            //    log.Money = info.Money;
            //}

            //log.BrowseType = DN.Framework.Utility.ClientHelper.GetUserAgent();
            //log.ClientIp = DN.Framework.Utility.ClientHelper.ClientIP();
            //log.CreateDate = DateTime.Now;
            //log.AdUrl = Request.Url.ToString();
            //log.IsMoney = 0;
            //log.AdId = aid;
            //log.AdUserId = aduserid;
            //log.Time = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
            //log.ClientId = GetClentId(Request, Response);
            //log.IsMobile = DN.Framework.Utility.ClientHelper.GetIsMobileDevice() ? 1 : 0;
            //log.ReferrerUrl = Request.UrlReferrer == null ? "" : Request.UrlReferrer.AbsoluteUri;
            //log.OsName = DN.Framework.Utility.ClientHelper.GetOsName();
            //log.BrowseName = DN.Framework.Utility.ClientHelper.GetBrowseName();
            //log.BrowseVersion = DN.Framework.Utility.ClientHelper.GetBrowseVersion();
            //log.Url = Request.Url.ToString();
            //var ipinfo = DN.WeiAd.Business.Services.IpTaoBaoHelper.GetIpResult(log.ClientIp);
            //if (ipinfo != null && ipinfo.code == 0 && ipinfo.data != null)
            //{
            //    log.Country = ipinfo.data.country;
            //    log.Area = ipinfo.data.area;
            //    log.City = ipinfo.data.city;
            //    log.Region = ipinfo.data.region;
            //    log.County = ipinfo.data.county;
            //    log.Isp = ipinfo.data.isp;

            //    if (!string.IsNullOrEmpty(log.Isp))
            //    {
            //        if (log.Isp.IndexOf("腾讯") != -1)
            //        {
            //            ViewBag.Content = "";
            //            ViewBag.Title = "";
            //        }
            //    }
            //}

            //if (!string.IsNullOrEmpty(td))
            //{
            //    var ainfo = ArticleInfoBLL.Instance.GetSingle(new ArticleInfoPara() { Id = int.Parse(td) });
            //    if (ainfo != null)
            //    {
            //        ViewBag.ArticleTitle = ainfo.Title;
            //        ViewBag.ArticleContent = ainfo.Content;

            //        if (string.IsNullOrEmpty(ViewBag.Title))
            //        {
            //            ViewBag.Title = ainfo.Title;
            //        }
            //    }
            //}

            //ViewBag.AdId = aid;
            //ViewBag.AdUserId = aduserid;


            //DN.WeiAd.Business.LogBrowseBLL.Instance.Add(log);

            #endregion
            return View();
        }

        // GET: p
        public ActionResult n(string gid, string td)
        {
            CommonView(gid, td);

            #region 原代码

            //int aid = int.Parse(gid);
            //int aduserid = 0;
            //var info = DN.WeiAd.Business.AdPageInfoBLL.Instance.GetSingle(new DN.WeiAd.Models.AdPageInfoPara() { Id = aid });

            //DN.WeiAd.Models.LogBrowseVO log = new DN.WeiAd.Models.LogBrowseVO();

            //if (info != null)
            //{
            //    ViewBag.Title = info.Title;
            //    ViewBag.Content = info.Content;
            //    ViewBag.StaticContent = "<span></span>";
            //    if (!string.IsNullOrEmpty(info.StaticContent))
            //    {
            //        ViewBag.StaticContent = info.StaticContent;
            //    }
            //    ViewBag.UserCode = "<span></span>";
            //    if (!string.IsNullOrEmpty(info.UserCode))
            //    {
            //        ViewBag.UserCode = info.UserCode;
            //    }
            //    aduserid = info.UserId;
            //    log.Money = info.Money;
            //}

            //log.BrowseType = DN.Framework.Utility.ClientHelper.GetUserAgent();
            //log.ClientIp = DN.Framework.Utility.ClientHelper.ClientIP();
            //log.CreateDate = DateTime.Now;
            //log.AdUrl = Request.Url.ToString();
            //log.IsMoney = 0;
            //log.AdId = aid;
            //log.AdUserId = aduserid;
            //log.Time = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
            //log.ClientId = GetClentId(Request, Response);
            //log.IsMobile = DN.Framework.Utility.ClientHelper.GetIsMobileDevice() ? 1 : 0;
            //log.ReferrerUrl = Request.UrlReferrer == null ? "" : Request.UrlReferrer.AbsoluteUri;
            //log.OsName = DN.Framework.Utility.ClientHelper.GetOsName();
            //log.BrowseName = DN.Framework.Utility.ClientHelper.GetBrowseName();
            //log.BrowseVersion = DN.Framework.Utility.ClientHelper.GetBrowseVersion();
            //log.Url = Request.Url.ToString();
            //var ipinfo = DN.WeiAd.Business.Services.IpTaoBaoHelper.GetIpResult(log.ClientIp);
            //if (ipinfo != null && ipinfo.code == 0 && ipinfo.data != null)
            //{
            //    log.Country = ipinfo.data.country;
            //    log.Area = ipinfo.data.area;
            //    log.City = ipinfo.data.city;
            //    log.Region = ipinfo.data.region;
            //    log.County = ipinfo.data.county;
            //    log.Isp = ipinfo.data.isp;

            //    if (!string.IsNullOrEmpty(log.Isp))
            //    {
            //        if (log.Isp.IndexOf("腾讯") != -1)
            //        {
            //            ViewBag.Content = "";
            //            ViewBag.Title = "";
            //        }
            //    }
            //}

            //if (!string.IsNullOrEmpty(td))
            //{
            //    var ainfo = ArticleInfoBLL.Instance.GetSingle(new ArticleInfoPara() { Id = int.Parse(td) });
            //    if (ainfo != null)
            //    {
            //        ViewBag.ArticleTitle = ainfo.Title;
            //        ViewBag.ArticleContent = ainfo.Content;

            //        if (string.IsNullOrEmpty(ViewBag.Title))
            //        {
            //            ViewBag.Title = ainfo.Title;
            //        }
            //    }
            //}


            //DN.WeiAd.Business.LogBrowseBLL.Instance.Add(log);

            #endregion

            return View();
        }

        public ActionResult b(string gid, string td)
        {
            #region 原代码 

            //int aid = 188;
            //try
            //{
            //    int.TryParse(gid, out aid);
            //    int aduserid = 0;
            //    var info = DN.WeiAd.Business.AdPageInfoBLL.Instance.GetSingle(new DN.WeiAd.Models.AdPageInfoPara() { Id = aid });

            //    ViewBag.AdId = aid;
            //    ViewBag.AdUserId = aduserid;
            //    DN.WeiAd.Models.LogBrowseVO log = new DN.WeiAd.Models.LogBrowseVO();

            //    if (info != null)
            //    {
            //        ViewBag.Title = info.Title;
            //        ViewBag.Content = info.Content;
            //        ViewBag.StaticContent = "<span></span>";
            //        if (!string.IsNullOrEmpty(info.StaticContent))
            //        {
            //            ViewBag.StaticContent = info.StaticContent;
            //        }
            //        ViewBag.UserCode = "<span></span>";
            //        if (!string.IsNullOrEmpty(info.UserCode))
            //        {
            //            ViewBag.UserCode = info.UserCode;
            //        }
            //        aduserid = info.UserId;
            //        log.Money = info.Money;

            //        ViewBag.AdId = aid;
            //        ViewBag.AdUserId = aduserid;
            //    }

            //    log.BrowseType = DN.Framework.Utility.ClientHelper.GetUserAgent();
            //    log.ClientIp = DN.Framework.Utility.ClientHelper.ClientIP();
            //    log.CreateDate = DateTime.Now;
            //    log.AdUrl = Request.Url.ToString();
            //    log.IsMoney = 0;
            //    log.AdId = aid;
            //    log.AdUserId = aduserid;
            //    log.Time = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
            //    log.ClientId = GetClentId(Request, Response);
            //    log.IsMobile = DN.Framework.Utility.ClientHelper.GetIsMobileDevice() ? 1 : 0;
            //    log.ReferrerUrl = Request.UrlReferrer == null ? "" : Request.UrlReferrer.AbsoluteUri;
            //    log.OsName = DN.Framework.Utility.ClientHelper.GetOsName();
            //    log.BrowseName = DN.Framework.Utility.ClientHelper.GetBrowseName();
            //    log.BrowseVersion = DN.Framework.Utility.ClientHelper.GetBrowseVersion();
            //    log.Url = Request.Url.ToString();
            //    var ipinfo = DN.WeiAd.Business.Services.IpTaoBaoHelper.GetIpResult(log.ClientIp);
            //    if (ipinfo != null && ipinfo.code == 0 && ipinfo.data != null)
            //    {
            //        log.Country = ipinfo.data.country;
            //        log.Area = ipinfo.data.area;
            //        log.City = ipinfo.data.city;
            //        log.Region = ipinfo.data.region;
            //        log.County = ipinfo.data.county;
            //        log.Isp = ipinfo.data.isp;

            //        if (!string.IsNullOrEmpty(log.Isp))
            //        {
            //            if (log.Isp.IndexOf("腾讯") != -1)
            //            {
            //                ViewBag.Content = "";
            //                ViewBag.Title = "";
            //            }
            //        }
            //    }

            //    if (!string.IsNullOrEmpty(td))
            //    {
            //        int nid = 10;
            //        int.TryParse(td, out nid);
            //        var ainfo = ArticleInfoBLL.Instance.GetSingle(new ArticleInfoPara() { Id = nid });
            //        if (ainfo != null)
            //        {
            //            ViewBag.ArticleTitle = ainfo.Title;
            //            ViewBag.ArticleContent = ainfo.Content;

            //            if (string.IsNullOrEmpty(ViewBag.Title))
            //            {
            //                ViewBag.Title = ainfo.Title;
            //            }
            //        }
            //    }


            //    DN.WeiAd.Business.LogBrowseBLL.Instance.Add(log);

            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            #endregion

            CommonView(gid, td);

            return View();
        }

        /// <summary>
        /// 中间页
        /// </summary>
        /// <param name="gid">广告ID</param>
        /// <param name="td">新闻</param>
        /// <param name="pt">平台简写</param>
        /// <returns></returns>
        // GET: p
        public ActionResult m(string gid, string td, string pt)
        {
            #region 原代码

            //int aid = int.Parse(gid);
            //int aduserid = 0;
            //var info = DN.WeiAd.Business.AdPageInfoBLL.Instance.GetSingle(new DN.WeiAd.Models.AdPageInfoPara() { Id = aid });
            //ViewBag.Pt = pt;
            //DN.WeiAd.Models.LogBrowseVO log = new DN.WeiAd.Models.LogBrowseVO();

            //if (info != null)
            //{
            //    ViewBag.Title = info.Title;
            //    ViewBag.Content = info.Content;
            //    ViewBag.StaticContent = "<span></span>";
            //    if (!string.IsNullOrEmpty(info.StaticContent))
            //    {
            //        ViewBag.StaticContent = info.StaticContent;
            //    }
            //    ViewBag.UserCode = "<span></span>";
            //    if (!string.IsNullOrEmpty(info.UserCode))
            //    {
            //        ViewBag.UserCode = info.UserCode;
            //    }
            //    aduserid = info.UserId;
            //    log.Money = info.Money;
            //}

            //log.BrowseType = DN.Framework.Utility.ClientHelper.GetUserAgent();
            //log.ClientIp = DN.Framework.Utility.ClientHelper.ClientIP();
            //log.CreateDate = DateTime.Now;
            //log.AdUrl = Request.Url.ToString();
            //log.IsMoney = 0;
            //log.AdId = aid;
            //log.AdUserId = aduserid;
            //log.Time = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
            //log.ClientId = GetClentId(Request, Response);
            //log.IsMobile = DN.Framework.Utility.ClientHelper.GetIsMobileDevice() ? 1 : 0;
            //log.ReferrerUrl = Request.UrlReferrer == null ? "" : Request.UrlReferrer.AbsoluteUri;
            //log.OsName = DN.Framework.Utility.ClientHelper.GetOsName();
            //log.BrowseName = DN.Framework.Utility.ClientHelper.GetBrowseName();
            //log.BrowseVersion = DN.Framework.Utility.ClientHelper.GetBrowseVersion();
            //log.Url = Request.Url.ToString();
            //var ipinfo = DN.WeiAd.Business.Services.IpTaoBaoHelper.GetIpResult(log.ClientIp);
            //if (ipinfo != null && ipinfo.code == 0 && ipinfo.data != null)
            //{
            //    log.Country = ipinfo.data.country;
            //    log.Area = ipinfo.data.area;
            //    log.City = ipinfo.data.city;
            //    log.Region = ipinfo.data.region;
            //    log.County = ipinfo.data.county;
            //    log.Isp = ipinfo.data.isp;

            //    if (!string.IsNullOrEmpty(log.Isp))
            //    {
            //        if (log.Isp.IndexOf("腾讯") != -1)
            //        {
            //            ViewBag.Content = "";
            //            ViewBag.Title = "";
            //        }
            //    }
            //}

            //if (!string.IsNullOrEmpty(td))
            //{
            //    var ainfo = ArticleInfoBLL.Instance.GetSingle(new ArticleInfoPara() { Id = int.Parse(td) });
            //    if (ainfo != null)
            //    {
            //        ViewBag.ArticleTitle = ainfo.Title;
            //        ViewBag.ArticleContent = ainfo.Content;

            //        if (string.IsNullOrEmpty(ViewBag.Title))
            //        {
            //            ViewBag.Title = ainfo.Title;
            //        }
            //    }
            //}


            //DN.WeiAd.Business.LogBrowseBLL.Instance.Add(log);


            #endregion

            CommonView(gid, td);

            return View();
        }


        // GET: p
        /// <summary>
        /// 退弹功能的界面
        /// </summary>
        /// <param name="gid"></param>
        /// <param name="td"></param>
        /// <returns></returns>
        public ActionResult ts(string gid, string td)
        {
            #region 原代码

            //int aid = int.Parse(gid);
            //int aduserid = 0;
            //var info = DN.WeiAd.Business.AdPageInfoBLL.Instance.GetSingle(new DN.WeiAd.Models.AdPageInfoPara() { Id = aid });

            //DN.WeiAd.Models.LogBrowseVO log = new DN.WeiAd.Models.LogBrowseVO();

            //if (info != null)
            //{
            //    ViewBag.Title = info.Title;
            //    ViewBag.Content = info.Content;
            //    ViewBag.StaticContent = "<span></span>";
            //    if (!string.IsNullOrEmpty(info.StaticContent))
            //    {
            //        ViewBag.StaticContent = info.StaticContent;
            //    }
            //    ViewBag.UserCode = "<span></span>";
            //    if (!string.IsNullOrEmpty(info.UserCode))
            //    {
            //        ViewBag.UserCode = info.UserCode;
            //    }
            //    aduserid = info.UserId;
            //    log.Money = info.Money;
            //    ViewBag.QcodeImg = info.QcodeImg;
            //    ViewBag.QcodeImg2 = info.QcodeImg2;
            //}

            //log.BrowseType = DN.Framework.Utility.ClientHelper.GetUserAgent();
            //log.ClientIp = DN.Framework.Utility.ClientHelper.ClientIP();
            //log.CreateDate = DateTime.Now;
            //log.AdUrl = Request.Url.ToString();
            //log.IsMoney = 0;
            //log.AdId = aid;
            //log.AdUserId = aduserid;
            //log.Time = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
            //log.ClientId = GetClentId(Request, Response);
            //log.IsMobile = DN.Framework.Utility.ClientHelper.GetIsMobileDevice() ? 1 : 0;
            //log.ReferrerUrl = Request.UrlReferrer == null ? "" : Request.UrlReferrer.AbsoluteUri;
            //log.OsName = DN.Framework.Utility.ClientHelper.GetOsName();
            //log.BrowseName = DN.Framework.Utility.ClientHelper.GetBrowseName();
            //log.BrowseVersion = DN.Framework.Utility.ClientHelper.GetBrowseVersion();
            //log.Url = Request.Url.ToString();
            //var ipinfo = DN.WeiAd.Business.Services.IpTaoBaoHelper.GetIpResult(log.ClientIp);
            //if (ipinfo != null && ipinfo.code == 0 && ipinfo.data != null)
            //{
            //    log.Country = ipinfo.data.country;
            //    log.Area = ipinfo.data.area;
            //    log.City = ipinfo.data.city;
            //    log.Region = ipinfo.data.region;
            //    log.County = ipinfo.data.county;
            //    log.Isp = ipinfo.data.isp;

            //    if (!string.IsNullOrEmpty(log.Isp))
            //    {
            //        if (log.Isp.IndexOf("腾讯") != -1)
            //        {
            //            ViewBag.Content = "";
            //            ViewBag.Title = "";
            //        }
            //    }
            //}

            //if (!string.IsNullOrEmpty(td))
            //{
            //    var ainfo = ArticleInfoBLL.Instance.GetSingle(new ArticleInfoPara() { Id = int.Parse(td) });
            //    if (ainfo != null)
            //    {
            //        ViewBag.ArticleTitle = ainfo.Title;
            //        ViewBag.ArticleContent = ainfo.Content;

            //        if (string.IsNullOrEmpty(ViewBag.Title))
            //        {
            //            ViewBag.Title = ainfo.Title;
            //        }
            //    }
            //}

            //DN.WeiAd.Business.LogBrowseBLL.Instance.Add(log);

            #endregion

            CommonView(gid, td);

            return View();
        }

        // GET: p
        /// <summary>
        /// 鼻炎功能的界面
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nd"></param>
        /// <returns></returns>
        public ActionResult by(string id, string nd)
        {
            CommonView(id, nd);
            return View();
        }

        // GET: p
        /// <summary>
        /// 增高弹功能的界面
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nd"></param>
        /// <returns></returns>
        public ActionResult zg(string id, string nd)
        {
            CommonView(id, nd);
            return View();
        }

        // GET: p
        /// <summary>
        /// 牛皮癣的界面
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nd"></param>
        /// <returns></returns>
        public ActionResult npx(string id, string nd)
        {
            CommonView(id, nd);
            return View();
        }


        public ActionResult ab(string id, string nd)
        {
            CommonView(id, nd);
            return View();
        }

        /// <summary>
        /// 男科广告
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nd"></param>
        /// <returns></returns>
        public ActionResult nk(string id, string nd)
        {
            CommonView(id, nd);
            return View();
        }

        /// <summary>
        /// AJAX加载
        /// </summary>
        /// <param name="d"></param>
        /// <param name="nd"></param>
        /// <returns></returns>
        public ActionResult d(string d, string nd, string t)
        {
            string adid = t;
            if (string.IsNullOrEmpty(adid))
            {
                adid = d;
            }

            CommonView(adid, nd);
            ViewBag.Nid = adid;
            return View();
        }

        /// <summary>
        /// 男科广告
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nd"></param>
        /// <returns></returns>
        public ActionResult nk1(string id, string nd)
        {
            CommonViewAreasByTemplateName(id, nd, "nk1.txt");
            return View();
        }

        /// <summary>
        /// 屏蔽上海的广告，加上替换功能
        /// </summary>
        /// <param name="wid"></param>
        /// <param name="wnd"></param>
        /// <returns></returns>
        public ActionResult vw(string wid, string wnd)
        {
            CommonViewArea(wid, wnd);
            return View();
        }

        /// <summary>
        /// 男科广告
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nd"></param>
        /// <returns></returns>
        public ActionResult nk2(string id, string nd)
        {
            CommonView(id, nd);
            return View();
        }

        // GET: p
        /// <summary>
        /// 鼻炎功能的界面,WAP使用微信号
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nd"></param>
        /// <returns></returns>
        public ActionResult byw(string id, string nd)
        {
            CommonViewAreasByTemplateName(id, nd, "bywap.txt", true);
            return View();
        }

        /// <summary>
        /// 鼻炎
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nd"></param>
        /// <returns></returns>
        public ActionResult byw1(string id, string nd)
        {
            CommonViewAreasByTemplateName(id, nd, "bywap.txt", true);
            return View();
        }
        
        /// <summary>
        /// 痔疮
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nd"></param>
        /// <returns></returns>
        public ActionResult zc(string id, string nd)
        {
            CommonView(id, nd);
            return View();
        }

        /// <summary>
        /// 增高
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nd"></param>
        /// <returns></returns>
        public ActionResult zgw(string id, string nd)
        {
            CommonView(id, nd);
            return View();
        }

        /// <summary>
        /// 丰胸
        /// </summary>
        /// <param name="d"></param>
        /// <param name="nd"></param>
        /// <returns></returns>
        public ActionResult fx(string d, string nd)
        {
            CommonView(d, nd);
            return View();
        }

    }
}