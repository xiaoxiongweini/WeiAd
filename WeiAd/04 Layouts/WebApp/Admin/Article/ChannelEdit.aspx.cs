using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DN.WeiAd.Models;
using DN.WeiAd.Business;
using DN.WeiAd.Business.Pages;

namespace WebApp.Admin.Article
{
    public partial class ChannelEdit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                hidId.Value = Request.Params["id"] ?? "";
                BindPage();
            }
        }

        private void BindPage()
        {
            if (!string.IsNullOrEmpty(hidId.Value))
            {
                var info = ChannelInfoBLL.Instance.GetSingle(new ChannelInfoPara() { Id = int.Parse(hidId.Value) });
                if (info != null)
                {
                    txtDesc.Text = info.Desc;
                    txtLinkUrl.Value = info.LinkUrl;
                    txtName.Value = info.Name;
                    btnEdit.Visible = true;
                }
            }

            btnSave.Visible = !btnEdit.Visible;
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            ChannelInfoVO info = new ChannelInfoVO();
            info.ColorValue = "";
            info.CreateDate = DateTime.Now;
            info.CreateUserId = Account.UserId;
            info.Desc = txtDesc.Text;
            info.ImgUrl = "";
            info.LastDate = DateTime.Now;
            info.LinkUrl = txtLinkUrl.Value;
            info.Name = txtName.Value;

            ChannelInfoBLL.Instance.Add(info);
            Response.Redirect("/Admin/Article/ChannelList.aspx");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(hidId.Value))
            {
                var info = ChannelInfoBLL.Instance.GetSingle(new ChannelInfoPara() { Id = int.Parse(hidId.Value) });
                if(info!= null)
                {
                    info.ColorValue = "";
                    info.Desc = txtDesc.Text;
                    info.ImgUrl = "";
                    info.LastDate = DateTime.Now;
                    info.LinkUrl = txtLinkUrl.Value;
                    info.Name = txtName.Value;

                    ChannelInfoBLL.Instance.Edit(info);
                    Response.Redirect("/Admin/Article/ChannelList.aspx");
                }
            }
        }
    }
}