
/*

skey edit by 2017-05-01 15:14:58

*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DN.WeiAd.Models;
using DN.Framework.Core;

namespace DN.WeiAd.Interface
{
    public abstract class DomainInfoInterface : IAccess<DomainInfoVO, DomainInfoPara>
    {
		
        public abstract bool Delete(DomainInfoPara mp);
        public abstract bool Edit(DomainInfoVO m);
        public abstract string GetConditionByModel(DomainInfoVO m);
        public abstract string GetConditionByPara(DomainInfoPara mp);
        public abstract List<DomainInfoVO> GetModels(DomainInfoPara mp);
        public abstract List<DomainInfoVO> GetModels(ref DomainInfoPara mp);
        public abstract string GetOrderByModel(DomainInfoVO m);
        public abstract string GetOrderByPara(DomainInfoPara mp);
        public abstract string GetOtherConditionByModel(DomainInfoVO m);
        public abstract string GetOtherConditionByPara(DomainInfoPara mp);
        public abstract int GetRecords(DomainInfoPara mp);
        public abstract DomainInfoVO GetSingle(DomainInfoPara mp);
        public abstract bool Insert(DomainInfoVO m);
        public abstract int InsertIdentityId(DomainInfoVO m);
    }
}
