
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
    public abstract class LogIpInfoInterface : IAccess<LogIpInfoVO, LogIpInfoPara>
    {
		
        public abstract bool Delete(LogIpInfoPara mp);
        public abstract bool Edit(LogIpInfoVO m);
        public abstract string GetConditionByModel(LogIpInfoVO m);
        public abstract string GetConditionByPara(LogIpInfoPara mp);
        public abstract List<LogIpInfoVO> GetModels(LogIpInfoPara mp);
        public abstract List<LogIpInfoVO> GetModels(ref LogIpInfoPara mp);
        public abstract string GetOrderByModel(LogIpInfoVO m);
        public abstract string GetOrderByPara(LogIpInfoPara mp);
        public abstract string GetOtherConditionByModel(LogIpInfoVO m);
        public abstract string GetOtherConditionByPara(LogIpInfoPara mp);
        public abstract int GetRecords(LogIpInfoPara mp);
        public abstract LogIpInfoVO GetSingle(LogIpInfoPara mp);
        public abstract bool Insert(LogIpInfoVO m);
        public abstract int InsertIdentityId(LogIpInfoVO m);
    }
}
