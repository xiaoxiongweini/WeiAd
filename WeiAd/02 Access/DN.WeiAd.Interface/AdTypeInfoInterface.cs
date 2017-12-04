
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
    public abstract class AdTypeInfoInterface : IAccess<AdTypeInfoVO, AdTypeInfoPara>
    {
		
        public abstract bool Delete(AdTypeInfoPara mp);
        public abstract bool Edit(AdTypeInfoVO m);
        public abstract string GetConditionByModel(AdTypeInfoVO m);
        public abstract string GetConditionByPara(AdTypeInfoPara mp);
        public abstract List<AdTypeInfoVO> GetModels(AdTypeInfoPara mp);
        public abstract List<AdTypeInfoVO> GetModels(ref AdTypeInfoPara mp);
        public abstract string GetOrderByModel(AdTypeInfoVO m);
        public abstract string GetOrderByPara(AdTypeInfoPara mp);
        public abstract string GetOtherConditionByModel(AdTypeInfoVO m);
        public abstract string GetOtherConditionByPara(AdTypeInfoPara mp);
        public abstract int GetRecords(AdTypeInfoPara mp);
        public abstract AdTypeInfoVO GetSingle(AdTypeInfoPara mp);
        public abstract bool Insert(AdTypeInfoVO m);
        public abstract int InsertIdentityId(AdTypeInfoVO m);
    }
}
