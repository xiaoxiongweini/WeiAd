using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DN.WeiAd.Models;
using DN.WeiAd.Business;
using DN.WeiAd.Business.Pages;

namespace WebApp.Accounts
{
    public partial class EditPwd : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            var info = AccountInfoBLL.Instance.GetSingle(new AccountInfoPara() { Id = Account.UserId });
            if (info != null)
            {
                if(DN.Framework.Utility.EncryptHelper.GetMd5(txtPwd.Value).Equals(info.UserPwd, StringComparison.OrdinalIgnoreCase))
                {
                    info.UserPwd = DN.Framework.Utility.EncryptHelper.GetMd5(txtPwd1.Value);
                    AccountInfoBLL.Instance.Edit(info);
                }
                else
                {
                    lblMsg.Text = "【原密码】输入不正确。";   
                }
            }
            else
            {
                lblMsg.Text = "加载用户信息出错，请登录之后再试。";
            }
        }
    }
}