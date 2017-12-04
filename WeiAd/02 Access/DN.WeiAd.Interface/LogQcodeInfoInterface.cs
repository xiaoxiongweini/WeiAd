
/*

skey edit by 2017/12/4 11:53:42

mail:skey111@foxmail.com

version edit by v1.0.3

*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DN.WeiAd.Models;
using DN.Framework.Core;

namespace DN.WeiAd.Interface
{
    public abstract class LogQcodeInfoInterface : IAccess<LogQcodeInfoVO, LogQcodeInfoPara>
    {
		
        public abstract bool Delete(LogQcodeInfoPara mp);
        public abstract bool Edit(LogQcodeInfoVO m);
        public abstract string GetConditionByModel(LogQcodeInfoVO m);
        public abstract string GetConditionByPara(LogQcodeInfoPara mp);
        public abstract List<LogQcodeInfoVO> GetModels(LogQcodeInfoPara mp);
        public abstract List<LogQcodeInfoVO> GetModels(ref LogQcodeInfoPara mp);
        public abstract string GetOrderByModel(LogQcodeInfoVO m);
        public abstract string GetOrderByPara(LogQcodeInfoPara mp);
        public abstract string GetOtherConditionByModel(LogQcodeInfoVO m);
        public abstract string GetOtherConditionByPara(LogQcodeInfoPara mp);
        public abstract int GetRecords(LogQcodeInfoPara mp);
        public abstract LogQcodeInfoVO GetSingle(LogQcodeInfoPara mp);
        public abstract bool Insert(LogQcodeInfoVO m);
        public abstract int InsertIdentityId(LogQcodeInfoVO m);
    }
}
