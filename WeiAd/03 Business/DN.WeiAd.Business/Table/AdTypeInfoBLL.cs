
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
    public partial class AdTypeInfoBLL : IBusiness<AdTypeInfoVO, AdTypeInfoPara>
    {
        #region 实例

        static AdTypeInfoBLL m_proxy = null;
        static AdTypeInfoInterface acc = null;
        public static AdTypeInfoBLL Instance
        {
            get
            {
                if (m_proxy == null)
                {
                    acc = AccessFactory.CreatedObject<AdTypeInfoInterface>();
                    m_proxy = new AdTypeInfoBLL();
                }

                return m_proxy;
            }
        }

        #endregion

        public int AddIdentity(AdTypeInfoVO m)
        {
            return acc.InsertIdentityId(m);
        }

        public bool Add(AdTypeInfoVO m)
        {
            return acc.Insert(m);
        }

        public bool Edit(AdTypeInfoVO m)
        {
            return acc.Edit(m);
        }

        public bool Delete(AdTypeInfoPara mp)
        {
            return acc.Delete(mp);
        }

        public AdTypeInfoVO GetSingle(AdTypeInfoPara mp)
        {
            return acc.GetSingle(mp);
        }

        public List<AdTypeInfoVO> GetModels(AdTypeInfoPara mp)
        {
            return acc.GetModels(mp);
        }

        public List<AdTypeInfoVO> GetModels(ref AdTypeInfoPara mp)
        {
            return acc.GetModels(ref mp);
        }

        public int GetRecords(AdTypeInfoPara mp)
        {
            return acc.GetRecords(mp);
        }
    }
}
