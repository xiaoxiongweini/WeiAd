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
    public partial class UserEdit : BasePageAdmin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                hidId.Value = Request.Params["userid"] ?? "";

                BindPage();
            }
        }

        private void BindPage()
        {
            ddlUserType.DataSource = AccountInfoBLL.Instance.GetUserTypes();
            ddlUserType.DataTextField = "Name";
            ddlUserType.DataValueField = "Id";
            ddlUserType.DataBind();

            if(!string.IsNullOrEmpty(hidId.Value))
            {
                var info = AccountInfoBLL.Instance.GetSingle(new AccountInfoPara() { Id = int.Parse(hidId.Value) });
                if(info!= null)
                {
                    txtEmail.Value = info.Email;                    
                    txtPhone.Value = info.Phone;
                    txtUserName.Value = info.UserName;
                    ddlUserType.SelectedValue = info.UserType.ToString();
                    chkIsLock.Checked = info.IsLock == 1 ? true : false;
                    btnEdit.Visible = true;
                    txtUserName.Attributes.Add("disabled", "disabled");
                }
            }

            btnSave.Visible = !btnEdit.Visible;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            AccountInfoVO info = new AccountInfoVO();
            info.AccountType = 0;
            info.ConsumptionMoney = 0;
            info.Email = txtEmail.Value;
            info.LastLoginDate = DateTime.Now;
            info.LastMoneyDate = DateTime.Now;
            info.Money = 0;
            info.MoneyCount = 0;
            info.MoneyFree = 0;
            info.NickName = txtUserName.Value;
            info.Phone = txtPhone.Value;
            info.RegDate = DateTime.Now;
            info.RegIp = DN.Framework.Utility.ClientHelper.ClientIP();
            info.UserImg = "";
            info.UserName = txtUserName.Value;
            info.UserType = int.Parse(ddlUserType.SelectedValue);
            info.UserPwd = DN.Framework.Utility.EncryptHelper.GetMd5(txtPwd.Value);
            info.IsLock = chkIsLock.Checked ? 1 : 0;

            AccountInfoPara ap = new AccountInfoPara();
            ap.UserName = info.UserName;

            var list = AccountInfoBLL.Instance.GetModels(ap);
            if(list.Count == 0)
            {
                AccountInfoBLL.Instance.Add(info);
                Response.Redirect("/Admin/Users/UserList.aspx");
            }
            else
            {
                lblMsg.Text = "【登录名称】登录名称己经存在，请重新输入。";
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(hidId.Value))
            {
                var info = AccountInfoBLL.Instance.GetSingle(new AccountInfoPara() { Id = int.Parse(hidId.Value) });
                if (info != null)
                {
                    info.Email = txtEmail.Value;
                    info.NickName = txtUserName.Value;
                    info.Phone = txtPhone.Value;
                    info.UserType = int.Parse(ddlUserType.SelectedValue);
                    info.IsLock = chkIsLock.Checked ? 1 : 0;
                    if(!string.IsNullOrEmpty(txtPwd.Value))
                    {
                        info.UserPwd = DN.Framework.Utility.EncryptHelper.GetMd5(txtPwd.Value);
                    }
                    AccountInfoBLL.Instance.Edit(info);
                    lblMsg.Text = "修改成功。";
                }
                else
                {
                    lblMsg.Text = "【用户ID】不正确，请重新选择。";
                }
            }
            else
            {
                lblMsg.Text = "【用户ID】不能为空。";
            }
        }
    }
}