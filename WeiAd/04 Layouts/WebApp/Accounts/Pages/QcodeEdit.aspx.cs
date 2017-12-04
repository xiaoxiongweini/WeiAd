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
using System.IO;

namespace WebApp.Accounts.Pages
{
    public partial class QcodeEdit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hidAdId.Value = Request.Params["adid"] ?? "0";
                hidId.Value = Request.Params["id"] ?? "";

                BindPage();
            }
        }

        private void BindPage()
        {
            if (!string.IsNullOrEmpty(hidId.Value))
            {
                var info = AdQcodeInfoBLL.Instance.GetSingle(new AdQcodeInfoPara() { Id = int.Parse(hidId.Value), AdId = int.Parse(hidAdId.Value), AdUserId = Account.UserId });
                if (info != null)
                {
                    txtName.Value = info.Name;
                    if(info.QcodeUrl.IndexOf("//")!=-1)
                    {
                        imgPreview.ImageUrl = info.QcodeUrl;
                    }else
                    {
                        txtQcodeUrl.Text = info.QcodeUrl;
                    }
                    txtWeiXinName.Text = info.QcodeUrl2;

                    btnEdit.Visible = true;
                }
            }
            btnSave.Visible = !btnEdit.Visible;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            AdQcodeInfoVO info = new AdQcodeInfoVO();
            info.Name = txtName.Value;
            info.AdUserId = Account.UserId;
            info.AdId = int.Parse(hidAdId.Value);
            info.CreateDate = DateTime.Now;
            info.CreateUserId = Account.UserId;
            txtWeiXinName.Text = info.QcodeUrl2;
            if (string.IsNullOrEmpty(txtQcodeUrl.Text))
            {
                info.QcodeUrl = imgPreview.ImageUrl;
            }
            else
            {
                info.QcodeUrl = txtQcodeUrl.Text;
            }

            AdQcodeInfoBLL.Instance.Add(info);
            var adinfo = AdPageInfoBLL.Instance.GetSingle(new AdPageInfoPara() { Id = info.AdId });
            if(adinfo!= null)
            {
                adinfo.QcodeCount = AdQcodeInfoBLL.Instance.GetRecords(new AdQcodeInfoPara() { AdId = info.AdId });
                adinfo.LastDate = DateTime.Now;
                AdPageInfoBLL.Instance.Edit(adinfo);
            }
            AdQcodeInfoBLL.Instance.Refresh();
            Response.Redirect("/Accounts/Pages/QcodeList.aspx?adid=" + hidAdId.Value);
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            var info = AdQcodeInfoBLL.Instance.GetSingle(new AdQcodeInfoPara() { Id = int.Parse(hidId.Value), AdUserId = Account.UserId });
            if (info != null)
            {
                info.Name = txtName.Value;
                info.AdUserId = Account.UserId;
                info.AdId = int.Parse(hidAdId.Value);
                if (string.IsNullOrEmpty(txtQcodeUrl.Text))
                {
                    info.QcodeUrl = imgPreview.ImageUrl;
                }
                else
                {
                    info.QcodeUrl = txtQcodeUrl.Text;
                }
                txtWeiXinName.Text = info.QcodeUrl2;
                AdQcodeInfoBLL.Instance.Edit(info);
                AdQcodeInfoBLL.Instance.Refresh();
                Response.Redirect("/Accounts/Pages/QcodeList.aspx?adid=" + hidAdId.Value);
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            UploadItem info = new UploadItem("erweima", flImg);
            string url = UploadHelper.Upload(info);

            if (DN.WeiAd.Business.Config.AppConfig.AliYunIsSave)
            {
                string path = Server.MapPath(url);
                string fileName = Path.GetFileName(path);
                url = DN.WeiAd.Business.Utilty.AliYunOssClientHelper.PutObject(fileName, path);
            }
            imgPreview.ImageUrl = url;
        }
    }
}