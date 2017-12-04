using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using DN.WeiAd.Models;
using DN.WeiAd.Business;
using System.Web;

namespace DN.WeiAd.Business.Pages
{
    /// <summary>
    /// 广告页
    /// </summary>
    public class AdBasePage : System.Web.UI.Page
    {
        #region 公共控件

        /// <summary>
        /// ltPageTitle 控件。
        /// </summary>
        /// <remarks>
        /// 自动生成的字段。
        /// 若要进行修改，请将字段声明从设计器文件移到代码隐藏文件。
        /// </remarks>
        protected global::System.Web.UI.WebControls.Literal ltPageTitle;

        /// <summary>
        /// form1 控件。
        /// </summary>
        /// <remarks>
        /// 自动生成的字段。
        /// 若要进行修改，请将字段声明从设计器文件移到代码隐藏文件。
        /// </remarks>
        protected global::System.Web.UI.HtmlControls.HtmlForm form1;

        /// <summary>
        /// ltTitle 控件。
        /// </summary>
        /// <remarks>
        /// 自动生成的字段。
        /// 若要进行修改，请将字段声明从设计器文件移到代码隐藏文件。
        /// </remarks>
        protected global::System.Web.UI.WebControls.Literal ltTitle;

        /// <summary>
        /// ltContent 控件。
        /// </summary>
        /// <remarks>
        /// 自动生成的字段。
        /// 若要进行修改，请将字段声明从设计器文件移到代码隐藏文件。
        /// </remarks>
        protected global::System.Web.UI.WebControls.Literal ltContent;

        /// <summary>
        /// ltUserCode 控件。
        /// </summary>
        /// <remarks>
        /// 自动生成的字段。
        /// 若要进行修改，请将字段声明从设计器文件移到代码隐藏文件。
        /// </remarks>
        protected global::System.Web.UI.WebControls.Literal ltUserCode;

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            BindPage();
        }

        private void BindPage()
        {
            string filepath = Path.GetFileName(Request.FilePath);
            string fileExt = Path.GetExtension(filepath);

            string PageName = filepath;
            int last = PageName.IndexOf("?");
            if (last != -1)
            {
                PageName = PageName.Substring(0, last);
            }

            //访问日志
            AdBrowseVO log = new AdBrowseVO();

            try
            {
                var userpage = AdUserPageBLL.Instance.GetModelByPageName(PageName);

                log.BrowseType = DN.Framework.Utility.ClientHelper.GetBrowseInfo();
                log.ClientIp = DN.Framework.Utility.ClientHelper.ClientIP();
                log.CreateDate = DateTime.Now;
                log.AdUrl = Request.Url.ToString();
                log.IsMoney = 0;
                log.Money = 0;
                log.Time = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
                log.ClientId = GetClentId();
                log.IsMobile = DN.Framework.Utility.ClientHelper.GetIsMobileDevice() ? 1 : 0;
                log.ReferrerUrl = DN.Framework.Utility.ClientHelper.GetReferer();
                log.OsName = DN.Framework.Utility.ClientHelper.GetOsName();
                log.BrowseName = DN.Framework.Utility.ClientHelper.GetBrowseName();
                log.BrowseVersion = DN.Framework.Utility.ClientHelper.GetBrowseVersion();

                if (userpage != null)
                {
                    var info = AdPageInfoBLL.Instance.GetModelById(userpage.AdPageId);

                    ltPageTitle.Text = info.Title;
                    ltTitle.Text = info.Title;
                    ltContent.Text = GetContent(info);

                    var usercode = UserCodeInfoBLL.Instance.GetModelById(info.UserCodeId);
                    if (usercode != null)
                    {
                        ltUserCode.Text = DN.Framework.Utility.HtmlHelper.DecodeHtml(usercode.CodeContent);
                    }
                    if (userpage != null)
                    {
                        log.FlowUserId = userpage.FlowUserId;
                    }
                    log.Url = AdPageInfoBLL.Instance.GetAdViewUrl(info.ViewPage);
                    log.AdUserId = info.UserId;
                    log.AdId = info.Id;
                    //检查是否计费，如果为0则计费，否则不计费
                    //log.IsMoney = AdBrowseBLL.Instance.GetRecords(new AdBrowsePara() { ClientIp = log.ClientIp, AdId = log.AdId });
                    //if (log.IsMoney == 0)
                    //{
                    //    //log.Money = adinfo.ClickMoney;
                    //}

                    ////扣费信息
                    //if (log.IsMoney == 0)
                    //{
                    //    var account = AccountInfoBLL.Instance.GetSingle(new AccountInfoPara() { Id = adinfo.UserId });
                    //    if (account != null)
                    //    {
                    //        account.Money = account.Money - log.Money;
                    //        account.ConsumptionMoney = account.ConsumptionMoney + log.Money;
                    //        account.LastMoneyDate = DateTime.Now;
                    //        AccountInfoBLL.Instance.Edit(account);
                    //    }
                    //}
                }
                else
                {
                    var info = AdPageInfoBLL.Instance.GetModelByViewPage(PageName);

                    ltPageTitle.Text = info.Title;
                    ltTitle.Text = info.Title;
                    ltContent.Text = GetContent(info);
                    ltUserCode.Text = DN.Framework.Utility.HtmlHelper.DecodeHtml(info.UserCode);

                    log.Url = AdPageInfoBLL.Instance.GetAdViewUrl(info.ViewPage);
                    log.AdUserId = info.UserId;
                    log.AdId = info.Id;
                }

                if (Config.AppConfig.IsLogBrowse == 0)
                {
                    AdBrowseBLL.Instance.Add(log);
                }
                else
                {
                    ErrorBLL.Add<AdBrowseVO>(log);
                }
            }
            catch (Exception ex)
            {
                ErrorBLL.Add<AdBrowseVO>(ex, log);

                DN.Framework.Utility.LogHelper.Write(ex.Message, "erroradv0");
            }
        }

        private string GetContent(AdPageInfoVO info)
        {
            string html = DN.Framework.Utility.HtmlHelper.DecodeHtml(info.Content);

            if (!string.IsNullOrEmpty(info.QcodeImg))
            {
                var qcode = AdQcodeInfoBLL.Instance.GetRandQcode(info.Id);
                string url = string.Empty;
                if (qcode != null)
                {
                    url = qcode.QcodeUrl;
                }
                if (!string.IsNullOrEmpty(url))
                {
                    var list = info.QcodeImg.Split(',');
                    foreach (var item in list)
                    {
                        if(!string.IsNullOrEmpty(item))
                        {
                            html = html.Replace(item, url);
                        }
                    }                    
                }
            }

            return html;
        }

        private string GetClentId()
        {
            string client = string.Empty;
            HttpCookie cookie = Request.Cookies.Get("_adclientid");
            if(cookie == null)
            {
                client =  Guid.NewGuid().ToString();
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
