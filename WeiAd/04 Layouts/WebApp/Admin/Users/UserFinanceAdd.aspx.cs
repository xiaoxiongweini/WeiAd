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
    public partial class UserFinanceAdd : BasePageAdmin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                hidId.Value = Request.Params["uid"] ?? "";
                BindPage();
            }
        }

        private void BindPage()
        {
            ddlRechargeType.DataSource = UserFinanceHistoryBLL.Instance.GetRechargeTypes();
            ddlRechargeType.DataTextField = "Name";
            ddlRechargeType.DataValueField = "Id";
            ddlRechargeType.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(hidId.Value))
            {
                var userinfo = AccountInfoBLL.Instance.GetSingle(new AccountInfoPara() { Id = int.Parse(hidId.Value) });
                if (userinfo != null)
                {
                    UserFinanceHistoryVO userfin = new UserFinanceHistoryVO();
                    userfin.CreateDate = DateTime.Now;
                    userfin.CreateUserId = Account.UserId;
                    userfin.Money = decimal.Parse(txtMoney.Value);
                    userfin.MoneyType = 0;
                    userfin.RechargeType = 0;
                    userfin.UserId = userinfo.Id;

                    if (UserFinanceHistoryBLL.Instance.Add(userfin))
                    {
                        //userinfo.Money = userinfo.Money + userfin.Money;
                        userinfo.LastMoneyDate = DateTime.Now;
                        AccountInfoBLL.Instance.Edit(userinfo);
                    }
                }
            }
        }
    }
}