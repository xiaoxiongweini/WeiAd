using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DN.WeiAd.Business.Pages;
using DN.WeiAd.Business;

namespace WebApp.Accounts.Ads
{
    public partial class AdFullChart : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hidAdId.Value = Request.Params["adid"] ?? "0";
                Bind();
            }
        }

        private void Bind()
        {
            
            //var adinfo = AdInfoBLL.Instance.GetSingle(new DN.WeiAd.Models.AdInfoPara() { Id = int.Parse(hidAdId.Value) });
            //if (adinfo != null)
            //{
            //    hidTitle.Value = adinfo.Title;
            //    var chart = ChartBLL.Instance.GetChartByAd(Account.UserId, int.Parse(hidAdId.Value));
            //    hidDataJson.Value = DN.Framework.Utility.Serializer.SerializeObject(chart);
            //}
        }
    }
}