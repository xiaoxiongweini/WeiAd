
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
    public abstract class AdSiteInfoInterface : IAccess<AdSiteInfoVO, AdSiteInfoPara>
    {
		
        public abstract bool Delete(AdSiteInfoPara mp);
        public abstract bool Edit(AdSiteInfoVO m);
        public abstract string GetConditionByModel(AdSiteInfoVO m);
        public abstract string GetConditionByPara(AdSiteInfoPara mp);
        public abstract List<AdSiteInfoVO> GetModels(AdSiteInfoPara mp);
        public abstract List<AdSiteInfoVO> GetModels(ref AdSiteInfoPara mp);
        public abstract string GetOrderByModel(AdSiteInfoVO m);
        public abstract string GetOrderByPara(AdSiteInfoPara mp);
        public abstract string GetOtherConditionByModel(AdSiteInfoVO m);
        public abstract string GetOtherConditionByPara(AdSiteInfoPara mp);
        public abstract int GetRecords(AdSiteInfoPara mp);
        public abstract AdSiteInfoVO GetSingle(AdSiteInfoPara mp);
        public abstract bool Insert(AdSiteInfoVO m);
        public abstract int InsertIdentityId(AdSiteInfoVO m);
    }
}
