using DN.WeiAd.Business.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DN.WeiAd.Models;
using DN.WeiAd.Business;

namespace WebApp.Accounts.LogBrowse
{
    public partial class BrowseList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtTime.Value = DateTime.Now.ToString("yyyy-MM-dd");
                hidAdId.Value = Request.Params["adid"] ?? "";

                string time = Request.Params["time"] ?? "";
                if (!string.IsNullOrEmpty(time))
                {
                    txtTime.Value = DN.WeiAd.Framework.TimeHelper.ConverTimeByString(time).ToString("yyyy-MM-dd");
                }

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
                li.Text = item.Id.ToString() + "__" + item.Title;
                li.Value = item.Id.ToString();
                ddlAdPage.Items.Add(li);
            }
            ddlAdPage.Items.Insert(0, new ListItem() { Text = "不限", Value = "" });

            if (!string.IsNullOrEmpty(hidAdId.Value))
            {
                ddlAdPage.SelectedValue = hidAdId.Value;
            }
        }

        private void Bind(int pageIndex = 1)
        {
            LogBrowsePara lp = new LogBrowsePara();
            lp.PageIndex = pageIndex - 1;
            lp.PageSize = 10;
            lp.AdUserId = Account.UserId;
            lp.Time = int.Parse(txtTime.Value.Replace("-", ""));
            if (!string.IsNullOrEmpty(ddlAdPage.SelectedValue))
            {
                lp.AdId = int.Parse(ddlAdPage.SelectedValue);
            }
            lp.OrderBy = " id desc ";
            
            var list = LogBrowseBLL.Instance.GetModels(ref lp);
            rptTable.DataSource = list;
            rptTable.DataBind();

            apPager.RecordCount = lp.Recount.Value;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Bind();
        }
        protected void apPager_PageChanged(object sender, EventArgs e)
        {
            Bind(apPager.CurrentPageIndex);
        }
    }
}