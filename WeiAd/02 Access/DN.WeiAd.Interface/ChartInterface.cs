using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DN.WeiAd.Models;

namespace DN.WeiAd.Interface
{
    /// <summary>
    /// 图形处理
    /// </summary>
    public abstract class ChartInterface
    {
        /// <summary>
        /// 获取图形
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public abstract DataTable GetTable(ChartPara para);

        /// <summary>
        /// 执行SQL
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public abstract int InsertInto(ChartPara para);
    }
}
