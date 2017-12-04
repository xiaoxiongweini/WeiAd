using DN.WeiAd.Business;
using DN.WeiAd.Business.Entity.Analysis;
using DN.WeiAd.Business.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.Admin.Qcode
{
    public partial class DayAnalysis : BasePageAdmin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
        }

        private void Bind(int pageIndex = 1)
        {
            QcodeQueryInfo query = new QcodeQueryInfo();
            query.TimeStart = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-01"));
            query.TimeEnd = DateTime.Now;
            query.GroupBy = "time";
            query.OrderBy = " time desc ";
            var list = LogAdQcodeBLL.Instance.GetAnalysis(query);
            rptTable.DataSource = list;
            rptTable.DataBind();
        }
    }
}