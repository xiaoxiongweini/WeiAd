using DN.Framework.Core;
using DN.WeiAd.Business.Entity;
using DN.WeiAd.Interface;
using DN.WeiAd.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DN.WeiAd.Business.Entity.Analysis;

namespace DN.WeiAd.Business
{
    /// <summary>
    /// 流量主分析
    /// </summary>
    public class AnalysisFlowBLL
    {
        #region 实例

        static AnalysisFlowBLL m_proxy = null;

        static ChartInterface acc = null;
        public static AnalysisFlowBLL Instance
        {
            get
            {
                if (m_proxy == null)
                {
                    acc = AccessFactory.CreatedObject<ChartInterface>();
                    m_proxy = new AnalysisFlowBLL();
                }

                return m_proxy;
            }
        }

        #endregion


        /// <summary>
        /// 获取某个用户的某个时间全部URL统计图
        /// </summary>
        /// <param name="flow"></param>
        /// <returns></returns>
        public DataTable GetPageAnalysis(FlowInfo flow)
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

            string cmd = string.Format(@"select time,count(*) as pvcount
,count(distinct(clientid)) as uvcount
,count(distinct(clientip)) as ipcount  
,count(distinct(clientid)) /count(*) as useravg
from AdBrowse
where time={0} {1}
group by time", flow.Time.ToString("yyyyMMdd"), sb);
            ChartPara cp = new ChartPara();
            cp.CommandText = cmd;
            DataTable table = acc.GetTable(cp);

            return table;
        }

        /// <summary>
        /// 生成当天的最大小时数据
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public DataTable GetBrowseHour(FlowInfo flow)
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

            ChartPara cp = new ChartPara();
            cp.CommandText = string.Format(@"select * from (
select count(*) as pvcount
,count(distinct(clientid)) as uvcount
,count(distinct(clientip)) as ipcount  
,count(distinct(clientid)) /count(*) as useravg
,left(convert(varchar(10), CreateDate, 108), 2) as time from [AdBrowse]
where time = {0} {1}
group by left(convert(varchar(10), CreateDate, 108), 2)
) a order by a.time asc", flow.Time.ToString("yyyyMMdd"), sb);

            //数据
            DataTable table = acc.GetTable(cp);

            return table;
        }


        /// <summary>
        /// 获取当日广告点击图形
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public EChartInfoJson GetAdBrowseHour(DataTable table, int time=0)
        {
            //时间数据
            var hours = CommonBLL.GetHourTable(time);
            //图形
            Entity.EChartInfoJson chart = new Entity.EChartInfoJson();
            chart.legend = new List<string>();
            chart.xAxis = hours;
            chart.series = new List<Entity.serie>();
            chart.xAxis = hours;


            Entity.serie data = new Entity.serie();
            data.name = "浏览次数（PV）";
            data.data = new List<string>();
            data.stack = "浏览次数（PV）";
            data.type = "line";

            Entity.serie data1 = new Entity.serie();
            data1.name = "独立访客（UV）";
            data1.data = new List<string>();
            data1.stack = "独立访客（UV）";
            data1.type = "line";

            Entity.serie data2 = new Entity.serie();
            data2.name = "IP";
            data2.data = new List<string>();
            data2.stack = "IP";
            data2.type = "line";

            foreach (var hour in hours)
            {
                var row = table.Select(string.Format("time='{0}'", hour));
                if (row.Length == 0)
                {
                    data.data.Add("0");
                    data1.data.Add("0");
                    data2.data.Add("0");
                }
                else
                {
                    data.data.Add(row[0]["pvcount"].ToString());
                    data1.data.Add(row[0]["uvcount"].ToString());
                    data2.data.Add(row[0]["ipcount"].ToString());
                }
            }

            chart.series.Add(data);
            chart.series.Add(data1);
            chart.series.Add(data2);

            return chart;
        }



        /// <summary>
        /// 获取某月的历史数据
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public EChartInfoJson GetHistoryMonthDays(FlowInfo flow)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(" [Time] = {0} ", flow.Time.ToString("yyyyMM"));

            if (flow.FlowUserId.HasValue)
            {
                sb.AppendFormat(" and FlowUserId={0} ", flow.FlowUserId);
            }
            if (flow.AdId.HasValue)
            {
                sb.AppendFormat(" and AdId={0} ", flow.AdId);
            }


            ChartPara cp = new ChartPara();
            cp.CommandText = string.Format(@"select * from (
select AdId, count(distinct(ClientIp)) as clickcount,  time as time from[dbo].[AdBrowseHistory]
where {0}
group by AdId, time
) a order by a.time asc ", sb);


            //时间数据
            var hours = CommonBLL.GetDayTable(int.Parse(flow.Time.ToString("yyyyMM")));
            //数据
            DataTable table = acc.GetTable(cp);

            //图形
            Entity.EChartInfoJson chart = new Entity.EChartInfoJson();
            chart.legend = new List<string>();
            chart.xAxis = hours;
            chart.series = new List<Entity.serie>();

            var adlist = AdUserPageBLL.Instance.GetModels(new AdUserPagePara() { FlowUserId = flow.FlowUserId.Value });
            chart.xAxis = hours;

            foreach (var item in adlist)
            {
                string title = AdPageInfoBLL.Instance.GetTitleById(item.AdPageId);
                chart.legend.Add(title);

                Entity.serie data = new Entity.serie();
                data.name = title;
                data.data = new List<string>();
                data.stack = "浏览量";
                data.type = "line";

                foreach (var hour in hours)
                {
                    var row = table.Select(string.Format("AdId={0} and time='{1}'", item.AdPageId, hour));
                    if (row.Length == 0)
                    {
                        data.data.Add("0");
                    }
                    else
                    {
                        data.data.Add(row[0]["clickcount"].ToString());
                    }
                }

                chart.series.Add(data);
            }

            return chart;
        }

    }
}
