
/*

skey edit by 2017-03-20 22:47:56

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
    public partial class LogBrowseBLL : IBusiness<LogBrowseVO, LogBrowsePara>
    {
        #region 实例

        static LogBrowseBLL m_proxy = null;
        static LogBrowseInterface acc = null;
        public static LogBrowseBLL Instance
        {
            get
            {
                if (m_proxy == null)
                {
                    acc = AccessFactory.CreatedObject<LogBrowseInterface>();
                    m_proxy = new LogBrowseBLL();
                }

                return m_proxy;
            }
        }

        #endregion

        public int AddIdentity(LogBrowseVO m)
        {
            return acc.InsertIdentityId(m);
        }

        public bool Add(LogBrowseVO m)
        {
            return acc.Insert(m);
        }

        public bool Edit(LogBrowseVO m)
        {
            return acc.Edit(m);
        }

        public bool Delete(LogBrowsePara mp)
        {
            return acc.Delete(mp);
        }

        public LogBrowseVO GetSingle(LogBrowsePara mp)
        {
            return acc.GetSingle(mp);
        }

        public List<LogBrowseVO> GetModels(LogBrowsePara mp)
        {
            return acc.GetModels(mp);
        }

        public List<LogBrowseVO> GetModels(ref LogBrowsePara mp)
        {
            return acc.GetModels(ref mp);
        }

        public int GetRecords(LogBrowsePara mp)
        {
            return acc.GetRecords(mp);
        }
    }
}
