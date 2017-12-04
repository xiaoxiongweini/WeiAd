
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
    public abstract class UserFinanceHistoryInterface : IAccess<UserFinanceHistoryVO, UserFinanceHistoryPara>
    {
		
        public abstract bool Delete(UserFinanceHistoryPara mp);
        public abstract bool Edit(UserFinanceHistoryVO m);
        public abstract string GetConditionByModel(UserFinanceHistoryVO m);
        public abstract string GetConditionByPara(UserFinanceHistoryPara mp);
        public abstract List<UserFinanceHistoryVO> GetModels(UserFinanceHistoryPara mp);
        public abstract List<UserFinanceHistoryVO> GetModels(ref UserFinanceHistoryPara mp);
        public abstract string GetOrderByModel(UserFinanceHistoryVO m);
        public abstract string GetOrderByPara(UserFinanceHistoryPara mp);
        public abstract string GetOtherConditionByModel(UserFinanceHistoryVO m);
        public abstract string GetOtherConditionByPara(UserFinanceHistoryPara mp);
        public abstract int GetRecords(UserFinanceHistoryPara mp);
        public abstract UserFinanceHistoryVO GetSingle(UserFinanceHistoryPara mp);
        public abstract bool Insert(UserFinanceHistoryVO m);
        public abstract int InsertIdentityId(UserFinanceHistoryVO m);
    }
}
