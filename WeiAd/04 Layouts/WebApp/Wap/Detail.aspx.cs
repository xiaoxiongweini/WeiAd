using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DN.WeiAd.Models;
using DN.WeiAd.Business;

namespace WebApp.Wap
{
    public partial class Detail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                hidId.Value = Request.Params["id"] ?? "0";
                BindPage();
                BindAd();
            }
        }

        private void BindPage()
        {
            var info = ArticleInfoBLL.Instance.GetSingle(new ArticleInfoPara() { Id = int.Parse(hidId.Value) });
            if(info!= null)
            {
                ltContent.Text = DN.Framework.Utility.HtmlHelper.DecodeHtml(info.Content);
                ltTitle.Text = info.Title;

                info.OpenCount += 1;
                ArticleInfoBLL.Instance.Edit(info);
            }
        }

        private void BindAd()
        {
            var list = DN.WeiAd.Business.AdBusiness.AdBLL.Instance.GetAdInfo(int.Parse(hidId.Value));
            rptTable.DataSource = list;
            rptTable.DataBind();
        }
    }
}