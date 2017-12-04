
/*

skey edit by 2017/7/19 15:50:43

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
    public partial class ServerInfoBLL : IBusiness<ServerInfoVO, ServerInfoPara>
    {
        #region 实例

        static ServerInfoBLL m_proxy = null;
        static ServerInfoInterface acc = null;
        public static ServerInfoBLL Instance
        {
            get
            {
                if (m_proxy == null)
                {
                    acc = AccessFactory.CreatedObject<ServerInfoInterface>();
                    m_proxy = new ServerInfoBLL();
                }

                return m_proxy;
            }
        }

        #endregion

        public int AddIdentity(ServerInfoVO m)
        {
            return acc.InsertIdentityId(m);
        }

        public bool Add(ServerInfoVO m)
        {
            return acc.Insert(m);
        }

        public bool Edit(ServerInfoVO m)
        {
            return acc.Edit(m);
        }

        public bool Delete(ServerInfoPara mp)
        {
            return acc.Delete(mp);
        }

        public ServerInfoVO GetSingle(ServerInfoPara mp)
        {
            return acc.GetSingle(mp);
        }

        public List<ServerInfoVO> GetModels(ServerInfoPara mp)
        {
            return acc.GetModels(mp);
        }

        public List<ServerInfoVO> GetModels(ref ServerInfoPara mp)
        {
            return acc.GetModels(ref mp);
        }

        public int GetRecords(ServerInfoPara mp)
        {
            return acc.GetRecords(mp);
        }
    }
}
