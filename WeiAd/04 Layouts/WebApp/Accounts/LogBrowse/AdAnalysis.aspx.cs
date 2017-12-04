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

namespace WebApp.Accounts.LogBrowse
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
                Bind();
            }
        }

        private void Bind()
        {
            QueryGroupInfo query = new QueryGroupInfo();
            query.Time = DN.WeiAd.Framework.TimeHelper.ConverTimeByString(txtTime.Value);
            query.GroupBy = "time,AdId ";
            query.OrderBy = " time desc,adid desc ";
            query.AdUserID = Account.UserId;

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