
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
    public abstract class VirAdInfoInterface : IAccess<VirAdInfoVO, VirAdInfoPara>
    {
		
        public abstract bool Delete(VirAdInfoPara mp);
        public abstract bool Edit(VirAdInfoVO m);
        public abstract string GetConditionByModel(VirAdInfoVO m);
        public abstract string GetConditionByPara(VirAdInfoPara mp);
        public abstract List<VirAdInfoVO> GetModels(VirAdInfoPara mp);
        public abstract List<VirAdInfoVO> GetModels(ref VirAdInfoPara mp);
        public abstract string GetOrderByModel(VirAdInfoVO m);
        public abstract string GetOrderByPara(VirAdInfoPara mp);
        public abstract string GetOtherConditionByModel(VirAdInfoVO m);
        public abstract string GetOtherConditionByPara(VirAdInfoPara mp);
        public abstract int GetRecords(VirAdInfoPara mp);
        public abstract VirAdInfoVO GetSingle(VirAdInfoPara mp);
        public abstract bool Insert(VirAdInfoVO m);
        public abstract int InsertIdentityId(VirAdInfoVO m);
    }
}
