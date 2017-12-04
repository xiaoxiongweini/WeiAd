
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
    public abstract class AdBrowseHistoryInterface : IAccess<AdBrowseHistoryVO, AdBrowseHistoryPara>
    {
		
        public abstract bool Delete(AdBrowseHistoryPara mp);
        public abstract bool Edit(AdBrowseHistoryVO m);
        public abstract string GetConditionByModel(AdBrowseHistoryVO m);
        public abstract string GetConditionByPara(AdBrowseHistoryPara mp);
        public abstract List<AdBrowseHistoryVO> GetModels(AdBrowseHistoryPara mp);
        public abstract List<AdBrowseHistoryVO> GetModels(ref AdBrowseHistoryPara mp);
        public abstract string GetOrderByModel(AdBrowseHistoryVO m);
        public abstract string GetOrderByPara(AdBrowseHistoryPara mp);
        public abstract string GetOtherConditionByModel(AdBrowseHistoryVO m);
        public abstract string GetOtherConditionByPara(AdBrowseHistoryPara mp);
        public abstract int GetRecords(AdBrowseHistoryPara mp);
        public abstract AdBrowseHistoryVO GetSingle(AdBrowseHistoryPara mp);
        public abstract bool Insert(AdBrowseHistoryVO m);
        public abstract int InsertIdentityId(AdBrowseHistoryVO m);
    }
}
