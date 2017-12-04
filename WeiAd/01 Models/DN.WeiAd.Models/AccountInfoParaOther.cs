using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.WeiAd.Models
{
    /// <summary>
    /// 查询参数
    /// </summary>
    public partial class AccountInfoPara
    {
        /// <summary>
        /// 多个用户类型
        /// </summary>
        public List<int> UserTypes { get; set; }

        /// <summary>
        /// 管理员
        /// </summary>
        public bool? IsNotAdmin { get; set; }
    }
}
