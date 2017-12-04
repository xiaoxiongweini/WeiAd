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
    /// <summary>
    /// 从LogBrowseHistory表统计数据
    /// </summary>
    public class LogBrowseHistoryAnalysisBLL
    {
        #region 实例

        static LogBrowseAnalysisBLL m_proxy = null;

        static ChartInterface acc = null;
        public static LogBrowseAnalysisBLL Instance
        {
            get
            {
                if (m_proxy == null)
                {
                    acc = AccessFactory.CreatedObject<ChartInterface>();
                    m_proxy = new LogBrowseAnalysisBLL();
                }

                return m_proxy;
            }
        }

        #endregion


        /// <summary>
        /// 通用汇总，groupby必须填写
        /// </summary>
        /// <param name="flow"></param>
        /// <returns></returns>
        public DataTable GetAnalysis(QueryGroupInfo flow)
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
            if (flow.Time.HasValue)
            {
                sb.AppendFormat(" and time = {0} ", flow.Time.Value.ToString("yyyyMMdd"));
            }
            if (flow.TimeStart.HasValue)
            {
                sb.AppendFormat(" and time >= {0} ", flow.TimeStart.Value.ToString("yyyyMMdd"));
            }
            if (flow.TimeEnd.HasValue)
            {
                sb.AppendFormat(" and time <= {0} ", flow.TimeEnd.Value.ToString("yyyyMMdd"));
            }

            string orderby = "";
            if (!string.IsNullOrEmpty(flow.OrderBy))
            {
                orderby = " order by " + flow.OrderBy;
            }

            string cmd = string.Format(@"
select 
{1}
,count(*) as pvcount
,count(distinct(clientid)) as uvcount
,count(distinct(clientip)) as ipcount  
,count(distinct(clientid)) /count(*) as useravg 
from  [LogBrowseHistory]
where 1=1 {0}
group by {1} {2}", sb, flow.GroupBy, orderby);

            ChartPara cp = new ChartPara();
            cp.CommandText = cmd;
            DataTable table = acc.GetTable(cp);

            return table;
        }

        /// <summary>
        /// 获取小时分组数据
        /// </summary>
        /// <param name="flow"></param>
        /// <returns></returns>
        public DataTable GetBrowseHour(QueryGroupInfo flow)
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
            if (flow.Time.HasValue)
            {
                sb.AppendFormat(" and time = {0} ", flow.Time.Value.ToString("yyyyMMdd"));
            }

            ChartPara cp = new ChartPara();
            cp.CommandText = string.Format(@"select * from (
select left(convert(varchar(10), CreateDate, 108), 2) as time
,count(*) as pvcount
,count(distinct(clientid)) as uvcount
,count(distinct(clientip)) as ipcount  
 from [LogBrowseHistory]
where 1=1 {0}
group by left(convert(varchar(10), CreateDate, 108), 2)
) a order by a.time asc", sb);

            //数据
            DataTable table = acc.GetTable(cp);

            return table;
        }
    }
}
   