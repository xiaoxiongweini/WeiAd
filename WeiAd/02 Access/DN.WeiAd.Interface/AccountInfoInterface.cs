
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
    public abstract class AccountInfoInterface : IAccess<AccountInfoVO, AccountInfoPara>
    {
		
        public abstract bool Delete(AccountInfoPara mp);
        public abstract bool Edit(AccountInfoVO m);
        public abstract string GetConditionByModel(AccountInfoVO m);
        public abstract string GetConditionByPara(AccountInfoPara mp);
        public abstract List<AccountInfoVO> GetModels(AccountInfoPara mp);
        public abstract List<AccountInfoVO> GetModels(ref AccountInfoPara mp);
        public abstract string GetOrderByModel(AccountInfoVO m);
        public abstract string GetOrderByPara(AccountInfoPara mp);
        public abstract string GetOtherConditionByModel(AccountInfoVO m);
        public abstract string GetOtherConditionByPara(AccountInfoPara mp);
        public abstract int GetRecords(AccountInfoPara mp);
        public abstract AccountInfoVO GetSingle(AccountInfoPara mp);
        public abstract bool Insert(AccountInfoVO m);
        public abstract int InsertIdentityId(AccountInfoVO m);
    }
}
