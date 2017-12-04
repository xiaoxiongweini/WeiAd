
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
    public abstract class SysAreaDistrictsInterface : IAccess<SysAreaDistrictsVO, SysAreaDistrictsPara>
    {
		
        public abstract bool Delete(SysAreaDistrictsPara mp);
        public abstract bool Edit(SysAreaDistrictsVO m);
        public abstract string GetConditionByModel(SysAreaDistrictsVO m);
        public abstract string GetConditionByPara(SysAreaDistrictsPara mp);
        public abstract List<SysAreaDistrictsVO> GetModels(SysAreaDistrictsPara mp);
        public abstract List<SysAreaDistrictsVO> GetModels(ref SysAreaDistrictsPara mp);
        public abstract string GetOrderByModel(SysAreaDistrictsVO m);
        public abstract string GetOrderByPara(SysAreaDistrictsPara mp);
        public abstract string GetOtherConditionByModel(SysAreaDistrictsVO m);
        public abstract string GetOtherConditionByPara(SysAreaDistrictsPara mp);
        public abstract int GetRecords(SysAreaDistrictsPara mp);
        public abstract SysAreaDistrictsVO GetSingle(SysAreaDistrictsPara mp);
        public abstract bool Insert(SysAreaDistrictsVO m);
        public abstract int InsertIdentityId(SysAreaDistrictsVO m);
    }
}
