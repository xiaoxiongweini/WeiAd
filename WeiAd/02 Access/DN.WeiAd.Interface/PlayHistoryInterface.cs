
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
    public abstract class PlayHistoryInterface : IAccess<PlayHistoryVO, PlayHistoryPara>
    {
		
        public abstract bool Delete(PlayHistoryPara mp);
        public abstract bool Edit(PlayHistoryVO m);
        public abstract string GetConditionByModel(PlayHistoryVO m);
        public abstract string GetConditionByPara(PlayHistoryPara mp);
        public abstract List<PlayHistoryVO> GetModels(PlayHistoryPara mp);
        public abstract List<PlayHistoryVO> GetModels(ref PlayHistoryPara mp);
        public abstract string GetOrderByModel(PlayHistoryVO m);
        public abstract string GetOrderByPara(PlayHistoryPara mp);
        public abstract string GetOtherConditionByModel(PlayHistoryVO m);
        public abstract string GetOtherConditionByPara(PlayHistoryPara mp);
        public abstract int GetRecords(PlayHistoryPara mp);
        public abstract PlayHistoryVO GetSingle(PlayHistoryPara mp);
        public abstract bool Insert(PlayHistoryVO m);
        public abstract int InsertIdentityId(PlayHistoryVO m);
    }
}
