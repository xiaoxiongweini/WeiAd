using DN.WeiAd.Business.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DN.WeiAd.Models;
using DN.WeiAd.Business;

namespace WebApp.Admin.Sys
{
    public partial class CacheList : BasePageAdmin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

            }
        }

        protected void btnQueryCache_Click(object sender, EventArgs e)
        {
            BindPage();
        }

        void BindPage()
        {
            List<CacheItem> list = new List<CacheItem>();

            list.Add(new CacheItem() { NameEn = "ArticleInfoBLL", NameCn = "文章数据", CacheCount = ArticleInfoBLL.Instance.GetCache().Count });
            list.Add(new CacheItem() { NameEn = "AdPageInfoBLL", NameCn = "广告数据", CacheCount = AdPageInfoBLL.Instance.GetCache().Count });
            list.Add(new CacheItem() { NameEn = "AdQcodeInfoBLL", NameCn = "二 维码数据", CacheCount = AdQcodeInfoBLL.Instance.GetCache().Count });
            list.Add(new CacheItem() { NameEn = "AdUserPageBLL", NameCn = "自定义页", CacheCount = AdUserPageBLL.Instance.GetCache().Count });
            list.Add(new CacheItem() { NameEn = "AccountInfoBLL", NameCn = "用户数据", CacheCount = AccountInfoBLL.Instance.GetCache().Count });

            rptTable.DataSource = list;
            rptTable.DataBind();
        }

        protected void btnReface_Click(object sender, EventArgs e)
        {
            AdPageInfoBLL.Instance.Refresh();
            ArticleInfoBLL.Instance.Refresh();
            AdQcodeInfoBLL.Instance.Refresh();
            AdUserPageBLL.Instance.Refresh();
            AccountInfoBLL.Instance.RefreshCache();
        }

        class CacheItem
        {
            public string NameCn { get; set; }
            public string NameEn { get; set; }

            public int CacheCount { get; set; }

            public int DbCount { get; set; }

        }

        protected void btnReaderDbFile_Click(object sender, EventArgs e)
        {
            AdPageInfoBLL.Instance.Refresh();
        }

        protected void btnSaveDbFile_Click(object sender, EventArgs e)
        {
            AdPageInfoBLL.Instance.RefreshSaveDbFile();
        }
    }
}