
/*

skey edit by 2017/7/4 11:20:59

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
    public partial class LogBrowseHistoryBLL : IBusiness<LogBrowseHistoryVO, LogBrowseHistoryPara>
    {
        #region 实例

        static LogBrowseHistoryBLL m_proxy = null;
        static LogBrowseHistoryInterface acc = null;
        public static LogBrowseHistoryBLL Instance
        {
            get
            {
                if (m_proxy == null)
                {
                    acc = AccessFactory.CreatedObject<LogBrowseHistoryInterface>();
                    m_acc = AccessFactory.CreatedObject<ChartInterface>();

                    m_proxy = new LogBrowseHistoryBLL();
                }

                return m_proxy;
            }
        }

        #endregion

        public int AddIdentity(LogBrowseHistoryVO m)
        {
            return acc.InsertIdentityId(m);
        }

        public bool Add(LogBrowseHistoryVO m)
        {
            return acc.Insert(m);
        }

        public bool Edit(LogBrowseHistoryVO m)
        {
            return acc.Edit(m);
        }

        public bool Delete(LogBrowseHistoryPara mp)
        {
            return acc.Delete(mp);
        }

        public LogBrowseHistoryVO GetSingle(LogBrowseHistoryPara mp)
        {
            return acc.GetSingle(mp);
        }

        public List<LogBrowseHistoryVO> GetModels(LogBrowseHistoryPara mp)
        {
            return acc.GetModels(mp);
        }

        public List<LogBrowseHistoryVO> GetModels(ref LogBrowseHistoryPara mp)
        {
            return acc.GetModels(ref mp);
        }

        public int GetRecords(LogBrowseHistoryPara mp)
        {
            return acc.GetRecords(mp);
        }
    }
}
