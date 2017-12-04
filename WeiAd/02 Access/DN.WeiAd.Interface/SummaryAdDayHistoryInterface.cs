
/*

skey edit by 2017/9/21 10:02:13

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
    public abstract class SummaryAdDayHistoryInterface : IAccess<SummaryAdDayHistoryVO, SummaryAdDayHistoryPara>
    {
		
        public abstract bool Delete(SummaryAdDayHistoryPara mp);
        public abstract bool Edit(SummaryAdDayHistoryVO m);
        public abstract string GetConditionByModel(SummaryAdDayHistoryVO m);
        public abstract string GetConditionByPara(SummaryAdDayHistoryPara mp);
        public abstract List<SummaryAdDayHistoryVO> GetModels(SummaryAdDayHistoryPara mp);
        public abstract List<SummaryAdDayHistoryVO> GetModels(ref SummaryAdDayHistoryPara mp);
        public abstract string GetOrderByModel(SummaryAdDayHistoryVO m);
        public abstract string GetOrderByPara(SummaryAdDayHistoryPara mp);
        public abstract string GetOtherConditionByModel(SummaryAdDayHistoryVO m);
        public abstract string GetOtherConditionByPara(SummaryAdDayHistoryPara mp);
        public abstract int GetRecords(SummaryAdDayHistoryPara mp);
        public abstract SummaryAdDayHistoryVO GetSingle(SummaryAdDayHistoryPara mp);
        public abstract bool Insert(SummaryAdDayHistoryVO m);
        public abstract int InsertIdentityId(SummaryAdDayHistoryVO m);
    }
}
