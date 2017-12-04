using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DN.WeiAd.Models;
using DN.WeiAd.Business;

namespace WebApp.Accounts
{
    public partial class CheckMyDomain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hidUserId.Value = Request.Params["id"] ?? "0";
                BindPage();
            }
        }

        private void BindPage()
        {
            AdPageInfoPara app = new AdPageInfoPara();
            app.UserId = int.Parse(hidUserId.Value);
            var list = AdPageInfoBLL.Instance.GetModels(app);

            List<AdDomainItem> dlist = new List<AdDomainItem>();
            foreach (var item in list)
            {
                if (!string.IsNullOrEmpty(item.DomainList))
                {
                    var tlist = item.DomainList.Split(',');
                    foreach (var url in tlist)
                    {
                        if(!string.IsNullOrEmpty(url))
                        {
                            AdDomainItem domain = new AdDomainItem();
                            domain.Url = url;

                            if(!dlist.Contains(domain))
                            {
                                dlist.Add(domain);
                            }
                        }
                    }
                }
            }

            rptDomain.DataSource = dlist;
            rptDomain.DataBind();
        }

        class AdDomainItem
        {
            public string Url { get; set; }
        }
    }
}