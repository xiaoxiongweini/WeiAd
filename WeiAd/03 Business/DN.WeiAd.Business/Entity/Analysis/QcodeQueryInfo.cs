using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.WeiAd.Business.Entity.Analysis
{
    /// <summary>
    /// 二给码日志分析
    /// </summary>
    public class QcodeQueryInfo
    {
        /// <summary>
        /// 广告ID
        /// </summary>
        public int? AdId { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int? AdUserId { get; set; }
        /// <summary>
        /// URL
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 时间,YYYYMMDD
        /// </summary>
        public int? Time { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? TimeStart { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? TimeEnd { get; set; }

        /// <summary>
        /// 分组SQL
        /// </summary>
        public string GroupBy { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public string OrderBy { get; set; }
    }
}
