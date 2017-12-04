using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.WeiAd.Models
{
    /// <summary>
    /// 查询参数
    /// </summary>
    public partial class AdPageInfoPara
    {
        /// <summary>
        /// 流量主关闭任务
        /// </summary>
        public int? FlowUserClosed { get; set;}

        /// <summary>
        /// 流量主运行中的任务
        /// </summary>
        public int? FlowUserRunning { get; set; }

        /// <summary>
        /// 流量主可接任务
        /// </summary>
        public int? FlowUserTask { get; set; }

        /// <summary>
        /// 模糊搜索
        /// </summary>
        public string LikeDesc { get; set; }
        
    }
}
