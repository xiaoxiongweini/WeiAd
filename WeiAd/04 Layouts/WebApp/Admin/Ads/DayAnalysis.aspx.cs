using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DN.WeiAd.Models;
using DN.WeiAd.Business;
using DN.WeiAd.Business.Entity.Analysis;
using DN.WeiAd.Business.Pages;

namespace WebApp.Admin.Ads
{
    public partial class DayAnalysis : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hidAdId.Value = Request.Params["adid"] ?? "0";

                BindPage();

                Bind();
            }
        }

        private void BindPage()
        {
            //ddlAdType.DataSource = AdPageInfoBLL.Instance.GetAdTypes();
            //ddlAdType.DataTextField = "Name";
            //ddlAdType.DataValueField = "Id";
            //ddlAdType.DataBind();

            //ddlAdType.Items.Insert(0, new ListItem() { Text = "不限广告类型", Value = "" });
            var info = AdPageInfoBLL.Instance.GetSingle(new AdPageInfoPara() { Id = int.Parse(hidAdId.Value) });
            if(info!= null)
            {
                ltAdTitle.Text = info.Title;
            }
        }

        private void Bind(int pageIndex = 1)
        {
            QueryGroupInfo query = new QueryGroupInfo();
            query.AdId = int.Parse(hidAdId.Value);
            query.GroupBy = "time"; 

            var list = AnalysisBLL.Instance.GetAnalysis(query);
            rptTable.DataSource = list;
            rptTable.DataBind();
        }
    }
}