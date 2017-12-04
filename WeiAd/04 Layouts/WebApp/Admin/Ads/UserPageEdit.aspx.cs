using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DN.WeiAd.Business.Pages;
using DN.WeiAd.Business;
using DN.WeiAd.Models;

namespace WebApp.Admin.Ads
{
    public partial class UserPageEdit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hidId.Value = Request.Params["adid"] ?? "";
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

            var ulist = AccountInfoBLL.Instance.GetModels(new AccountInfoPara() { UserType = 1 });
            ddlFlow.DataSource = ulist;
            ddlFlow.DataTextField = "NickName";
            ddlFlow.DataValueField = "Id";
            ddlFlow.DataBind();

            AdUserPagePara aup = new AdUserPagePara();
            aup.AdPageId = int.Parse(hidId.Value);
            aup.FlowUserId = Account.UserId;

            var list = AdUserPageBLL.Instance.GetModels(aup);
            if (list.Count == 0)
            {
                txtPageName.Value = AdPageInfoBLL.Instance.GetPageName();
            }
            else
            {
                txtPageName.Value = list[0].PageName;
            }

            var info = AdPageInfoBLL.Instance.GetModelById(aup.AdPageId.Value);
            if (info != null)
            {
                lnkPrview.NavigateUrl = string.Format("/Ad/{0}.aspx", info.ViewPage);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            AdUserPagePara aup = new AdUserPagePara();
            aup.AdPageId = int.Parse(hidId.Value);
            aup.FlowUserId = int.Parse(ddlFlow.SelectedValue);

            var list = AdUserPageBLL.Instance.GetModels(aup);
            if (list.Count == 0)
            {
                var adpage = AdPageInfoBLL.Instance.GetSingle(new AdPageInfoPara() { Id = aup.AdPageId.Value });
                if (adpage != null)
                {
                    AdUserPageVO info = new AdUserPageVO();
                    info.AdPageId = int.Parse(hidId.Value);
                    info.CreateDate = DateTime.Now;
                    info.CreateUserId = Account.UserId;
                    info.PageName = txtPageName.Value;
                    info.AdUserId = adpage.UserId;
                    info.FlowLastDate = DateTime.Now;
                    info.FlowUserId = int.Parse(ddlFlow.SelectedValue);
                    info.Gid = Guid.NewGuid().ToString();

                    var plist = AdUserPageBLL.Instance.GetModels(new AdUserPagePara() { PageName = info.PageName });
                    if (plist.Count == 0)
                    {
                        if (AdPageInfoBLL.Instance.CreateAdPage(info.PageName,ddlTemplate.SelectedValue,adpage.Id))
                        {
                            AdUserPageBLL.Instance.Add(info);
                            lblMsg.Text = "分配成功。";
                        }
                        else
                        {
                            lblMsg.Text = "分配成功失败，再试一试。";
                        }
                    }
                    else
                    {
                        lblMsg.Text = "该页面己经存在，重新添加任务一次。";
                    }
                }
                else
                {
                    lblMsg.Text = "该广告己经不存，无法领取任务。";
                }
            }
            else
            {
                lblMsg.Text = "该工作室中己存在该广告";
            }
        }
    }
}