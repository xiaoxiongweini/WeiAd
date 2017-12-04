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

namespace WebApp.Accounts.Ads
{
    public partial class AdEdit : BasePage
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
            //var clist = AdPageInfoBLL.Instance.GetAdTypes();
            //ddlAdType.DataSource = clist;
            //ddlAdType.DataTextField = "Name";
            //ddlAdType.DataValueField = "Id";
            //ddlAdType.DataBind();

            if (!string.IsNullOrEmpty(hidId.Value))
            {
                var info = AdPageInfoBLL.Instance.GetSingle(new AdPageInfoPara() { Id = int.Parse(hidId.Value), UserId = Account.UserId });
                if (info != null)
                {
                    txtTitle.Value = info.Title;

                    //ddlAdType.SelectedValue = info.AdType.ToString();
                    //txtLinkUrl.Value = info.LinkUrl;
                    //chkIsShow.Checked = info.IsShow == 1 ? true : false;
                    //txtDesc.Value = info.Desc;
                    //txtClickMoney.Value = info.ClickMoney.ToString();
                    //txtLinkUrlBak.Value = info.LinkUrlBak;
                    
                    btnEdit.Visible = true;
                }
            }
            btnSave.Visible = !btnEdit.Visible;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            AdPageInfoVO info = new AdPageInfoVO();
            info.AdType = int.Parse(ddlAdType.SelectedValue);
            info.Title = txtTitle.Value;
            //info.LinkUrl = txtLinkUrl.Value;
            //info.DateEnd = DateTime.Now;
            //info.DateStart = DateTime.Now;
            //info.IsShow = chkIsShow.Checked ? 1 : 0;
            info.UserId = Account.UserId;
            //info.Desc = txtDesc.Value;
            //info.ClickMoney = decimal.Parse(txtClickMoney.Value);
            //info.LinkUrlBak = txtLinkUrlBak.Value;

            AdPageInfoBLL.Instance.Add(info);
            Response.Redirect("/Accounts/Ads/AdList.aspx");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            var info = AdPageInfoBLL.Instance.GetSingle(new AdPageInfoPara() { Id = int.Parse(hidId.Value) });
            if (info != null)
            {
                info.AdType = int.Parse(ddlAdType.SelectedValue);
                info.Title = txtTitle.Value;
                //info.LinkUrl = txtLinkUrl.Value;
                //info.IsShow = chkIsShow.Checked ? 1 : 0;
                info.UserId = Account.UserId;
                //info.Desc = txtDesc.Value;
                //info.ClickMoney = decimal.Parse(txtClickMoney.Value);
                //info.LinkUrlBak = txtLinkUrlBak.Value;


                AdPageInfoBLL.Instance.Edit(info);
                Response.Redirect("/Accounts/Ads/AdList.aspx");
            }
        }
    }
}