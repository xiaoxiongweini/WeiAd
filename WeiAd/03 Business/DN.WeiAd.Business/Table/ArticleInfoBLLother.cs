using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DN.WeiAd.Models;
using System.Collections.Concurrent;

namespace DN.WeiAd.Business
{
    public partial class ArticleInfoBLL
    {
        static object m_lock = new object();
        static Random _random = new Random();
        int m_maxleng = 0;

        ConcurrentBag<ArticleInfoVO> _list = new ConcurrentBag<ArticleInfoVO>();
        public List<ArticleInfoVO> GetCache()
        {
            List<ArticleInfoVO> cache = new List<ArticleInfoVO>();
            cache = _list.ToList<ArticleInfoVO>();

            return cache;
        }


        /// <summary>
        /// 刷新缓存
        /// </summary>
        public void Refresh()
        {
            var list = GetModels(new ArticleInfoPara());
            lock (m_lock)
            {
                _list = new ConcurrentBag<ArticleInfoVO>();
                foreach (var item in list)
                {
                    _list.Add(item);
                    m_maxleng = _list.Count - 1;
                }
            }
        }

        public ArticleInfoVO GetRandModel()
        {
            if(m_maxleng == 0)
            {
                Refresh();
            }

            ArticleInfoVO info = _list.First();
            int len = _random.Next(m_maxleng);
            for (int i = 0; i < m_maxleng; i++)
            {
                if(len == i)
                {
                    info = _list.Skip(len).First();
                }
            }

            return info;
        }
    }
}
