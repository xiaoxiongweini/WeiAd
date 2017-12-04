using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.WeiAd.Business.Entity.Analysis
{

    /// <summary>
    /// 通用汇总
    /// </summary>
    public class QueryGroupInfo
    {
        /// <summary>
        /// 流量主用户ID
        /// </summary>
        public int? FlowUserId { get; set; }

        /// <summary>
        /// 广告主用户ID
        /// </summary>
        public int? AdUserID { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        public DateTime? Time { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? TimeStart { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? TimeEnd { get; set; }

        /// <summary>
        /// 广告ID
        /// </summary>
        public int? AdId { get; set; }

        /// <summary>
        /// 分组条件
        /// </summary>
        public string GroupBy { get; set; }

        /// <summary>
        /// 排序条件，可为空
        /// </summary>
        public string OrderBy { get; set; }
    }
}
