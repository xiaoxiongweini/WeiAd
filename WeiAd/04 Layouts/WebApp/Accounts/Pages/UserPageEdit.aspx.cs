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
    public partial class UserPageEdit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hidId.Value = Request.Params["adid"] ?? "0";
                BindPage();
            }
        }

        private void BindPage()
        {
            var tlist = AdPageInfoBLL.Instance.GetTemplateSett();
            ddlTemplate.Items.Clear();
            foreach (var item in tlist)
            {
                ddlTemplate.Items.Add(item);
            }

            var info = AdPageInfoBLL.Instance.GetSingle(new AdPageInfoPara() { Id = int.Parse(hidId.Value), UserId = Account.UserId });
            if (info != null)
            {
                ltAdTitle.Text = info.Title;
                ddlTemplate.SelectedValue = info.TemplateName;      
            }
            if(string.IsNullOrEmpty(txtPageName.Value))
            {
                txtPageName.Value = AdPageInfoBLL.Instance.GetPageName();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            AdUserPagePara aup = new AdUserPagePara();
            aup.PageName = txtPageName.Value;

            var list = AdUserPageBLL.Instance.GetModels(aup);
            if (list.Count == 0)
            {
                AdUserPageVO info = new AdUserPageVO();
                info.AdPageId = int.Parse(hidId.Value);
                info.CreateDate = DateTime.Now;
                info.CreateUserId = Account.UserId;
                info.PageName = txtPageName.Value;
                info.FlowLastDate = DateTime.Now;
                info.AdUserId = Account.UserId;
                info.Gid = Guid.NewGuid().ToString();
                if (AdPageInfoBLL.Instance.CreateAdPage(info.PageName,ddlTemplate.SelectedValue,int.Parse(hidId.Value)))
                {
                    AdUserPageBLL.Instance.Add(info);

                    var adinfo = AdPageInfoBLL.Instance.GetSingle(new AdPageInfoPara() { Id = info.AdPageId });
                    if (adinfo != null)
                    {
                        adinfo.PageCount = AdUserPageBLL.Instance.GetRecords(new AdUserPagePara() { AdPageId = info.AdPageId });
                        adinfo.LastDate = DateTime.Now;
                        AdPageInfoBLL.Instance.Edit(adinfo);
                    }

                    lblMsg.Text = "页面创建成功。";
                }
                else
                {
                    lblMsg.Text = "创建广告页失败，请联系管理员处理。";
                }
            }
            else
            {
                lblMsg.Text = "该页面己经存在，请重新输入。";
            }
        }
    }
}