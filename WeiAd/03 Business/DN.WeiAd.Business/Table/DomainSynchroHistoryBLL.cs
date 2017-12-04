
/*

skey edit by 2017/7/27 18:02:51

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
    public partial class DomainSynchroHistoryBLL : IBusiness<DomainSynchroHistoryVO, DomainSynchroHistoryPara>
    {
        #region 实例

        static DomainSynchroHistoryBLL m_proxy = null;
        static DomainSynchroHistoryInterface acc = null;
        public static DomainSynchroHistoryBLL Instance
        {
            get
            {
                if (m_proxy == null)
                {
                    acc = AccessFactory.CreatedObject<DomainSynchroHistoryInterface>();
                    m_proxy = new DomainSynchroHistoryBLL();
                }

                return m_proxy;
            }
        }

        #endregion

        public int AddIdentity(DomainSynchroHistoryVO m)
        {
            return acc.InsertIdentityId(m);
        }

        public bool Add(DomainSynchroHistoryVO m)
        {
            return acc.Insert(m);
        }

        public bool Edit(DomainSynchroHistoryVO m)
        {
            return acc.Edit(m);
        }

        public bool Delete(DomainSynchroHistoryPara mp)
        {
            return acc.Delete(mp);
        }

        public DomainSynchroHistoryVO GetSingle(DomainSynchroHistoryPara mp)
        {
            return acc.GetSingle(mp);
        }

        public List<DomainSynchroHistoryVO> GetModels(DomainSynchroHistoryPara mp)
        {
            return acc.GetModels(mp);
        }

        public List<DomainSynchroHistoryVO> GetModels(ref DomainSynchroHistoryPara mp)
        {
            return acc.GetModels(ref mp);
        }

        public int GetRecords(DomainSynchroHistoryPara mp)
        {
            return acc.GetRecords(mp);
        }
    }
}
