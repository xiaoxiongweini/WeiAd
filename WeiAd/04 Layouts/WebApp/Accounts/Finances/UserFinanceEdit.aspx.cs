using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DN.WeiAd.Models;
using DN.WeiAd.Business;
using DN.WeiAd.Business.Pages;

namespace WebApp.Accounts.Finances
{
    public partial class UserFinanceEdit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Bind();
            }
        }

        private void Bind()
        {
            AccountInfoPara up = new AccountInfoPara();
            up.Id = Account.UserId;

            var list = AccountInfoBLL.Instance.GetModels(up);
            rptTable.DataSource = list;
            rptTable.DataBind();
        }
    }
}