using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.WeiAd.Business.Shop
{
    /// <summary>
    /// 产品信息
    /// </summary>
    public class ProductItem
    {
        /// <summary>
        /// 产品ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 文案ID
        /// </summary>
        public int AdId { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Desc { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// 属性配置信息
        /// </summary>
        public List<AttrItem> Attr { get; set; }

    }
}
