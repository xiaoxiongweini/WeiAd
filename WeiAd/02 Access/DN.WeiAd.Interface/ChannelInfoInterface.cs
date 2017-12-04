
/*

skey edit by 2017/7/6 12:42:03

*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DN.WeiAd.Models;
using DN.Framework.Core;

namespace DN.WeiAd.Interface
{
    public abstract class ChannelInfoInterface : IAccess<ChannelInfoVO, ChannelInfoPara>
    {
		
        public abstract bool Delete(ChannelInfoPara mp);
        public abstract bool Edit(ChannelInfoVO m);
        public abstract string GetConditionByModel(ChannelInfoVO m);
        public abstract string GetConditionByPara(ChannelInfoPara mp);
        public abstract List<ChannelInfoVO> GetModels(ChannelInfoPara mp);
        public abstract List<ChannelInfoVO> GetModels(ref ChannelInfoPara mp);
        public abstract string GetOrderByModel(ChannelInfoVO m);
        public abstract string GetOrderByPara(ChannelInfoPara mp);
        public abstract string GetOtherConditionByModel(ChannelInfoVO m);
        public abstract string GetOtherConditionByPara(ChannelInfoPara mp);
        public abstract int GetRecords(ChannelInfoPara mp);
        public abstract ChannelInfoVO GetSingle(ChannelInfoPara mp);
        public abstract bool Insert(ChannelInfoVO m);
        public abstract int InsertIdentityId(ChannelInfoVO m);
    }
}
