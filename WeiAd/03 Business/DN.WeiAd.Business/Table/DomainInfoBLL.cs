
/*

skey edit by 2017-02-28 21:22:50

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
    public partial class DomainInfoBLL : IBusiness<DomainInfoVO, DomainInfoPara>
    {
        #region 实例

        static DomainInfoBLL m_proxy = null;
        static DomainInfoInterface acc = null;
        public static DomainInfoBLL Instance
        {
            get
            {
                if (m_proxy == null)
                {
                    acc = AccessFactory.CreatedObject<DomainInfoInterface>();
                    m_proxy = new DomainInfoBLL();
                }

                return m_proxy;
            }
        }

        #endregion

        public int AddIdentity(DomainInfoVO m)
        {
            return acc.InsertIdentityId(m);
        }

        public bool Add(DomainInfoVO m)
        {
            return acc.Insert(m);
        }

        public bool Edit(DomainInfoVO m)
        {
            return acc.Edit(m);
        }

        public bool Delete(DomainInfoPara mp)
        {
            return acc.Delete(mp);
        }

        public DomainInfoVO GetSingle(DomainInfoPara mp)
        {
            return acc.GetSingle(mp);
        }

        public List<DomainInfoVO> GetModels(DomainInfoPara mp)
        {
            return acc.GetModels(mp);
        }

        public List<DomainInfoVO> GetModels(ref DomainInfoPara mp)
        {
            return acc.GetModels(ref mp);
        }

        public int GetRecords(DomainInfoPara mp)
        {
            return acc.GetRecords(mp);
        }
    }
}
