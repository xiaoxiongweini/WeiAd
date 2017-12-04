
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
    public partial class AccountInfoBLL : IBusiness<AccountInfoVO, AccountInfoPara>
    {
        #region 实例

        static AccountInfoBLL m_proxy = null;
        static AccountInfoInterface acc = null;
        public static AccountInfoBLL Instance
        {
            get
            {
                if (m_proxy == null)
                {
                    acc = AccessFactory.CreatedObject<AccountInfoInterface>();    
                    m_proxy = new AccountInfoBLL();
                }

                return m_proxy;
            }
        }

        #endregion

        public int AddIdentity(AccountInfoVO m)
        {
            return acc.InsertIdentityId(m);
        }

        public bool Add(AccountInfoVO m)
        {
            return acc.Insert(m);
        }

        public bool Edit(AccountInfoVO m)
        {
            return acc.Edit(m);
        }

        public bool Delete(AccountInfoPara mp)
        {
            return acc.Delete(mp);
        }

        public AccountInfoVO GetSingle(AccountInfoPara mp)
        {
            return acc.GetSingle(mp);
        }

        public List<AccountInfoVO> GetModels(AccountInfoPara mp)
        {
            return acc.GetModels(mp);
        }

        public List<AccountInfoVO> GetModels(ref AccountInfoPara mp)
        {
            return acc.GetModels(ref mp);
        }

        public int GetRecords(AccountInfoPara mp)
        {
            return acc.GetRecords(mp);
        }
    }
}
