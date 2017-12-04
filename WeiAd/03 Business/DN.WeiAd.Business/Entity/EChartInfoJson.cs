using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.WeiAd.Business.Entity
{
    /// <summary>
    /// Echart数据实体
    /// </summary>
    public class EChartInfoJson
    {
        /// <summary>
        /// 数据图例
        /// </summary>
        public List<string> legend { get; set; }

        /// <summary>
        /// X轴数据
        /// </summary>
        public List<string> xAxis { get; set; }


        /// <summary>
        /// 数据列
        /// </summary>
        public List<serie> series { get; set; }
    }

    /// <summary>
    /// 数据项
    /// </summary>
    public class serie
    {
        /// <summary>
        /// 图例名称
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 图形类型
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string stack { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public List<string> data { get; set; }

    }
}
