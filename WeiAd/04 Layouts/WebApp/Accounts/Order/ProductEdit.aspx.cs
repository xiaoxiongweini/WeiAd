using DN.WeiAd.Business.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DN.WeiAd.Models;
using DN.WeiAd.Business;   

namespace WebApp.Accounts.Order
{
    public partial class ProductEdit : BasePage
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
            adp.UserId = Account.UserId;

            var adlist = AdPageInfoBLL.Instance.GetModels(adp);

            ddlAd.Items.Clear();
            foreach (var item in adlist)
            {
                ddlAd.Items.Add(new ListItem() { Value = item.Id.ToString(), Text = string.Format("{0}-{1}", item.Id, item.Title) });
            }
            if(!string.IsNullOrEmpty(hidId.Value))
            {
                var info = ProductInfoBLL.Instance.GetSingle(new ProductInfoPara() { Id = int.Parse(hidId.Value), CreateUserId = Account.UserId });
                if (info != null)
                {
                    txtDesc.Text = info.Desc;
                    txtName.Text = info.Name;
                    txtPrice.Text = info.Price.ToString();
                    txtAttr.Text = info.AttrText;
                    ddlAd.SelectedValue = info.AdId.ToString();
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
            info.AttrText =txtAttr.Text;
            info.Desc = txtDesc.Text;
            info.Name = txtName.Text;
            info.Price = int.Parse(txtPrice.Text);
            info.CreateDate = DateTime.Now;
            info.CreateUserId = Account.UserId;
            ProductInfoBLL.Instance.Add(info);
            Response.Redirect("/Accounts/Order/ProductList.aspx");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            var info = ProductInfoBLL.Instance.GetSingle(new ProductInfoPara() { Id = int.Parse(hidId.Value), CreateUserId = Account.UserId });
            if (info != null)
            {
                info.AdId = int.Parse(ddlAd.SelectedValue);
                info.AttrStyle = "";
                info.AttrText = txtAttr.Text;
                info.Desc = txtDesc.Text;
                info.Name = txtName.Text;
                info.Price = int.Parse(txtPrice.Text);

                ProductInfoBLL.Instance.Edit(info);
                Response.Redirect("/Accounts/Order/ProductList.aspx");
            }
        }
    }
}