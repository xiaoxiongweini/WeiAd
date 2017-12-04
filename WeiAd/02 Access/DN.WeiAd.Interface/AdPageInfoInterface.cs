
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
    public abstract class AdPageInfoInterface : IAccess<AdPageInfoVO, AdPageInfoPara>
    {
		
        public abstract bool Delete(AdPageInfoPara mp);
        public abstract bool Edit(AdPageInfoVO m);
        public abstract string GetConditionByModel(AdPageInfoVO m);
        public abstract string GetConditionByPara(AdPageInfoPara mp);
        public abstract List<AdPageInfoVO> GetModels(AdPageInfoPara mp);
        public abstract List<AdPageInfoVO> GetModels(ref AdPageInfoPara mp);
        public abstract string GetOrderByModel(AdPageInfoVO m);
        public abstract string GetOrderByPara(AdPageInfoPara mp);
        public abstract string GetOtherConditionByModel(AdPageInfoVO m);
        public abstract string GetOtherConditionByPara(AdPageInfoPara mp);
        public abstract int GetRecords(AdPageInfoPara mp);
        public abstract AdPageInfoVO GetSingle(AdPageInfoPara mp);
        public abstract bool Insert(AdPageInfoVO m);
        public abstract int InsertIdentityId(AdPageInfoVO m);
    }
}
