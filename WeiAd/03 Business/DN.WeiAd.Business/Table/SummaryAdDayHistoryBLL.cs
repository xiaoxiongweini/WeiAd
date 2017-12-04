
/*

skey edit by 2017/9/21 10:02:13

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
    public partial class SummaryAdDayHistoryBLL : IBusiness<SummaryAdDayHistoryVO, SummaryAdDayHistoryPara>
    {
        #region 实例

        static SummaryAdDayHistoryBLL m_proxy = null;
        static SummaryAdDayHistoryInterface acc = null;
        public static SummaryAdDayHistoryBLL Instance
        {
            get
            {
                if (m_proxy == null)
                {
                    acc = AccessFactory.CreatedObject<SummaryAdDayHistoryInterface>();
                    m_proxy = new SummaryAdDayHistoryBLL();
                }

                return m_proxy;
            }
        }

        #endregion

        public int AddIdentity(SummaryAdDayHistoryVO m)
        {
            return acc.InsertIdentityId(m);
        }

        public bool Add(SummaryAdDayHistoryVO m)
        {
            return acc.Insert(m);
        }

        public bool Edit(SummaryAdDayHistoryVO m)
        {
            return acc.Edit(m);
        }

        public bool Delete(SummaryAdDayHistoryPara mp)
        {
            return acc.Delete(mp);
        }

        public SummaryAdDayHistoryVO GetSingle(SummaryAdDayHistoryPara mp)
        {
            return acc.GetSingle(mp);
        }

        public List<SummaryAdDayHistoryVO> GetModels(SummaryAdDayHistoryPara mp)
        {
            return acc.GetModels(mp);
        }

        public List<SummaryAdDayHistoryVO> GetModels(ref SummaryAdDayHistoryPara mp)
        {
            return acc.GetModels(ref mp);
        }

        public int GetRecords(SummaryAdDayHistoryPara mp)
        {
            return acc.GetRecords(mp);
        }
    }
}
