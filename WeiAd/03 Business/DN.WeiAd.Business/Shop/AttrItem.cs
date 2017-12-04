using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.WeiAd.Business.Shop
{
    /// <summary>
    /// 属性信息
    /// </summary>
    public class AttrItem
    {
        /// <summary>
        /// 属性名称
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 属性值集合
        /// </summary>
        public List<string> value { get; set; }
    }
}
