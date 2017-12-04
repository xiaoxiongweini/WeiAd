using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DN.WeiAd.Models;
using DN.WeiAd.Business;
using DN.WeiAd.Business.Pages;
using DN.WeiAd.Business.Entity.Analysis;
using System.Data;

namespace WebApp.AccAnalysis
{
    public partial class AdSummerList : BasePage
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
            query.GroupBy = "AdId";
            query.OrderBy = " AdId desc ";
            query.AdUserID = Account.UserId;

            DataTable table = LogBrowseAnalysisBLL.Instance.GetAnalysis(query);

            VirAdBrowsePara adp = new VirAdBrowsePara();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                int AdId = int.Parse(table.Rows[i]["AdId"].ToString());
                int ipcount = int.Parse(table.Rows[i]["ipcount"].ToString());
                adp.AdId = AdId;

                var list = VirAdBrowseBLL.Instance.GetModels(adp);
                foreach (var item in list)
                {
                    ipcount += item.IpCount;
                }

                table.Rows[i]["ipcount"] = ipcount;
            }

            rptTable.DataSource = table;
            rptTable.DataBind();
        }

    }
}