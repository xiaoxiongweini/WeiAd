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
    public partial class UserPageList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hidAdId.Value = Request.Params["adid"] ?? "0";
                BindPage();

                Bind();
            }
        }

        private void BindPage()
        {
            AdPageInfoPara ap = new AdPageInfoPara();
            ap.UserId = Account.UserId;
            var list = AdPageInfoBLL.Instance.GetModels(ap);
            ddlAdInfo.DataSource = list;
            ddlAdInfo.DataTextField = "Title";
            ddlAdInfo.DataValueField = "Id";
            ddlAdInfo.DataBind();
            ddlAdInfo.Items.Insert(0, new ListItem() { Text = "不限", Value = "" });
            if(!string.IsNullOrEmpty(hidAdId.Value))
            {
                ddlAdInfo.SelectedValue = hidAdId.Value;
                ddlAdInfo.Enabled = false;
            }
        }

        public string GetUserName(object userid)
        {
            var info = AccountInfoBLL.Instance.GetModelByUserId(userid);
            if (info != null)
            {
                return info.UserName;
            }

            return userid.ToString();
        }

        private void Bind(int pageIndex = 1)
        {
            AdUserPagePara cip = new AdUserPagePara();
            cip.PageIndex = pageIndex - 1;
            cip.PageSize = 10;
            if(!string.IsNullOrEmpty(ddlAdInfo.SelectedValue))
            {
                cip.AdPageId = int.Parse(ddlAdInfo.SelectedValue);
            }
            cip.AdPageId = int.Parse(hidAdId.Value);
            cip.AdUserId = Account.UserId;
            cip.OrderBy = " id desc ";
            
            var list = AdUserPageBLL.Instance.GetModels(ref cip);
            rptTable.DataSource = list;
            rptTable.DataBind();

            apPager.RecordCount = cip.Recount.Value;
            apPager.PageSize = cip.PageSize.Value;
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