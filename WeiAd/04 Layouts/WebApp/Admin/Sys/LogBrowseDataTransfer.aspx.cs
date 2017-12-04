using DN.WeiAd.Business.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DN.WeiAd.Models;
using DN.WeiAd.Business;

namespace WebApp.Admin.Sys
{
    public partial class LogBrowseDataTransfer : BasePageAdmin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                txtTimeOld.Value = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            }
        }

        protected void btnTransfer_Click(object sender, EventArgs e)
        {
            LogBrowseHistoryBLL.Instance.TransferDay(DateTime.Parse(txtTimeOld.Value));
        }

        protected void btnShowSummer_Click(object sender, EventArgs e)
        {
            HistoryUserLogBrowsePara ubp = new HistoryUserLogBrowsePara();
            ubp.Time = int.Parse(txtTimeOld.Value.Replace("-", ""));

            var list = HistoryUserLogBrowseBLL.Instance.GetModels(ubp);
            rptTables.DataSource = list;
            rptTables.DataBind();
        }
    }
}