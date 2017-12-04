using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DN.WeiAd.Models;
using DN.WeiAd.Business;
using DN.WeiAd.Business.Entity.Analysis;
using DN.WeiAd.Business.Pages;
using System.Data;

namespace WebApp.AccAnalysis
{
    public partial class Index : BasePage
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
            QueryGroupInfo query = new QueryGroupInfo();
            query.Time = DateTime.Now;
            query.GroupBy = "time,AdId ";
            query.OrderBy = " time desc ";
            query.AdUserID = Account.UserId;

            DataTable table = LogBrowseAnalysisBLL.Instance.GetAnalysis(query);
            rptTable.DataSource = table;
            rptTable.DataBind();
        }
    }
}