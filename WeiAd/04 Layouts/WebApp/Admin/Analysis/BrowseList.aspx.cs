using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DN.WeiAd.Models;
using DN.WeiAd.Business;
using DN.WeiAd.Business.Pages;

namespace WebApp.Admin.Analysis
{
    public partial class BrowseList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindPage();

                Bind();
            }
        }

        private void BindPage()
        {
            var list = AdPageInfoBLL.Instance.GetModels(new AdPageInfoPara() );
            ddlAdPage.Items.Clear();
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
            AdBrowsePara cip = new AdBrowsePara();
            cip.PageIndex = pageIndex - 1;
            cip.PageSize = 10;
            cip.Time = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
            cip.OrderBy = " id desc ";
            if (!string.IsNullOrEmpty(ddlAdPage.SelectedValue))
            {
                cip.AdId = int.Parse(ddlAdPage.SelectedValue);
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