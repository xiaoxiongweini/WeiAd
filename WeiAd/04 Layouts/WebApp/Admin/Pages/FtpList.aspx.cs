using DN.WeiAd.Business.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DN.WeiAd.Models;
using DN.WeiAd.Business;

namespace WebApp.Admin.Pages
{
    public partial class FtpList : BasePageAdmin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                int page = int.Parse(Request.Params["page"] ?? "1");
                Bind(page);
            }
        }

        private void Bind(int pageIndex=1)
        {
            FtpInfoPara fip = new FtpInfoPara();
            fip.PageIndex = pageIndex - 1;
            fip.PageSize = 10;

            var list = FtpInfoBLL.Instance.GetModels(ref fip);
            rptTable.DataSource = list;
            rptTable.DataBind();

            apPager.RecordCount = fip.Recount.Value;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Bind();
        }
    }
}