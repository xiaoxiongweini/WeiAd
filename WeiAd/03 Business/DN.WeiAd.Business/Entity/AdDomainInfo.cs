using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.WeiAd.Business.Entity
{
    /// <summary>
    /// 广告域名配置信息
    /// </summary>
    public class AdDomainInfo
    {
        /// <summary>
        /// 广告ID
        /// </summary>
        public int AdId { get; set; }

        /// <summary>
        /// 广告域名，一级域名
        /// </summary>
        public List<string> Domains { get; set; }

        /// <summary>
        /// 如果设置该值，则不随机生成
        /// </summary>
        public string TwoDomain { get; set; }

    }
}
