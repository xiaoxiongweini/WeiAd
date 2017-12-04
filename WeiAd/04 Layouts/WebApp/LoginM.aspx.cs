using DN.WeiAd.Business;
using DN.WeiAd.Business.Entity;
using DN.WeiAd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class LoginM : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void login_ServerClick(object sender, EventArgs e)
        {
            LoginInfo info = new LoginInfo();

            info.UserName = txtUserName.Value;
            info.UserPwd = txtUserPwd.Value;

            var result = LoginBLL.Instance.Login(info);
            if (result.State)
            {
                System.Web.Security.FormsAuthentication.SetAuthCookie(info.UserName, false);

                if ((result.Data as AccountInfoVO).UserType == 100)
                {
                    //管理员
                    Response.Redirect("/Admin/Index.aspx");
                }
                else if ((result.Data as AccountInfoVO).UserType == 1)
                {
                    //流量主
                    Response.Redirect("/AccFlow/Index.aspx");
                }
                else if ((result.Data as AccountInfoVO).UserType == 2)
                {
                    //简版广告主
                    //Response.Redirect("/AccAnalysis/Index.aspx");
                    Response.Redirect("/AccVir/Index.aspx");
                }
                else if ((result.Data as AccountInfoVO).UserType == 3)
                {
                    //CPS广告分成
                    Response.Redirect("/AccShop/Index.aspx");
                }
                else if ((result.Data as AccountInfoVO).UserType == 4)
                {
                    //本平台统计数据
                    Response.Redirect("/AccAnalysis/Index.aspx");
                }
                else
                {
                    //广告主
                    Response.Redirect("/Accounts/Index.aspx");
                }
            }
            else
            {
                ltMsg.Text = result.Msg;
            }
        }
    }
}