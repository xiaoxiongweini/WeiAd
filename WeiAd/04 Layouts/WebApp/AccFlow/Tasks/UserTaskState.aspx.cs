using DN.WeiAd.Business.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DN.WeiAd.Models;
using DN.WeiAd.Business;

namespace WebApp.AccFlow.Tasks
{
    public partial class UserTaskState : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hidUserPageName.Value = Request.Params["pagename"] ?? "";

                BindPage();
            }
        }

        private void BindPage()
        {
            var info = DN.WeiAd.Business.AdUserPageBLL.Instance.GetModelByPageName(hidUserPageName.Value);
            if (info != null)
            {
                lnkPrview.NavigateUrl = DN.WeiAd.Business.AdPageInfoBLL.Instance.GetAdViewUrl(hidUserPageName.Value);
                txtPageName.Value = hidUserPageName.Value;
                chkState.Checked = info.IsState == 0 ? true : false;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var info = DN.WeiAd.Business.AdUserPageBLL.Instance.GetModelByPageName(hidUserPageName.Value);
            if (info != null)
            {
                info.IsState = chkState.Checked ? 0 : 1;
                info.FlowLastDate = DateTime.Now;
                DN.WeiAd.Business.AdUserPageBLL.Instance.Edit(info);
            }
        }
    }
}