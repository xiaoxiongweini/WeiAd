using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DN.WeiAd.Models;
using DN.WeiAd.Business;
using DN.WeiAd.Business.Pages;
using DN.Framework.Utility;

namespace WebApp.Accounts.Sys
{
    public partial class AdTypeEdit : BasePage
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
            if (!string.IsNullOrEmpty(hidId.Value))
            {
                var info = AdTypeInfoBLL.Instance.GetSingle(new AdTypeInfoPara() { Id = int.Parse(hidId.Value), UserId = Account.UserId });
                if (info != null)
                {
                    txtName.Value = info.Name;
                    txtDesc.Text = info.Desc;
                    btnEdit.Visible = true;
                }
            }
            btnSave.Visible = !btnEdit.Visible;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            AdTypeInfoVO info = new AdTypeInfoVO();
            info.Name = txtName.Value;
            info.UserId = Account.UserId;
            info.CreateDate = DateTime.Now;
            info.Desc = txtDesc.Text;
            info.LastDate = DateTime.Now;

            AdTypeInfoBLL.Instance.Add(info);
            Response.Redirect("/Accounts/Sys/AdTypeList.aspx");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            var info = AdTypeInfoBLL.Instance.GetSingle(new AdTypeInfoPara() { Id = int.Parse(hidId.Value), UserId = Account.UserId });
            if (info != null)
            {
                info.Name = txtName.Value;
                info.UserId = Account.UserId;
                info.Desc = txtDesc.Text;
                info.LastDate = DateTime.Now;

                AdTypeInfoBLL.Instance.Edit(info);
                Response.Redirect("/Accounts/Sys/AdTypeList.aspx");
            }
        }
    }
}