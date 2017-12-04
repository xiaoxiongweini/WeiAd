using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.WeiAd.Business.Cache
{
    public abstract class BLLCacheHelper<T> : ICacheHelper
    {

        /// <summary>
        /// 锁对象
        /// </summary>
        protected static object m_lock = new object();

        /// <summary>
        /// 缓存对象
        /// </summary>
        protected ConcurrentBag<T> m_list = new ConcurrentBag<T>();


        /// <summary>
        /// 刷新
        /// </summary>
        public abstract void RefreshCache();
    }
}
