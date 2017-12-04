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

namespace WebApp.Accounts.Pages
{
    public partial class ChangAdHtml : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hidAdId.Value = Request.Params["adid"] ?? "0";
                BindPage();
            }
        }

        private void BindPage()
        {
            var tlist = AdPageInfoBLL.Instance.GetTemplateSett();
            ddlTemplate.Items.Clear();
            foreach (var item in tlist)
            {
                ddlTemplate.Items.Add(item);
            }

            var info = AdPageInfoBLL.Instance.GetSingle(new AdPageInfoPara() { Id = int.Parse(hidAdId.Value) });
            if (info != null)
            {
                ltTitle.Text = info.Title;
                hyplnkMiddle.Text = info.MiddlePage;
                hyplnkMiddle.NavigateUrl = info.MiddlePage;

                var list = AdUserPageBLL.Instance.GetModels(new AdUserPagePara() { AdPageId = info.Id });
                rptTable.DataSource = list;
                rptTable.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            var info = AdPageInfoBLL.Instance.GetSingle(new AdPageInfoPara() { Id = int.Parse(hidAdId.Value) });
            if (info != null)
            {
                string template = ddlTemplate.SelectedValue;
                var result = AdPageInfoBLL.Instance.ChangeAdPage(info.ViewPage, template);
                sb.AppendFormat("{0}-{1},", info.ViewPage, result);
                var list = AdUserPageBLL.Instance.GetModels(new AdUserPagePara() { AdPageId = info.Id });
                foreach (var item in list)
                {
                    var result1 = AdPageInfoBLL.Instance.ChangeAdPage(item.PageName, template);
                    AdUserPageBLL.Instance.Edit(item);
                    sb.AppendFormat("{0}-{1},", item.PageName, result1);
                    item.FlowLastDate = DateTime.Now;
                }
            }

            lblMsg.Text = sb.ToString();
        }

        protected void btnMiddle_Click(object sender, EventArgs e)
        {
            var info = AdPageInfoBLL.Instance.GetSingle(new AdPageInfoPara() { Id = int.Parse(hidAdId.Value) });
            if (info != null)
            {
                string pagename = AdPageInfoBLL.Instance.CreateMiddlePage(info);
                info.MiddlePage = pagename;
                AdPageInfoBLL.Instance.Edit(info);
                hyplnkMiddle.Text = info.MiddlePage;
                hyplnkMiddle.NavigateUrl = info.MiddlePage + "?t=" + DateTime.Now.ToString("hhmmss");
            }
        }

        protected void btnJsHtml_Click(object sender, EventArgs e)
        {
            var info = AdPageInfoBLL.Instance.GetSingle(new AdPageInfoPara() { Id = int.Parse(hidAdId.Value) });
            if (info != null)
            {
                string adurl = AdPageInfoBLL.Instance.CreateJSFile(info);
                hyplnkJsHtml.Text = adurl;
                hyplnkJsHtml.NavigateUrl = adurl;
            }
        }
    }
}