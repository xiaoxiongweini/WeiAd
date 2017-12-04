using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DN.WeiAd.Models;
using DN.WeiAd.Business;
using DN.WeiAd.Business.Pages;
using DN.Framework.Utility;


namespace WebApp.Accounts.Sys
{
    public partial class SiteEdit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hidId.Value = Request.Params["id"] ?? "";

                BindPage();
            }
        }

        private void BindPage()
        {
            if (!string.IsNullOrEmpty(hidId.Value))
            {
                var info = AdSiteInfoBLL.Instance.GetSingle(new AdSiteInfoPara() { Id = int.Parse(hidId.Value), UserId = Account.UserId });
                if (info != null)
                {
                    txtName.Value = info.Name;
                    txtDesc.Text = info.Desc;
                    txtWebSite.Text = info.WebSite;
                    btnEdit.Visible = true;
                }
            }
            btnSave.Visible = !btnEdit.Visible;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            AdSiteInfoVO info = new AdSiteInfoVO();
            info.Name = txtName.Value;
            info.UserId = Account.UserId;
            info.Contact = "";
            info.CreateDate = DateTime.Now;
            info.Desc = txtDesc.Text;
            info.LastDate = DateTime.Now;
            info.PlatformType = "";
            info.WebSite = txtWebSite.Text;

            AdSiteInfoBLL.Instance.Add(info);
            Response.Redirect("/Accounts/Sys/SiteList.aspx");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            var info = AdSiteInfoBLL.Instance.GetSingle(new AdSiteInfoPara() { Id = int.Parse(hidId.Value), UserId = Account.UserId });
            if (info != null)
            {
                info.Name = txtName.Value;
                info.UserId = Account.UserId;
                info.Contact = "";
                info.Desc = txtDesc.Text;
                info.LastDate = DateTime.Now;
                info.PlatformType = "";
                info.WebSite = txtWebSite.Text;

                AdSiteInfoBLL.Instance.Edit(info);
                Response.Redirect("/Accounts/Sys/SiteList.aspx");
            }
        }
    }
}