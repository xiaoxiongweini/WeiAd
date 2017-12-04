using DN.WeiAd.Business.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DN.WeiAd.Models;

namespace DN.WeiAd.Business
{
    /// <summary>
    /// 产品管理
    /// </summary>
    public partial class ProductInfoBLL
    {
        /// <summary>
        /// 将产品转换成界面需要的数据格式
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProductItem GetProductById(object id)
        {
            ProductItem pinfo = new ProductItem();
            var info = GetSingle(new ProductInfoPara() { Id = int.Parse(id.ToString()) });

            if(info!= null)
            {
                pinfo.AdId = info.AdId;
                pinfo.Attr = new List<AttrItem>();

                pinfo.Desc = info.Desc;
                pinfo.Name = info.Name;
                pinfo.Id = info.Id;
                pinfo.Price = info.Price;
                
                //格式：产品颜色=红色，绿色
                if(!string.IsNullOrEmpty(info.AttrText))
                {
                    var list = info.AttrText.Split(new char[] { '\r', '\t', '\n' });
                    foreach (var item in list)
                    {
                        if(!string.IsNullOrEmpty(item))
                        {
                            var nlist = item.Split('=');
                            if (nlist.Length >= 1)
                            {
                                AttrItem aitem = new AttrItem();
                                aitem.value = new List<string>();
                                aitem.name = nlist[0];

                                if (!string.IsNullOrEmpty(nlist[1]))
                                {
                                    var tnlist = nlist[1].Split(new char[] { ',', '，' });
                                    for (int i = 0; i < tnlist.Length; i++)
                                    {
                                        aitem.value.Add(tnlist[i]);
                                    }
                                }

                                pinfo.Attr.Add(aitem);
                            }
                        }
                    }
                }
            }

            return pinfo;

        }
    }
}
