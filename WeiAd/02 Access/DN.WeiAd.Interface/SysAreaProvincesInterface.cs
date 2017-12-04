
/*

skey edit by 2017/7/16 9:01:29

*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DN.WeiAd.Models;
using DN.Framework.Core;

namespace DN.WeiAd.Interface
{
    public abstract class SysAreaProvincesInterface : IAccess<SysAreaProvincesVO, SysAreaProvincesPara>
    {
		
        public abstract bool Delete(SysAreaProvincesPara mp);
        public abstract bool Edit(SysAreaProvincesVO m);
        public abstract string GetConditionByModel(SysAreaProvincesVO m);
        public abstract string GetConditionByPara(SysAreaProvincesPara mp);
        public abstract List<SysAreaProvincesVO> GetModels(SysAreaProvincesPara mp);
        public abstract List<SysAreaProvincesVO> GetModels(ref SysAreaProvincesPara mp);
        public abstract string GetOrderByModel(SysAreaProvincesVO m);
        public abstract string GetOrderByPara(SysAreaProvincesPara mp);
        public abstract string GetOtherConditionByModel(SysAreaProvincesVO m);
        public abstract string GetOtherConditionByPara(SysAreaProvincesPara mp);
        public abstract int GetRecords(SysAreaProvincesPara mp);
        public abstract SysAreaProvincesVO GetSingle(SysAreaProvincesPara mp);
        public abstract bool Insert(SysAreaProvincesVO m);
        public abstract int InsertIdentityId(SysAreaProvincesVO m);
    }
}
