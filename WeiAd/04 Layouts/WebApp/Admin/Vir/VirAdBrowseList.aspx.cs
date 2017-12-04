using DN.WeiAd.Business.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DN.WeiAd.Models;
using DN.WeiAd.Business;

namespace WebApp.Admin.Vir
{
    public partial class VirAdBrowseList : BasePageAdmin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.Params["id"] ?? "";
                string isdel = Request.Params["isdel"] ?? "";
                if(isdel == "1")
                {
                    if (!string.IsNullOrEmpty(id))
                    {
                        VirAdBrowseBLL.Instance.Delete(new VirAdBrowsePara() { Id = int.Parse(id) });
                    }
                }
                BindPage();
                Bind();
            }
        }


        private void BindPage()
        {
            var list = AdPageInfoBLL.Instance.GetModels(new AdPageInfoPara());

            foreach (var item in list)
            {
                ddlAd.Items.Add(new ListItem() { Value = item.Id.ToString(), Text = string.Format("{0}--{1}--{2}", item.Id, item.UserId, item.Title) });
            }
        }

        private void Bind(int pageIndex = 1)
        {
            VirAdBrowsePara adp = new VirAdBrowsePara();
            adp.PageIndex = pageIndex - 1;
            adp.PageSize = 10;
            adp.OrderBy = " id desc ";

            var list = VirAdBrowseBLL.Instance.GetModels(ref adp);
            rptTable.DataSource = list;
            rptTable.DataBind();

            apPager.RecordCount = adp.Recount.Value;
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