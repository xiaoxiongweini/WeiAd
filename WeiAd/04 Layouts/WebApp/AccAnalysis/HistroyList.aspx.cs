using DN.WeiAd.Business.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DN.WeiAd.Models;
using DN.WeiAd.Business;

namespace WebApp.AccAnalysis
{
    public partial class HistroyList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int page = int.Parse(Request.Params["page"] ?? "1");
                Bind(page);
            }
        }

        private void Bind(int pageIndex = 1)
        {
            HistoryUserLogBrowsePara hup = new HistoryUserLogBrowsePara();
            hup.UserId = Account.UserId;
            hup.PageIndex = pageIndex - 1;
            hup.PageSize = 10;

            var list = HistoryUserLogBrowseBLL.Instance.GetModels(ref hup);
            rptTable.DataSource = list;
            rptTable.DataBind();

            apPager.RecordCount = hup.Recount.Value;
        }
    }
}