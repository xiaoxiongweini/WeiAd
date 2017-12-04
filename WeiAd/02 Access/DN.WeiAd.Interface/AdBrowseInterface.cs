
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
    public abstract class AdBrowseInterface : IAccess<AdBrowseVO, AdBrowsePara>
    {
		
        public abstract bool Delete(AdBrowsePara mp);
        public abstract bool Edit(AdBrowseVO m);
        public abstract string GetConditionByModel(AdBrowseVO m);
        public abstract string GetConditionByPara(AdBrowsePara mp);
        public abstract List<AdBrowseVO> GetModels(AdBrowsePara mp);
        public abstract List<AdBrowseVO> GetModels(ref AdBrowsePara mp);
        public abstract string GetOrderByModel(AdBrowseVO m);
        public abstract string GetOrderByPara(AdBrowsePara mp);
        public abstract string GetOtherConditionByModel(AdBrowseVO m);
        public abstract string GetOtherConditionByPara(AdBrowsePara mp);
        public abstract int GetRecords(AdBrowsePara mp);
        public abstract AdBrowseVO GetSingle(AdBrowsePara mp);
        public abstract bool Insert(AdBrowseVO m);
        public abstract int InsertIdentityId(AdBrowseVO m);
    }
}
