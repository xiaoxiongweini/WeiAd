using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DN.WeiAd.Models;
using DN.WeiAd.Business;
using DN.WeiAd.Business.Pages;

namespace WebApp.AccFlow.Tasks
{
    public partial class AddTask : BasePage
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
            

            AdUserPagePara aup = new AdUserPagePara();
            aup.AdPageId = int.Parse(hidId.Value);
            aup.FlowUserId = Account.UserId;

            var list = AdUserPageBLL.Instance.GetModels(aup);
            if(list.Count == 0)
            {
                if (string.IsNullOrEmpty(txtPageName.Value))
                {
                    txtPageName.Value = AdPageInfoBLL.Instance.GetPageName();
                    AdPageInfoBLL.Instance.CreateAdPage(txtPageName.Value, DN.WeiAd.Business.Config.AppConfig.TemplateName);
                }
            }
            else
            {
                txtPageName.Value = list[0].PageName;
            }

            var info = AdPageInfoBLL.Instance.GetModelById(aup.AdPageId.Value);
            if (info != null)
            {
                lnkPrview.NavigateUrl = AdPageInfoBLL.Instance.GetAdViewUrl(txtPageName.Value);
                lnkPrview.Text = lnkPrview.NavigateUrl;
                ltAdTitle.Text = info.Title;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            AdUserPagePara aup = new AdUserPagePara();
            aup.AdPageId = int.Parse(hidId.Value);
            aup.FlowUserId = Account.UserId;

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
                    info.FlowUserId = Account.UserId;
                    info.Gid = Guid.NewGuid().ToString();

                    var plist = AdUserPageBLL.Instance.GetModels(new AdUserPagePara() { PageName = info.PageName });
                    if (plist.Count == 0)
                    {
                        if (AdPageInfoBLL.Instance.CreateAdPage(info.PageName,DN.WeiAd.Business.Config.AppConfig.TemplateName,adpage.Id))
                        {
                            AdUserPageBLL.Instance.Add(info);
                            Response.Redirect("/AccFlow/Tasks/UserTaskList.aspx?state=0");
                            lblMsg.Text = "领取任务成功。";
                        }
                        else
                        {
                            lblMsg.Text = "领取任务失败，再试一试。";
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
                lblMsg.Text = "您己经领取过该任务。";
            }
        }
    }
}