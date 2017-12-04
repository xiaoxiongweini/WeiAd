
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
    public abstract class AdUserPageInterface : IAccess<AdUserPageVO, AdUserPagePara>
    {
		
        public abstract bool Delete(AdUserPagePara mp);
        public abstract bool Edit(AdUserPageVO m);
        public abstract string GetConditionByModel(AdUserPageVO m);
        public abstract string GetConditionByPara(AdUserPagePara mp);
        public abstract List<AdUserPageVO> GetModels(AdUserPagePara mp);
        public abstract List<AdUserPageVO> GetModels(ref AdUserPagePara mp);
        public abstract string GetOrderByModel(AdUserPageVO m);
        public abstract string GetOrderByPara(AdUserPagePara mp);
        public abstract string GetOtherConditionByModel(AdUserPageVO m);
        public abstract string GetOtherConditionByPara(AdUserPagePara mp);
        public abstract int GetRecords(AdUserPagePara mp);
        public abstract AdUserPageVO GetSingle(AdUserPagePara mp);
        public abstract bool Insert(AdUserPageVO m);
        public abstract int InsertIdentityId(AdUserPageVO m);
    }
}
