using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DN.WeiAd.Models;
using DN.WeiAd.Business;
using DN.WeiAd.Business.Pages;
using System.Data;
using System.IO;

namespace WebApp.Accounts.Order
{
    public partial class OrderList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.Params["id"] ?? "";
                string del = Request.Params["isdel"] ?? "";
                if (del == "1")
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
            aip.IsDelete = 0;
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

        protected void btnExport_Click(object sender, EventArgs e)
        {
            CustomerInfoPara aip = new CustomerInfoPara();
            aip.OrderBy = " id desc ";
            aip.IsDelete = 0;
            aip.LikeKey = txtSerchTitle.Text;

            var list = CustomerInfoBLL.Instance.GetModels(aip);

            DataTable table = new DataTable();
            table.Columns.Add("广告ID");
            table.Columns.Add("产品");
            table.Columns.Add("姓名");
            table.Columns.Add("电话");
            table.Columns.Add("地址");
            table.Columns.Add("备注");
            table.Columns.Add("时间");

            foreach (var item in list)
            {
                DataRow row = table.NewRow();
                row["广告ID"] = item.AdId;
                row["产品"] = item.Color + item.Size;
                row["姓名"] = item.RealName;
                row["电话"] = item.Phone;
                row["地址"] = string.Format("{0}-{1}-{2}-{3}", item.UserRegion, item.UserCity, item.UserCountry, item.Address);
                row["备注"] = item.Remark;
                row["时间"] = item.CreateDate.ToString();

                table.Rows.Add(row);
            }

            string url = string.Format("/Resources/Customer/{0}-{1}.xlsx", DateTime.Now.ToString("yyyyMMdd"), Guid.NewGuid().ToString());
            string filename = Server.MapPath(url);
            DN.Framework.Utility.ExcelHelper helper = new DN.Framework.Utility.ExcelHelper(filename);
            helper.DataTableToExcel(table, DateTime.Now.ToString("yyyyMMdd"), true);

            //Response.Write("<script>window.open('" + url + "','','','')</script>");
            string fname = Path.GetFileName(filename);
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
            Response.ContentType = "application/vnd.ms-excel";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + fname);
            Response.WriteFile(filename);
            Response.Flush();
            Response.End();

        }

        protected void apPager_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            Bind(apPager.CurrentPageIndex);
        }
    }
}