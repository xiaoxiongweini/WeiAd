
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
    public abstract class LogAdQcodeInterface : IAccess<LogAdQcodeVO, LogAdQcodePara>
    {
		
        public abstract bool Delete(LogAdQcodePara mp);
        public abstract bool Edit(LogAdQcodeVO m);
        public abstract string GetConditionByModel(LogAdQcodeVO m);
        public abstract string GetConditionByPara(LogAdQcodePara mp);
        public abstract List<LogAdQcodeVO> GetModels(LogAdQcodePara mp);
        public abstract List<LogAdQcodeVO> GetModels(ref LogAdQcodePara mp);
        public abstract string GetOrderByModel(LogAdQcodeVO m);
        public abstract string GetOrderByPara(LogAdQcodePara mp);
        public abstract string GetOtherConditionByModel(LogAdQcodeVO m);
        public abstract string GetOtherConditionByPara(LogAdQcodePara mp);
        public abstract int GetRecords(LogAdQcodePara mp);
        public abstract LogAdQcodeVO GetSingle(LogAdQcodePara mp);
        public abstract bool Insert(LogAdQcodeVO m);
        public abstract int InsertIdentityId(LogAdQcodeVO m);
    }
}
