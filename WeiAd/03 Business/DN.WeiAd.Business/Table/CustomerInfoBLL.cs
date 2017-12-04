
/*

skey edit by 2017/7/15 23:22:53

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
    public partial class CustomerInfoBLL : IBusiness<CustomerInfoVO, CustomerInfoPara>
    {
        #region 实例

        static CustomerInfoBLL m_proxy = null;
        static CustomerInfoInterface acc = null;
        public static CustomerInfoBLL Instance
        {
            get
            {
                if (m_proxy == null)
                {
                    acc = AccessFactory.CreatedObject<CustomerInfoInterface>();
                    m_proxy = new CustomerInfoBLL();
                }

                return m_proxy;
            }
        }

        #endregion

        public int AddIdentity(CustomerInfoVO m)
        {
            return acc.InsertIdentityId(m);
        }

        public bool Add(CustomerInfoVO m)
        {
            return acc.Insert(m);
        }

        public bool Edit(CustomerInfoVO m)
        {
            return acc.Edit(m);
        }

        public bool Delete(CustomerInfoPara mp)
        {
            return acc.Delete(mp);
        }

        public CustomerInfoVO GetSingle(CustomerInfoPara mp)
        {
            return acc.GetSingle(mp);
        }

        public List<CustomerInfoVO> GetModels(CustomerInfoPara mp)
        {
            return acc.GetModels(mp);
        }

        public List<CustomerInfoVO> GetModels(ref CustomerInfoPara mp)
        {
            return acc.GetModels(ref mp);
        }

        public int GetRecords(CustomerInfoPara mp)
        {
            return acc.GetRecords(mp);
        }
    }
}
