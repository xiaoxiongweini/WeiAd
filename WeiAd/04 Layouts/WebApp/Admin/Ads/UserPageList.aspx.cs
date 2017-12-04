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
    public partial class UserPageList : BasePage
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
            
        }

        public string GetUserName(object userid)
        {
            var info = AccountInfoBLL.Instance.GetModelByUserId(userid);
            if (info != null)
            {
                return info.UserName;
            }

            return userid.ToString();
        }

        private void Bind(int pageIndex = 1)
        {
            AdUserPagePara cip = new AdUserPagePara();
            cip.PageIndex = pageIndex - 1;
            cip.PageSize = 10;
            cip.AdPageId = int.Parse(hidAdId.Value);
            cip.OrderBy = " id desc ";

            var list = AdUserPageBLL.Instance.GetModels(ref cip);
            rptTable.DataSource = list;
            rptTable.DataBind();

            DN.WeiAd.Business.Entity.Analysis.FlowInfo finfo = new DN.WeiAd.Business.Entity.Analysis.FlowInfo();
            finfo.AdId = int.Parse(hidAdId.Value);
            finfo.Time = DateTime.Now;
            //var table = AnalysisAdBLL.Instance.GetAdFlowDetail(finfo);

            for (int i = 0; i < rptTable.Items.Count; i++)
            {
                Literal ltPv = (Literal)rptTable.Items[i].FindControl("ltPv");
                Literal ltUv = (Literal)rptTable.Items[i].FindControl("ltUv");
                Literal ltIp = (Literal)rptTable.Items[i].FindControl("ltIp");
                HiddenField hidFlowUserId = (HiddenField)rptTable.Items[i].FindControl("hidFlowUserId");

                //var row = table.Select(string.Format("FlowUserId={0}", hidFlowUserId.Value));
                //if(row!= null && row.Length >=1)
                //{
                //    ltPv.Text = row[0]["pvcount"].ToString();
                //    ltUv.Text = row[0]["uvcount"].ToString();
                //    ltIp.Text = row[0]["ipcount"].ToString();
                //}
            }

            apPager.RecordCount = cip.Recount.Value;
            apPager.PageSize = cip.PageSize.Value;
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