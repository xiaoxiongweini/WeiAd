using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DN.WeiAd.Models;
using DN.WeiAd.Business;

namespace WebApp.Wap
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                hidChannelId.Value = Request.Params["cid"] ?? "";
                BindPage();

                int page = int.Parse(Request.Params["page"] ?? "1");
                Bind(page);
            }
        }

        private void BindPage()
        {
            var list = ChannelInfoBLL.Instance.GetModels(new ChannelInfoPara());
            rptChannel.DataSource = list;
            rptChannel.DataBind();
        }

        private void Bind(int pageIndex=1)
        {
            ArticleInfoPara aip = new ArticleInfoPara();
            if (!string.IsNullOrEmpty(hidChannelId.Value))
            {
                aip.ChannelId = int.Parse(hidChannelId.Value);
            }

            aip.PageIndex = pageIndex - 1;
            aip.PageSize = 10;
            aip.OrderBy = " LastDate desc ";

            var list = ArticleInfoBLL.Instance.GetModels(ref aip);
            rptTable.DataSource = list;
            rptTable.DataBind();
        }
    }
}