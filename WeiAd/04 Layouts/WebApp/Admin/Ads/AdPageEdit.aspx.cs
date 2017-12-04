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
using System.IO.Compression;

namespace WebApp.Admin.Ads
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
            
            var adlist = AccountInfoBLL.Instance.GetModels(new AccountInfoPara() { IsNotAdmin = true });

            ddlAdUserName.Items.Clear();
            foreach (var item in adlist)
            {
                ddlAdUserName.Items.Add(new ListItem() { Text = item.UserName + AccountInfoBLL.Instance.GetUserTypeNameById(item.UserType), Value = item.Id.ToString() });
            }
            //ddlAdUserName.DataSource = adlist;
            //ddlAdUserName.DataTextField = "UserName";
            //ddlAdUserName.DataValueField = "Id";
            //ddlAdUserName.DataBind();

            rdlstState.DataSource = AdPageInfoBLL.Instance.GetStates();
            rdlstState.DataTextField = "Name";
            rdlstState.DataValueField = "Id";
            rdlstState.DataBind();
            rdlstState.SelectedIndex = 0;

            if (!string.IsNullOrEmpty(hidId.Value))
            {
                var info = AdPageInfoBLL.Instance.GetSingle(new AdPageInfoPara() { Id = int.Parse(hidId.Value) });
                if (info != null)
                {
                    txtTitle.Value = info.Title;
                    hidContent.Value = info.Content;
                    txtWeiXinUrl.Value = info.WeiXinUrl;
                    txtPage.Value = info.ViewPage;
                    hidUserCode.Value = info.UserCode;
                    imgPerview.ImageUrl = info.TitleImg;
                    txtMoney.Value = info.Money.ToString("0.00");
                    txtMoneyCount.Value = info.MoneyCount.ToString("0.00");
                    txtPlanIp.Value = info.PlanIp.ToString();
                    txtTitleShort.Text = info.TitleShort;
                    txtUserCode.Text = DN.Framework.Utility.HtmlHelper.DecodeHtml(hidUserCode.Value);
                    ddlAdUserName.SelectedValue = info.UserId.ToString();
                    txtQcodeImg.Text = info.QcodeImg;
                    hidStaticContent.Value = info.StaticContent;
                    ddlTemplate.SelectedValue = info.TemplateName;
                    txtDefaultQcode.Text = info.DefaultQcode;
                    btnEdit.Visible = true;
                    txtQcodeImg2.Text = info.QcodeImg2;
                    txtDefaultQcode2.Text = info.DefaultQcode2;
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
            info.Title = txtTitle.Value;
            info.UserId = int.Parse(ddlAdUserName.SelectedValue);
            info.AdType = 0;
            info.Content = hidContent.Value;
            info.CreateDate = DateTime.Now;
            info.LastDate = DateTime.Now;
            info.Title = txtTitle.Value;
            info.TitleImg = imgPerview.ImageUrl;
            info.WeiXinUrl = txtWeiXinUrl.Value;
            info.ViewPage = txtPage.Value;
            info.Money = DbConvert.GetDecimal(txtMoney.Value, 0);
            info.QcodeImg = txtQcodeImg.Text;
            info.BuyMoney = 0;
            info.MoneyCount = DbConvert.GetDecimal(txtMoneyCount.Value, 0);
            int planip = 0;
            if (!string.IsNullOrEmpty(txtPlanIp.Value))
            {
                planip = DbConvert.GetInt(txtPlanIp.Value);
            }
            info.PlanIp = planip;

            info.PlanTerminal = 0;
            info.StartTime = DateTime.Now;
            info.UserCode = hidUserCode.Value;
            info.TemplateName = ddlTemplate.SelectedValue;
            info.CreateUserId = Account.UserId;
            info.StaticContent = hidStaticContent.Value;
            info.DeleteDate = DateTime.Now;
            info.DefaultQcode = txtQcodeImg.Text;
            info.QcodeImg2 = txtQcodeImg2.Text;
            info.DefaultQcode2 = txtDefaultQcode2.Text;
            info.DomainList = txtDomainList.Text;
            info.TitleShort = txtTitleShort.Text;

            int adid = AdPageInfoBLL.Instance.AddIdentity(info);
            if (AdPageInfoBLL.Instance.CreateAdPage(info.ViewPage, ddlTemplate.SelectedValue, adid))
            {
                Response.Redirect("/Admin/Ads/AdPageList.aspx");
            }
            else
            {
                lblMsg.Text = "【广告页面】己经存在。";
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

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            var info = AdPageInfoBLL.Instance.GetSingle(new AdPageInfoPara() { Id = int.Parse(hidId.Value) });
            if (info != null)
            {
                info.Title = txtTitle.Value;
                info.UserId = int.Parse(ddlAdUserName.SelectedValue);
                info.Content = hidContent.Value;
                info.LastDate = DateTime.Now;
                info.Title = txtTitle.Value;
                info.WeiXinUrl = txtWeiXinUrl.Value;
                info.ViewPage = txtPage.Value;
                info.Money = DbConvert.GetDecimal(txtMoney.Value, 0);
                info.PlanIp = DbConvert.GetInt(txtPlanIp.Value, 0);
                info.UserCode = hidUserCode.Value;
                info.QcodeImg = txtQcodeImg.Text;

                info.TitleImg = imgPerview.ImageUrl;
                info.TitleShort = txtTitleShort.Text;
                info.MoneyCount = DbConvert.GetDecimal(txtMoneyCount.Value, 0);
                int planip = 0;
                if (!string.IsNullOrEmpty(txtPlanIp.Value))
                {
                    planip = DbConvert.GetInt(txtPlanIp.Value);
                }
                info.PlanIp = planip;
                info.TemplateName = ddlTemplate.SelectedValue;
                info.StaticContent = hidStaticContent.Value;
                info.DefaultQcode = txtQcodeImg.Text;

                info.QcodeImg2 = txtQcodeImg2.Text;
                info.DefaultQcode2 = txtDefaultQcode2.Text;
                info.DomainList = txtDomainList.Text;
                info.TitleShort = txtTitleShort.Text;

                if (AdPageInfoBLL.Instance.CreateAdPage(info.ViewPage, ddlTemplate.SelectedValue, info.Id))
                {
                    AdPageInfoBLL.Instance.Edit(info);
                }
                else
                {
                    lblMsg.Text = "【广告页面】己经存在。";
                }

                AdPageInfoBLL.Instance.Refresh();
                Response.Redirect("/Admin/Ads/AdPageList.aspx");
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
                    hidContent.Value = adpage.Content;
                }
            }
            BindImg();
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            UploadItem info = new UploadItem("weixinad", flTitleImg);
            var url = UploadHelper.Upload(info);
            imgPerview.ImageUrl = url;
        }

        protected void btnDownloadImg_Click(object sender, EventArgs e)
        {
            string html = AdPageInfoBLL.Instance.DownloadHtml(hidContent.Value);
            hidContent.Value = html;
            BindImg();
        }

        protected void btnUploadFile_Click(object sender, EventArgs e)
        {
            UploadItem info = new UploadItem("wenaan", flFile);
            var url = UploadHelper.Upload(info);
            

            string filepath = Server.MapPath(url);
            string fileName = Path.GetFileName(filepath);
            string fileExt = Path.GetExtension(filepath);
            string dir = Server.MapPath(UploadHelper.UPLOAD_DIRECTORY + "wenan");
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            string ndir = fileName.Replace(fileExt, "");

            //文件必须是index.html，同时对文件压缩也有要求
            string nurl = UploadHelper.UPLOAD_DIRECTORY + "wenan" + "//" + ndir + "//index.html";

            string extractPath = Path.Combine(dir, ndir);
            if (File.Exists(filepath))
            {
                ZipFile.ExtractToDirectory(filepath, extractPath);
            }

            hyplnkFile.NavigateUrl = nurl;
            hyplnkFile.Text = "打开方案";
            hyplnkFile.Target = "_blank";

            string newhtml = string.Empty;
            string nfilepath = Path.Combine(extractPath, "index.html");
            if (File.Exists(nfilepath))
            {
                using (StreamReader reader = new StreamReader(nfilepath))
                {
                    newhtml = reader.ReadToEnd();
                }
            }
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(newhtml);

            string body = doc.DocumentNode.SelectSingleNode("/html/body").InnerHtml;
            var imglist = doc.DocumentNode.SelectNodes("//img");

            //图片去重功能
            List<string> ilist = new List<string>();
            foreach (var item in imglist)
            {
                var img = item.OuterHtml;
                var imgsrc = item.GetAttributeValue("src", "");
                ilist.Add(imgsrc);
            }
            var tilist = ilist.Distinct<string>().ToList<string>();
            foreach (var imgsrc in tilist)
            {
                string nimgsrc = UploadHelper.UPLOAD_DIRECTORY + "wenan" + "//" + ndir + "//" + imgsrc;
                body = body.Replace(imgsrc, nimgsrc);
            }

            hidContent.Value = DN.Framework.Utility.HtmlHelper.EncodeHtml(body);
            //找出所有的CSS文件
            var stylelist = doc.DocumentNode.SelectNodes("//link");
            System.Text.StringBuilder sbStyle = new System.Text.StringBuilder();

            foreach (var item in stylelist)
            {
                string style = item.OuterHtml;
                string href = item.GetAttributeValue("href", "");
                string nhref = UploadHelper.UPLOAD_DIRECTORY + "wenan" + "//" + ndir + "//" + href;
                sbStyle.Append(style.Replace(href, nhref));
                sbStyle.AppendLine();
            }
            hidStaticContent.Value = DN.Framework.Utility.HtmlHelper.EncodeHtml(sbStyle.ToString());
        }

        protected void btnImportAliyun_Click(object sender, EventArgs e)
        {
            //导入到远程服务器
            string html = hidContent.Value;
            Dictionary<string, string> imgs = AdPageInfoBLL.Instance.PutAliyun(html);
            string nhtml = DN.Framework.Utility.HtmlHelper.DecodeHtml(html);            
            foreach (var item in imgs)
            {
                nhtml = nhtml.Replace(item.Key, item.Value);
            }
            if (nhtml.IndexOf("<img") != -1)
            {
                hidContent.Value = DN.Framework.Utility.HtmlHelper.EncodeHtml(nhtml);
            }
            else
            {
                hidContent.Value = DN.Framework.Utility.HtmlHelper.DecodeHtml(nhtml);
            }
            BindImg();
        }

        protected void btnBindImg_Click(object sender, EventArgs e)
        {
            BindImg();
        }

        protected void btnZip_Click(object sender, EventArgs e)
        {
            string html = DN.Framework.Utility.HtmlHelper.DecodeHtml(hidContent.Value);
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