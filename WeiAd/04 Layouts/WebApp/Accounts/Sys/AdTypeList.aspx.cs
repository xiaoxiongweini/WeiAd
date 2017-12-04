using DN.WeiAd.Business;
using DN.WeiAd.Business.Pages;
using DN.WeiAd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.Accounts.Sys
{
    public partial class AdTypeList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.Params["id"] ?? "";
                if (!string.IsNullOrEmpty(id))
                {
                    //var adinfo = AdPageInfoBLL.Instance.GetSingle(new AdPageInfoPara() { Id = int.Parse(adid), UserId = Account.UserId });
                    //if (adinfo != null)
                    //{
                    //    AdPageInfoBLL.Instance.DeleteAd(adinfo);
                    //}
                }
                BindPage();

                Bind();
            }
        }

        private void BindPage()
        {
            //ddlAdType.DataSource = AdPageInfoBLL.Instance.GetAdTypes();
            //ddlAdType.DataTextField = "Name";
            //ddlAdType.DataValueField = "Id";
            //ddlAdType.DataBind();

            //ddlAdType.Items.Insert(0, new ListItem() { Text = "不限广告类型", Value = "" });
        }

        private void Bind(int pageIndex = 1)
        {
            AdTypeInfoPara cip = new AdTypeInfoPara();
            cip.PageIndex = pageIndex - 1;
            cip.PageSize = 10;
            cip.UserId = Account.UserId;
            cip.OrderBy = " id desc ";

            var list = AdTypeInfoBLL.Instance.GetModels(ref cip);
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