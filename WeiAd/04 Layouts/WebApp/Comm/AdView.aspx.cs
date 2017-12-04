using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DN.WeiAd.Models;
using DN.WeiAd.Business;

namespace WebApp.Comm
{
    public partial class AdView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                hidAdId.Value = Request.Params["adid"] ?? "0";
                BindPage();
            }
        }

        private void BindPage()
        {
            var info = AdPageInfoBLL.Instance.GetSingle(new AdPageInfoPara() { Id = int.Parse(hidAdId.Value) });
            if(info!= null)
            {
                ltTitle.Text = info.Title;
                ltContent.Text = DN.Framework.Utility.HtmlHelper.DecodeHtml(info.Content);
                ltStateContent.Text = DN.Framework.Utility.HtmlHelper.DecodeHtml(info.StaticContent);
                ltStateContent1.Text = DN.Framework.Utility.HtmlHelper.DecodeHtml(info.UserCode);
            }
        }
    }
}