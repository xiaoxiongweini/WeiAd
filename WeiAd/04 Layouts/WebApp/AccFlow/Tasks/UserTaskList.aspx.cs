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

namespace WebApp.AccFlow.Tasks
{
    public partial class UserTaskList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hidState.Value = Request.Params["state"] ?? "0";
                BindPage();

                Bind();
            }
        }

        private void BindPage()
        {
            //ddlAdType.DataSource = AdInfoBLL.Instance.GetAdTypes();
            //ddlAdType.DataTextField = "Name";
            //ddlAdType.DataValueField = "Id";
            //ddlAdType.DataBind();

            //ddlAdType.Items.Insert(0, new ListItem() { Text = "不限广告类型", Value = "" });
        }

        private void Bind(int pageIndex = 1)
        {
            AdUserPagePara cip = new AdUserPagePara();
            cip.PageIndex = pageIndex - 1;
            cip.PageSize = 10;
            cip.FlowUserId = Account.UserId;            
            cip.OrderBy = " id desc ";
            cip.IsState = int.Parse(hidState.Value);

            var list = AdUserPageBLL.Instance.GetModels(ref cip);
            rptTable.DataSource = list;
            rptTable.DataBind();

            QueryGroupInfo query = new QueryGroupInfo();
            query.FlowUserId = Account.UserId;
            query.Time = DateTime.Now;
            query.GroupBy = "adid";

            var table = AnalysisBLL.Instance.GetAnalysis(query);

            for (int i = 0; i < rptTable.Items.Count; i++)
            {
                HiddenField hidAdId = (HiddenField)rptTable.Items[i].FindControl("hidAdId");
                Literal ltPvCount = (Literal)rptTable.Items[i].FindControl("ltPvCount");
                Literal ltUvCount = (Literal)rptTable.Items[i].FindControl("ltUvCount");
                Literal ltIpCount = (Literal)rptTable.Items[i].FindControl("ltIpCount");
                var rows = table.Select(string.Format("adid={0}", hidAdId.Value));
                if (rows != null && rows.Count() != 0)
                {
                    ltPvCount.Text = rows[0]["pvcount"].ToString();
                    ltUvCount.Text = rows[0]["uvcount"].ToString();
                    ltIpCount.Text = rows[0]["ipcount"].ToString();
                }
            }

            apPager.RecordCount = cip.Recount.Value;
        }

        protected void apPager_PageChanged(object sender, EventArgs e)
        {
            Bind(apPager.CurrentPageIndex);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Bind();
        }
    }
}