
/*

skey edit by 2017/7/20 12:01:19

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
    public partial class CpsUserInfoBLL : IBusiness<CpsUserInfoVO, CpsUserInfoPara>
    {
        #region 实例

        static CpsUserInfoBLL m_proxy = null;
        static CpsUserInfoInterface acc = null;
        public static CpsUserInfoBLL Instance
        {
            get
            {
                if (m_proxy == null)
                {
                    acc = AccessFactory.CreatedObject<CpsUserInfoInterface>();
                    m_proxy = new CpsUserInfoBLL();
                }

                return m_proxy;
            }
        }

        #endregion

        public int AddIdentity(CpsUserInfoVO m)
        {
            return acc.InsertIdentityId(m);
        }

        public bool Add(CpsUserInfoVO m)
        {
            return acc.Insert(m);
        }

        public bool Edit(CpsUserInfoVO m)
        {
            return acc.Edit(m);
        }

        public bool Delete(CpsUserInfoPara mp)
        {
            return acc.Delete(mp);
        }

        public CpsUserInfoVO GetSingle(CpsUserInfoPara mp)
        {
            return acc.GetSingle(mp);
        }

        public List<CpsUserInfoVO> GetModels(CpsUserInfoPara mp)
        {
            return acc.GetModels(mp);
        }

        public List<CpsUserInfoVO> GetModels(ref CpsUserInfoPara mp)
        {
            return acc.GetModels(ref mp);
        }

        public int GetRecords(CpsUserInfoPara mp)
        {
            return acc.GetRecords(mp);
        }
    }
}
