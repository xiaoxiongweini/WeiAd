
/*

skey edit by 2017/7/24 9:27:34

*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DN.WeiAd.Models;
using DN.WeiAd.Interface;
using DN.Framework.Core;

namespace DN.WeiAd.Business
{
    public partial class ProductInfoBLL : IBusiness<ProductInfoVO, ProductInfoPara>
    {
        #region 实例

        static ProductInfoBLL m_proxy = null;
        static ProductInfoInterface acc = null;
        public static ProductInfoBLL Instance
        {
            get
            {
                if (m_proxy == null)
                {
                    acc = AccessFactory.CreatedObject<ProductInfoInterface>();
                    m_proxy = new ProductInfoBLL();
                }

                return m_proxy;
            }
        }

        #endregion

        public int AddIdentity(ProductInfoVO m)
        {
            return acc.InsertIdentityId(m);
        }

        public bool Add(ProductInfoVO m)
        {
            return acc.Insert(m);
        }

        public bool Edit(ProductInfoVO m)
        {
            return acc.Edit(m);
        }

        public bool Delete(ProductInfoPara mp)
        {
            return acc.Delete(mp);
        }

        public ProductInfoVO GetSingle(ProductInfoPara mp)
        {
            return acc.GetSingle(mp);
        }

        public List<ProductInfoVO> GetModels(ProductInfoPara mp)
        {
            return acc.GetModels(mp);
        }

        public List<ProductInfoVO> GetModels(ref ProductInfoPara mp)
        {
            return acc.GetModels(ref mp);
        }

        public int GetRecords(ProductInfoPara mp)
        {
            return acc.GetRecords(mp);
        }
    }
}
