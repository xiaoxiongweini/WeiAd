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
    public partial class VirAdBrowseEdit : BasePageAdmin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindPage();
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            VirAdBrowseVO info = new VirAdBrowseVO();
            info.AdId = int.Parse(ddlAd.SelectedValue);
            info.CreateDate = DateTime.Now;
            info.CreateUserId = Account.UserId;
            info.IpCount = int.Parse(txtIpCount.Value);
            info.PvCount = int.Parse(txtPvCount.Value);
            info.TimeId = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
            info.UvCount = int.Parse(txtUvCount.Value);

            VirAdBrowseBLL.Instance.Add(info);

            Response.Redirect("/Admin/Vir/VirAdBrowseList.aspx");
        }
    }
}