using DN.WeiAd.Business.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DN.WeiAd.Models;
using DN.WeiAd.Business;

namespace WebApp.Admin.Server
{
    public partial class SerEdit : BasePageAdmin
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
                var info = ServerInfoBLL.Instance.GetSingle(new ServerInfoPara() { Id = int.Parse(hidId.Value) });
                if (info != null)
                {
                    txtName.Value = info.Name;
                    txtDesc.Value = info.Desc;
                    txtIp.Value = info.Ip;
                    txtServerId.Value = info.ServerId;
                    chkIsState.Checked = info.IsState == 0 ? false : true;
                    btnEdit.Visible = true;
                }
            }
            btnSave.Visible = !btnEdit.Visible;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //ServerInfoVO info = new ServerInfoVO();
            //info.IsState = chkIsState.Checked ? 1 : 0;
            //ServerInfoBLL.Instance.Add(info);
            Response.Redirect("/Admin/Server/SerList.aspx");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            var info = ServerInfoBLL.Instance.GetSingle(new ServerInfoPara() { Id = int.Parse(hidId.Value) });
            if (info != null)
            {
                info.Name = txtName.Value;
                info.IsState = chkIsState.Checked ? 1 : 0;
                ServerInfoBLL.Instance.Edit(info);
                Response.Redirect("/Admin/Server/SerList.aspx");
            }
        }
    }
}