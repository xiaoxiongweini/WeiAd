
/*

skey edit by 2017-04-24 20:20:39

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
    public partial class AdSiteInfoBLL : IBusiness<AdSiteInfoVO, AdSiteInfoPara>
    {
        #region 实例

        static AdSiteInfoBLL m_proxy = null;
        static AdSiteInfoInterface acc = null;
        public static AdSiteInfoBLL Instance
        {
            get
            {
                if (m_proxy == null)
                {
                    acc = AccessFactory.CreatedObject<AdSiteInfoInterface>();
                    m_proxy = new AdSiteInfoBLL();
                }

                return m_proxy;
            }
        }

        #endregion

        public int AddIdentity(AdSiteInfoVO m)
        {
            return acc.InsertIdentityId(m);
        }

        public bool Add(AdSiteInfoVO m)
        {
            return acc.Insert(m);
        }

        public bool Edit(AdSiteInfoVO m)
        {
            return acc.Edit(m);
        }

        public bool Delete(AdSiteInfoPara mp)
        {
            return acc.Delete(mp);
        }

        public AdSiteInfoVO GetSingle(AdSiteInfoPara mp)
        {
            return acc.GetSingle(mp);
        }

        public List<AdSiteInfoVO> GetModels(AdSiteInfoPara mp)
        {
            return acc.GetModels(mp);
        }

        public List<AdSiteInfoVO> GetModels(ref AdSiteInfoPara mp)
        {
            return acc.GetModels(ref mp);
        }

        public int GetRecords(AdSiteInfoPara mp)
        {
            return acc.GetRecords(mp);
        }
    }
}
