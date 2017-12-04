using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DN.WeiAd.Models;
using DN.WeiAd.Business;
using DN.WeiAd.Business.Pages;

namespace WebApp.Accounts.Pages
{
    public partial class UserCodeEdit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hidId.Value = Request.Params["id"] ?? "";
                BindPage();
            }
        }

        private void BindPage()
        {
            ddlType.DataSource = UserCodeInfoBLL.Instance.GetCodeTypes();
            ddlType.DataTextField = "Name";
            ddlType.DataValueField = "Id";
            ddlType.DataBind();

            if (!string.IsNullOrEmpty(hidId.Value))
            {
                var info = UserCodeInfoBLL.Instance.GetSingle(new UserCodeInfoPara() { Id = int.Parse(hidId.Value), UserId = Account.UserId });
                if (info != null)
                {
                    txtUserCode.Text = DN.Framework.Utility.HtmlHelper.DecodeHtml(info.CodeContent);
                    hidContent.Value = info.CodeContent;
                    txtName.Text = info.Name;
                    
                    btnEdit.Visible = true;
                }
            }
            btnSave.Visible = !btnEdit.Visible;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            UserCodeInfoVO info = new UserCodeInfoVO();
            info.UserId = Account.UserId;
            info.CreateDate = DateTime.Now;
            info.TypeId = int.Parse(ddlType.SelectedValue);
            info.CodeContent = hidContent.Value;
            info.Name = txtName.Text;
            UserCodeInfoBLL.Instance.Add(info);
            Response.Redirect("/Accounts/Pages/UserCodeList.aspx");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            var info = UserCodeInfoBLL.Instance.GetSingle(new UserCodeInfoPara() { Id = int.Parse(hidId.Value), UserId = Account.UserId });
            if (info != null)
            {
                info.TypeId = int.Parse(ddlType.SelectedValue);
                info.CodeContent = hidContent.Value;
                info.Name = txtName.Text;

                UserCodeInfoBLL.Instance.Edit(info);
                UserCodeInfoBLL.Instance.Refresh();
                Response.Redirect("/Accounts/Pages/UserCodeList.aspx");
            }
        }
    }
}