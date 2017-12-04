using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DN.WeiAd.Business.Shop;
using DN.Framework.Utility;

namespace DN.WeiAd.Business
{
    public class ProductBLL
    {
        /// <summary>
        /// 获取所有产品配置信息
        /// </summary>
        /// <returns></returns>
        private static List<ProductItem> GetProducts()
        {
            List<ProductItem> list = new List<ProductItem>();

            //文件读取方式己经取消
            list = ConfigJsonHelper.GetTypes<ProductItem>("products");

            return list;
        }

        /// <summary>
        /// 获取产品信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static ProductItem GetProductsById(object id)
        {
            return ProductInfoBLL.Instance.GetProductById(id);
        }

        private static List<ProductItem> CreateProduct()
        {
            List<ProductItem> list = new List<ProductItem>();
            
            //包包产品
            ProductItem p1 = new ProductItem();
            p1.AdId = 140;
            p1.Id = 1;
            p1.Attr = new List<AttrItem>();
            p1.Desc = "XX鞋子特惠专卖";
            p1.Name= "XX鞋子特惠专卖";
            p1.Price = 108;

            AttrItem a1 = new AttrItem();
            a1.name = "颜色";
            a1.value = new List<string>();
            a1.value.Add("红色");
            a1.value.Add("绿色");
            a1.value.Add("蓝色");

            p1.Attr.Add(a1);

            AttrItem a2 = new AttrItem();
            a2.name = "尺寸";
            a2.value = new List<string>();
            a2.value.Add("42码");
            a2.value.Add("43码");
            a2.value.Add("44码");
            p1.Attr.Add(a2);

            list.Add(p1);

            return list;
        }
    }
}
