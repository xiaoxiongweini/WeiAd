using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DN.WeiAd.Business;
using DN.WeiAd.Business.Entity.Analysis;
using DN.WeiAd.Business.Pages;
using DN.WeiAd.Models;
using System.Data;

namespace WebApp.Accounts.Charts.His
{
    public partial class AdFlowDetail : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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

            DataTable table1 = AnalysisAdHisBLL.Instance.GetAdFlowDetail(flow);
            rptTable.DataSource = table1;
            rptTable.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Bind();
        }
    }
}