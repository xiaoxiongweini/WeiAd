using DN.WeiAd.Business.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DN.WeiAd.Models;
using DN.WeiAd.Business;

namespace WebApp.Accounts.Order
{
    public partial class CpsUserEdit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindPage();
            }
        }

        private void BindPage()
        {
            AdPageInfoPara adp = new AdPageInfoPara();
            adp.UserId = Account.UserId;

            var adlist = AdPageInfoBLL.Instance.GetModels(adp);

            ddlAd.Items.Clear();
            foreach (var item in adlist)
            {
                ddlAd.Items.Add(new ListItem() { Value = item.Id.ToString(), Text = string.Format("{0}-{1}", item.Id, item.Title) });
            }
            
            var ulist = AccountInfoBLL.Instance.GetModels(new AccountInfoPara() { UserType = 3 });
            ddlCpsUser.DataSource = ulist;
            ddlCpsUser.DataTextField = "UserName";
            ddlCpsUser.DataValueField = "Id";
            ddlCpsUser.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            CpsUserInfoPara cup = new CpsUserInfoPara();
            cup.AdId = int.Parse(ddlAd.SelectedValue);
            cup.CpsUserId = int.Parse(ddlCpsUser.SelectedValue);

            var list = CpsUserInfoBLL.Instance.GetModels(cup);
            if(list.Count == 0)
            {
                CpsUserInfoVO info = new CpsUserInfoVO();
                info.AdId = int.Parse(ddlAd.SelectedValue);
                info.CpsUserId = int.Parse(ddlCpsUser.SelectedValue);
                info.CreateDate = DateTime.Now;
                info.CreateUserId = Account.UserId;
                CpsUserInfoBLL.Instance.Add(info);
                Response.Redirect("/Accounts/Order/CpsUserConfigList.aspx");
            }else
            {
                lblMsg.Text = "该用户己配置相关广告。";
            }
        }
    }
}