using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DN.WeiAd.Models;
using DN.WeiAd.Business;
using DN.WeiAd.Business.Pages;

namespace WebApp.Accounts.Ads
{
    public partial class LogListDay : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
            }
        }

        private void Bind(int pageIndex = 1)
        {
            AdBrowsePara cip = new AdBrowsePara();
            cip.PageIndex = pageIndex - 1;
            cip.PageSize = 10;
            cip.OrderBy = " id desc ";
            cip.AdUserId = Account.UserId;

            var list = AdBrowseBLL.Instance.GetModels(ref cip);
            rptTable.DataSource = list;
            rptTable.DataBind();

            apPager.RecordCount = cip.Recount.Value;
        }

        protected void apPager_PageChanged(object sender, EventArgs e)
        {
            Bind(apPager.CurrentPageIndex);
        }

    }
}