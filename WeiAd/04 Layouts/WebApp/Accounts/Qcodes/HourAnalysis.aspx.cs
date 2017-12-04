using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DN.WeiAd.Models;
using DN.WeiAd.Business;
using DN.WeiAd.Business.Pages;
using DN.WeiAd.Business.Entity.Analysis;
using System.Data;

namespace WebApp.Accounts.Qcodes
{
    public partial class HourAnalysis : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtTime.Value = DateTime.Now.ToString("yyyy-MM-dd");

                hidAdId.Value = Request.Params["adid"] ?? "";

                string time = Request.Params["time"] ?? "";
                if (!string.IsNullOrEmpty(time))
                {
                    txtTime.Value = DN.WeiAd.Framework.TimeHelper.ConverTimeByString(time).ToString("yyyy-MM-dd");
                }

                BindPage();
                Bind();
            }
        }

        private void BindPage()
        {
            var list = AdPageInfoBLL.Instance.GetModels(new AdPageInfoPara() { UserId = Account.UserId });
            ddlAdPage.Items.Clear();
            foreach (var item in list)
            {
                ListItem li = new ListItem();
                li.Text = item.Id.ToString() + "__" + item.Title;
                li.Value = item.Id.ToString();
                ddlAdPage.Items.Add(li);
            }
            ddlAdPage.Items.Insert(0, new ListItem() { Text = "不限", Value = "" });

            if (!string.IsNullOrEmpty(hidAdId.Value))
            {
                plSearch.Visible = false;
                ddlAdPage.SelectedValue = hidAdId.Value;
            }
        }

        private void Bind()
        {
            ltStime.Text = txtTime.Value;
            ltAdTitle.Text = ddlAdPage.SelectedItem.Text;

            QcodeQueryInfo query = new QcodeQueryInfo();
            query.Time = int.Parse(DN.WeiAd.Framework.TimeHelper.ConverTimeByString(txtTime.Value).ToString("yyyyMMdd"));
            query.GroupBy = " time ";
            query.OrderBy = "time desc ";
            query.AdUserId = Account.UserId;

            if (!string.IsNullOrEmpty(ddlAdPage.SelectedValue))
            {
                query.AdId = int.Parse(ddlAdPage.SelectedValue);
            }


            DataTable table = LogAdQcodeBLL.Instance.GetAnalysis(query);

            if (table.Rows.Count != 0)
            {
                ltIp.Text = table.Rows[0]["ipcount"].ToString();
                ltPv.Text = table.Rows[0]["pvcount"].ToString();
                ltUv.Text = table.Rows[0]["uvcount"].ToString();

                ltIp1.Text = table.Rows[0]["ipcount"].ToString();
                ltPv1.Text = table.Rows[0]["pvcount"].ToString();
                ltUv1.Text = table.Rows[0]["uvcount"].ToString();
            }
            else
            {
                ltIp.Text = "0";
                ltPv.Text = "0";
                ltUv.Text = "0";

                ltIp1.Text = "0";
                ltPv1.Text = "0";
                ltUv1.Text = "0";
            }

            DataTable table1 = LogAdQcodeBLL.Instance.GetBrowseHour(query);

            int hour = int.Parse(DateTime.Now.ToString("HH"));
            if (query.Time.Value != int.Parse(DateTime.Now.ToString("yyyyMMdd")))
            {
                hour = 24;
            }
            var chart = ChartComonBLL.GetAdBrowseHour(table1, hour);
            hidDataJson.Value = DN.Framework.Utility.Serializer.SerializeObject(chart);

            rptTable.DataSource = table1;
            rptTable.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Bind();
        }
    }
}