using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DN.WeiAd.Models;
using DN.WeiAd.Interface;
using DN.Framework.Core;
using DN.WeiAd.Business.Entity;

namespace DN.WeiAd.Business
{
    /// <summary>
    /// 统计图业务类
    /// </summary>
    public class ChartBLL
    {
        #region 实例

        static ChartBLL m_proxy = null;
        static ChartInterface acc = null;
        public static ChartBLL Instance
        {
            get
            {
                if (m_proxy == null)
                {
                    acc = AccessFactory.CreatedObject<ChartInterface>();
                    m_proxy = new ChartBLL();
                }

                return m_proxy;
            }
        }

        #endregion

        public DataTable GetTable(string cmd)
        {
            ChartPara cp = new ChartPara();
            cp.CommandText = cmd;

            return acc.GetTable(cp);

        }
        
        /// <summary>
        /// 获取某月的历史数据
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public EChartInfoJson GetAdBrowseDay(int userid)
        {
            ChartPara cp = new ChartPara();
            cp.CommandText = string.Format(@"select * from (
select AdId, count(distinct(ClientIp)) as clickcount,  time as time from[dbo].[AdBrowseHistory]
where UserId={0}
group by AdId, time
) a order by a.time asc ", userid);


            //时间数据
            var hours = CommonBLL.GetDayTable();
            //数据
            DataTable table = acc.GetTable(cp);

            //图形
            Entity.EChartInfoJson chart = new Entity.EChartInfoJson();
            chart.legend = new List<string>();
            chart.xAxis = hours;
            chart.series = new List<Entity.serie>();

            var adlist = AdPageInfoBLL.Instance.GetModels(new AdPageInfoPara() { UserId = userid });
            chart.xAxis = hours;

            foreach (var item in adlist)
            {
                chart.legend.Add(item.Title);

                Entity.serie data = new Entity.serie();
                data.name = item.Title;
                data.data = new List<string>();
                data.stack = "浏览量";
                data.type = "line";

                foreach (var hour in hours)
                {
                    var row = table.Select(string.Format("AdId={0} and time='{1}'", item.Id, hour));
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


        /// <summary>
        /// 获取当日广告点击图形
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public EChartInfoJson GetAdBrowseHour(int userid)
        {
            ChartPara cp = new ChartPara();
            cp.CommandText = string.Format(@"select * from (
select AdId, count(distinct(ClientIp)) as clickcount, left(convert(varchar(10), CreateDate, 108), 2) as time from[dbo].[AdBrowse]
where userid={0}
group by AdId, left(convert(varchar(10), CreateDate, 108), 2)
) a order by a.time asc", userid);


            //时间数据
            var hours = CommonBLL.GetHourTable();
            //数据
            DataTable table = acc.GetTable(cp);

            //图形
            Entity.EChartInfoJson chart = new Entity.EChartInfoJson();
            chart.legend = new List<string>();
            chart.xAxis = hours;
            chart.series = new List<Entity.serie>();

            var adlist = AdPageInfoBLL.Instance.GetModels(new AdPageInfoPara() { UserId = userid });
            chart.xAxis = hours;

            foreach (var item in adlist)
            {
                chart.legend.Add(item.Title);

                Entity.serie data = new Entity.serie();
                data.name = item.Title;
                data.data = new List<string>();
                data.stack = "浏览量";
                data.type = "line";

                foreach (var hour in hours)
                {
                    var row = table.Select(string.Format("AdId={0} and time='{1}'", item.Id, hour));
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

        /// <summary>
        /// 获取某广告的详细统计
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="adid">广告ID</param>
        /// <param name="monthtime">月份，如：201702</param>
        /// <returns></returns>
        public EChartInfoJson GetChartByAd(int userid, int adid, int monthtime = 0)
        {
            EChartInfoJson chart = new EChartInfoJson();

            var days = CommonBLL.GetDayTable(monthtime);

            string cmd = string.Format(@"select * from (
select AdId, count(distinct(ClientIp)) as clickcount, count(ClientIp) adcount, time as time from[dbo].[AdBrowseHistory]
where userid={0} and adid={0}
group by AdId, time
) a order by a.time asc", userid, adid);

            DataTable table = acc.GetTable(new ChartPara() { CommandText = cmd });

            //图形
            chart.legend = new List<string>();
            chart.xAxis = days;
            chart.series = new List<Entity.serie>();

            var adinfo = AdPageInfoBLL.Instance.GetSingle(new AdPageInfoPara() { UserId = userid, Id = adid });
            if (adinfo != null)
            {
                chart.legend.Add(adinfo.Title);

                Entity.serie data = new Entity.serie();
                data.name = "UV统计";
                data.data = new List<string>();
                data.stack = "UV统计";
                data.type = "line";

                Entity.serie data1 = new Entity.serie();
                data1.name = "PV统计";
                data1.data = new List<string>();
                data1.stack = "PV统计";
                data1.type = "line";

                foreach (var day in days)
                {
                    var row = table.Select(string.Format("AdId={0} and time='{1}'", adid, day));
                    if (row.Length == 0)
                    {
                        data.data.Add("0");
                        data1.data.Add("0");
                    }
                    else
                    {
                        data.data.Add(row[0]["clickcount"].ToString());
                        data1.data.Add(row[0]["adcount"].ToString());
                    }
                }

                chart.series.Add(data);
                chart.series.Add(data1);
            }

            return chart;

        }
    }
}
