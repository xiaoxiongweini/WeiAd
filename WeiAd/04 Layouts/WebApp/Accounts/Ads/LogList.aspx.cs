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
    public partial class LogList : BasePage
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
            AdBrowseHistoryPara cip = new AdBrowseHistoryPara();
            cip.PageIndex = pageIndex - 1;
            cip.PageSize = 10;
            cip.OrderBy = " id desc ";
            cip.AdUserId = Account.UserId;

            var list = AdBrowseHistoryBLL.Instance.GetModels(ref cip);
            rptTable.DataSource = list;
            rptTable.DataBind();

            apPager.RecordCount = cip.Recount.Value;
        }

        protected void apPager_PageChanged(object sender, EventArgs e)
        {
            Bind(apPager.CurrentPageIndex);
        }
        protected void btnAddHistory_Click(object sender, EventArgs e)
        {
            AdBrowseBLL.Instance.Synchronization();
        }
    }
}