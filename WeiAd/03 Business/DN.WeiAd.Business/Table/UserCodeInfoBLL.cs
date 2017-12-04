
/*

skey edit by 2017-02-28 21:22:50

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
    public partial class UserCodeInfoBLL : IBusiness<UserCodeInfoVO, UserCodeInfoPara>
    {
        #region 实例

        static UserCodeInfoBLL m_proxy = null;
        static UserCodeInfoInterface acc = null;
        public static UserCodeInfoBLL Instance
        {
            get
            {
                if (m_proxy == null)
                {
                    acc = AccessFactory.CreatedObject<UserCodeInfoInterface>();
                    m_proxy = new UserCodeInfoBLL();
                    m_proxy.Refresh();
                }

                return m_proxy;
            }
        }

        #endregion

        public int AddIdentity(UserCodeInfoVO m)
        {
            return acc.InsertIdentityId(m);
        }

        public bool Add(UserCodeInfoVO m)
        {
            return acc.Insert(m);
        }

        public bool Edit(UserCodeInfoVO m)
        {
            return acc.Edit(m);
        }

        public bool Delete(UserCodeInfoPara mp)
        {
            return acc.Delete(mp);
        }

        public UserCodeInfoVO GetSingle(UserCodeInfoPara mp)
        {
            return acc.GetSingle(mp);
        }

        public List<UserCodeInfoVO> GetModels(UserCodeInfoPara mp)
        {
            return acc.GetModels(mp);
        }

        public List<UserCodeInfoVO> GetModels(ref UserCodeInfoPara mp)
        {
            return acc.GetModels(ref mp);
        }

        public int GetRecords(UserCodeInfoPara mp)
        {
            return acc.GetRecords(mp);
        }
    }
}
