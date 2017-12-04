using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DN.WeiAd.Framework;

namespace DN.WeiAd.Business.Services
{
    /// <summary>
    /// 广告记数板
    /// </summary>
    public class AdBrowseHelper
    {
       static  RedisHelper m_redis = new RedisHelper();

        const string m_cacheHashId = "";


        /// <summary>
        /// URL记数统计
        /// </summary>
        /// <param name="url">URL地址</param>
        /// <param name="count">记数统计</param>
        /// <returns></returns>
        public static int GetUrl(string url,int count)
        {
            int res = m_redis.Get<int>(m_cacheHashId, url);
            if(res == 0)
            {
                count = 1;
            }
            else
            {
                count = res + 1;
            }            

            m_redis.Add<int>(m_cacheHashId, url, count);

            return count;
        }
    }
}
