
/*

skey edit by 2017/7/17 16:02:27

*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DN.WeiAd.Models;
using DN.Framework.Core;

namespace DN.WeiAd.Interface
{
    public abstract class VirAdLogBrowseInterface : IAccess<VirAdLogBrowseVO, VirAdLogBrowsePara>
    {
		
        public abstract bool Delete(VirAdLogBrowsePara mp);
        public abstract bool Edit(VirAdLogBrowseVO m);
        public abstract string GetConditionByModel(VirAdLogBrowseVO m);
        public abstract string GetConditionByPara(VirAdLogBrowsePara mp);
        public abstract List<VirAdLogBrowseVO> GetModels(VirAdLogBrowsePara mp);
        public abstract List<VirAdLogBrowseVO> GetModels(ref VirAdLogBrowsePara mp);
        public abstract string GetOrderByModel(VirAdLogBrowseVO m);
        public abstract string GetOrderByPara(VirAdLogBrowsePara mp);
        public abstract string GetOtherConditionByModel(VirAdLogBrowseVO m);
        public abstract string GetOtherConditionByPara(VirAdLogBrowsePara mp);
        public abstract int GetRecords(VirAdLogBrowsePara mp);
        public abstract VirAdLogBrowseVO GetSingle(VirAdLogBrowsePara mp);
        public abstract bool Insert(VirAdLogBrowseVO m);
        public abstract int InsertIdentityId(VirAdLogBrowseVO m);
    }
}
