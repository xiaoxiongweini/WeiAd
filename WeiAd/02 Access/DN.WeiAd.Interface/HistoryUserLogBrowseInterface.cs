
/*

skey edit by 2017/7/4 15:51:12

*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DN.WeiAd.Models;
using DN.Framework.Core;

namespace DN.WeiAd.Interface
{
    public abstract class HistoryUserLogBrowseInterface : IAccess<HistoryUserLogBrowseVO, HistoryUserLogBrowsePara>
    {
		
        public abstract bool Delete(HistoryUserLogBrowsePara mp);
        public abstract bool Edit(HistoryUserLogBrowseVO m);
        public abstract string GetConditionByModel(HistoryUserLogBrowseVO m);
        public abstract string GetConditionByPara(HistoryUserLogBrowsePara mp);
        public abstract List<HistoryUserLogBrowseVO> GetModels(HistoryUserLogBrowsePara mp);
        public abstract List<HistoryUserLogBrowseVO> GetModels(ref HistoryUserLogBrowsePara mp);
        public abstract string GetOrderByModel(HistoryUserLogBrowseVO m);
        public abstract string GetOrderByPara(HistoryUserLogBrowsePara mp);
        public abstract string GetOtherConditionByModel(HistoryUserLogBrowseVO m);
        public abstract string GetOtherConditionByPara(HistoryUserLogBrowsePara mp);
        public abstract int GetRecords(HistoryUserLogBrowsePara mp);
        public abstract HistoryUserLogBrowseVO GetSingle(HistoryUserLogBrowsePara mp);
        public abstract bool Insert(HistoryUserLogBrowseVO m);
        public abstract int InsertIdentityId(HistoryUserLogBrowseVO m);
    }
}
