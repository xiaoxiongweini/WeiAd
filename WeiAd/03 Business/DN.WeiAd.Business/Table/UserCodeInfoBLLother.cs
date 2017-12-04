using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DN.WeiAd.Models;
using DN.Framework.Utility;
using System.Collections.Concurrent;

namespace DN.WeiAd.Business
{
    public partial class UserCodeInfoBLL
    {
        static object m_lock = new object();
        ConcurrentBag<UserCodeInfoVO> _list = new ConcurrentBag<UserCodeInfoVO>();

        public void Refresh()
        {
            var list = GetModels(new UserCodeInfoPara());
            lock (m_lock)
            {
                _list = new ConcurrentBag<UserCodeInfoVO>();
                foreach (var item in list)
                {
                    _list.Add(item);
                }
            }
        }

        public UserCodeInfoVO GetModelById(int id)
        {
            var info = _list.Where(p => p.Id == id).FirstOrDefault();
            if (info == null)
            {
                info = GetSingle(new UserCodeInfoPara() { Id = id });
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

        /// <summary>
        /// 获取代码类型
        /// </summary>
        /// <returns></returns>
        public List<TypeItem> GetCodeTypes()
        {
            List<TypeItem> list = new List<TypeItem>();
            list.Add(new TypeItem() { Id = 0, Name = "无" });
            list.Add(new TypeItem() { Id = 1, Name = "cnzz代码" });

            return list;
        }

        /// <summary>
        /// 获取代码类型名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetCodeTypeNameById(object id)
        {
            if (id == null) return "";
            var info = GetCodeTypes().SingleOrDefault(p => p.Id == int.Parse(id.ToString()));
            if (info != null) return info.Name;

            return "";
        }
    }
}
