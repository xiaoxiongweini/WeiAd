using DN.WeiAd.Business.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DN.WeiAd.Models;
using DN.WeiAd.Business;


namespace WebApp.Accounts.Qcodes
{
    public partial class QcodeList : BasePage
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
            var list = AdPageInfoBLL.Instance.GetModels(new AdPageInfoPara() { UserId = Account.UserId });
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
            LogAdQcodePara cip = new LogAdQcodePara();
            cip.PageIndex = pageIndex - 1;
            cip.PageSize = 10;
            cip.Time = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
            cip.OrderBy = " id desc ";
            cip.AdUserId = Account.UserId;

            if (!string.IsNullOrEmpty(ddlAdPage.SelectedValue))
            {
                cip.AdId = int.Parse(ddlAdPage.SelectedValue);
            }

            var list = LogAdQcodeBLL.Instance.GetModels(ref cip);
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