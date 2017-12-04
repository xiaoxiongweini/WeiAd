
/*

skey edit by 2017/7/15 23:22:53

*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DN.WeiAd.Models;
using DN.Framework.Core;

namespace DN.WeiAd.Interface
{
    public abstract class CustomerInfoInterface : IAccess<CustomerInfoVO, CustomerInfoPara>
    {
		
        public abstract bool Delete(CustomerInfoPara mp);
        public abstract bool Edit(CustomerInfoVO m);
        public abstract string GetConditionByModel(CustomerInfoVO m);
        public abstract string GetConditionByPara(CustomerInfoPara mp);
        public abstract List<CustomerInfoVO> GetModels(CustomerInfoPara mp);
        public abstract List<CustomerInfoVO> GetModels(ref CustomerInfoPara mp);
        public abstract string GetOrderByModel(CustomerInfoVO m);
        public abstract string GetOrderByPara(CustomerInfoPara mp);
        public abstract string GetOtherConditionByModel(CustomerInfoVO m);
        public abstract string GetOtherConditionByPara(CustomerInfoPara mp);
        public abstract int GetRecords(CustomerInfoPara mp);
        public abstract CustomerInfoVO GetSingle(CustomerInfoPara mp);
        public abstract bool Insert(CustomerInfoVO m);
        public abstract int InsertIdentityId(CustomerInfoVO m);
    }
}
