
/*

skey edit by 2017/7/4 11:20:59

*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DN.WeiAd.Models;
using DN.Framework.Core;

namespace DN.WeiAd.Interface
{
    public abstract class LogBrowseHistoryInterface : IAccess<LogBrowseHistoryVO, LogBrowseHistoryPara>
    {
		
        public abstract bool Delete(LogBrowseHistoryPara mp);
        public abstract bool Edit(LogBrowseHistoryVO m);
        public abstract string GetConditionByModel(LogBrowseHistoryVO m);
        public abstract string GetConditionByPara(LogBrowseHistoryPara mp);
        public abstract List<LogBrowseHistoryVO> GetModels(LogBrowseHistoryPara mp);
        public abstract List<LogBrowseHistoryVO> GetModels(ref LogBrowseHistoryPara mp);
        public abstract string GetOrderByModel(LogBrowseHistoryVO m);
        public abstract string GetOrderByPara(LogBrowseHistoryPara mp);
        public abstract string GetOtherConditionByModel(LogBrowseHistoryVO m);
        public abstract string GetOtherConditionByPara(LogBrowseHistoryPara mp);
        public abstract int GetRecords(LogBrowseHistoryPara mp);
        public abstract LogBrowseHistoryVO GetSingle(LogBrowseHistoryPara mp);
        public abstract bool Insert(LogBrowseHistoryVO m);
        public abstract int InsertIdentityId(LogBrowseHistoryVO m);
    }
}
