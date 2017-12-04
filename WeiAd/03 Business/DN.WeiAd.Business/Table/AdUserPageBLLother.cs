using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DN.WeiAd.Models;
using System.Collections.Concurrent;
using DN.Framework.Utility;

namespace DN.WeiAd.Business
{
    public partial class AdUserPageBLL
    {
        static object m_lock = new object();
        ConcurrentBag<AdUserPageVO> _list = new ConcurrentBag<AdUserPageVO>();
        public List<AdUserPageVO> GetCache()
        {
            List<AdUserPageVO> cache = new List<AdUserPageVO>();
            cache = _list.ToList<AdUserPageVO>();

            return cache;
        }

        public void Refresh()
        {
            var list = GetModels(new AdUserPagePara());
            lock (m_lock)
            {
                _list = new ConcurrentBag<AdUserPageVO>();
                foreach (var item in list)
                {
                    _list.Add(item);
                }
            }
        }

        public AdUserPageVO GetModelByPageName(string pageName)
        {
            var info = _list.Where(p => p.PageName == pageName).FirstOrDefault();
            if (info == null)
            {
                info = GetSingle(new AdUserPagePara() { PageName = pageName });
                if (info != null)
                {
                    lock (m_lock)
                    {
                        if (!_list.Contains(info))
                        {
                            _list.Add(info);
                        }
                    }
                }
            }

            return info;
        }

        public List<DN.Framework.Utility.TypeItem> GetStates()
        {
            List<TypeItem> list = new List<TypeItem>();

            list.Add(new TypeItem() { Id = 0, Name = "运行中" });
            list.Add(new TypeItem() { Id = 1, Name = "己关闭" });

            return list;
        }

        public string GetStateNameById(object id)
        {
            if (id == null) return "任务状态未识别";

            var info = GetStates().SingleOrDefault(p => p.Id == int.Parse(id.ToString()));

            if (info != null)
            {
                return info.Name;
            }

            return id.ToString();
        }
    }
}
