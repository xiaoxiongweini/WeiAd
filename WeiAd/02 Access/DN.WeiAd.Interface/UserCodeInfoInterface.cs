
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
    public abstract class UserCodeInfoInterface : IAccess<UserCodeInfoVO, UserCodeInfoPara>
    {
		
        public abstract bool Delete(UserCodeInfoPara mp);
        public abstract bool Edit(UserCodeInfoVO m);
        public abstract string GetConditionByModel(UserCodeInfoVO m);
        public abstract string GetConditionByPara(UserCodeInfoPara mp);
        public abstract List<UserCodeInfoVO> GetModels(UserCodeInfoPara mp);
        public abstract List<UserCodeInfoVO> GetModels(ref UserCodeInfoPara mp);
        public abstract string GetOrderByModel(UserCodeInfoVO m);
        public abstract string GetOrderByPara(UserCodeInfoPara mp);
        public abstract string GetOtherConditionByModel(UserCodeInfoVO m);
        public abstract string GetOtherConditionByPara(UserCodeInfoPara mp);
        public abstract int GetRecords(UserCodeInfoPara mp);
        public abstract UserCodeInfoVO GetSingle(UserCodeInfoPara mp);
        public abstract bool Insert(UserCodeInfoVO m);
        public abstract int InsertIdentityId(UserCodeInfoVO m);
    }
}
