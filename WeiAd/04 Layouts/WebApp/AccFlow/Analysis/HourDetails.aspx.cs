using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DN.WeiAd.Models;
using DN.WeiAd.Business;
using DN.WeiAd.Business.Pages;

namespace WebApp.AccFlow.Analysis
{
    public partial class HourDetails : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hidAdUserId.Value = Request.Params["aduserid"] ?? "";
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
            AdBrowsePara cip = new AdBrowsePara();
            cip.PageIndex = pageIndex - 1;
            cip.PageSize = 10;
            cip.FlowUserId = Account.UserId;
            cip.OrderBy = " id desc ";
            cip.Time = int.Parse(txtTime.Value.Replace("-", ""));

            if(!string.IsNullOrEmpty(ddlAdPage.SelectedValue))
            {
                cip.AdId = int.Parse(ddlAdPage.SelectedValue);
            }
            if(!string.IsNullOrEmpty(hidAdUserId.Value))
            {
                cip.AdUserId = int.Parse(hidAdUserId.Value);
            }

            var list = AdBrowseBLL.Instance.GetModels(ref cip);
            rptTable.DataSource = list;
            rptTable.DataBind();

            apPager.RecordCount = cip.Recount.Value;
        }

        protected void apPager_PageChanged(object sender, EventArgs e)
        {
            Bind(apPager.CurrentPageIndex);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Bind();
        }
    }
}