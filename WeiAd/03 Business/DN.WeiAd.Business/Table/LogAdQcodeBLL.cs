
/*

skey edit by 2017-03-29 20:00:21

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
    public partial class LogAdQcodeBLL : IBusiness<LogAdQcodeVO, LogAdQcodePara>
    {
        #region 实例

        static LogAdQcodeBLL m_proxy = null;
        static LogAdQcodeInterface acc = null;

        static ChartInterface chartcacc = null;

        public static LogAdQcodeBLL Instance
        {
            get
            {
                if (m_proxy == null)
                {
                    acc = AccessFactory.CreatedObject<LogAdQcodeInterface>();
                    if (chartcacc == null)
                    {
                        chartcacc = AccessFactory.CreatedObject<ChartInterface>();
                    }
                    m_proxy = new LogAdQcodeBLL();
                }

                return m_proxy;
            }
        }

        #endregion

        public int AddIdentity(LogAdQcodeVO m)
        {
            return acc.InsertIdentityId(m);
        }

        public bool Add(LogAdQcodeVO m)
        {
            return acc.Insert(m);
        }

        public bool Edit(LogAdQcodeVO m)
        {
            return acc.Edit(m);
        }

        public bool Delete(LogAdQcodePara mp)
        {
            return acc.Delete(mp);
        }

        public LogAdQcodeVO GetSingle(LogAdQcodePara mp)
        {
            return acc.GetSingle(mp);
        }

        public List<LogAdQcodeVO> GetModels(LogAdQcodePara mp)
        {
            return acc.GetModels(mp);
        }

        public List<LogAdQcodeVO> GetModels(ref LogAdQcodePara mp)
        {
            return acc.GetModels(ref mp);
        }

        public int GetRecords(LogAdQcodePara mp)
        {
            return acc.GetRecords(mp);
        }
    }
}
