
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
    public partial class LogLoginBLL : IBusiness<LogLoginVO, LogLoginPara>
    {
        #region 实例

        static LogLoginBLL m_proxy = null;
        static LogLoginInterface acc = null;
        public static LogLoginBLL Instance
        {
            get
            {
                if (m_proxy == null)
                {
                    acc = AccessFactory.CreatedObject<LogLoginInterface>();
                    m_proxy = new LogLoginBLL();
                }

                return m_proxy;
            }
        }

        #endregion

        public int AddIdentity(LogLoginVO m)
        {
            return acc.InsertIdentityId(m);
        }

        public bool Add(LogLoginVO m)
        {
            return acc.Insert(m);
        }

        public bool Edit(LogLoginVO m)
        {
            return acc.Edit(m);
        }

        public bool Delete(LogLoginPara mp)
        {
            return acc.Delete(mp);
        }

        public LogLoginVO GetSingle(LogLoginPara mp)
        {
            return acc.GetSingle(mp);
        }

        public List<LogLoginVO> GetModels(LogLoginPara mp)
        {
            return acc.GetModels(mp);
        }

        public List<LogLoginVO> GetModels(ref LogLoginPara mp)
        {
            return acc.GetModels(ref mp);
        }

        public int GetRecords(LogLoginPara mp)
        {
            return acc.GetRecords(mp);
        }
    }
}
