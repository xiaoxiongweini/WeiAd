using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainApp
{
    /// <summary>
    /// API结果
    /// </summary>
    public class ApiResult
    {
        /// <summary>
        /// 0失败，1成功，2异常
        /// </summary>
        public int code { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string msg { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public string datajson { get; set; }
    }
}
