using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DN.WeiAd.Business;
using DN.WeiAd.Business.Pages;

namespace WebApp.Accounts.Ads
{
    public partial class DayChart : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
            }
        }

        private void Bind()
        {
            var chart = ChartBLL.Instance.GetAdBrowseDay(Account.UserId);
            hidDataJson.Value = DN.Framework.Utility.Serializer.SerializeObject(chart);
        }
    }
}