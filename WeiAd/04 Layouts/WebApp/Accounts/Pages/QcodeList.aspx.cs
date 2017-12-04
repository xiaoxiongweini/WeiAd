﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DN.WeiAd.Models;
using DN.WeiAd.Business;
using DN.WeiAd.Business.Pages;


namespace WebApp.Accounts.Pages
{
    public partial class QcodeList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hidAdId.Value = Request.Params["adid"] ?? "0";
                hidQcodeId.Value = Request.Params["id"] ?? "0";

                string isdel = Request.Params["isdel"] ?? "";
                if (isdel == "1")
                {
                    AdQcodeInfoPara ap = new AdQcodeInfoPara();
                    ap.Id = int.Parse(hidQcodeId.Value);
                    ap.AdUserId = Account.UserId;
                    var qinfo = AdQcodeInfoBLL.Instance.GetSingle(ap);
                    if (qinfo != null)
                    {
                        AdQcodeInfoBLL.Instance.Delete(ap);

                        var adinfo = AdPageInfoBLL.Instance.GetSingle(new AdPageInfoPara() { Id = qinfo.AdId });
                        if (adinfo != null)
                        {
                            adinfo.QcodeCount = AdQcodeInfoBLL.Instance.GetRecords(new AdQcodeInfoPara() { AdId = qinfo.AdId });
                            adinfo.LastDate = DateTime.Now;
                            AdPageInfoBLL.Instance.Edit(adinfo);
                        }
                    }
                }
                
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
            AdQcodeInfoPara cip = new AdQcodeInfoPara();
            cip.PageIndex = pageIndex - 1;
            cip.PageSize = 10;
            cip.AdUserId = Account.UserId;
            cip.AdId = int.Parse(hidAdId.Value);
            cip.OrderBy = " id desc ";

            var list = AdQcodeInfoBLL.Instance.GetModels(ref cip);
            rptTable.DataSource = list;
            rptTable.DataBind();

            apPager.RecordCount = cip.Recount.Value;
        }

        protected void apPager_PageChanged(object sender, EventArgs e)
        {
            Bind(apPager.CurrentPageIndex);
        }

        protected void btnReface_Click(object sender, EventArgs e)
        {
            AdQcodeInfoBLL.Instance.Refresh();
        }
    }
}