using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.WeiAd.Business.Sdk
{
    /// <summary>
    /// 查询参数
    /// </summary>
    public class QueryPara
    {
        /// <summary>
        /// API名称
        /// </summary>
        public string ApiName { get; set; }

        /// <summary>
        /// 数据集合
        /// </summary>
        public Dictionary<string,string> Data { get; set; }
    }
}
