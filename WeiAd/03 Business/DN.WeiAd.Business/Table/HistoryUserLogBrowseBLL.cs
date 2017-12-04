
/*

skey edit by 2017/7/4 15:51:12

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
    public partial class HistoryUserLogBrowseBLL : IBusiness<HistoryUserLogBrowseVO, HistoryUserLogBrowsePara>
    {
        #region 实例

        static HistoryUserLogBrowseBLL m_proxy = null;
        static HistoryUserLogBrowseInterface acc = null;
        public static HistoryUserLogBrowseBLL Instance
        {
            get
            {
                if (m_proxy == null)
                {
                    acc = AccessFactory.CreatedObject<HistoryUserLogBrowseInterface>();
                    m_proxy = new HistoryUserLogBrowseBLL();
                }

                return m_proxy;
            }
        }

        #endregion

        public int AddIdentity(HistoryUserLogBrowseVO m)
        {
            return acc.InsertIdentityId(m);
        }

        public bool Add(HistoryUserLogBrowseVO m)
        {
            return acc.Insert(m);
        }

        public bool Edit(HistoryUserLogBrowseVO m)
        {
            return acc.Edit(m);
        }

        public bool Delete(HistoryUserLogBrowsePara mp)
        {
            return acc.Delete(mp);
        }

        public HistoryUserLogBrowseVO GetSingle(HistoryUserLogBrowsePara mp)
        {
            return acc.GetSingle(mp);
        }

        public List<HistoryUserLogBrowseVO> GetModels(HistoryUserLogBrowsePara mp)
        {
            return acc.GetModels(mp);
        }

        public List<HistoryUserLogBrowseVO> GetModels(ref HistoryUserLogBrowsePara mp)
        {
            return acc.GetModels(ref mp);
        }

        public int GetRecords(HistoryUserLogBrowsePara mp)
        {
            return acc.GetRecords(mp);
        }
    }
}
