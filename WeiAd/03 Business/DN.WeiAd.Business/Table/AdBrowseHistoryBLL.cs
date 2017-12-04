
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
    public partial class AdBrowseHistoryBLL : IBusiness<AdBrowseHistoryVO, AdBrowseHistoryPara>
    {
        #region 实例

        static AdBrowseHistoryBLL m_proxy = null;
        static AdBrowseHistoryInterface acc = null;
        public static AdBrowseHistoryBLL Instance
        {
            get
            {
                if (m_proxy == null)
                {
                    acc = AccessFactory.CreatedObject<AdBrowseHistoryInterface>();
                    m_proxy = new AdBrowseHistoryBLL();
                }

                return m_proxy;
            }
        }

        #endregion

        public int AddIdentity(AdBrowseHistoryVO m)
        {
            return acc.InsertIdentityId(m);
        }

        public bool Add(AdBrowseHistoryVO m)
        {
            return acc.Insert(m);
        }

        public bool Edit(AdBrowseHistoryVO m)
        {
            return acc.Edit(m);
        }

        public bool Delete(AdBrowseHistoryPara mp)
        {
            return acc.Delete(mp);
        }

        public AdBrowseHistoryVO GetSingle(AdBrowseHistoryPara mp)
        {
            return acc.GetSingle(mp);
        }

        public List<AdBrowseHistoryVO> GetModels(AdBrowseHistoryPara mp)
        {
            return acc.GetModels(mp);
        }

        public List<AdBrowseHistoryVO> GetModels(ref AdBrowseHistoryPara mp)
        {
            return acc.GetModels(ref mp);
        }

        public int GetRecords(AdBrowseHistoryPara mp)
        {
            return acc.GetRecords(mp);
        }
    }
}
