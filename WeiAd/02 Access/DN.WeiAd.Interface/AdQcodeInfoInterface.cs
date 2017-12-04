
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
    public abstract class AdQcodeInfoInterface : IAccess<AdQcodeInfoVO, AdQcodeInfoPara>
    {
		
        public abstract bool Delete(AdQcodeInfoPara mp);
        public abstract bool Edit(AdQcodeInfoVO m);
        public abstract string GetConditionByModel(AdQcodeInfoVO m);
        public abstract string GetConditionByPara(AdQcodeInfoPara mp);
        public abstract List<AdQcodeInfoVO> GetModels(AdQcodeInfoPara mp);
        public abstract List<AdQcodeInfoVO> GetModels(ref AdQcodeInfoPara mp);
        public abstract string GetOrderByModel(AdQcodeInfoVO m);
        public abstract string GetOrderByPara(AdQcodeInfoPara mp);
        public abstract string GetOtherConditionByModel(AdQcodeInfoVO m);
        public abstract string GetOtherConditionByPara(AdQcodeInfoPara mp);
        public abstract int GetRecords(AdQcodeInfoPara mp);
        public abstract AdQcodeInfoVO GetSingle(AdQcodeInfoPara mp);
        public abstract bool Insert(AdQcodeInfoVO m);
        public abstract int InsertIdentityId(AdQcodeInfoVO m);
    }
}
