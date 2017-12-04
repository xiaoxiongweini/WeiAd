
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
    public abstract class VersionInfoInterface : IAccess<VersionInfoVO, VersionInfoPara>
    {
		
        public abstract bool Delete(VersionInfoPara mp);
        public abstract bool Edit(VersionInfoVO m);
        public abstract string GetConditionByModel(VersionInfoVO m);
        public abstract string GetConditionByPara(VersionInfoPara mp);
        public abstract List<VersionInfoVO> GetModels(VersionInfoPara mp);
        public abstract List<VersionInfoVO> GetModels(ref VersionInfoPara mp);
        public abstract string GetOrderByModel(VersionInfoVO m);
        public abstract string GetOrderByPara(VersionInfoPara mp);
        public abstract string GetOtherConditionByModel(VersionInfoVO m);
        public abstract string GetOtherConditionByPara(VersionInfoPara mp);
        public abstract int GetRecords(VersionInfoPara mp);
        public abstract VersionInfoVO GetSingle(VersionInfoPara mp);
        public abstract bool Insert(VersionInfoVO m);
        public abstract int InsertIdentityId(VersionInfoVO m);
    }
}
