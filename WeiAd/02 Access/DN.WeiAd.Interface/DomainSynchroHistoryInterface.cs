
/*

skey edit by 2017/7/27 18:02:51

*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DN.WeiAd.Models;
using DN.Framework.Core;

namespace DN.WeiAd.Interface
{
    public abstract class DomainSynchroHistoryInterface : IAccess<DomainSynchroHistoryVO, DomainSynchroHistoryPara>
    {
		
        public abstract bool Delete(DomainSynchroHistoryPara mp);
        public abstract bool Edit(DomainSynchroHistoryVO m);
        public abstract string GetConditionByModel(DomainSynchroHistoryVO m);
        public abstract string GetConditionByPara(DomainSynchroHistoryPara mp);
        public abstract List<DomainSynchroHistoryVO> GetModels(DomainSynchroHistoryPara mp);
        public abstract List<DomainSynchroHistoryVO> GetModels(ref DomainSynchroHistoryPara mp);
        public abstract string GetOrderByModel(DomainSynchroHistoryVO m);
        public abstract string GetOrderByPara(DomainSynchroHistoryPara mp);
        public abstract string GetOtherConditionByModel(DomainSynchroHistoryVO m);
        public abstract string GetOtherConditionByPara(DomainSynchroHistoryPara mp);
        public abstract int GetRecords(DomainSynchroHistoryPara mp);
        public abstract DomainSynchroHistoryVO GetSingle(DomainSynchroHistoryPara mp);
        public abstract bool Insert(DomainSynchroHistoryVO m);
        public abstract int InsertIdentityId(DomainSynchroHistoryVO m);
    }
}
