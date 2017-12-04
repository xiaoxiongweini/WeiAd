using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DN.WeiAd.Models;
using DN.WeiAd.Business;
using DN.WeiAd.Business.Pages;
namespace WebApp.Accounts.Charts.His
{
    public partial class HourDetails : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hidFlowUserId.Value = Request.Params["FlowUserId"] ?? "";
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
            ddlAdPage.Items.Insert(0, new ListItem() { Text = "不限", Value = "" });
        }

        private void Bind(int pageIndex = 1)
        {
            AdBrowseHistoryPara cip = new AdBrowseHistoryPara();
            cip.PageIndex = pageIndex - 1;
            cip.PageSize = 10;
            cip.AdUserId = Account.UserId;
            cip.OrderBy = " id desc ";
            cip.Time = int.Parse(DateTime.Parse(txtTime.Value).ToString("yyyyMMdd"));

            if (!string.IsNullOrEmpty(hidFlowUserId.Value))
            {
                cip.FlowUserId = int.Parse(hidFlowUserId.Value);
            }

            var list = AdBrowseHistoryBLL.Instance.GetModels(ref cip);
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