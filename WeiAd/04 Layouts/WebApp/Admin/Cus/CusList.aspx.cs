using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DN.WeiAd.Models;
using DN.WeiAd.Business;
using DN.WeiAd.Business.Pages;

namespace WebApp.Admin.Cus
{
    public partial class CusList : BasePage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.Params["id"] ?? "";
                string isdel = Request.Params["isdel"] ?? "";
                if (!string.IsNullOrEmpty(id) && isdel == "1")
                {
                    var info = CustomerInfoBLL.Instance.GetSingle(new CustomerInfoPara() { Id = int.Parse(id) });
                    if (info != null)
                    {
                        info.IsDelete = 1;
                        CustomerInfoBLL.Instance.Edit(info);
                    }
                }

                BindPage();
                int pageIndex = int.Parse(Request.Params["page"] ?? "1");
                Bind(pageIndex);
            }
        }

        private void BindPage()
        {
            //ddlArticleType.DataSource = ArticleTypeBLL.Instance.GetModels(new ArticleTypePara());
            //ddlArticleType.DataTextField = "Name";
            //ddlArticleType.DataValueField = "Id";
            //ddlArticleType.DataBind();
            //ddlArticleType.Items.Insert(0, new ListItem() { Text = "不限分类", Value = "" });
        }

        private void Bind(int pageIndex = 1)
        {
            CustomerInfoPara aip = new CustomerInfoPara();
            aip.PageIndex = pageIndex - 1;
            aip.PageSize = 10;
            aip.OrderBy = " id desc ";
            if(!string.IsNullOrEmpty(ddlDel.SelectedValue))
            {
                aip.IsDelete = int.Parse(ddlDel.SelectedValue);
            }
            aip.LikeKey = txtSerchTitle.Text;

            var list = CustomerInfoBLL.Instance.GetModels(ref aip);
            rptTables.DataSource = list;
            rptTables.DataBind();

            apPager.RecordCount = aip.Recount.Value;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Bind();
        }

    }
}