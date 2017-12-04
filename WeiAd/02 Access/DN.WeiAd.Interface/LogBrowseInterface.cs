
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
    public abstract class LogBrowseInterface : IAccess<LogBrowseVO, LogBrowsePara>
    {
		
        public abstract bool Delete(LogBrowsePara mp);
        public abstract bool Edit(LogBrowseVO m);
        public abstract string GetConditionByModel(LogBrowseVO m);
        public abstract string GetConditionByPara(LogBrowsePara mp);
        public abstract List<LogBrowseVO> GetModels(LogBrowsePara mp);
        public abstract List<LogBrowseVO> GetModels(ref LogBrowsePara mp);
        public abstract string GetOrderByModel(LogBrowseVO m);
        public abstract string GetOrderByPara(LogBrowsePara mp);
        public abstract string GetOtherConditionByModel(LogBrowseVO m);
        public abstract string GetOtherConditionByPara(LogBrowsePara mp);
        public abstract int GetRecords(LogBrowsePara mp);
        public abstract LogBrowseVO GetSingle(LogBrowsePara mp);
        public abstract bool Insert(LogBrowseVO m);
        public abstract int InsertIdentityId(LogBrowseVO m);
    }
}
