
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
    public abstract class SysAreaCityInterface : IAccess<SysAreaCityVO, SysAreaCityPara>
    {
		
        public abstract bool Delete(SysAreaCityPara mp);
        public abstract bool Edit(SysAreaCityVO m);
        public abstract string GetConditionByModel(SysAreaCityVO m);
        public abstract string GetConditionByPara(SysAreaCityPara mp);
        public abstract List<SysAreaCityVO> GetModels(SysAreaCityPara mp);
        public abstract List<SysAreaCityVO> GetModels(ref SysAreaCityPara mp);
        public abstract string GetOrderByModel(SysAreaCityVO m);
        public abstract string GetOrderByPara(SysAreaCityPara mp);
        public abstract string GetOtherConditionByModel(SysAreaCityVO m);
        public abstract string GetOtherConditionByPara(SysAreaCityPara mp);
        public abstract int GetRecords(SysAreaCityPara mp);
        public abstract SysAreaCityVO GetSingle(SysAreaCityPara mp);
        public abstract bool Insert(SysAreaCityVO m);
        public abstract int InsertIdentityId(SysAreaCityVO m);
    }
}
