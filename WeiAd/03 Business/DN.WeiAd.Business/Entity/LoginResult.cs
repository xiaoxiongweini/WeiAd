using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.WeiAd.Business.Entity
{
    /// <summary>
    /// 登录结果
    /// </summary>
    public class LoginResult
    {
        /// <summary>
        /// 状态
        /// </summary>
        public bool State { get; set; }

        /// <summary>
        /// 消息对象
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// 数据对象
        /// </summary>
        public object Data { get; set; }
    }
}
