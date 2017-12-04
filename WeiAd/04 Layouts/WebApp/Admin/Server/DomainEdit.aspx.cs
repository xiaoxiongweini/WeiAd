using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DN.WeiAd.Models;
using DN.WeiAd.Business;
using DN.WeiAd.Business.Pages;

namespace WebApp.Admin.Server
{
    public partial class DomainEdit : BasePageAdmin
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
                var info = DomainInfoBLL.Instance.GetSingle(new DomainInfoPara() { Id = int.Parse(hidId.Value) });
                if (info != null)
                {
                    txtName.Value = info.Name;
                    txtDomain.Value = info.Domain;
                    chkIsState.Checked = info.IsState == 1 ? true : false;
                    chkIsAuth.Checked = info.IsAuth == 1 ? true : false;
                    txtCityName.Value = info.CityName;
                    btnEdit.Visible = true;
                }
            }
            btnSave.Visible = !btnEdit.Visible;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DomainInfoVO info = new DomainInfoVO();
            info.CloseUserId = Account.UserId;
            info.ColseDate = DateTime.Now;
            info.CreateDate = DateTime.Now;
            info.CreateUserId = Account.UserId;
            info.Domain = txtDomain.Value;
            info.Name = txtName.Value;
            info.IsAuth = chkIsAuth.Checked ? 1 : 0;
            info.IsState = chkIsState.Checked ? 1 : 0;
            info.CityName = txtCityName.Value;
            info.ResolutionDate = DateTime.Now;

            DomainInfoBLL.Instance.Add(info);
            Response.Redirect("/Admin/Server/DomainList.aspx");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            var info = DomainInfoBLL.Instance.GetSingle(new DomainInfoPara() { Id = int.Parse(hidId.Value) });
            if (info != null)
            {
                info.CloseUserId = Account.UserId;
                info.ColseDate = DateTime.Now;
                info.CreateUserId = Account.UserId;
                info.Domain = txtDomain.Value;
                info.Name = txtName.Value;
                info.IsAuth = chkIsAuth.Checked ? 1 : 0;
                info.IsState = chkIsState.Checked ? 1 : 0;
                info.CityName = txtCityName.Value;

                DomainInfoBLL.Instance.Edit(info);
                Response.Redirect("/Admin/Server/DomainList.aspx");
            }
        }
    }
}