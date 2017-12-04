using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DN.WeiAd.Models;
using System.Collections.Concurrent;

namespace DN.WeiAd.Business
{
    public partial class SysAreaProvincesBLL
    {
        ConcurrentBag<SysAreaProvincesVO> m_list = new ConcurrentBag<SysAreaProvincesVO>();
        static object m_lock = new object();
        /// <summary>
        /// 刷新缓存
        /// </summary>
        private void Refresh()
        {
            var list = GetModels(new SysAreaProvincesPara());
            lock (m_lock)
            {
                m_list = new ConcurrentBag<SysAreaProvincesVO>();
                foreach (var item in list)
                {
                    m_list.Add(item);
                }
            }
        }

        /// <summary>
        /// 获取省份信息
        /// </summary>
        /// <returns></returns>
        public List<SysAreaProvincesVO> GetRegions()
        {
            if (m_list.Count == 0)
            {
                Refresh();
            }

            return m_list.ToList<SysAreaProvincesVO>();
        }
    }
}
