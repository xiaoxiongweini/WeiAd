using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DN.WeiAd.Models;
using System.Collections.Concurrent;

namespace DN.WeiAd.Business
{
    public partial class SysAreaCityBLL
    {
        ConcurrentBag<SysAreaCityVO> m_list = new ConcurrentBag<SysAreaCityVO>();
        static object m_lock = new object();
        /// <summary>
        /// 刷新缓存
        /// </summary>
        private void Refresh()
        {
            var list = GetModels(new SysAreaCityPara());
            lock (m_lock)
            {
                m_list = new ConcurrentBag<SysAreaCityVO>();
                foreach (var item in list)
                {
                    m_list.Add(item);
                }
            }
        }

        /// <summary>
        /// 获取城市信息
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public List<SysAreaCityVO> GetCitysById(int pid)
        {
            if(m_list.Count==0)
            {
                Refresh();
            }

            var tlist = m_list.Where(p => p.ParentId == pid).ToList<SysAreaCityVO>();

            return tlist;
        }
    }
}
