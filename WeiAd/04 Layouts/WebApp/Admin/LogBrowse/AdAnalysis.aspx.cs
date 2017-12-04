using DN.WeiAd.Business;
using DN.WeiAd.Business.Entity.Analysis;
using DN.WeiAd.Business.Pages;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.Admin.LogBrowse
{
    public partial class AdAnalysis : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtTime.Value = DateTime.Now.ToString("yyyy-MM-dd");
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
            var list = AccountInfoBLL.Instance.GetModels(new DN.WeiAd.Models.AccountInfoPara() { UserType = 0 });
            ddlAdUserId.Items.Clear();
            foreach (var item in list)
            {
                ListItem li = new ListItem();
                li.Text = item.UserName;
                li.Value = item.Id.ToString();
                ddlAdUserId.Items.Add(li);
            }
            ddlAdUserId.Items.Insert(0, new ListItem() { Text = "选择广告主", Value = "" });
        }

        private void Bind()
        {
            QueryGroupInfo query = new QueryGroupInfo();
            query.Time = DN.WeiAd.Framework.TimeHelper.ConverTimeByString(txtTime.Value);
            query.GroupBy = "time,AdId ";
            query.OrderBy = " time desc,adid desc ";

            if(!string.IsNullOrEmpty(ddlAdUserId.SelectedValue))
            {
                query.AdUserID = int.Parse(ddlAdUserId.SelectedValue);
            }

            DataTable table = LogBrowseAnalysisBLL.Instance.GetAnalysis(query);
            rptTable.DataSource = table;
            rptTable.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Bind();
        }
    }
}