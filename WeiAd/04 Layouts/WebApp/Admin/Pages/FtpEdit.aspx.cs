using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DN.WeiAd.Models;
using DN.WeiAd.Business;
using DN.WeiAd.Business.Pages;

namespace WebApp.Admin.Pages
{
    public partial class FtpEdit : BasePageAdmin
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
                var info = FtpInfoBLL.Instance.GetSingle(new FtpInfoPara() { Id = int.Parse(hidId.Value) });
                if (info != null)
                {
                    txtName.Value = info.Name;
                    txtDomain.Value = info.Domains;
                    txtFtpServer.Value = info.FtpServer;
                    txtUserName.Value = info.FtpUserName;
                    txtUserPwd.Value = info.FtpPassword;
                    chkIsState.Checked = info.IsSynchronization == 1 ? true : false;
                    btnEdit.Visible = true;
                }
            }
            btnSave.Visible = !btnEdit.Visible;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            FtpInfoVO info = new FtpInfoVO();
            info.CloseDate = DateTime.Now;
            info.CreateDate = DateTime.Now;
            info.Desc = txtName.Value;
            info.Domains = txtDomain.Value;
            info.FtpPassword = txtUserPwd.Value;
            info.FtpServer = txtFtpServer.Value;
            info.FtpUserName = txtUserName.Value;
            info.IsSynchronization = chkIsState.Checked ? 1 : 0;
            info.Name = txtName.Value;
            
            FtpInfoBLL.Instance.Add(info);
            Response.Redirect("/Admin/Pages/FtpList.aspx");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            var info = FtpInfoBLL.Instance.GetSingle(new FtpInfoPara() { Id = int.Parse(hidId.Value) });
            if (info != null)
            {
                txtName.Value = info.Name;
                txtDomain.Value = info.Domains;
                txtFtpServer.Value = info.FtpServer;
                txtUserName.Value = info.FtpUserName;
                txtUserPwd.Value = info.FtpPassword;
                chkIsState.Checked = info.IsSynchronization == 1 ? true : false;

                FtpInfoBLL.Instance.Edit(info);
                Response.Redirect("/Admin/Pages/FtpList.aspx");
            }
        }
    }
}