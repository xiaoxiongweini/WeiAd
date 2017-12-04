using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DN.WeiAd.Models;
using DN.WeiAd.Business.Entity.Analysis;

namespace DN.WeiAd.Business
{
    public partial class LogAdQcodeBLL
    {
        /// <summary>
        /// 通用汇总，groupby必须填写
        /// </summary>
        /// <param name="flow"></param>
        /// <returns></returns>
        public DataTable GetAnalysis(QcodeQueryInfo flow)
        {
            StringBuilder sb = new StringBuilder();

            if (flow.AdId.HasValue)
            {
                sb.AppendFormat(" and AdId = {0} ", flow.AdId);
            }
            if (flow.AdUserId.HasValue)
            {
                sb.AppendFormat(" and AdUserId = {0} ", flow.AdUserId);
            }
            if (!string.IsNullOrEmpty(flow.Url))
            {
                sb.AppendFormat(" and Url = '{0}' ", flow.Url);
            }
            if (flow.Time.HasValue)
            {
                sb.AppendFormat(" and time = {0} ", flow.Time.Value);
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
            if(!string.IsNullOrEmpty(flow.OrderBy))
            {
                orderby = string.Format(" order by {0} ", flow.OrderBy);
            }

            string cmd = string.Format(@"
select 
{1}
,count(*) as pvcount
,count(distinct(clientid)) as uvcount
,count(distinct(clientip)) as ipcount  
from  [LogAdQcode]
where 1=1 {0}
group by {1} {2}", sb, flow.GroupBy, orderby);

            ChartPara cp = new ChartPara();
            cp.CommandText = cmd;
            DataTable table = chartcacc.GetTable(cp);

            return table;
        }

        /// <summary>
        /// 分小时粒度汇总
        /// </summary>
        /// <param name="aduserid"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public DataTable GetBrowseHour(QcodeQueryInfo flow)
        {
            StringBuilder sb = new StringBuilder();

            if (flow.AdId.HasValue)
            {
                sb.AppendFormat(" and AdId = {0} ", flow.AdId);
            }
            if (flow.AdUserId.HasValue)
            {
                sb.AppendFormat(" and AdUserId = {0} ", flow.AdUserId);
            }
            if (!string.IsNullOrEmpty(flow.Url))
            {
                sb.AppendFormat(" and Url = '{0}' ", flow.Url);
            }
            if (flow.Time.HasValue)
            {
                sb.AppendFormat(" and time = {0} ", flow.Time.Value);
            }

            ChartPara cp = new ChartPara();
            cp.CommandText = string.Format(@"select * from (
select 
left(convert(varchar(10), CreateDate, 108), 2) as time 
,count(*) as pvcount
,count(distinct(clientid)) as uvcount
,count(distinct(clientip)) as ipcount  
from  [LogAdQcode]
where 1=1 {0}
group by left(convert(varchar(10), CreateDate, 108), 2)
) a order by a.time asc", sb);

            //数据
            DataTable table = chartcacc.GetTable(cp);

            return table;
        }
    }
}
