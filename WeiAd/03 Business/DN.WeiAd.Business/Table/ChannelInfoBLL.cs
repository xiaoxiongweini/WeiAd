
/*

skey edit by 2017/7/6 12:42:03

*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DN.WeiAd.Models;
using DN.WeiAd.Interface;
using DN.Framework.Core;

namespace DN.WeiAd.Business
{
    public partial class ChannelInfoBLL : IBusiness<ChannelInfoVO, ChannelInfoPara>
    {
        #region 实例

        static ChannelInfoBLL m_proxy = null;
        static ChannelInfoInterface acc = null;
        public static ChannelInfoBLL Instance
        {
            get
            {
                if (m_proxy == null)
                {
                    acc = AccessFactory.CreatedObject<ChannelInfoInterface>();
                    m_proxy = new ChannelInfoBLL();
                }

                return m_proxy;
            }
        }

        #endregion

        public int AddIdentity(ChannelInfoVO m)
        {
            return acc.InsertIdentityId(m);
        }

        public bool Add(ChannelInfoVO m)
        {
            return acc.Insert(m);
        }

        public bool Edit(ChannelInfoVO m)
        {
            return acc.Edit(m);
        }

        public bool Delete(ChannelInfoPara mp)
        {
            return acc.Delete(mp);
        }

        public ChannelInfoVO GetSingle(ChannelInfoPara mp)
        {
            return acc.GetSingle(mp);
        }

        public List<ChannelInfoVO> GetModels(ChannelInfoPara mp)
        {
            return acc.GetModels(mp);
        }

        public List<ChannelInfoVO> GetModels(ref ChannelInfoPara mp)
        {
            return acc.GetModels(ref mp);
        }

        public int GetRecords(ChannelInfoPara mp)
        {
            return acc.GetRecords(mp);
        }
    }
}
