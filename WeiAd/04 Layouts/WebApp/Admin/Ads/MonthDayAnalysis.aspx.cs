using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DN.WeiAd.Models;
using DN.WeiAd.Business;
using DN.WeiAd.Business.Pages;

namespace WebApp.Admin.Ads
{
    public partial class MonthDayAnalysis : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hidFlowUserId.Value = Request.Params["flowuserid"] ?? "0";
                hidAdId.Value = Request.Params["adid"] ?? "0";

                Bind();
            }
        }

        private void Bind()
        {
            DN.WeiAd.Business.Entity.Analysis.FlowInfo flow = new DN.WeiAd.Business.Entity.Analysis.FlowInfo();
            flow.AdId = int.Parse(hidAdId.Value);
            flow.FlowUserId = int.Parse(hidFlowUserId.Value);
            flow.Time = DateTime.Now;
            var chart = AnalysisFlowBLL.Instance.GetHistoryMonthDays(flow);
            hidDataJson.Value = DN.Framework.Utility.Serializer.SerializeObject(chart);
        }
    }
}