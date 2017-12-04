using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DN.WeiAd.Models;
using DN.WeiAd.Business;
using DN.WeiAd.Business.Pages;
using System.Data;

namespace WebApp.Accounts.Charts
{
    public partial class PageAnalysis : BasePage
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
            DataTable table = AnalysisAdBLL.Instance.GetPageAnalysis(Account.UserId, DateTime.Now);
            if (table.Rows.Count != 0)
            {
                ltIp.Text = table.Rows[0]["ipcount"].ToString();
                ltPv.Text = table.Rows[0]["pvcount"].ToString();
                ltUserAvg.Text = table.Rows[0]["useravg"].ToString();
                ltUv.Text = table.Rows[0]["uvcount"].ToString();

                ltIp1.Text = table.Rows[0]["ipcount"].ToString();
                ltPv1.Text = table.Rows[0]["pvcount"].ToString();
                ltUserAvg1.Text = table.Rows[0]["useravg"].ToString();
                ltUv1.Text = table.Rows[0]["uvcount"].ToString();
            }

            DataTable table1 = AnalysisAdBLL.Instance.GetPagesAnalysis(Account.UserId, DateTime.Now);
            rptTable.DataSource = table1;
            rptTable.DataBind();
        }
    }
}