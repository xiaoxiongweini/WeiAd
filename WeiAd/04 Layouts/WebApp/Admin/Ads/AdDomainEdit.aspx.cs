using DN.WeiAd.Business.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DN.WeiAd.Models;
using DN.WeiAd.Business;
using DN.WeiAd.Business.Entity;
using DN.WeiAd.Business.AdPages;

namespace WebApp.Admin.Ads
{
    public partial class AdDomainEdit : BasePageAdmin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var adids = txtAds.Text.Split(',');
            var domain = txtDomain.Text.Split(new string[] { "\r\n" }, StringSplitOptions.None);

            AdDomainInfo info = new AdDomainInfo();
            info.Domains = domain.ToList<string>();
            info.AdId = int.Parse(adids[0]);
            info.TwoDomain = txtTwoDomain.Text;

            AdDomainBLL bll = new AdDomainBLL();
            bll.CreatedAdDomain(info);

        }
    }
}