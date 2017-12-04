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
    public partial class AdPageEdit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hidId.Value = Request.Params["id"] ?? "";
                BindPage();
            }
        }
        private void BindImg()
        {
            string html = hidContent.Value;
            html = DN.Framework.Utility.HtmlHelper.DecodeHtml(html);
            if (!string.IsNullOrEmpty(html))
            {
                var list = AdPageInfoBLL.Instance.GetPadSrcImg(html);
                var tlist = list.Distinct<string>();
                rptImg.DataSource = tlist;
                rptImg.DataBind();
            }
        }
        private void BindPage()
        {
            //模版文件
            var tlist = AdPageInfoBLL.Instance.GetTemplateSett();
            ddlTemplate.Items.Clear();
            foreach (var item in tlist)
            {
                ddlTemplate.Items.Add(new ListItem() { Text = item, Value = item });
            }

            ddlTemplate.SelectedValue = DN.WeiAd.Business.Config.AppConfig.TemplateName;

            //广告分类
            var adtypelist = AdTypeInfoBLL.Instance.GetModels(new AdTypeInfoPara() { UserId = Account.UserId });
            ddlUserAdTypeId.DataSource = adtypelist;
            ddlUserAdTypeId.DataTextField = "Name";
            ddlUserAdTypeId.DataValueField = "Id";
            ddlUserAdTypeId.DataBind();
            ddlUserAdTypeId.Items.Insert(0, new ListItem() { Text = "不限", Value = "0" });

            //投放平台分类
            var sitelist = AdSiteInfoBLL.Instance.GetModels(new AdSiteInfoPara() { UserId = Account.UserId });
            ddlSiteType.DataSource = sitelist;
            ddlSiteType.DataTextField = "Name";
            ddlSiteType.DataValueField = "Id";
            ddlSiteType.DataBind();
            ddlSiteType.Items.Insert(0, new ListItem() { Text = "不限", Value = "0" });

            //平台类型
            ddlPlatformType.DataSource = CommonBLL.GetPlatform();
            ddlPlatformType.DataTextField = "Name";
            ddlPlatformType.DataValueField = "Name";
            ddlPlatformType.DataBind();

            if (!string.IsNullOrEmpty(hidId.Value))
            {
                var info = AdPageInfoBLL.Instance.GetSingle(new AdPageInfoPara() { Id = int.Parse(hidId.Value), UserId = Account.UserId });
                if (info != null)
                {
                    txtTitle.Text = info.Title;
                    hidContent.Value = info.Content;
                    txtWeiXinUrl.Value = info.WeiXinUrl;
                    txtPage.Value = info.ViewPage;
                    txtQcode.Text = info.QcodeImg;
                    imgPerview.ImageUrl = info.TitleImg;
                    txtTitleShort.Text = info.TitleShort;
                    hidUserCode.Value = info.UserCode;
                    hidStaticContent.Value = info.StaticContent;
                    if (!string.IsNullOrEmpty(info.TemplateName))
                    {
                        ddlTemplate.SelectedValue = info.TemplateName;
                    }

                    txtDesc.Text = info.Desc;
                    txtDefaultQcode.Text = info.DefaultQcode;
                    ddlUserAdTypeId.SelectedValue = info.UserAdTypeId.ToString();
                    ddlPlatformType.SelectedValue = info.PlatformType;
                    ddlSiteType.SelectedValue = info.SiteTypeId.ToString();
                    txtAdTimeEnd.Value = info.AdTimeEnd;
                    txtAdTimeStart.Value = info.AdTimeStart;
                    btnEdit.Visible = true;

                    txtWeiXinName.Text = info.QcodeImg2;
                    txtDefaultWeiXinName.Text = info.DefaultQcode2;
                    txtDomainList.Text = info.DomainList;
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
            AdPageInfoVO info = new AdPageInfoVO();
            info.Title = txtTitle.Text;
            info.UserId = Account.UserId;
            info.AdType = 0;
            info.Content = hidContent.Value;
            info.CreateDate = DateTime.Now;
            info.LastDate = DateTime.Now;
            info.WeiXinUrl = txtWeiXinUrl.Value;
            info.ViewPage = txtPage.Value;
            info.QcodeImg = txtQcode.Text;
            info.TitleImg = imgPerview.ImageUrl;
            info.TitleShort = txtTitleShort.Text;
            info.UserCode = hidUserCode.Value;
            info.StartTime = DateTime.Now;
            info.TemplateName = ddlTemplate.SelectedValue;
            info.CreateUserId = Account.UserId;
            info.TemplateName = ddlTemplate.SelectedValue;
            info.StaticContent = hidStaticContent.Value;
            info.DefaultQcode = txtDefaultQcode.Text;
            info.Desc = txtDesc.Text;
            info.SiteTypeId = int.Parse(ddlSiteType.SelectedValue);
            info.PlatformType = ddlPlatformType.SelectedValue;
            info.UserAdTypeId = int.Parse(ddlUserAdTypeId.SelectedValue);
            info.AdTimeEnd = txtAdTimeEnd.Value;
            info.AdTimeStart = txtAdTimeStart.Value;
            info.DeleteDate = DateTime.Now;
            info.QcodeImg2 = txtWeiXinName.Text;
            info.DefaultQcode2 = txtDefaultWeiXinName.Text;
            info.DomainList = txtDomainList.Text;

            int adid = AdPageInfoBLL.Instance.AddIdentity(info);
            AdPageInfoBLL.Instance.CreateAdPage(info.ViewPage, ddlTemplate.SelectedValue, adid);
            AdPageInfoBLL.Instance.Refresh();
            Response.Redirect("/Accounts/Pages/AdPageList.aspx");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            var info = AdPageInfoBLL.Instance.GetSingle(new AdPageInfoPara() { Id = int.Parse(hidId.Value), UserId = Account.UserId });
            if (info != null)
            {
                info.Title = txtTitle.Text;
                info.UserId = Account.UserId;
                info.Content = hidContent.Value;
                info.LastDate = DateTime.Now;
                info.WeiXinUrl = txtWeiXinUrl.Value;
                info.ViewPage = txtPage.Value;
                info.QcodeImg = txtQcode.Text;
                info.TitleImg = imgPerview.ImageUrl;
                info.TitleShort = txtTitleShort.Text;
                info.UserCode = hidUserCode.Value;
                info.TemplateName = ddlTemplate.SelectedValue;
                info.StaticContent = hidStaticContent.Value;
                info.DefaultQcode = txtDefaultQcode.Text;
                info.Desc = txtDesc.Text;
                info.SiteTypeId = int.Parse(ddlSiteType.SelectedValue);
                info.PlatformType = ddlPlatformType.SelectedValue;
                info.UserAdTypeId = int.Parse(ddlUserAdTypeId.SelectedValue);
                info.AdTimeEnd = txtAdTimeEnd.Value;
                info.AdTimeStart = txtAdTimeStart.Value;
                info.QcodeImg2 = txtWeiXinName.Text;
                info.DefaultQcode2 = txtDefaultWeiXinName.Text;
                info.DomainList = txtDomainList.Text;

                AdPageInfoBLL.Instance.Edit(info);
                AdPageInfoBLL.Instance.CreateAdPage(info.ViewPage, ddlTemplate.SelectedValue, info.Id);
                AdPageInfoBLL.Instance.Refresh();
                Response.Redirect("/Accounts/Pages/AdPageList.aspx");
            }
        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            UploadItem info = new UploadItem("weixinad", flTitleImg);
            var url = UploadHelper.Upload(info);
            imgPerview.ImageUrl = url;
        }
        protected void btnGather_Click(object sender, EventArgs e)
        {
            var adpage = AdPageInfoBLL.Instance.GetWeiXin(txtWeiXinUrl.Value);
            if (adpage != null)
            {
                if (!string.IsNullOrEmpty(adpage.Title))
                {
                    txtTitle.Text = adpage.Title.Trim();
                }
                if (!string.IsNullOrEmpty(adpage.Content))
                {
                    hidContent.Value = adpage.Content;
                }
            }

            BindImg();
        }

        protected void btnBindImg_Click(object sender, EventArgs e)
        {
            BindImg();
        }

        protected void btnRefImg_Click(object sender, EventArgs e)
        {
            //刷新图片，随机加图片水印
            string html = hidContent.Value;
            html = DN.Framework.Utility.HtmlHelper.DecodeHtml(html);

            if (!string.IsNullOrEmpty(html))
            {
                string nhtml = DownloadHtml(html);
                hidContent.Value = nhtml;
            }
        }

        Random m_rd = new Random();

        /// <summary>
        /// 自动保存图片
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string DownloadHtml(string text)
        {
            string temp = DN.Framework.Utility.HtmlHelper.DecodeHtml(text);
            var list = AdPageInfoBLL.Instance.GetPadSrcImg(temp);
            Dictionary<string, string> ilist = new Dictionary<string, string>();

            //透明度1-100之间，值越大，越不透明
            int quality = DN.WeiAd.Business.Config.AppConfig.ImgQuality;
            //水印文字
            string wenzhi = DN.WeiAd.Business.Config.AppConfig.ImgWenZhi;
            if (quality != 0)
            {
                foreach (var item in list)
                {
                    int point = m_rd.Next(1, 9);
                    if (item.StartsWith("/"))
                    {
                        try
                        {
                            string filepath = Server.MapPath(item);
                            string extfile = Path.GetExtension(filepath);
                            string newfile = filepath.Replace(extfile, "_sywz_" + extfile);
                            System.Drawing.Image img = System.Drawing.Image.FromFile(filepath);

                            DN.Framework.Utility.ImageHelper.ImageWaterMarkText(img, newfile, wenzhi, point, quality, "宋体", 26);

                            ilist.Add(item, item.Replace(extfile, "_sywz_" + extfile));
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }
            }

            foreach (var item in ilist)
            {
                temp = temp.Replace(item.Key, item.Value);
            }

            text = DN.Framework.Utility.HtmlHelper.EncodeHtml(temp);

            return text;
        }

        protected void btnZip_Click(object sender, EventArgs e)
        {
            string html = hidContent.Value;
            string temp = DN.Framework.Utility.HtmlHelper.DecodeHtml(html);
            var list = AdPageInfoBLL.Instance.GetPadSrcImg(temp);
            Dictionary<string, string> ilist = new Dictionary<string, string>();

            //透明度1-100之间，值越大，越不透明
            int quality = int.Parse(txtImgLevel.Text);
            //水印文字
            string wenzhi = DN.WeiAd.Business.Config.AppConfig.ImgWenZhi;
            foreach (var item in list)
            {
                if (item.StartsWith("/"))
                {
                    try
                    {
                        string filepath = Server.MapPath(item);
                        string extfile = Path.GetExtension(filepath);
                        string newfile = filepath;
                        string filename = Path.GetFileName(newfile);
                        string filedir = Path.GetDirectoryName(newfile);
                        System.Drawing.Image img = System.Drawing.Image.FromFile(filepath);
                        StreamReader reader = new StreamReader(filepath);
                        DN.Framework.Utility.ImageHelper.CompressImage(reader.BaseStream, filename, filedir, quality);

                        ilist.Add(item, item.Replace(extfile, "_" + quality.ToString() + extfile));
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }

            foreach (var item in ilist)
            {
                temp = temp.Replace(item.Key, item.Value);
            }

            string text = DN.Framework.Utility.HtmlHelper.EncodeHtml(temp);
            hidContent.Value = temp;
        }
    }
}