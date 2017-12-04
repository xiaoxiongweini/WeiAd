
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
    public abstract class VirAdBrowseInterface : IAccess<VirAdBrowseVO, VirAdBrowsePara>
    {
		
        public abstract bool Delete(VirAdBrowsePara mp);
        public abstract bool Edit(VirAdBrowseVO m);
        public abstract string GetConditionByModel(VirAdBrowseVO m);
        public abstract string GetConditionByPara(VirAdBrowsePara mp);
        public abstract List<VirAdBrowseVO> GetModels(VirAdBrowsePara mp);
        public abstract List<VirAdBrowseVO> GetModels(ref VirAdBrowsePara mp);
        public abstract string GetOrderByModel(VirAdBrowseVO m);
        public abstract string GetOrderByPara(VirAdBrowsePara mp);
        public abstract string GetOtherConditionByModel(VirAdBrowseVO m);
        public abstract string GetOtherConditionByPara(VirAdBrowsePara mp);
        public abstract int GetRecords(VirAdBrowsePara mp);
        public abstract VirAdBrowseVO GetSingle(VirAdBrowsePara mp);
        public abstract bool Insert(VirAdBrowseVO m);
        public abstract int InsertIdentityId(VirAdBrowseVO m);
    }
}
