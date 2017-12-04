using DN.WeiAd.Business.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DN.WeiAd.Models;
using DN.WeiAd.Business;

namespace WebApp.Admin.Shop
{
    public partial class ProdcuteEdit : BasePageAdmin
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
            AdPageInfoPara adp = new AdPageInfoPara();

            var adlist = AdPageInfoBLL.Instance.GetModels(adp);
            var ulist = AccountInfoBLL.Instance.GetModels(new AccountInfoPara() { IsNotAdmin = true });

            ddlAd.Items.Clear();
            foreach (var item in adlist)
            {
                string nick = "";
                var user = ulist.SingleOrDefault(p => p.Id == item.UserId);
                if (user != null) nick = user.NickName;

                ddlAd.Items.Add(new ListItem() { Value = item.Id.ToString(), Text = string.Format("用户ID={2}-{3}，广告ID={0}-{1}", item.Id, item.Title,item.UserId, nick) });
            }

            ddlAdUserName.Items.Clear();
            foreach (var item in ulist)
            {
                ddlAdUserName.Items.Add(new ListItem() { Text = item.UserName + AccountInfoBLL.Instance.GetUserTypeNameById(item.UserType), Value = item.Id.ToString() });
            }

            if (!string.IsNullOrEmpty(hidId.Value))
            {
                var info = ProductInfoBLL.Instance.GetSingle(new ProductInfoPara() { Id = int.Parse(hidId.Value)});
                if (info != null)
                {
                    txtDesc.Text = info.Desc;
                    txtName.Text = info.Name;
                    txtPrice.Text = info.Price.ToString();
                    txtAttr.Text = info.AttrText;
                    ddlAd.SelectedValue = info.AdId.ToString();
                    ddlAdUserName.SelectedValue = info.CreateUserId.ToString();
                    btnEdit.Visible = true;
                }
            }

            btnSave.Visible = !btnEdit.Visible;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ProductInfoVO info = new ProductInfoVO();
            info.AdId = int.Parse(ddlAd.SelectedValue);
            info.AttrStyle = "";
            info.AttrText = txtAttr.Text;
            info.Desc = txtDesc.Text;
            info.Name = txtName.Text;
            info.Price = int.Parse(txtPrice.Text);
            info.CreateDate = DateTime.Now;
            info.CreateUserId = int.Parse(ddlAdUserName.SelectedValue);
            ProductInfoBLL.Instance.Add(info);

            Response.Redirect("/Admin/Shop/ProducteList.aspx");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            var info = ProductInfoBLL.Instance.GetSingle(new ProductInfoPara() { Id = int.Parse(hidId.Value) });
            if (info != null)
            {
                info.AdId = int.Parse(ddlAd.SelectedValue);
                info.AttrStyle = "";
                info.AttrText = txtAttr.Text;
                info.Desc = txtDesc.Text;
                info.Name = txtName.Text;
                info.Price = int.Parse(txtPrice.Text);
                info.CreateUserId = int.Parse(ddlAdUserName.SelectedValue);

                ProductInfoBLL.Instance.Edit(info);
                Response.Redirect("/Admin/Shop/ProducteList.aspx");
            }
        }
    }
}