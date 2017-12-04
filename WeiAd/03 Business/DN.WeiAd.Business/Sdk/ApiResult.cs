using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.WeiAd.Business.Sdk
{
    /// <summary>
    /// API结果
    /// </summary>
    public class ApiResult
    {
        /// <summary>
        /// 状态值
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 消息信息
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// 数据对象
        /// </summary>
        public object Data { get; set; }
    }
}
