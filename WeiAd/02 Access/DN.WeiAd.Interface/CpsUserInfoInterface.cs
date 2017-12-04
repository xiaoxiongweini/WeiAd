
/*

skey edit by 2017/7/20 12:01:18

*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DN.WeiAd.Models;
using DN.Framework.Core;

namespace DN.WeiAd.Interface
{
    public abstract class CpsUserInfoInterface : IAccess<CpsUserInfoVO, CpsUserInfoPara>
    {
		
        public abstract bool Delete(CpsUserInfoPara mp);
        public abstract bool Edit(CpsUserInfoVO m);
        public abstract string GetConditionByModel(CpsUserInfoVO m);
        public abstract string GetConditionByPara(CpsUserInfoPara mp);
        public abstract List<CpsUserInfoVO> GetModels(CpsUserInfoPara mp);
        public abstract List<CpsUserInfoVO> GetModels(ref CpsUserInfoPara mp);
        public abstract string GetOrderByModel(CpsUserInfoVO m);
        public abstract string GetOrderByPara(CpsUserInfoPara mp);
        public abstract string GetOtherConditionByModel(CpsUserInfoVO m);
        public abstract string GetOtherConditionByPara(CpsUserInfoPara mp);
        public abstract int GetRecords(CpsUserInfoPara mp);
        public abstract CpsUserInfoVO GetSingle(CpsUserInfoPara mp);
        public abstract bool Insert(CpsUserInfoVO m);
        public abstract int InsertIdentityId(CpsUserInfoVO m);
    }
}
