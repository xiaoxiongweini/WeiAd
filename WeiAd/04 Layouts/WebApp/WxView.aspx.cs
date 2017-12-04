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
    public partial class WxView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                var id = Request.Params["id"] ?? "0";

                var info = AdPageInfoBLL.Instance.GetSingle(new AdPageInfoPara() { Id = int.Parse(id) });
                if(info!= null)
                {
                    ltPageTitle.Text = info.Title;
                    ltTitle.Text = info.Title;
                    ltContent.Text = DN.Framework.Utility.HtmlHelper.DecodeHtml(info.Content);
                    var usercode = UserCodeInfoBLL.Instance.GetSingle(new UserCodeInfoPara() { Id = info.UserCodeId });
                    if (usercode != null)
                    {
                        ltUserCode.Text = DN.Framework.Utility.HtmlHelper.DecodeHtml(usercode.CodeContent);
                    }
                }
            }
        }
    }
}