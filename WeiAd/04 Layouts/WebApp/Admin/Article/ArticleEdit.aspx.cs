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

namespace WebApp.Admin.Article
{
    public partial class ArticleEdit : BasePage
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
            var list = ChannelInfoBLL.Instance.GetModels(new ChannelInfoPara());
            ddlChannel.DataSource = list;
            ddlChannel.DataTextField = "Name";
            ddlChannel.DataValueField = "Id";
            ddlChannel.DataBind();
            
            if (!string.IsNullOrEmpty(hidId.Value))
            {
                var info = ArticleInfoBLL.Instance.GetSingle(new ArticleInfoPara() { Id = int.Parse(hidId.Value) });
                if (info != null)
                {
                    txtTitle.Value = info.Title;
                    hidContent.Value = info.Content;
                    ltContent.Text = DN.Framework.Utility.HtmlHelper.DecodeHtml(info.Content);
                    imgPerview.ImageUrl = info.TitleImg;
                    txtTitleShort.Text = info.TitleShort;
                    ddlChannel.SelectedValue = info.ChannelId.ToString();                    
                    btnEdit.Visible = true;
                }
            }
            if (string.IsNullOrEmpty(txtPage.Value))
            {
                txtPage.Value = AdPageInfoBLL.Instance.GetPageName();
            }
            btnSave.Visible = !btnEdit.Visible;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ArticleInfoVO info = new ArticleInfoVO();
            info.Title = txtTitle.Value;
            info.Content = hidContent.Value;
            info.CreateDate = DateTime.Now;
            info.LastDate = DateTime.Now;
            info.Title = txtTitle.Value;
            info.TitleImg = imgPerview.ImageUrl;
            info.AuditDate = DateTime.Now;
            info.ChannelId = int.Parse(ddlChannel.SelectedValue);
            info.CreateUserId = Account.UserId;
            info.TitleShort = txtTitleShort.Text;

            if (ArticleInfoBLL.Instance.Add(info))
            {
                Response.Redirect("/Admin/Article/ArticleList.aspx");
            }
            else
            {
                lblMsg.Text = "【广告页面】己经存在。";
            }

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            var info = ArticleInfoBLL.Instance.GetSingle(new ArticleInfoPara() { Id = int.Parse(hidId.Value) });
            if (info != null)
            {
                info.Title = txtTitle.Value;
                info.Content = hidContent.Value;
                info.LastDate = DateTime.Now;
                info.Title = txtTitle.Value;
                info.TitleImg = imgPerview.ImageUrl;
                info.ChannelId = int.Parse(ddlChannel.SelectedValue);
                info.TitleShort = txtTitleShort.Text;

                if (ArticleInfoBLL.Instance.Edit(info))
                {
                    Response.Redirect("/Admin/Article/ArticleList.aspx");
                }
                else
                {
                    lblMsg.Text = "【广告页面】己经存在。";
                }
            }
        }

        protected void btnGather_Click(object sender, EventArgs e)
        {
            var adpage = AdPageInfoBLL.Instance.GetWeiXin(txtWeiXinUrl.Value);
            if (adpage != null)
            {
                if (!string.IsNullOrEmpty(adpage.Title))
                {
                    txtTitle.Value = adpage.Title.Trim();
                }
                if (!string.IsNullOrEmpty(adpage.Content))
                {
                    ltContent.Text = DN.Framework.Utility.HtmlHelper.DecodeHtml(adpage.Content);
                }
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            UploadItem info = new UploadItem("weixinarticle", flTitleImg);
            var url = UploadHelper.Upload(info);
            imgPerview.ImageUrl = url;
        }
    }
}