using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DN.WeiAd.Models;
using DN.WeiAd.Business;
using DN.WeiAd.Business.Pages;

namespace WebApp.Admin.Users
{
    public partial class LoginList : BasePageAdmin
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
            ddlUserType.DataSource = AccountInfoBLL.Instance.GetUserTypes();
            ddlUserType.DataTextField = "Name";
            ddlUserType.DataValueField = "Id";
            ddlUserType.DataBind();
        }

        private void Bind(int pageIndex = 1)
        {
            LogLoginPara cip = new LogLoginPara();
            cip.PageIndex = pageIndex - 1;
            cip.PageSize = 10;
            cip.OrderBy = " id desc ";

            var list = LogLoginBLL.Instance.GetModels(ref cip);
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