
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
    public partial class AdBrowseBLL : IBusiness<AdBrowseVO, AdBrowsePara>
    {
        #region 实例

        static AdBrowseBLL m_proxy = null;
        static AdBrowseInterface acc = null;
        public static AdBrowseBLL Instance
        {
            get
            {
                if (m_proxy == null)
                {
                    acc = AccessFactory.CreatedObject<AdBrowseInterface>();
                    m_proxy = new AdBrowseBLL();
                }

                return m_proxy;
            }
        }

        #endregion

        public int AddIdentity(AdBrowseVO m)
        {
            return acc.InsertIdentityId(m);
        }

        public bool Add(AdBrowseVO m)
        {   
            return acc.Insert(m);
        }

        public bool Edit(AdBrowseVO m)
        {
            return acc.Edit(m);
        }

        public bool Delete(AdBrowsePara mp)
        {
            return acc.Delete(mp);
        }

        public AdBrowseVO GetSingle(AdBrowsePara mp)
        {
            return acc.GetSingle(mp);
        }

        public List<AdBrowseVO> GetModels(AdBrowsePara mp)
        {
            return acc.GetModels(mp);
        }

        public List<AdBrowseVO> GetModels(ref AdBrowsePara mp)
        {
            return acc.GetModels(ref mp);
        }

        public int GetRecords(AdBrowsePara mp)
        {
            return acc.GetRecords(mp);
        }
    }
}
