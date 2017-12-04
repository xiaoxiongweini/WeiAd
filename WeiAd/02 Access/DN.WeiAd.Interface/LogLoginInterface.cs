
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
    public abstract class LogLoginInterface : IAccess<LogLoginVO, LogLoginPara>
    {
		
        public abstract bool Delete(LogLoginPara mp);
        public abstract bool Edit(LogLoginVO m);
        public abstract string GetConditionByModel(LogLoginVO m);
        public abstract string GetConditionByPara(LogLoginPara mp);
        public abstract List<LogLoginVO> GetModels(LogLoginPara mp);
        public abstract List<LogLoginVO> GetModels(ref LogLoginPara mp);
        public abstract string GetOrderByModel(LogLoginVO m);
        public abstract string GetOrderByPara(LogLoginPara mp);
        public abstract string GetOtherConditionByModel(LogLoginVO m);
        public abstract string GetOtherConditionByPara(LogLoginPara mp);
        public abstract int GetRecords(LogLoginPara mp);
        public abstract LogLoginVO GetSingle(LogLoginPara mp);
        public abstract bool Insert(LogLoginVO m);
        public abstract int InsertIdentityId(LogLoginVO m);
    }
}
