
/*

skey edit by 2017/7/24 9:27:33

*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DN.WeiAd.Models;
using DN.Framework.Core;

namespace DN.WeiAd.Interface
{
    public abstract class ProductInfoInterface : IAccess<ProductInfoVO, ProductInfoPara>
    {
		
        public abstract bool Delete(ProductInfoPara mp);
        public abstract bool Edit(ProductInfoVO m);
        public abstract string GetConditionByModel(ProductInfoVO m);
        public abstract string GetConditionByPara(ProductInfoPara mp);
        public abstract List<ProductInfoVO> GetModels(ProductInfoPara mp);
        public abstract List<ProductInfoVO> GetModels(ref ProductInfoPara mp);
        public abstract string GetOrderByModel(ProductInfoVO m);
        public abstract string GetOrderByPara(ProductInfoPara mp);
        public abstract string GetOtherConditionByModel(ProductInfoVO m);
        public abstract string GetOtherConditionByPara(ProductInfoPara mp);
        public abstract int GetRecords(ProductInfoPara mp);
        public abstract ProductInfoVO GetSingle(ProductInfoPara mp);
        public abstract bool Insert(ProductInfoVO m);
        public abstract int InsertIdentityId(ProductInfoVO m);
    }
}
