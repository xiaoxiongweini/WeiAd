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

namespace WebApp.Admin.Analysis
{
    public partial class FlowUserAnalysis : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtTime.Value = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");

                string time = Request.Params["time"] ?? "";
                hidAdId.Value = Request.Params["adid"] ?? "";

                if(!string.IsNullOrEmpty(time))
                {
                    txtTime.Value = time.Insert(4, "-").Insert(7, "-");
                }

                BindPage();
                Bind();
            }
        }

        private void BindPage()
        {
            var list = AdPageInfoBLL.Instance.GetModels(new AdPageInfoPara());
            ddlAdPage.Items.Clear();
            foreach (var item in list)
            {
                ListItem li = new ListItem();
                li.Text = item.Title;
                li.Value = item.Id.ToString();
                ddlAdPage.Items.Add(li);
            }
            ddlAdPage.Items.Insert(0, new ListItem() { Text = "不限", Value = "" });

            if (!string.IsNullOrEmpty(hidAdId.Value))
            {
                plSearch.Visible = false;
                ddlAdPage.SelectedValue = hidAdId.Value;
            }
        }

        private void Bind()
        {
            FlowInfo flow = new FlowInfo();
            //flow.UserId = Account.UserId;
            flow.Time = DateTime.Parse(txtTime.Value);
            
            if (!string.IsNullOrEmpty(ddlAdPage.SelectedValue))
            {
                flow.AdId = int.Parse(ddlAdPage.SelectedValue);
            }

            ltStime.Text = flow.Time.ToString("yyyy-MM-dd");
            ltAdTitle.Text = ddlAdPage.SelectedItem.Text;

            DataTable table = AnalysisFlowBLL.Instance.GetPageAnalysis(flow);
            if (table.Rows.Count != 0)
            {
                ltIp.Text = table.Rows[0]["ipcount"].ToString();
                ltPv.Text = table.Rows[0]["pvcount"].ToString();
                ltUserAvg.Text = table.Rows[0]["useravg"].ToString();
                ltUv.Text = table.Rows[0]["uvcount"].ToString();
            }

            DataTable table1 = AnalysisAdBLL.Instance.GetAdFlowDetail(flow);

            rptTable.DataSource = table1;
            rptTable.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Bind();
        }
    }
}