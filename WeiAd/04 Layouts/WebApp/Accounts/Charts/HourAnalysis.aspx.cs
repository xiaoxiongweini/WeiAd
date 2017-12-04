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

namespace WebApp.Accounts.Charts
{
    public partial class HourAnalysis : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ltStime.Text = DateTime.Now.ToString("yyyy-MM-dd");
                hidAdId.Value = Request.Params["adid"] ?? "";

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
            ddlAdPage.Items.Insert(0, new ListItem() { Text = "不限", Value = "" });
            if (string.IsNullOrEmpty(hidAdId.Value))
            {
                ddlAdPage.SelectedValue = hidAdId.Value;
                plSearch.Visible = false;            
            }
        }

        private void Bind()
        {
            FlowInfo flow = new FlowInfo();
            flow.AdUserID = Account.UserId;
            flow.Time = DateTime.Now;
            if (!string.IsNullOrEmpty(ddlAdPage.SelectedValue))
            {
                flow.AdId = int.Parse(ddlAdPage.SelectedValue);
                ltAdTitle.Text = ddlAdPage.SelectedItem.Text;
            }

            DataTable table = AnalysisFlowBLL.Instance.GetPageAnalysis(flow);
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