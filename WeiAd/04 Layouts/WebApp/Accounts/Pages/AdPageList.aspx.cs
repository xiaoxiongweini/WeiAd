using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DN.WeiAd.Models;
using DN.WeiAd.Business;
using DN.WeiAd.Business.Pages;

namespace WebApp.Accounts.Pages
{
    public partial class AdPageList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
                string adid = Request.Params["adid"] ?? "";
                if(!string.IsNullOrEmpty(adid))
                {
                    var adinfo = AdPageInfoBLL.Instance.GetSingle(new AdPageInfoPara() { Id = int.Parse(adid), UserId = Account.UserId });
                    if (adinfo != null)
                    {
                        AdPageInfoBLL.Instance.DeleteAd(adinfo);
                    }
                }
                BindPage();

                Bind();
            }
        }

        private void BindPage()
        {
            //广告分类
            var adtypelist = AdTypeInfoBLL.Instance.GetModels(new AdTypeInfoPara() { UserId = Account.UserId });
            ddlUserAdType.DataSource = adtypelist;
            ddlUserAdType.DataTextField = "Name";
            ddlUserAdType.DataValueField = "Id";
            ddlUserAdType.DataBind();
            ddlUserAdType.Items.Insert(0, new ListItem() { Text = "不限广告分类", Value = "" });

            //投放平台分类
            var sitelist = AdSiteInfoBLL.Instance.GetModels(new AdSiteInfoPara() { UserId = Account.UserId });
            ddlSiteType.DataSource = sitelist;
            ddlSiteType.DataTextField = "Name";
            ddlSiteType.DataValueField = "Id";
            ddlSiteType.DataBind();
            ddlSiteType.Items.Insert(0, new ListItem() { Text = "不限投放平台", Value = "" });

            //ddlAdType.DataSource = AdPageInfoBLL.Instance.GetAdTypes();
            //ddlAdType.DataTextField = "Name";
            //ddlAdType.DataValueField = "Id";
            //ddlAdType.DataBind();

            //ddlAdType.Items.Insert(0, new ListItem() { Text = "不限广告类型", Value = "" });
        }

        private void Bind(int pageIndex = 1)
        {
            AdPageInfoPara cip = new AdPageInfoPara();
            cip.PageIndex = pageIndex - 1;
            cip.PageSize = 10;
            cip.IsDel = 0;
            cip.UserId = Account.UserId;
            cip.OrderBy = " id desc ";
            if(!string.IsNullOrEmpty(ddlUserAdType.SelectedValue))
            {
                cip.UserAdTypeId = int.Parse(ddlUserAdType.SelectedValue);
            }
            if (!string.IsNullOrEmpty(ddlSiteType.SelectedValue))
            {
                cip.SiteTypeId = int.Parse(ddlSiteType.SelectedValue);
            }
            if(!string.IsNullOrEmpty(txtDesc.Value))
            {
                cip.LikeDesc = txtDesc.Value;
            }

            var list = AdPageInfoBLL.Instance.GetModels(ref cip);
            rptTable.DataSource = list;
            rptTable.DataBind();

            apPager.RecordCount = cip.Recount.Value;
        }

        protected void apPager_PageChanged(object sender, EventArgs e)
        {
            Bind(apPager.CurrentPageIndex);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Bind();
        }
    }
}