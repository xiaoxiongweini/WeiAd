using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.WeiAd.Business.Entity
{
    /// <summary>
    /// IP结果
    /// </summary>
    public class IpResult
    {
        /// <summary>
        /// 结果 0正确，1错误
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IpInfo data { get; set; }
    }
}
