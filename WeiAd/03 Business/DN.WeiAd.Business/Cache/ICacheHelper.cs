using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.WeiAd.Business.Cache
{
    /// <summary>
    /// 缓存接口
    /// </summary>
    public interface ICacheHelper
    {
        /// <summary>
        /// 刷新缓存
        /// </summary>
        void RefreshCache();
    }
}
