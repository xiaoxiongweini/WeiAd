using DN.WeiAd.Business.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DN.WeiAd.Models;
using DN.WeiAd.Business;
using System.Text.RegularExpressions;

namespace WebApp.Admin.Server
{
    public partial class ImportDomain : BasePageAdmin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                txtName.Value = string.Format("分组-{0}", DateTime.Now.ToString("yyyyMMdd"));
                BindPage();
            }
        }

        private void BindPage()
        {
            ddlCity.DataSource = DomainInfoBLL.Instance.GetCitys();
            ddlCity.DataTextField = "Name";
            ddlCity.DataValueField = "Name";
            ddlCity.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string domain = txtDomain.Text;
            int dcount = 0;
            int count = 0;
            if (!string.IsNullOrEmpty(domain))
            {
                var list = domain.Split(System.Environment.NewLine.ToCharArray());

                DomainInfoVO info = new DomainInfoVO();
                info.AdUserId = 0;
                info.CityName = ddlCity.SelectedValue;
                info.CloseUserId = 0;
                info.ColseDate = DateTime.Now;
                info.CreateDate = DateTime.Now;
                info.CreateUserId = Account.UserId;
                info.Domain = "";
                info.Name = txtName.Value;
                info.PageName = "";
                info.ResolutionDate = DateTime.Now;
                info.IsAuth = chkIsAuth.Checked ? 1 : 0;
                                
                foreach (var item in list)
                {
                    if(!string.IsNullOrEmpty(item))
                    {
                        count += 1;

                        info.Domain = item;

                       if( DomainInfoBLL.Instance.Add(info))
                        {
                            //成功加1次
                            dcount += 1;
                        }
                    }
                }

                lblMsg.Text = string.Format("本次共检查到{0}个域名，成功导入{1}个域名。", count, dcount);
            }
            else
            {
                lblMsg.Text = "域名不能为空。";
            }
        }
    }
}