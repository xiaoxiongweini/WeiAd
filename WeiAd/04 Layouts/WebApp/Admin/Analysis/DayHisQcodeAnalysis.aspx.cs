﻿using DN.WeiAd.Business;
using DN.WeiAd.Business.Entity.Analysis;
using DN.WeiAd.Business.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WebApp.Admin.Analysis
{
    public partial class DayHisQcodeAnalysis : BasePage
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
            query.GroupBy = "time";
            var list = LogAdQcodeBLL.Instance.GetAnalysis(query);
            rptTable.DataSource = list;
            rptTable.DataBind();
        }
    }
}