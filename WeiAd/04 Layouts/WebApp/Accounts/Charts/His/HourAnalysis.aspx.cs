using DN.WeiAd.Business;
using DN.WeiAd.Business.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DN.WeiAd.Models;
using DN.WeiAd.Business.Entity.Analysis;


namespace WebApp.Accounts.Charts.His
{
    public partial class HourAnalysis : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ltStime.Text = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
                ltEtime.Text = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
                txtTime.Value = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
                BindPage();
                Bind();
            }
        }

        private void BindPage()
        {
            var list = AdPageInfoBLL.Instance.GetModels(new AdPageInfoPara() { UserId = Account.UserId });
            foreach (var item in list)
            {
                ListItem li = new ListItem();
                li.Text = item.Title;
                li.Value = item.Id.ToString();
                ddlAdPage.Items.Add(li);
            }
        }

        private void Bind()
        {
            FlowInfo flow = new FlowInfo();
            flow.AdUserID = Account.UserId;
            flow.Time = DateTime.Parse(txtTime.Value);
            if (!string.IsNullOrEmpty(ddlAdPage.SelectedValue))
            {
                flow.AdId = int.Parse(ddlAdPage.SelectedValue);
            }

            ltStime.Text = flow.Time.ToString("yyyy-MM-dd");
            ltEtime.Text = flow.Time.ToString("yyyy-MM-dd");

            DataTable table = AnalysisFlowHisBLL.Instance.GetPageAnalysis(flow);
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

            DataTable table1 = AnalysisFlowHisBLL.Instance.GetBrowseHour(flow);

            var chart = AnalysisFlowBLL.Instance.GetAdBrowseHour(table1, 23);
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