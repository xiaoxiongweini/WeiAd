using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DN.WeiAd.Models;
using System.Collections.Concurrent;

namespace DN.WeiAd.Business
{
    public partial class SysAreaDistrictsBLL
    {

        ConcurrentBag<SysAreaDistrictsVO> m_list = new ConcurrentBag<SysAreaDistrictsVO>();
        static object m_lock = new object();
        /// <summary>
        /// 刷新缓存
        /// </summary>
        private void Refresh()
        {
            var list = GetModels(new SysAreaDistrictsPara());
            lock (m_lock)
            {
                m_list = new ConcurrentBag<SysAreaDistrictsVO>();
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
        public List<SysAreaDistrictsVO> GetCountyByCityId(int pid)
        {
            if (m_list.Count == 0)
            {
                Refresh();
            }

            var tlist = m_list.Where(p => p.CityId  == pid).ToList<SysAreaDistrictsVO>();

            return tlist;
        }
    }
}
