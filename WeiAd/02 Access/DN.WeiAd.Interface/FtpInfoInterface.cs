
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
    public abstract class FtpInfoInterface : IAccess<FtpInfoVO, FtpInfoPara>
    {
		
        public abstract bool Delete(FtpInfoPara mp);
        public abstract bool Edit(FtpInfoVO m);
        public abstract string GetConditionByModel(FtpInfoVO m);
        public abstract string GetConditionByPara(FtpInfoPara mp);
        public abstract List<FtpInfoVO> GetModels(FtpInfoPara mp);
        public abstract List<FtpInfoVO> GetModels(ref FtpInfoPara mp);
        public abstract string GetOrderByModel(FtpInfoVO m);
        public abstract string GetOrderByPara(FtpInfoPara mp);
        public abstract string GetOtherConditionByModel(FtpInfoVO m);
        public abstract string GetOtherConditionByPara(FtpInfoPara mp);
        public abstract int GetRecords(FtpInfoPara mp);
        public abstract FtpInfoVO GetSingle(FtpInfoPara mp);
        public abstract bool Insert(FtpInfoVO m);
        public abstract int InsertIdentityId(FtpInfoVO m);
    }
}
