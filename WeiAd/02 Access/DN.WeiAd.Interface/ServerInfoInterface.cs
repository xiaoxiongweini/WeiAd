
/*

skey edit by 2017/7/19 15:50:42

*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DN.WeiAd.Models;
using DN.Framework.Core;

namespace DN.WeiAd.Interface
{
    public abstract class ServerInfoInterface : IAccess<ServerInfoVO, ServerInfoPara>
    {
		
        public abstract bool Delete(ServerInfoPara mp);
        public abstract bool Edit(ServerInfoVO m);
        public abstract string GetConditionByModel(ServerInfoVO m);
        public abstract string GetConditionByPara(ServerInfoPara mp);
        public abstract List<ServerInfoVO> GetModels(ServerInfoPara mp);
        public abstract List<ServerInfoVO> GetModels(ref ServerInfoPara mp);
        public abstract string GetOrderByModel(ServerInfoVO m);
        public abstract string GetOrderByPara(ServerInfoPara mp);
        public abstract string GetOtherConditionByModel(ServerInfoVO m);
        public abstract string GetOtherConditionByPara(ServerInfoPara mp);
        public abstract int GetRecords(ServerInfoPara mp);
        public abstract ServerInfoVO GetSingle(ServerInfoPara mp);
        public abstract bool Insert(ServerInfoVO m);
        public abstract int InsertIdentityId(ServerInfoVO m);
    }
}
