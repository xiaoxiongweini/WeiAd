using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.WeiAd.Business.Pages
{
    public class BaseUserControl : System.Web.UI.UserControl
    {
        AccountIdentity _account = new AccountIdentity();
        public AccountIdentity Account
        {
            get
            {
                if (Page != null && Page.User!= null 
                    && Page.User.Identity != null 
                    && Page.User.Identity.IsAuthenticated 
                    && Page.User.Identity.Name != "")
                {
                    string user = Page.User.Identity.Name;

                    var info = AccountInfoBLL.Instance.GetModelByUserName(user);
                    if (info != null)
                    {
                        _account.NickName = info.NickName;
                        _account.UserId = info.Id;
                        _account.UserName = info.UserName;
                        _account.UserType = info.UserType;
                        _account.UserImg = info.UserImg;
                        return _account;
                    }

                    return null;
                }

                return null;
            }
        }
    }
}
