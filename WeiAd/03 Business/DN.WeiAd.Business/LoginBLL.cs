using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DN.WeiAd.Models;
using DN.WeiAd.Business;
using DN.WeiAd.Business.Entity;

namespace DN.WeiAd.Business
{
    public class LoginBLL
    {
        #region 实例

        static LoginBLL m_proxy = null;
        public static LoginBLL Instance
        {
            get
            {
                if (m_proxy == null)
                {
                    m_proxy = new LoginBLL();
                }

                return m_proxy;
            }
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public LoginResult Login(LoginInfo info)
        {
            LoginResult result = new LoginResult();
            result.Msg = "正在登录";

            AccountInfoPara ap = new AccountInfoPara();
            ap.UserName = info.UserName;

            var list = AccountInfoBLL.Instance.GetModels(ap);
            foreach (var item in list)
            {
                if (item.UserPwd == DN.Framework.Utility.EncryptHelper.GetMd5(info.UserPwd))
                {
                    if (item.IsLock == 0)
                    {
                        result.State = true;
                        result.Msg = "登录成功";
                        result.Data = item;
                    }
                    else
                    {
                        result.State = false;
                        result.Msg = "用户被锁定";
                        result.Data = item;
                    }
                }
            }

            if (list.Count == 0)
            {
                result.Msg = "用户名不存在。";
            }
            else if (list.Count != 0)
            {
                if (!result.State)
                {
                    result.Msg = "用户名或密码不正确，请重新输入。";
                }
            }

            LogLoginVO log = new LogLoginVO();

            log.BrowseType = DN.Framework.Utility.ClientHelper.GetBrowseInfo();
            log.ClientIp = DN.Framework.Utility.ClientHelper.ClientIP();
            log.LoginDate = DateTime.Now;
            log.LoginDesc = result.Msg;
            log.LoginName = info.UserName;
            log.LoginState = result.State ? 1 : 0;

            LogLoginBLL.Instance.Add(log);

            return result;
        }

        public bool RegAccount(LoginInfo reg)
        {
            AccountInfoVO info = new AccountInfoVO();
            info.Email = reg.UserName;
            info.LastLoginDate = DateTime.Now;
            info.NickName = reg.UserName;
            info.UserPwd = DN.Framework.Utility.EncryptHelper.GetMd5(reg.UserPwd);
            info.RegDate = DateTime.Now;
            info.RegIp = DN.Framework.Utility.ClientHelper.ClientIP();
            info.UserName = reg.UserName;

            return AccountInfoBLL.Instance.Add(info);
        }
    }
}
