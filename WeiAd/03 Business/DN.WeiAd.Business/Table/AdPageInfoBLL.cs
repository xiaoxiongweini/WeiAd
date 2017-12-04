
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
    public partial class AdPageInfoBLL : IBusiness<AdPageInfoVO, AdPageInfoPara>
    {
        #region 实例

        static AdPageInfoBLL m_proxy = null;
        static AdPageInfoInterface acc = null;
        public static AdPageInfoBLL Instance
        {
            get
            {
                if (m_proxy == null)
                {
                    acc = AccessFactory.CreatedObject<AdPageInfoInterface>();
                    //acc = new DN.WeiAd.Access.MsSqlAccess.AdPageInfoAccess();
                    m_proxy = new AdPageInfoBLL();
                    m_proxy.Init();
                }

                return m_proxy;
            }
        }

        #endregion

        public int AddIdentity(AdPageInfoVO m)
        {
            return acc.InsertIdentityId(m);
        }

        public bool Add(AdPageInfoVO m)
        {
            return acc.Insert(m);
        }

        public bool Edit(AdPageInfoVO m)
        {
            return acc.Edit(m);
        }

        public bool Delete(AdPageInfoPara mp)
        {
            return acc.Delete(mp);
        }

        public AdPageInfoVO GetSingle(AdPageInfoPara mp)
        {
            return acc.GetSingle(mp);
        }

        public List<AdPageInfoVO> GetModels(AdPageInfoPara mp)
        {
            return acc.GetModels(mp);
        }

        public List<AdPageInfoVO> GetModels(ref AdPageInfoPara mp)
        {
            return acc.GetModels(ref mp);
        }

        public int GetRecords(AdPageInfoPara mp)
        {
            return acc.GetRecords(mp);
        }
    }
}
