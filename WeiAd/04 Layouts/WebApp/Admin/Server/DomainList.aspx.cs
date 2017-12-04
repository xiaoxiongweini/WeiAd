using DN.WeiAd.Business.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DN.WeiAd.Models;
using DN.WeiAd.Business;

namespace WebApp.Admin.Server
{
    public partial class DomainList : BasePageAdmin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.Params["id"] ?? "";
                string isstate = Request.Params["isstate"] ?? "";
                string isauth = Request.Params["isauth"] ?? "";

                //是否关闭
                if (!string.IsNullOrEmpty(isstate))
                {
                    var info = DomainInfoBLL.Instance.GetSingle(new DomainInfoPara() { Id = int.Parse(id) });
                    if(info!= null)
                    {
                        if(info.IsState == 0)
                        {
                            info.IsState = 1;
                            info.ColseDate = DateTime.Now;
                            info.CloseUserId = Account.UserId;
                        }
                        else
                        {
                            info.IsState = 0;
                        }
                        
                        DomainInfoBLL.Instance.Edit(info);
                    }
                }
                //是否备案
                if (!string.IsNullOrEmpty(isauth))
                {
                    var info = DomainInfoBLL.Instance.GetSingle(new DomainInfoPara() { Id = int.Parse(id) });
                    if (info != null)
                    {
                        if (info.IsAuth == 0)
                        {
                            info.IsState = 1;
                        }
                        else
                        {
                            info.IsAuth = 0;
                        }

                        DomainInfoBLL.Instance.Edit(info);
                    }
                }
                Bind();
            }
        }

        private void Bind(int pageIndex = 1)
        {
            DomainInfoPara cip = new DomainInfoPara();
            cip.PageIndex = pageIndex - 1;
            cip.PageSize = 10;
            cip.OrderBy = " id desc ";

            var list = DomainInfoBLL.Instance.GetModels(ref cip);
            rptTable.DataSource = list;
            rptTable.DataBind();

            apPager.RecordCount = cip.Recount.Value;
        }

        protected void apPager_PageChanged(object sender, EventArgs e)
        {
            Bind(apPager.CurrentPageIndex);
        }
        protected void btnAddHistory_Click(object sender, EventArgs e)
        {
            AdBrowseBLL.Instance.Synchronization();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Bind();
        }
    }
}