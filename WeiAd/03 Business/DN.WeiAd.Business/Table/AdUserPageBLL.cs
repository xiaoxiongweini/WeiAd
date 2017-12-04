
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
    public partial class AdUserPageBLL : IBusiness<AdUserPageVO, AdUserPagePara>
    {
        #region 实例

        static AdUserPageBLL m_proxy = null;
        static AdUserPageInterface acc = null;
        public static AdUserPageBLL Instance
        {
            get
            {
                if (m_proxy == null)
                {
                    acc = AccessFactory.CreatedObject<AdUserPageInterface>();
                    m_proxy = new AdUserPageBLL();
                    m_proxy.Refresh();
                }

                return m_proxy;
            }
        }

        #endregion

        public int AddIdentity(AdUserPageVO m)
        {
            return acc.InsertIdentityId(m);
        }

        public bool Add(AdUserPageVO m)
        {
            return acc.Insert(m);
        }

        public bool Edit(AdUserPageVO m)
        {
            return acc.Edit(m);
        }

        public bool Delete(AdUserPagePara mp)
        {
            return acc.Delete(mp);
        }

        public AdUserPageVO GetSingle(AdUserPagePara mp)
        {   
            return acc.GetSingle(mp);
        }

        public List<AdUserPageVO> GetModels(AdUserPagePara mp)
        {
            return acc.GetModels(mp);
        }

        public List<AdUserPageVO> GetModels(ref AdUserPagePara mp)
        {
            return acc.GetModels(ref mp);
        }

        public int GetRecords(AdUserPagePara mp)
        {
            return acc.GetRecords(mp);
        }
    }
}
