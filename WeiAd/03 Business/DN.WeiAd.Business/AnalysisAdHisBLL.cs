using DN.Framework.Core;
using DN.WeiAd.Business.Entity.Analysis;
using DN.WeiAd.Interface;
using DN.WeiAd.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.WeiAd.Business
{
    class AnalysisAdHisBLL
    {
        #region 实例

        static AnalysisAdHisBLL m_proxy = null;

        static ChartInterface acc = null;
        public static AnalysisAdHisBLL Instance
        {
            get
            {
                if (m_proxy == null)
                {
                    acc = AccessFactory.CreatedObject<ChartInterface>();
                    m_proxy = new AnalysisAdHisBLL();
                }

                return m_proxy;
            }
        }

        #endregion

        /// <summary>
        /// 按工作室分析
        /// </summary>
        /// <param name="flow"></param>
        /// <returns></returns>
        public DataTable GetAdFlowDetail(FlowInfo flow)
        {
            StringBuilder sb = new StringBuilder();

            if (flow.AdId.HasValue)
            {
                sb.AppendFormat(" and AdId = {0} ", flow.AdId);
            }
            if (flow.FlowUserId.HasValue)
            {
                sb.AppendFormat(" and FlowUserId = {0} ", flow.FlowUserId);
            }
            if (flow.AdUserID.HasValue)
            {
                sb.AppendFormat(" and AdUserId = {0} ", flow.AdUserID);
            }

            string cmd = string.Format(@"select time
,FlowUserId
,count(*) as pvcount
,count(distinct(clientid)) as uvcount
,count(distinct(clientip)) as ipcount  
,count(distinct(clientid)) /count(*) as useravg 
from  [AdBrowseHistory]
where time={0} {1}
group by time,FlowUserId", flow.Time.ToString("yyyyMMdd"), sb);
            ChartPara cp = new ChartPara();
            cp.CommandText = cmd;
            DataTable table = acc.GetTable(cp);

            return table;
        }

        /// <summary>
        /// 按广告分析
        /// </summary>
        /// <param name="flow"></param>
        /// <returns></returns>
        public DataTable GetAllAdDetail(FlowInfo flow)
        {
            StringBuilder sb = new StringBuilder();

            if (flow.AdId.HasValue)
            {
                sb.AppendFormat(" and AdId = {0} ", flow.AdId);
            }
            if (flow.FlowUserId.HasValue)
            {
                sb.AppendFormat(" and FlowUserId = {0} ", flow.FlowUserId);
            }
            if (flow.AdUserID.HasValue)
            {
                sb.AppendFormat(" and AdUserId = {0} ", flow.AdUserID);
            }

            string cmd = string.Format(@"select time
,AdId
,count(*) as pvcount
,count(distinct(clientid)) as uvcount
,count(distinct(clientip)) as ipcount  
,count(distinct(clientid)) /count(*) as useravg 
from  [AdBrowseHistory]
where time={0} {1}
group by time,AdId", flow.Time.ToString("yyyyMMdd"), sb);
            ChartPara cp = new ChartPara();
            cp.CommandText = cmd;
            DataTable table = acc.GetTable(cp);

            return table;
        }


        /// <summary>
        /// 获取某个用户的某个时间全部URL统计图
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public DataTable GetPageAnalysis(int aduserid, DateTime time)
        {
            string cmd = string.Format(@"select time,count(*) as pvcount
,count(distinct(clientid)) as uvcount
,count(distinct(clientip)) as ipcount  
,count(distinct(clientid)) /count(*) as useravg
from AdBrowseHistory
where AdUserId={0}
and time={1}
group by time", aduserid, time.ToString("yyyyMMdd"));
            ChartPara cp = new ChartPara();
            cp.CommandText = cmd;
            DataTable table = acc.GetTable(cp);

            return table;
        }

        /// <summary>
        /// 分页面统计详情
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public DataTable GetPagesAnalysis(int aduserid, DateTime time)
        {
            string cmd = string.Format(@"select adurl,count(*) as pvcount
,count(distinct(clientid)) as uvcount
,count(distinct(clientip)) as ipcount  
,count(distinct(clientid)) /count(*) as useravg
from AdBrowseHistory
where AdUserId={0}
and time={1}
group by adurl", aduserid, time.ToString("yyyyMMdd"));
            ChartPara cp = new ChartPara();
            cp.CommandText = cmd;
            DataTable table = acc.GetTable(cp);

            return table;
        }

        public DataTable GetBrowseHour(int aduserid, DateTime time)
        {
            ChartPara cp = new ChartPara();
            cp.CommandText = string.Format(@"select * from (
select count(*) as pvcount
,count(distinct(clientid)) as uvcount
,count(distinct(clientip)) as ipcount  
,count(distinct(clientid)) /count(*) as useravg
,left(convert(varchar(10), CreateDate, 108), 2) as time from [AdBrowseHistory]
where AdUserId={0} and time = {1}
group by left(convert(varchar(10), CreateDate, 108), 2)
) a order by a.time asc", aduserid, time.ToString("yyyyMMdd"));

            //数据
            DataTable table = acc.GetTable(cp);

            return table;
        }
    }
}
