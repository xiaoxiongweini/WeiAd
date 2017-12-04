using DN.WeiAd.Business.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DN.WeiAd.Models;
using DN.WeiAd.Business;
using System.Text;
using System.IO;
using DN.WeiAd.Business.Config;

namespace WebApp.Admin.Sys
{
    public partial class TemplateEdit : BasePageAdmin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindPage();
            }
        }

        private void BindPage()
        {
            var list = AdPageInfoBLL.Instance.GetTemplateSett();
            ddlTemplate.Items.Clear();
            foreach (var item in list)
            {
                ddlTemplate.Items.Add(item);
            }
        }

        protected void btnBuilder_Click(object sender, EventArgs e)
        {
            var list = AdPageInfoBLL.Instance.GetModels(new AdPageInfoPara());
            var uplist = AdUserPageBLL.Instance.GetModels(new AdUserPagePara());

            StringBuilder sb = new StringBuilder();
            string template = ddlTemplate.SelectedValue;
            string pagetName = string.Empty;
            foreach (var item in uplist)
            {
                var isedit = false;
                if (item.PageName.IndexOf(".")==-1)
                {
                    item.PageName = item.PageName + template.Substring(template.IndexOf("."));
                    isedit = true;
                }
                var result = AdPageInfoBLL.Instance.ChangeAdPage(item.PageName, template);
                if (isedit)
                {
                    AdUserPageBLL.Instance.Edit(item);
                }
                sb.AppendFormat("UserPage:{0},{1}", item.PageName, result);
                sb.AppendLine();
            }

            foreach (var item in list)
            {
                var isedit = false;
                if (item.ViewPage.IndexOf(".") == -1)
                {
                    item.ViewPage = item.ViewPage + template.Substring(template.IndexOf("."));
                    isedit = true;
                }
                var result = AdPageInfoBLL.Instance.ChangeAdPage(item.ViewPage, template);
                if (isedit)
                {
                    AdPageInfoBLL.Instance.Edit(item);
                }
                sb.AppendFormat("AdPage:{0},{1}", item.ViewPage, result);
                sb.AppendLine();
            }

            lblMsg.Text = sb.ToString();
        }

        protected void btnMiddlePage_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            var list = AdPageInfoBLL.Instance.GetModels(new AdPageInfoPara());
            foreach (var info in list)
            {
                string pagename = AdPageInfoBLL.Instance.CreateMiddlePage(info);
                info.MiddlePage = pagename;
                info.LastDate = DateTime.Now;
                AdPageInfoBLL.Instance.Edit(info);
                sb.AppendFormat("广告ID：{0}，中间页：{1}", info.Id, info.MiddlePage);
                sb.AppendLine("<br />");
            }

            ltMiddle.Text = sb.ToString();
        }

        protected void btnTemplate_Click(object sender, EventArgs e)
        {
            var list = AdPageInfoBLL.Instance.GetModels(new AdPageInfoPara());
            var uplist = AdUserPageBLL.Instance.GetModels(new AdUserPagePara());

            StringBuilder sb = new StringBuilder();
            string template = AppConfig.TemplateName;
            string pagetName = string.Empty;
            foreach (var item in uplist)
            {
                var adinfo = list.SingleOrDefault(p => p.Id == item.AdPageId);
                if(adinfo!= null)
                {
                    if (!string.IsNullOrEmpty(adinfo.TemplateName))
                    {
                        template = adinfo.TemplateName;
                    }                    
                }

                var isedit = false;
                if (item.PageName.IndexOf(".") == -1)
                {
                    item.PageName = item.PageName + template.Substring(template.IndexOf("."));
                    isedit = true;
                }
                var result = AdPageInfoBLL.Instance.ChangeAdPage(item.PageName, template);
                if (isedit)
                {
                    AdUserPageBLL.Instance.Edit(item);
                }
                sb.AppendFormat("UserPage:{0},{1}", item.PageName, result);
                sb.AppendLine();
            }

            foreach (var item in list)
            {
                var isedit = false;
                if (item.ViewPage.IndexOf(".") == -1)
                {
                    item.ViewPage = item.ViewPage + template.Substring(template.IndexOf("."));
                    isedit = true;
                }
                var result = AdPageInfoBLL.Instance.ChangeAdPage(item.ViewPage, template);
                if (isedit)
                {
                    AdPageInfoBLL.Instance.Edit(item);
                }
                sb.AppendFormat("AdPage:{0},{1}", item.ViewPage, result);
                sb.AppendLine();
            }

            lblMsg.Text = sb.ToString();
        }

        protected void btnQcode_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            var list = AdPageInfoBLL.Instance.GetModels(new AdPageInfoPara() { IsDel = 0 });
            var ulist = AdQcodeInfoBLL.Instance.GetModels(new AdQcodeInfoPara());
            foreach (var item in list)
            {
                if (string.IsNullOrEmpty(item.DefaultQcode))
                {
                    var tulist = ulist.Where(p => p.AdId == item.Id).ToList<AdQcodeInfoVO>();
                    if (tulist.Count() >= 1)
                    {
                        item.DefaultQcode = tulist[0].QcodeUrl;
                        AdPageInfoBLL.Instance.Edit(item);
                        sb.AppendFormat("广告ID：{0},更新Qcode：{1}<br />", item.Id, item.DefaultQcode);                        
                    }
                }
            }
            ltMiddle.Text = sb.ToString();

            AdPageInfoBLL.Instance.Refresh();
        }

        protected void btnAdPagetCount_Click(object sender, EventArgs e)
        {
            var list = AdPageInfoBLL.Instance.GetModels(new AdPageInfoPara());
            var qlist = AdQcodeInfoBLL.Instance.GetModels(new AdQcodeInfoPara());
            var uplist = AdUserPageBLL.Instance.GetModels(new AdUserPagePara());
            foreach (var item in list)
            {
                item.QcodeCount = qlist.Count(p => p.AdId == item.Id);
                item.PageCount = uplist.Count(p => p.AdPageId == item.Id);
                AdPageInfoBLL.Instance.Edit(item);
            }

            AdPageInfoBLL.Instance.Refresh();
        }
    }
}