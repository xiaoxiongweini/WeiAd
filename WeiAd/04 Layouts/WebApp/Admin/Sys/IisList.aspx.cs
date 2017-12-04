using DN.WeiAd.Business.Pages;
using DN.WeiAd.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.Admin.Sys
{
    public partial class IisList : BasePageAdmin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindPage();
            }
        }

        private void BindPage()
        {
            IisHelper.GetSites();
        }
    }
}