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

namespace WebApp.Admin.Ads
{
    public partial class AdPageCopy : BasePageAdmin
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
                ltAdUrl.Text = AdPageInfoBLL.Instance.GetAdViewUrl(info.ViewPage);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            var info = AdPageInfoBLL.Instance.GetSingle(new AdPageInfoPara() { Id = int.Parse(hidAdId.Value) });
            string template = ddlTemplate.SelectedValue;
            if (info != null)
            {
                int max = int.Parse(txtNum.Text);
                for (int i = 0; i < max; i++)
                {
                    AdPageInfoVO adinfo = (AdPageInfoVO)info.Clone();
                    adinfo.ViewPage = AdPageInfoBLL.Instance.GetPageName(template);
                    adinfo.CreateDate = DateTime.Now;
                    if(AdPageInfoBLL.Instance.CreateAdPage(adinfo.ViewPage,DN.WeiAd.Business.Config.AppConfig.TemplateName))
                    {
                        var result = AdPageInfoBLL.Instance.Add(adinfo);
                        sb.AppendFormat("{0}-{1},", adinfo.ViewPage, result);
                        sb.AppendLine();
                    }

                }
                ltTitle.Text = info.Title;
                ltAdUrl.Text = AdPageInfoBLL.Instance.GetAdViewUrl(info.ViewPage);
            }

            lblMsg.Text = sb.ToString();
        }
    }
}