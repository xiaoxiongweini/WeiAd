using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.WeiAd.Business.Entity.Analysis
{
    /// <summary>
    /// 流量主查询参数
    /// </summary>
    public class FlowInfo
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
        public DateTime Time { get; set; }

        /// <summary>
        /// 查询时间
        /// </summary>
        public DateTime? QueryTime { get; set; }
        
        /// <summary>
        /// 广告ID
        /// </summary>
        public int? AdId { get; set; }

        /// <summary>
        /// 分组条件
        /// </summary>
        public string GroupBy { get; set; }
    }
}
