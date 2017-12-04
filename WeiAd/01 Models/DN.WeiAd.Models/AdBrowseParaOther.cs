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
    public partial class AdBrowsePara
    {
        /// <summary>
        /// 非当日时间
        /// </summary>
        public bool? IsNotDay
        {
            get; set;
        }

        /// <summary>
        /// IDS
        /// </summary>
        public List<int> Ids { get; set; }
    }
}
