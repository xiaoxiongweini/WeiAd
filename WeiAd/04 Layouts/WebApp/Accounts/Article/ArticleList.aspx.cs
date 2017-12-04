using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DN.WeiAd.Models;
using DN.WeiAd.Business;
using DN.WeiAd.Business.Pages;

namespace WebApp.Accounts.Article
{
    public partial class ArticleList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hidTypeId.Value = Request.Params["tid"] ?? "";

                string id = Request.Params["id"] ?? "";
                if (!string.IsNullOrEmpty(id))
                {
                    string isdel = Request.Params["del"] ?? "";
                    if (isdel == "1")
                    {
                        ArticleInfoBLL.Instance.Delete(new ArticleInfoPara() { Id = int.Parse(id), CreateUserId = Account.UserId });
                    }

                    //置顶
                    string istop = Request.Params["top"] ?? "";
                    if (istop == "1")
                    {
                        var info = ArticleInfoBLL.Instance.GetSingle(new ArticleInfoPara() { Id = int.Parse(id) });
                        if (info != null)
                        {
                            if (info.IsTop == 0)
                            {
                                info.IsTop = 1;
                                info.LastDate = DateTime.Now;
                            }
                            else
                            {
                                info.IsTop = 0;
                            }

                            ArticleInfoBLL.Instance.Edit(info);
                        }
                    }
                    //热门
                    string ishot = Request.Params["hot"] ?? "";
                    if (ishot == "1")
                    {
                        var info = ArticleInfoBLL.Instance.GetSingle(new ArticleInfoPara() { Id = int.Parse(id) });
                        if (info != null)
                        {
                            if (info.IsHot == 0)
                            {
                                info.IsHot = 1;
                                info.LastDate = DateTime.Now;
                            }
                            else
                            {
                                info.IsHot = 0;
                            }

                            ArticleInfoBLL.Instance.Edit(info);
                        }
                    }
                }

                BindPage();
                Bind();
            }
        }

        private void BindPage()
        {
            var list = ChannelInfoBLL.Instance.GetModels(new ChannelInfoPara());
            ddlChannel.DataSource = list;
            ddlChannel.DataTextField = "Name";
            ddlChannel.DataValueField = "Id";
            ddlChannel.DataBind();

            ddlChannel.Items.Insert(0, new ListItem() { Text = "不限频道", Value = "" });

            if (!string.IsNullOrEmpty(hidTypeId.Value))
            {
                ddlChannel.SelectedValue = hidTypeId.Value;
            }

            //ddlArticleType.DataSource = ArticleTypeBLL.Instance.GetModels(new ArticleTypePara());
            //ddlArticleType.DataTextField = "Name";
            //ddlArticleType.DataValueField = "Id";
            //ddlArticleType.DataBind();
            ddlArticleType.Items.Insert(0, new ListItem() { Text = "不限分类", Value = "" });
        }

        private void Bind(int pageIndex = 1)
        {
            ArticleInfoPara aip = new ArticleInfoPara();
            aip.PageIndex = pageIndex - 1;
            aip.PageSize = 10;
            aip.OrderBy = " LastDate desc ";
            aip.CreateUserId = Account.UserId;

            if (!string.IsNullOrEmpty(ddlChannel.SelectedValue))
            {
                aip.ChannelId = int.Parse(ddlChannel.SelectedValue);
            }
            if (!string.IsNullOrEmpty(ddlArticleType.SelectedValue))
            {
                aip.ArticleTypeId = int.Parse(ddlArticleType.SelectedValue);
            }
            if (!string.IsNullOrEmpty(ddlTop.SelectedValue))
            {
                aip.IsTop = int.Parse(ddlTop.SelectedValue);
            }
            if (!string.IsNullOrEmpty(ddlHot.SelectedValue))
            {
                aip.IsHot = int.Parse(ddlHot.SelectedValue);
            }
            if (!string.IsNullOrEmpty(ddlState.SelectedValue))
            {
                aip.IsState = int.Parse(ddlState.SelectedValue);
            }

            var list = ArticleInfoBLL.Instance.GetModels(ref aip);
            rptTables.DataSource = list;
            rptTables.DataBind();

            apPager.RecordCount = aip.Recount.Value;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Bind();
        }

        protected void apPager_PageChanged(object sender, EventArgs e)
        {
            Bind(apPager.CurrentPageIndex);
        }

        protected void btnRefCache_Click(object sender, EventArgs e)
        {
            ArticleInfoBLL.Instance.Refresh();
        }
    }
}