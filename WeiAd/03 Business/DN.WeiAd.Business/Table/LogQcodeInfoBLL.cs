
/*

skey edit by 2017/12/4 11:53:42

mail:skey111@foxmail.com

version edit by v1.0.3

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
    public partial class LogQcodeInfoBLL : IBusiness<LogQcodeInfoVO, LogQcodeInfoPara>
    {
        #region 实例

        static LogQcodeInfoBLL m_proxy = null;
        static LogQcodeInfoInterface acc = null;
        public static LogQcodeInfoBLL Instance
        {
            get
            {
                if (m_proxy == null)
                {
                    acc = AccessFactory.CreatedObject<LogQcodeInfoInterface>();
                    m_proxy = new LogQcodeInfoBLL();
                }

                return m_proxy;
            }
        }

        #endregion

        public int AddIdentity(LogQcodeInfoVO m)
        {
            return acc.InsertIdentityId(m);
        }

        public bool Add(LogQcodeInfoVO m)
        {
            return acc.Insert(m);
        }

        public bool Edit(LogQcodeInfoVO m)
        {
            return acc.Edit(m);
        }

        public bool Delete(LogQcodeInfoPara mp)
        {
            return acc.Delete(mp);
        }

        public LogQcodeInfoVO GetSingle(LogQcodeInfoPara mp)
        {
            return acc.GetSingle(mp);
        }

        public List<LogQcodeInfoVO> GetModels(LogQcodeInfoPara mp)
        {
            return acc.GetModels(mp);
        }

        public List<LogQcodeInfoVO> GetModels(ref LogQcodeInfoPara mp)
        {
            return acc.GetModels(ref mp);
        }

        public int GetRecords(LogQcodeInfoPara mp)
        {
            return acc.GetRecords(mp);
        }
    }
}
