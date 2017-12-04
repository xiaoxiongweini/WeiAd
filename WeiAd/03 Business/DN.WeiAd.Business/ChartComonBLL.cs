using DN.WeiAd.Business.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.WeiAd.Business
{
    /// <summary>
    /// 图形公共类
    /// </summary>
    public class ChartComonBLL
    {
        /// <summary>
        /// 获取当日广告点击图形
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public static EChartInfoJson GetAdBrowseHour(DataTable table, int time = 0)
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
    }
}
