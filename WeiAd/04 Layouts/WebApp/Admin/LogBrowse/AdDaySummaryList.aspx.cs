using DN.WeiAd.Business.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DN.WeiAd.Business.Entity.Analysis;
using DN.WeiAd.Business;

namespace WebApp.Admin.LogBrowse
{
    public partial class AdDaySummaryList : BasePage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hidAdId.Value = Request.Params["adid"] ?? "0";
                Bind();
            }
        }
        private void Bind()
        {
            QueryGroupInfo query = new QueryGroupInfo();
            query.AdId = int.Parse(hidAdId.Value);
            query.GroupBy = "Time,AdId";
            query.OrderBy = "Time desc, AdId desc ";

            DataTable table = LogBrowseAnalysisBLL.Instance.GetAnalysis(query);
            rptTable.DataSource = table;
            rptTable.DataBind();
        }
    }
}