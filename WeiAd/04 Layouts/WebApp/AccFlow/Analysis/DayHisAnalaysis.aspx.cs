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

namespace WebApp.AccFlow.Analysis
{
    public partial class DayHisAnalaysis : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtTime.Value = DateTime.Now.ToString("yyyy-MM-dd");
                BindPage();

                Bind();
            }
        }

        private void BindPage()
        {
            var list = AdUserPageBLL.Instance.GetModels(new AdUserPagePara() { FlowUserId = Account.UserId });
            ddlAdPage.Items.Clear();
            foreach (var item in list)
            {
                ListItem li = new ListItem();
                li.Text = AdPageInfoBLL.Instance.GetTitleById(item.AdPageId);
                li.Value = item.AdPageId.ToString();
                ddlAdPage.Items.Add(li);
            }
            ddlAdPage.Items.Insert(0, new ListItem() { Text = "不限", Value = "" });
        }

        private void Bind(int pageIndex = 1)
        {
            QueryGroupInfo query = new QueryGroupInfo();
            query.FlowUserId = Account.UserId;
            query.GroupBy = "time,adid";
            query.Time = DateTime.Parse(txtTime.Value);

            if (!string.IsNullOrEmpty(ddlAdPage.SelectedValue))
            {
                query.AdId = int.Parse(ddlAdPage.SelectedValue);
            }

            var list = AnalysisBLL.Instance.GetAnalysis(query);
            rptTable.DataSource = list;
            rptTable.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Bind();
        }
    }
}