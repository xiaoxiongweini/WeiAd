using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DN.WeiAd.Models;
using System.Collections.Concurrent;

namespace DN.WeiAd.Business
{
    public partial class AdQcodeInfoBLL
    {
        static object m_lock = new object();
        static Random _random = new Random();
        static int m_leng = 0;

        ConcurrentBag<AdQcodeInfoVO> _list = new ConcurrentBag<AdQcodeInfoVO>();
        public List<AdQcodeInfoVO> GetCache()
        {
            List<AdQcodeInfoVO> cache = new List<AdQcodeInfoVO>();
            cache = _list.ToList<AdQcodeInfoVO>();

            return cache;
        }

        /// <summary>
        /// 刷新缓存
        /// </summary>
        public void Refresh()
        {
            var list = GetModels(new AdQcodeInfoPara());
            lock (m_lock)
            {
                _list = new ConcurrentBag<AdQcodeInfoVO>();
                foreach (var item in list)
                {
                    _list.Add(item);
                }
                m_leng = _list.Count;
            }
        }

        /// <summary>
        /// 随机获取二维码
        /// </summary>
        /// <param name="adid"></param>
        /// <returns></returns>
        public AdQcodeInfoVO GetRandQcode(int adid)
        {
            AdQcodeInfoVO info = null;
            if (m_leng == 0)
            {
                Refresh();
            }
            var list = _list.Where(p => p.AdId == adid).ToList<AdQcodeInfoVO>();
            if (list.Count() == 1)
            {
                info = list[0];
            }
            else if(list.Count() != 0)
            {
                info = list[_random.Next(list.Count)];
            } 
            return info;
        }
    }
}
