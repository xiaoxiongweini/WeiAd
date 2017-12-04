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
    public partial class AdPageListDel : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.Params["id"] ?? "";
                string isdel = Request.Params["isdel"] ?? "";
                if (!string.IsNullOrEmpty(id))
                {
                    if (isdel == "0")
                    {
                        var adinfo = AdPageInfoBLL.Instance.GetSingle(new AdPageInfoPara() { Id = int.Parse(id) });
                        if(adinfo!= null)
                        {
                            adinfo.IsDel = 0;
                            AdPageInfoBLL.Instance.Edit(adinfo);
                        }
                    }
                }

                BindPage();

                Bind();
            }
        }

        private void BindPage()
        {
            //广告
            var ulist = AccountInfoBLL.Instance.GetModels(new AccountInfoPara() { UserType = 0 });
            ddlAdUser.Items.Clear();
            foreach (var item in ulist)
            {
                string txt = string.Format("{0}-{1}-{2}", item.Id, item.UserName, item.NickName);
                ddlAdUser.Items.Add(new ListItem() { Text = txt, Value = item.Id.ToString() });
            }
            ddlAdUser.Items.Insert(0, new ListItem() { Text = "不限", Value = "" });

            //广告分类
            var adtypelist = AdTypeInfoBLL.Instance.GetModels(new AdTypeInfoPara());
            ddlUserAdType.Items.Clear();
            foreach (var item in adtypelist)
            {
                string txt = string.Format("{0}-{1}-{2}", item.UserId, item.Id, item.Name);
                ddlUserAdType.Items.Add(new ListItem() { Text = txt, Value = item.Id.ToString() });
            }
            ddlUserAdType.Items.Insert(0, new ListItem() { Text = "不限广告分类", Value = "" });

            //投放平台分类
            var sitelist = AdSiteInfoBLL.Instance.GetModels(new AdSiteInfoPara());
            ddlSiteType.Items.Clear();
            foreach (var item in sitelist)
            {
                string txt = string.Format("{0}-{1}-{2}", item.UserId, item.Id, item.Name);
                ddlSiteType.Items.Add(new ListItem() { Text = txt, Value = item.Id.ToString() });
            }
            ddlSiteType.Items.Insert(0, new ListItem() { Text = "不限投放平台", Value = "" });


        }

        private void Bind(int pageIndex = 1)
        {
            AdPageInfoPara cip = new AdPageInfoPara();
            cip.PageIndex = pageIndex - 1;
            cip.PageSize = 10;
            cip.IsDel = 1;
            cip.OrderBy = " id desc ";
            if (!string.IsNullOrEmpty(ddlAdUser.SelectedValue))
            {
                cip.UserId = int.Parse(ddlAdUser.SelectedValue);
            }

            var list = AdPageInfoBLL.Instance.GetModels(ref cip);
            rptTable.DataSource = list;
            rptTable.DataBind();

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