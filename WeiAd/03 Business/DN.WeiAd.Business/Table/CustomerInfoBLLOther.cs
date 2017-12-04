using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace DN.WeiAd.Business
{
    public partial class CustomerInfoBLL
    {
        /// <summary>
        /// 名称加密
        /// </summary>
        /// <param name="realName"></param>
        /// <returns></returns>
        public string GetEncryRealName(object realName)
        {
            if (realName == null) return "";

            if (string.IsNullOrEmpty(realName.ToString())) return "";

            if (realName.ToString().Length >= 2)
            {
                return realName.ToString().Substring(0, 1) + "**";
            }

            return "**";
        }

        /// <summary>
        /// 手机加密
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public string GetEncryPhone(object phone)
        {
            if (phone == null) return "";

            if (string.IsNullOrEmpty(phone.ToString())) return "";

            string nphone = Regex.Replace(phone.ToString(), "(\\d{3})\\d{4}(\\d{4})", "$1****$2");

            return nphone;
        }
    }
}
