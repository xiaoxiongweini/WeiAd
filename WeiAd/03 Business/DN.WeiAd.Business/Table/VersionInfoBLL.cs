
/*

skey edit by 2017-05-01 15:15:01

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
    public partial class VersionInfoBLL : IBusiness<VersionInfoVO, VersionInfoPara>
    {
        #region 实例

        static VersionInfoBLL m_proxy = null;
        static VersionInfoInterface acc = null;
        public static VersionInfoBLL Instance
        {
            get
            {
                if (m_proxy == null)
                {
                    acc = AccessFactory.CreatedObject<VersionInfoInterface>();
                    m_proxy = new VersionInfoBLL();
                }

                return m_proxy;
            }
        }

        #endregion

        public int AddIdentity(VersionInfoVO m)
        {
            return acc.InsertIdentityId(m);
        }

        public bool Add(VersionInfoVO m)
        {
            return acc.Insert(m);
        }

        public bool Edit(VersionInfoVO m)
        {
            return acc.Edit(m);
        }

        public bool Delete(VersionInfoPara mp)
        {
            return acc.Delete(mp);
        }

        public VersionInfoVO GetSingle(VersionInfoPara mp)
        {
            return acc.GetSingle(mp);
        }

        public List<VersionInfoVO> GetModels(VersionInfoPara mp)
        {
            return acc.GetModels(mp);
        }

        public List<VersionInfoVO> GetModels(ref VersionInfoPara mp)
        {
            return acc.GetModels(ref mp);
        }

        public int GetRecords(VersionInfoPara mp)
        {
            return acc.GetRecords(mp);
        }
    }
}
