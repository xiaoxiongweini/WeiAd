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
    public partial class CustomerInfoPara
    {
        /// <summary>
        /// CPS广告用户ID
        /// </summary>
        public int? CpsUserId { get; set; }

        /// <summary>
        /// 模糊查找
        /// </summary>
        public string LikeKey { get; set; }


    }
}
