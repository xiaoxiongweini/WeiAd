using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.WeiAd.Business.AdData
{
    /// <summary>
    /// 采集数据配置信息
    /// </summary>
    public class AdDataItem
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 广告ID
        /// </summary>
        public int AdId { get; set; }

        /// <summary>
        /// 客户端地址
        /// </summary>
        public string ClientUrl { get; set; }

        /// <summary>
        /// 编码方式
        /// </summary>
        public string Encoding { get; set; }

        /// <summary>
        /// 数据获取方式
        /// </summary>
        public int App { get; set; }

        /// <summary>
        /// XPath
        /// </summary>
        public string XPath { get; set; }

        /// <summary>
        /// 其它配置参数
        /// </summary>
        public string Purl { get; set; }

        /// <summary>
        /// 虚拟数量
        /// </summary>
        public int VirCount { get; set; }
    }
}
