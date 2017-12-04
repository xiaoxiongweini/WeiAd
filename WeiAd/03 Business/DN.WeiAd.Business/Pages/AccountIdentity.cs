using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.WeiAd.Business.Pages
{
    /// <summary>
    /// 身份标识
    /// </summary>
    public class AccountIdentity
    {
        /// <summary>
        ///  用户ID
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 登录名称
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 用户昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 用户类型
        /// </summary>
        public int UserType { get; set; }

        /// <summary>
        /// 用户图片
        /// </summary>
        public string UserImg { get; set; }
    }
}
