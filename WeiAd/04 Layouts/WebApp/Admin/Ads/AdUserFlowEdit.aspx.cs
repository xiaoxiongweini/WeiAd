using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DN.WeiAd.Business.Pages;
using DN.WeiAd.Business;
using DN.WeiAd.Models;
using System.IO;

namespace WebApp.Admin.Ads
{
    public partial class AdUserFlowEdit : BasePageAdmin
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

        private void Bind(int pageIndex = 1)
        {
            AccountInfoPara cip = new AccountInfoPara();
            cip.OrderBy = " id desc ";
            cip.UserType = 1;

            var list = AccountInfoBLL.Instance.GetModels(cip);
            rptTable.DataSource = list;
            rptTable.DataBind();

            BindExitFile();
        }

        private void BindExitFile()
        {
            var ulist = AdUserPageBLL.Instance.GetModels(new AdUserPagePara() { AdPageId = int.Parse(hidAdId.Value) });
            for (int i = 0; i < rptTable.Items.Count; i++)
            {
                CheckBox chkSelect = (CheckBox)rptTable.Items[i].FindControl("chkSelect");
                HiddenField hidUserId = (HiddenField)rptTable.Items[i].FindControl("hidUserId");
                TextBox txtPageName = (TextBox)rptTable.Items[i].FindControl("txtPageName");
                HyperLink hyplnkPrview = (HyperLink)rptTable.Items[i].FindControl("hyplnkPrview");
                Literal ltExtName = (Literal)rptTable.Items[i].FindControl("ltExtName");

                var info = ulist.SingleOrDefault(p => p.FlowUserId == int.Parse(hidUserId.Value));
                if (info != null)
                {
                    chkSelect.Checked = true;
                    txtPageName.Text = info.PageName;
                }
                else
                {
                    if (string.IsNullOrEmpty(txtPageName.Text))
                    {
                        txtPageName.Text = AdPageInfoBLL.Instance.GetPageName();
                    }
                }
                hyplnkPrview.NavigateUrl = AdPageInfoBLL.Instance.GetAdViewUrl(txtPageName.Text);

                string filepath = Server.MapPath(hyplnkPrview.NavigateUrl);
                if (File.Exists(filepath))
                {
                    ltExtName.Text = "是";
                    hyplnkPrview.Target = "_blank";
                }
                else
                {
                    ltExtName.Text = "否";
                    hyplnkPrview.NavigateUrl = "#";
                }
            }
        }


        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var ulist = AdUserPageBLL.Instance.GetModels(new AdUserPagePara() { AdPageId = int.Parse(hidAdId.Value) });
            var adinfo = AdPageInfoBLL.Instance.GetModelById(int.Parse(hidAdId.Value));

            for (int i = 0; i < rptTable.Items.Count; i++)
            {
                CheckBox chkSelect = (CheckBox)rptTable.Items[i].FindControl("chkSelect");
                HiddenField hidUserId = (HiddenField)rptTable.Items[i].FindControl("hidUserId");
                TextBox txtPageName = (TextBox)rptTable.Items[i].FindControl("txtPageName");
                HyperLink hyplnkPrview = (HyperLink)rptTable.Items[i].FindControl("hyplnkPrview");
                Literal ltExtName = (Literal)rptTable.Items[i].FindControl("ltExtName");

                var info = ulist.SingleOrDefault(p => p.FlowUserId == int.Parse(hidUserId.Value));
                if(chkSelect.Checked)
                {
                    AdUserPageVO aduser = new AdUserPageVO();
                    aduser.AdPageId = int.Parse(hidAdId.Value);
                    aduser.AdUserId = adinfo.UserId;
                    aduser.CreateDate = DateTime.Now;
                    aduser.CreateUserId = Account.UserId;
                    aduser.FlowLastDate = DateTime.Now;
                    aduser.FlowUserId = int.Parse(hidUserId.Value);
                    aduser.Gid = Guid.NewGuid().ToString();
                    aduser.PageName = txtPageName.Text;

                    if (info == null)
                    {
                        AdUserPageBLL.Instance.Add(aduser);
                    }else
                    {
                        info.PageName = txtPageName.Text;
                        AdUserPageBLL.Instance.Edit(aduser);                        
                    }
                }
                else
                {
                    AdUserPageBLL.Instance.Delete(new AdUserPagePara() { AdPageId = int.Parse(hidAdId.Value), FlowUserId = int.Parse(hidUserId.Value) });
                }
            }
        }

        protected void rptTable_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if(e.CommandName.Equals("mybuilder"))
            {
                TextBox txtPageName = (TextBox)e.Item.FindControl("txtPageName");
                AdPageInfoBLL.Instance.CreateAdPage(txtPageName.Text, DN.WeiAd.Business.Config.AppConfig.TemplateName);

                BindExitFile();
            }
        }
    }
}
