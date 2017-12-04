using DN.WeiAd.Business.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DN.WeiAd.Models;
using DN.WeiAd.Business;
using DN.WeiAd.Business.Entity.Analysis;
using System.Data;

namespace WebApp.AccAnalysis.Vir
{
    public partial class Index : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int page = int.Parse(Request.Params["page"] ?? "1");
                Bind(page);
            }
        }

        private void Bind(int pageIndex = 1)
        {
            AdPageInfoPara app = new AdPageInfoPara();
            app.PageIndex = pageIndex - 1;
            app.PageSize = 10;
            app.UserId = Account.UserId;

            var list = AdPageInfoBLL.Instance.GetModels(ref app);
            rptTable.DataSource = list;
            rptTable.DataBind();
        }
    }
}