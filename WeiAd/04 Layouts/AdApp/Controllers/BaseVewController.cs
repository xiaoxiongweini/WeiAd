using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DN.WeiAd.Models;
using DN.WeiAd.Business;
using System.Web.Mvc;
using System.Text;
using System.Text.RegularExpressions;

namespace AdApp.Controllers
{
    /// <summary>
    /// 页面基类
    /// </summary>
    public class BaseVewController : Controller
    {
        /// <summary>
        /// 获取模版文件
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public string GetTemplateByName(string filename)
        {
            string filepath = Server.MapPath(string.Format("/Resources/Template/{0}", filename));
            string html = "";

            html =  TemplateBLL.GetTemplate(filepath);

            return html;
        }

        /// <summary>
        /// 获取加密模版文件
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public string GetTemplateByNameEncode(string filename)
        {
            string filepath = Server.MapPath(string.Format("/Resources/Template/{0}", filename));
            string html = "";

            html = TemplateBLL.GetTemplate(filepath);

            return html;
        }


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

        /// <summary>
        /// 带产品ID的页面
        /// </summary>
        /// <param name="producteid"></param>
        /// <param name="newid"></param>
        public void CommonViewProducte(string producteid, string td)
        {
            try
            {
                int pid = 1;
                if (!string.IsNullOrEmpty(producteid))
                {
                    int.TryParse(producteid, out pid);
                }
                //var pinfo = ProductBLL.GetProducts().SingleOrDefault(tp => tp.Id == pid);
                var pinfo = ProductInfoBLL.Instance.GetProductById(pid);

                ViewBag.ProductPrice = pinfo.Price;
                ViewBag.ProductId = pinfo.Id;
                ViewBag.AttrJson = DN.Framework.Utility.Serializer.SerializeObject(pinfo.Attr);
                ViewBag.ProductName = pinfo.Name;

                int aid = pinfo.AdId;
                int aduserid = 0;
                var info = DN.WeiAd.Business.AdPageInfoBLL.Instance.GetSingle(new DN.WeiAd.Models.AdPageInfoPara() { Id = aid });

                DN.WeiAd.Models.LogBrowseVO log = new DN.WeiAd.Models.LogBrowseVO();

                if (info != null)
                {
                    ViewBag.Title = info.Title;
                    ViewBag.Content = info.Content;
                    ViewBag.StaticContent = "<span></span>";
                    if (!string.IsNullOrEmpty(info.StaticContent))
                    {
                        ViewBag.StaticContent = info.StaticContent;
                    }
                    ViewBag.UserCode = "<span></span>";
                    if (!string.IsNullOrEmpty(info.UserCode))
                    {
                        ViewBag.UserCode = info.UserCode;
                    }
                    aduserid = info.UserId;
                    log.Money = info.Money;

                    ViewBag.QcodeImg = info.QcodeImg;
                    ViewBag.QcodeImg2 = info.QcodeImg2;

                }

                log.BrowseType = DN.Framework.Utility.ClientHelper.GetUserAgent();
                log.ClientIp = DN.Framework.Utility.ClientHelper.ClientIP();
                log.CreateDate = DateTime.Now;
                log.AdUrl = Request.Url.ToString();
                log.IsMoney = 0;
                log.AdId = aid;
                log.AdUserId = aduserid;
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

                    if (!string.IsNullOrEmpty(log.Isp))
                    {
                        if (log.Isp.IndexOf("腾讯") != -1)
                        {
                            ViewBag.Content = "";
                            ViewBag.Title = "";
                        }
                    }
                }



                if (!string.IsNullOrEmpty(td))
                {
                    var ainfo = ArticleInfoBLL.Instance.GetSingle(new ArticleInfoPara() { Id = int.Parse(td) });
                    if (ainfo != null)
                    {
                        ViewBag.ArticleTitle = ainfo.Title;
                        ViewBag.ArticleContent = ainfo.Content;

                        if (string.IsNullOrEmpty(ViewBag.Title))
                        {
                            ViewBag.Title = ainfo.Title;
                        }
                    }
                }

                ViewBag.AdId = aid;
                ViewBag.AdUserId = aduserid;


                DN.WeiAd.Business.LogBrowseBLL.Instance.Add(log);
            }
            catch (Exception ex)
            {
                DN.Framework.Utility.LogHelper.Error(ex.Message, "baseview");
            }
        }

        public void CommomViewCss(string adid, string newid)
        {

            int aid = int.Parse(adid);
            int aduserid = 0;
            var info = DN.WeiAd.Business.AdPageInfoBLL.Instance.GetSingle(new DN.WeiAd.Models.AdPageInfoPara() { Id = aid });

            DN.WeiAd.Models.LogBrowseVO log = new DN.WeiAd.Models.LogBrowseVO();

            if (info != null)
            {
                var imgs = DN.Framework.Utility.HtmlHelper.GetImgSrcs(info.Content);



                ViewBag.Title = info.Title;
                ViewBag.Content = info.Content;
                ViewBag.StaticContent = "<span></span>";
                if (!string.IsNullOrEmpty(info.StaticContent))
                {
                    ViewBag.StaticContent = info.StaticContent;
                }
                ViewBag.UserCode = "<span></span>";
                if (!string.IsNullOrEmpty(info.UserCode))
                {
                    ViewBag.UserCode = info.UserCode;
                }
                aduserid = info.UserId;
                log.Money = info.Money;
                ViewBag.QcodeImg = info.QcodeImg;
                ViewBag.QcodeImg2 = info.QcodeImg2;
            }

            log.BrowseType = DN.Framework.Utility.ClientHelper.GetUserAgent();
            log.ClientIp = DN.Framework.Utility.ClientHelper.ClientIP();
            log.CreateDate = DateTime.Now;
            log.AdUrl = Request.Url.ToString();
            log.IsMoney = 0;
            log.AdId = aid;
            log.AdUserId = aduserid;
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

                if (!string.IsNullOrEmpty(log.Isp))
                {
                    if (log.Isp.IndexOf("腾讯") != -1)
                    {
                        ViewBag.Content = "";
                        ViewBag.Title = "";
                    }
                }
            }

            if (!string.IsNullOrEmpty(newid))
            {
                var ainfo = ArticleInfoBLL.Instance.GetSingle(new ArticleInfoPara() { Id = int.Parse(newid) });
                if (ainfo != null)
                {
                    ViewBag.ArticleTitle = ainfo.Title;
                    ViewBag.ArticleContent = ainfo.Content;

                    if (string.IsNullOrEmpty(ViewBag.Title))
                    {
                        ViewBag.Title = ainfo.Title;
                    }
                }
            }

            DN.WeiAd.Business.LogBrowseBLL.Instance.Add(log);
        }

        /// <summary>
        /// 屏蔽多个区域
        /// </summary>
        /// <param name="adid"></param>
        /// <param name="newid"></param>
        public void CommonViewAreas(string adid, string newid)
        {

            int aid = int.Parse(adid);
            int aduserid = 0;
            var info = DN.WeiAd.Business.AdPageInfoBLL.Instance.GetSingle(new DN.WeiAd.Models.AdPageInfoPara() { Id = aid });

            DN.WeiAd.Models.LogBrowseVO log = new DN.WeiAd.Models.LogBrowseVO();

            if (info != null)
            {
                ViewBag.Title = info.Title;
                ViewBag.Content = info.Content;
                ViewBag.StaticContent = "<span></span>";
                if (!string.IsNullOrEmpty(info.StaticContent))
                {
                    ViewBag.StaticContent = info.StaticContent;
                }
                ViewBag.UserCode = "<span></span>";
                if (!string.IsNullOrEmpty(info.UserCode))
                {
                    ViewBag.UserCode = info.UserCode;
                }
                aduserid = info.UserId;
                log.Money = info.Money;
                ViewBag.QcodeImg = info.QcodeImg;
                ViewBag.QcodeImg2 = info.QcodeImg2;
            }

            log.BrowseType = DN.Framework.Utility.ClientHelper.GetUserAgent();
            log.ClientIp = DN.Framework.Utility.ClientHelper.ClientIP();
            log.CreateDate = DateTime.Now;
            log.AdUrl = Request.Url.ToString();
            log.IsMoney = 0;
            log.AdId = aid;
            log.AdUserId = aduserid;
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

                if (!string.IsNullOrEmpty(log.Isp))
                {
                    if (log.Isp.IndexOf("腾讯") != -1)
                    {
                        ViewBag.Content = "";
                        ViewBag.Title = "";
                    }
                }

                if (!string.IsNullOrEmpty(log.City))
                {
                    if (log.City.IndexOf("上海") != -1)
                    {
                        ViewBag.Content = "";
                        ViewBag.Title = "";
                    }
                    if (log.City.IndexOf("天津") != -1)
                    {
                        ViewBag.Content = "";
                        ViewBag.Title = "";
                    }
                    if (log.City.IndexOf("深圳") != -1)
                    {
                        ViewBag.Content = "";
                        ViewBag.Title = "";
                    }
                    if (log.City.IndexOf("广州") != -1)
                    {
                        ViewBag.Content = "";
                        ViewBag.Title = "";
                    }
                }
            }

            if (!string.IsNullOrEmpty(newid))
            {
                var ainfo = ArticleInfoBLL.Instance.GetSingle(new ArticleInfoPara() { Id = int.Parse(newid) });
                if (ainfo != null)
                {
                    ViewBag.ArticleTitle = ainfo.Title;
                    ViewBag.ArticleContent = ainfo.Content;

                    if (string.IsNullOrEmpty(ViewBag.Title))
                    {
                        ViewBag.Title = ainfo.Title;
                    }
                }
            }

            DN.WeiAd.Business.LogBrowseBLL.Instance.Add(log);
        }

        /// <summary>
        /// 屏蔽多个区域，并且使用模版
        /// </summary>
        /// <param name="adid"></param>
        /// <param name="newid"></param>
        /// <param name="templatename">模版文件名称加后缀</param>
        public void CommonViewAreasByTemplateName(string adid, string newid, string templatename, bool isencode = false)
        {

            int aid = int.Parse(adid);
            int aduserid = 0;
            var info = DN.WeiAd.Business.AdPageInfoBLL.Instance.GetSingle(new DN.WeiAd.Models.AdPageInfoPara() { Id = aid });

            DN.WeiAd.Models.LogBrowseVO log = new DN.WeiAd.Models.LogBrowseVO();

            if (info != null)
            {
                ViewBag.Title = info.Title;
                ViewBag.Content = info.Content;
                ViewBag.StaticContent = "<span></span>";
                if (!string.IsNullOrEmpty(info.StaticContent))
                {
                    ViewBag.StaticContent = info.StaticContent;
                }
                ViewBag.UserCode = "<span></span>";
                if (!string.IsNullOrEmpty(info.UserCode))
                {
                    ViewBag.UserCode = info.UserCode;
                }
                aduserid = info.UserId;
                log.Money = info.Money;
                ViewBag.QcodeImg = info.QcodeImg;
                ViewBag.QcodeImg2 = info.QcodeImg2;
            }

            log.BrowseType = DN.Framework.Utility.ClientHelper.GetUserAgent();
            log.ClientIp = DN.Framework.Utility.ClientHelper.ClientIP();
            log.CreateDate = DateTime.Now;
            log.AdUrl = Request.Url.ToString();
            log.IsMoney = 0;
            log.AdId = aid;
            log.AdUserId = aduserid;
            log.Time = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
            log.ClientId = GetClentId(Request, Response);
            log.IsMobile = DN.Framework.Utility.ClientHelper.GetIsMobileDevice() ? 1 : 0;
            log.ReferrerUrl = Request.UrlReferrer == null ? "" : Request.UrlReferrer.AbsoluteUri;
            log.OsName = DN.Framework.Utility.ClientHelper.GetOsName();
            log.BrowseName = DN.Framework.Utility.ClientHelper.GetBrowseName();
            log.BrowseVersion = DN.Framework.Utility.ClientHelper.GetBrowseVersion();
            log.Url = Request.Url.ToString();
            var ipinfo = DN.WeiAd.Business.Services.IpTaoBaoHelper.GetIpResult(log.ClientIp);

            string html = "";

            if (isencode)
            {
                html = GetTemplateByNameEncode(templatename);
            }
            else
            {
                html = GetTemplateByName(templatename);
            }


            ViewBag.TemplateContent = html;

            if (ipinfo != null && ipinfo.code == 0 && ipinfo.data != null)
            {
                log.Country = ipinfo.data.country;
                log.Area = ipinfo.data.area;
                log.City = ipinfo.data.city;
                log.Region = ipinfo.data.region;
                log.County = ipinfo.data.county;
                log.Isp = ipinfo.data.isp;

                if (!string.IsNullOrEmpty(log.Isp))
                {
                    if (log.Isp.IndexOf("腾讯") != -1)
                    {
                        ViewBag.Content = "";
                        ViewBag.Title = "";
                        ViewBag.TemplateContent = "";
                    }
                }

                if (!string.IsNullOrEmpty(log.City))
                {
                    //if (log.City.IndexOf("上海") != -1)
                    //{
                    //    ViewBag.Content = "";
                    //    ViewBag.Title = "";
                    //    ViewBag.TemplateContent = "";
                    //}
                    //if (log.City.IndexOf("天津") != -1)
                    //{
                    //    ViewBag.Content = "";
                    //    ViewBag.Title = "";
                    //    ViewBag.TemplateContent = "";
                    //}
                    //if (log.City.IndexOf("深圳") != -1)
                    //{
                    //    ViewBag.Content = "";
                    //    ViewBag.Title = "";
                    //    ViewBag.TemplateContent = "";
                    //}
                    //if (log.City.IndexOf("广州") != -1)
                    //{
                    //    ViewBag.Content = "";
                    //    ViewBag.Title = "";
                    //    ViewBag.TemplateContent = "";
                    //}
                    //if (log.City.IndexOf("北京") != -1)
                    //{
                    //    ViewBag.Content = "";
                    //    ViewBag.Title = "";
                    //    ViewBag.TemplateContent = "";
                    //}
                }
            }

            if (!string.IsNullOrEmpty(newid))
            {
                var ainfo = ArticleInfoBLL.Instance.GetSingle(new ArticleInfoPara() { Id = int.Parse(newid) });
                if (ainfo != null)
                {
                    ViewBag.ArticleTitle = ainfo.Title;
                    ViewBag.ArticleContent = ainfo.Content;

                    if (string.IsNullOrEmpty(ViewBag.Title))
                    {
                        ViewBag.Title = ainfo.Title;
                    }
                }
            }

            DN.WeiAd.Business.LogBrowseBLL.Instance.Add(log);
        }

        /// <summary>
        /// 带区域屏蔽的功能
        /// </summary>
        /// <param name="adid"></param>
        /// <param name="newid"></param>
        public void CommonViewArea(string adid, string newid)
        {
            int aid = int.Parse(adid);
            int aduserid = 0;
            var info = DN.WeiAd.Business.AdPageInfoBLL.Instance.GetSingle(new DN.WeiAd.Models.AdPageInfoPara() { Id = aid });

            DN.WeiAd.Models.LogBrowseVO log = new DN.WeiAd.Models.LogBrowseVO();

            if (info != null)
            {
                ViewBag.Title = info.Title;
                ViewBag.Content = info.Content;
                ViewBag.StaticContent = "<span></span>";
                if (!string.IsNullOrEmpty(info.StaticContent))
                {
                    ViewBag.StaticContent = info.StaticContent;
                }
                ViewBag.UserCode = "<span></span>";
                if (!string.IsNullOrEmpty(info.UserCode))
                {
                    ViewBag.UserCode = info.UserCode;
                }
                aduserid = info.UserId;
                log.Money = info.Money;
                ViewBag.QcodeImg = info.QcodeImg;
                ViewBag.QcodeImg2 = info.QcodeImg2;
            }

            log.BrowseType = DN.Framework.Utility.ClientHelper.GetUserAgent();
            log.ClientIp = DN.Framework.Utility.ClientHelper.ClientIP();
            log.CreateDate = DateTime.Now;
            log.AdUrl = Request.Url.ToString();
            log.IsMoney = 0;
            log.AdId = aid;
            log.AdUserId = aduserid;
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

                if (!string.IsNullOrEmpty(log.Isp))
                {
                    if (log.Isp.IndexOf("腾讯") != -1)
                    {
                        ViewBag.Content = "";
                        ViewBag.Title = "";
                    }
                }

                if (!string.IsNullOrEmpty(log.City))
                {
                    if (log.City.IndexOf("上海") != -1)
                    {
                        ViewBag.Content = "";
                        ViewBag.Title = "";
                    }
                }
            }

            if (!string.IsNullOrEmpty(newid))
            {
                var ainfo = ArticleInfoBLL.Instance.GetSingle(new ArticleInfoPara() { Id = int.Parse(newid) });
                if (ainfo != null)
                {
                    ViewBag.ArticleTitle = ainfo.Title;
                    ViewBag.ArticleContent = ainfo.Content;

                    if (string.IsNullOrEmpty(ViewBag.Title))
                    {
                        ViewBag.Title = ainfo.Title;
                    }
                }
            }

            DN.WeiAd.Business.LogBrowseBLL.Instance.Add(log);
        }

        /// <summary>
        /// 只读取新闻
        /// </summary>
        /// <param name="adid"></param>
        /// <param name="newid"></param>
        public void CommonViewNoLog(string adid,string newid)
        {
            if (!string.IsNullOrEmpty(newid))
            {
                var ainfo = ArticleInfoBLL.Instance.GetSingle(new ArticleInfoPara() { Id = int.Parse(newid) });
                if (ainfo != null)
                {
                    ViewBag.ArticleTitle = ainfo.Title;
                    ViewBag.ArticleContent = ainfo.Content;

                    if (string.IsNullOrEmpty(ViewBag.Title))
                    {
                        ViewBag.Title = ainfo.Title;
                    }
                }
            }
        }

        /// <summary>
        /// 公共方法
        /// </summary>
        /// <param name="adid"></param>
        /// <param name="newid"></param>
        public void CommonView(string adid, string newid)
        {
            /*
             加入来源判断，如果为NULL则跳转到其它页面，debug=1则不跳转调试使用 skey edit 2017-09-07
             */

            int aid = int.Parse(adid);
            int aduserid = 0;
            var info = DN.WeiAd.Business.AdPageInfoBLL.Instance.GetSingle(new DN.WeiAd.Models.AdPageInfoPara() { Id = aid });

            DN.WeiAd.Models.LogBrowseVO log = new DN.WeiAd.Models.LogBrowseVO();

            if (info != null)
            {
                ViewBag.Title = info.Title;
                ViewBag.Content = info.Content;
                ViewBag.StaticContent = "<span></span>";
                if (!string.IsNullOrEmpty(info.StaticContent))
                {
                    ViewBag.StaticContent = info.StaticContent;
                }
                ViewBag.UserCode = "<span></span>";
                if (!string.IsNullOrEmpty(info.UserCode))
                {
                    ViewBag.UserCode = info.UserCode;
                }
                aduserid = info.UserId;
                log.Money = info.Money;
                ViewBag.QcodeImg = info.QcodeImg;
                ViewBag.QcodeImg2 = info.QcodeImg2;
            }

            log.BrowseType = DN.Framework.Utility.ClientHelper.GetUserAgent();
            log.ClientIp = DN.Framework.Utility.ClientHelper.ClientIP();
            log.CreateDate = DateTime.Now;
            log.AdUrl = Request.Url.ToString();
            log.IsMoney = 0;
            log.AdId = aid;
            log.AdUserId = aduserid;
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

                if (!string.IsNullOrEmpty(log.Isp))
                {
                    if (log.Isp.IndexOf("腾讯") != -1)
                    {
                        ViewBag.Content = "";
                        ViewBag.Title = "";
                    }
                }
            }

            if (!string.IsNullOrEmpty(newid))
            {
                var ainfo = ArticleInfoBLL.Instance.GetSingle(new ArticleInfoPara() { Id = int.Parse(newid) });
                if (ainfo != null)
                {
                    ViewBag.ArticleTitle = ainfo.Title;
                    ViewBag.ArticleContent = ainfo.Content;

                    if (string.IsNullOrEmpty(ViewBag.Title))
                    {
                        ViewBag.Title = ainfo.Title;
                    }
                }
            }

            DN.WeiAd.Business.LogBrowseBLL.Instance.Add(log);

            //if(string.IsNullOrEmpty(log.ReferrerUrl))
            //{
            //    string debug = Request.Params["debug"] ?? "";

            //    if (debug != "1")
            //    {
            //        Response.Redirect("http://www.qq.com");
            //    }
            //}
        }


        /// <summary>
        /// 公共方法
        /// </summary>
        /// <param name="adid"></param>
        /// <param name="newid"></param>
        /// <param name="citys">屏蔽城市</param>
        public void CommonViewWeb(string adid, string newid)
        {
            /*
             加入来源判断，如果为NULL则跳转到其它页面，debug=1则不跳转调试使用 skey edit 2017-09-07
             */

            int aid = int.Parse(adid);
            int aduserid = 0;
            var info = DN.WeiAd.Business.AdPageInfoBLL.Instance.GetSingle(new DN.WeiAd.Models.AdPageInfoPara() { Id = aid });

            DN.WeiAd.Models.LogBrowseVO log = new DN.WeiAd.Models.LogBrowseVO();

            if (info != null)
            {
                ViewBag.Title = info.Title;
                ViewBag.Content = info.Content;
                ViewBag.StaticContent = "<span></span>";
                if (!string.IsNullOrEmpty(info.StaticContent))
                {
                    ViewBag.StaticContent = info.StaticContent;
                }
                ViewBag.UserCode = "<span></span>";
                if (!string.IsNullOrEmpty(info.UserCode))
                {
                    ViewBag.UserCode = info.UserCode;
                }
                aduserid = info.UserId;
                log.Money = info.Money;
                ViewBag.QcodeImg = info.QcodeImg;
                ViewBag.QcodeImg2 = info.QcodeImg2;
            }

            log.BrowseType = DN.Framework.Utility.ClientHelper.GetUserAgent();
            log.ClientIp = DN.Framework.Utility.ClientHelper.ClientIP();
            log.CreateDate = DateTime.Now;
            log.AdUrl = Request.Url.ToString();
            log.IsMoney = 0;
            log.AdId = aid;
            log.AdUserId = aduserid;
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

                if (!string.IsNullOrEmpty(log.Isp))
                {
                    if (log.Isp.IndexOf("腾讯") != -1)
                    {
                        ViewBag.Content = "";
                        ViewBag.Title = "";
                    }
                }

                if (DN.WeiAd.Business.Config.AppConfig.IsIpArea == 1)
                {
                    var clist = DN.WeiAd.Business.Config.AppConfig.IpAreas;

                    foreach (var item in clist)
                    {
                        if (log.City.IndexOf(item) != 0)
                        {
                            ViewBag.Content = "";
                            ViewBag.Title = "";
                        }
                    }
                }
            }

            if (!string.IsNullOrEmpty(newid))
            {
                var ainfo = ArticleInfoBLL.Instance.GetSingle(new ArticleInfoPara() { Id = int.Parse(newid) });
                if (ainfo != null)
                {
                    ViewBag.ArticleTitle = ainfo.Title;
                    ViewBag.ArticleContent = ainfo.Content;

                    if (string.IsNullOrEmpty(ViewBag.Title))
                    {
                        ViewBag.Title = ainfo.Title;
                    }
                }
            }

            DN.WeiAd.Business.LogBrowseBLL.Instance.Add(log);

            if (string.IsNullOrEmpty(log.ReferrerUrl))
            {
                string debug = Request.Params["debug"] ?? "";

                if (debug != "1")
                {
                    Response.Redirect("http://www.qq.com");
                }
            }
        }


        /// <summary>
        /// 公共方法
        /// </summary>
        /// <param name="adid"></param>
        /// <param name="newid"></param>
        /// <param name="qcode">二维码</param>
        public void CommonViewQcode(string adid, string newid, string qcode)
        {
            /*
             加入来源判断，如果为NULL则跳转到其它页面，debug=1则不跳转调试使用 skey edit 2017-09-07
             */

            int aid = int.Parse(adid);
            int aduserid = 0;
            var info = DN.WeiAd.Business.AdPageInfoBLL.Instance.GetSingle(new DN.WeiAd.Models.AdPageInfoPara() { Id = aid });

            DN.WeiAd.Models.LogBrowseVO log = new DN.WeiAd.Models.LogBrowseVO();

            if (info != null)
            {
                ViewBag.Title = info.Title;
                ViewBag.Content = info.Content;
                ViewBag.StaticContent = "<span></span>";
                if (!string.IsNullOrEmpty(info.StaticContent))
                {
                    ViewBag.StaticContent = info.StaticContent;
                }
                ViewBag.UserCode = "<span></span>";
                if (!string.IsNullOrEmpty(info.UserCode))
                {
                    ViewBag.UserCode = info.UserCode;
                }
                aduserid = info.UserId;
                log.Money = info.Money;
                ViewBag.QcodeImg = info.QcodeImg;
                ViewBag.QcodeImg2 = info.QcodeImg2;
            }

            log.BrowseType = DN.Framework.Utility.ClientHelper.GetUserAgent();
            log.ClientIp = DN.Framework.Utility.ClientHelper.ClientIP();
            log.CreateDate = DateTime.Now;
            log.AdUrl = Request.Url.ToString();
            log.IsMoney = 0;
            log.AdId = aid;
            log.AdUserId = aduserid;
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

                if (!string.IsNullOrEmpty(log.Isp))
                {
                    if (log.Isp.IndexOf("腾讯") != -1)
                    {
                        ViewBag.Content = "";
                        ViewBag.Title = "";
                    }
                }
            }

            if (!string.IsNullOrEmpty(newid))
            {
                var ainfo = ArticleInfoBLL.Instance.GetSingle(new ArticleInfoPara() { Id = int.Parse(newid) });
                if (ainfo != null)
                {
                    ViewBag.ArticleTitle = ainfo.Title;
                    ViewBag.ArticleContent = ainfo.Content;

                    if (string.IsNullOrEmpty(ViewBag.Title))
                    {
                        ViewBag.Title = ainfo.Title;
                    }
                }
            }

            if (!string.IsNullOrEmpty(qcode))
            {
                var adqcode = AdQcodeInfoBLL.Instance.GetSingle(new AdQcodeInfoPara() { Id = int.Parse(qcode) });
                if (adqcode != null)
                {

                }
            }

            DN.WeiAd.Business.LogBrowseBLL.Instance.Add(log);

            //if(string.IsNullOrEmpty(log.ReferrerUrl))
            //{
            //    string debug = Request.Params["debug"] ?? "";

            //    if (debug != "1")
            //    {
            //        Response.Redirect("http://www.qq.com");
            //    }
            //}
        }

        /// <summary>
        /// 转码方式
        /// </summary>
        /// <param name="adid"></param>
        /// <param name="newid"></param>
        public void CommonViewEncode(string adid, string newid)
        {
            /*
             加入来源判断，如果为NULL则跳转到其它页面，debug=1则不跳转调试使用 skey edit 2017-10-18
             */

            int aid = int.Parse(adid);
            int aduserid = 0;
            var info = DN.WeiAd.Business.AdPageInfoBLL.Instance.GetSingle(new DN.WeiAd.Models.AdPageInfoPara() { Id = aid });

            DN.WeiAd.Models.LogBrowseVO log = new DN.WeiAd.Models.LogBrowseVO();

            if (info != null)
            {
                ViewBag.Title = info.Title;
                string html = DN.Framework.Utility.HtmlHelper.DecodeHtml(info.Content);

                string content = DN.Framework.Utility.HtmlHelper.NoHTML(html);

                for (int i = 0; i < content.Length; i++)
                {
                    string str = string.Concat(content[i]);
                    if (DN.Framework.Utility.ValidateHelper.CheckStringChinese(str))
                    {
                        html = html.Replace(str, DN.Framework.Utility.HtmlHelper.String2Unicode(str));
                    }
                }
                ViewBag.Content = html;

                ViewBag.StaticContent = "<span></span>";
                if (!string.IsNullOrEmpty(info.StaticContent))
                {
                    ViewBag.StaticContent = info.StaticContent;
                }
                ViewBag.UserCode = "<span></span>";
                if (!string.IsNullOrEmpty(info.UserCode))
                {
                    ViewBag.UserCode = info.UserCode;
                }
                aduserid = info.UserId;
                log.Money = info.Money;
                ViewBag.QcodeImg = info.QcodeImg;
                ViewBag.QcodeImg2 = info.QcodeImg2;
            }

            log.BrowseType = DN.Framework.Utility.ClientHelper.GetUserAgent();
            log.ClientIp = DN.Framework.Utility.ClientHelper.ClientIP();
            log.CreateDate = DateTime.Now;
            log.AdUrl = Request.Url.ToString();
            log.IsMoney = 0;
            log.AdId = aid;
            log.AdUserId = aduserid;
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

                if (!string.IsNullOrEmpty(log.Isp))
                {
                    if (log.Isp.IndexOf("腾讯") != -1)
                    {
                        ViewBag.Content = "";
                        ViewBag.Title = "";
                    }
                }
            }

            if (!string.IsNullOrEmpty(newid))
            {
                var ainfo = ArticleInfoBLL.Instance.GetSingle(new ArticleInfoPara() { Id = int.Parse(newid) });
                if (ainfo != null)
                {
                    ViewBag.ArticleTitle = ainfo.Title;
                    ViewBag.ArticleContent = ainfo.Content;

                    if (string.IsNullOrEmpty(ViewBag.Title))
                    {
                        ViewBag.Title = ainfo.Title;
                    }
                }
            }

            DN.WeiAd.Business.LogBrowseBLL.Instance.Add(log);

            //if(string.IsNullOrEmpty(log.ReferrerUrl))
            //{
            //    string debug = Request.Params["debug"] ?? "";

            //    if (debug != "1")
            //    {
            //        Response.Redirect("http://www.qq.com");
            //    }
            //}
        }

    }
}