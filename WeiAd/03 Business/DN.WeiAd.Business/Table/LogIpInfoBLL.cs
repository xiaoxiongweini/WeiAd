
/*

skey edit by 2017-04-29 19:22:47

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
    public partial class LogIpInfoBLL : IBusiness<LogIpInfoVO, LogIpInfoPara>
    {
        #region 实例

        static LogIpInfoBLL m_proxy = null;
        static LogIpInfoInterface acc = null;
        public static LogIpInfoBLL Instance
        {
            get
            {
                if (m_proxy == null)
                {
                    acc = AccessFactory.CreatedObject<LogIpInfoInterface>();
                    m_proxy = new LogIpInfoBLL();
                }

                return m_proxy;
            }
        }

        #endregion

        public int AddIdentity(LogIpInfoVO m)
        {
            return acc.InsertIdentityId(m);
        }

        public bool Add(LogIpInfoVO m)
        {
            return acc.Insert(m);
        }

        public bool Edit(LogIpInfoVO m)
        {
            return acc.Edit(m);
        }

        public bool Delete(LogIpInfoPara mp)
        {
            return acc.Delete(mp);
        }

        public LogIpInfoVO GetSingle(LogIpInfoPara mp)
        {
            return acc.GetSingle(mp);
        }

        public List<LogIpInfoVO> GetModels(LogIpInfoPara mp)
        {
            return acc.GetModels(mp);
        }

        public List<LogIpInfoVO> GetModels(ref LogIpInfoPara mp)
        {
            return acc.GetModels(ref mp);
        }

        public int GetRecords(LogIpInfoPara mp)
        {
            return acc.GetRecords(mp);
        }
    }
}
