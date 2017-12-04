using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DN.WeiAd.Models;
using DN.WeiAd.Business;
using DN.WeiAd.Business.Pages;

namespace WebApp.Accounts.Ads
{
    public partial class AdDayChart : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Bind();
            }
        }

        private void Bind()
        {
            var chart = ChartBLL.Instance.GetAdBrowseHour(Account.UserId);
            hidDataJson.Value = DN.Framework.Utility.Serializer.SerializeObject(chart);
        }
    }
}