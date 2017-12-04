using DN.WeiAd.Business.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DN.WeiAd.Models;
using DN.WeiAd.Business;

namespace WebApp.Admin.Article
{
    public partial class ChannelList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                int pageIndex = int.Parse(Request.Params["page"] ?? "1");
                Bind(pageIndex);
            }
        }

        private void Bind(int pageIndex=1)
        {
            ChannelInfoPara cip = new ChannelInfoPara();
            cip.PageIndex = pageIndex - 1;
            cip.PageSize = 10;

            var list = ChannelInfoBLL.Instance.GetModels(ref cip);
            rptTables.DataSource = list;
            rptTables.DataBind();

            apPager.RecordCount = cip.Recount.Value;

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Bind();
        }
    }
}