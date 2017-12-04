using DN.WeiAd.Business;
using DN.WeiAd.Business.Entity.Analysis;
using DN.WeiAd.Business.Pages;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.Accounts.LogBrowse
{
    public partial class AdSummaryList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
            }
        }
        private void Bind()
        {
            QueryGroupInfo query = new QueryGroupInfo();
            query.TimeStart = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-01"));
            query.AdUserID = Account.UserId;
            query.GroupBy = "AdId";
            query.OrderBy = " AdId desc ";

            DataTable table = LogBrowseAnalysisBLL.Instance.GetAnalysis(query);
            rptTable.DataSource = table;
            rptTable.DataBind();
        }
    }
}