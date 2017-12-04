
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
    public partial class UserFinanceHistoryBLL : IBusiness<UserFinanceHistoryVO, UserFinanceHistoryPara>
    {
        #region 实例

        static UserFinanceHistoryBLL m_proxy = null;
        static UserFinanceHistoryInterface acc = null;
        public static UserFinanceHistoryBLL Instance
        {
            get
            {
                if (m_proxy == null)
                {
                    acc = AccessFactory.CreatedObject<UserFinanceHistoryInterface>();
                    m_proxy = new UserFinanceHistoryBLL();
                }

                return m_proxy;
            }
        }

        #endregion

        public int AddIdentity(UserFinanceHistoryVO m)
        {
            return acc.InsertIdentityId(m);
        }

        public bool Add(UserFinanceHistoryVO m)
        {
            return acc.Insert(m);
        }

        public bool Edit(UserFinanceHistoryVO m)
        {
            return acc.Edit(m);
        }

        public bool Delete(UserFinanceHistoryPara mp)
        {
            return acc.Delete(mp);
        }

        public UserFinanceHistoryVO GetSingle(UserFinanceHistoryPara mp)
        {
            return acc.GetSingle(mp);
        }

        public List<UserFinanceHistoryVO> GetModels(UserFinanceHistoryPara mp)
        {
            return acc.GetModels(mp);
        }

        public List<UserFinanceHistoryVO> GetModels(ref UserFinanceHistoryPara mp)
        {
            return acc.GetModels(ref mp);
        }

        public int GetRecords(UserFinanceHistoryPara mp)
        {
            return acc.GetRecords(mp);
        }
    }
}
