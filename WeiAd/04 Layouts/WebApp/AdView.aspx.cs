using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DN.WeiAd.Models;
using DN.WeiAd.Business;

namespace WebApp
{
    public partial class AdView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hidAdId.Value = Request.Params["adid"] ?? "1";
                BindPage();
            }
        }

        private void BindPage()
        {
            var adinfo = AdPageInfoBLL.Instance.GetSingle(new AdPageInfoPara() { Id = int.Parse(hidAdId.Value) });
            if (adinfo != null)
            {
                ltContent.Text = DN.Framework.Utility.HtmlHelper.DecodeHtml(adinfo.Content);
                ltUserCode.Text = DN.Framework.Utility.HtmlHelper.DecodeHtml(adinfo.UserCode);
                ltStaticContent.Text = DN.Framework.Utility.HtmlHelper.DecodeHtml(adinfo.StaticContent);
            }
        }
    }
}