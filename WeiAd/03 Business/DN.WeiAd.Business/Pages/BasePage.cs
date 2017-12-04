using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DN.WeiAd.Models;
using DN.WeiAd.Business;

namespace DN.WeiAd.Business.Pages
{
    public abstract class BasePage : System.Web.UI.Page
    {
        AccountIdentity _account = null;
        public AccountIdentity Account
        {
            get
            {
                if (User.Identity != null && User.Identity.IsAuthenticated && User.Identity.Name != "")
                {
                    string user = User.Identity.Name;

                    var info = AccountInfoBLL.Instance.GetModelByUserName(user);
                    if (info != null)
                    {
                        _account = new AccountIdentity();

                        _account.NickName = info.NickName;
                        _account.UserId = info.Id;
                        _account.UserName = info.UserName;
                        _account.UserType = info.UserType;
                        _account.UserImg = info.UserImg;
                    } 
                }

                if(_account == null)
                {
                    Response.Redirect("/Login.aspx");
                }

                return _account;
            }
        }

        protected override void OnInitComplete(EventArgs e)
        {
            int pindex = Page.Request.Url.ToString().IndexOf("/Admin/");
            if (Account != null)
            {
                if (pindex != -1 && Account.UserType != 100)
                {
                    Response.Redirect("/Login.aspx");
                }
            }

            base.OnInitComplete(e);
        }
    }
}
