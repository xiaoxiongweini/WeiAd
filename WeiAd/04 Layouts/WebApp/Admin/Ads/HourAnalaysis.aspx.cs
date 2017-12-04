using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DN.WeiAd.Models;
using DN.WeiAd.Business;
using DN.WeiAd.Business.Pages;
using DN.WeiAd.Business.Entity.Analysis;

namespace WebApp.Admin.Ads
{
    public partial class HourAnalaysis : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hidFlowUserId.Value = Request.Params["flowuserid"] ?? "0";
                hidAdId.Value = Request.Params["adid"] ?? "0";

                ltStime.Text = DateTime.Now.ToString("yyyy-MM-dd");
                ltEtime.Text = DateTime.Now.ToString("yyyy-MM-dd");
                BindPage();
                Bind();
            }
        }

        private void BindPage()
        {
        }

        private void Bind()
        {
            FlowInfo flow = new FlowInfo();
            flow.FlowUserId = int.Parse(hidFlowUserId.Value);
            flow.Time = DateTime.Now;
            flow.AdId = int.Parse(hidAdId.Value);

            DataTable table = AnalysisFlowBLL.Instance.GetPageAnalysis(flow);
            if (table.Rows.Count != 0)
            {
                ltIp.Text = table.Rows[0]["ipcount"].ToString();
                ltPv.Text = table.Rows[0]["pvcount"].ToString();
                //ltUserAvg.Text = table.Rows[0]["useravg"].ToString();
                ltUv.Text = table.Rows[0]["uvcount"].ToString();

                ltIp1.Text = table.Rows[0]["ipcount"].ToString();
                ltPv1.Text = table.Rows[0]["pvcount"].ToString();
                //ltUserAvg1.Text = table.Rows[0]["useravg"].ToString();
                ltUv1.Text = table.Rows[0]["uvcount"].ToString();
            }

            DataTable table1 = AnalysisFlowBLL.Instance.GetBrowseHour(flow);

            var chart = AnalysisFlowBLL.Instance.GetAdBrowseHour(table1);
            hidDataJson.Value = DN.Framework.Utility.Serializer.SerializeObject(chart);

            rptTable.DataSource = table1;
            rptTable.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Bind();
        }
    }
}