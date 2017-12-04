using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DN.WeiAd.Models;
using DN.Framework.Utility;
using DN.WeiAd.Business.Cache;
using System.Collections.Concurrent;

namespace DN.WeiAd.Business
{
    public partial class AccountInfoBLL : BLLCacheHelper<AccountInfoVO>
    {
        public List<AccountInfoVO> GetCache()
        {
            List<AccountInfoVO> cache = new List<AccountInfoVO>();
            cache = m_list.ToList<AccountInfoVO>();
            return cache;
        }


        public override void RefreshCache()
        {
            var list = GetModels(new AccountInfoPara());
            lock (m_lock)
            {
                m_list = new ConcurrentBag<AccountInfoVO>();
                foreach (var item in list)
                {
                    m_list.Add(item);
                }
            }
        }

        /// <summary>
        /// 获取用户信息对象
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public AccountInfoVO GetModelByUserName(string username)
        {
            var info = m_list.Where(p => p.UserName == username).FirstOrDefault();
            if (info == null)
            {
                info = GetSingle(new AccountInfoPara() { UserName = username });
                if (info != null)
                {
                    lock (m_lock)
                    {
                        if (!m_list.Contains(info))
                        {
                            m_list.Add(info);
                        }
                    }
                }
            }
            if(info!= null)
            {
                if(string.IsNullOrEmpty(info.UserImg))
                {
                    info.UserImg = "/Assets/Manager1/images/a4.jpg";
                }
            }
            return info;
        }

        /// <summary>
        /// 获取用户名
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public string GetUserNameByUserId(object userid)
        {
            var info = GetModelByUserId(userid);
            if (info != null)
                return info.UserName;
            return userid.ToString();

        }

        /// <summary>
        /// 获取用户昵称
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public string GetNickNameByUserId(object userid)
        {
            var info = GetModelByUserId(userid);
            if (info != null)
                return info.NickName;
            return userid.ToString();
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public AccountInfoVO GetModelByUserId(object userid)
        {
            var info = m_list.Where(p => p.Id == int.Parse(userid.ToString())).FirstOrDefault();
            if (info == null)
            {
                info = GetSingle(new AccountInfoPara() { Id = int.Parse(userid.ToString()) });
                if (info != null)
                {
                    lock (m_lock)
                    {
                        if (!m_list.Contains(info))
                        {
                            m_list.Add(info);
                        }
                    }
                }
            }

            return info;
        }

        /// <summary>
        /// 获取用户类型
        /// </summary>
        /// <returns></returns>
        public List<TypeItem> GetUserTypes(bool isadmin=false)
        {
            List<TypeItem> list = new List<TypeItem>();

            list.Add(new TypeItem() { Id = 0, Name = "广告主" });
            list.Add(new TypeItem() { Id = 1, Name = "流量主" });
            list.Add(new TypeItem() { Id = 2, Name = "广告VIP" });
            list.Add(new TypeItem() { Id = 3, Name = "广告CPS" });
            list.Add(new TypeItem() { Id = 4, Name = "广告VIP-1" });

            // if ((result.Data as AccountInfoVO).UserType == 0)
            //{
            //    //流量主
            //    Response.Redirect("/AccFlow/Index.aspx");
            //}
            //else if ((result.Data as AccountInfoVO).UserType == 1)
            //{
            //    //流量主
            //    Response.Redirect("/AccFlow/Index.aspx");
            //}
            //else if ((result.Data as AccountInfoVO).UserType == 2)
            //{
            //    //简版广告主
            //    Response.Redirect("/AccAnalysis/Index.aspx");
            //}
            //else if ((result.Data as AccountInfoVO).UserType == 3)
            //{
            //    //CPS广告分成
            //    Response.Redirect("/AccShop/Index.aspx");
            //}


            if (isadmin)
            {
                list.Add(new TypeItem() { Id = 100, Name = "超级管理员" });
            }

            return list;
        }

        /// <summary>
        /// 用户类型名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetUserTypeNameById(object id)
        {
            if (id == null) return "Id为空";

            var info = GetUserTypes(true).SingleOrDefault(p => p.Id == int.Parse(id.ToString()));
            if (info != null)
                return info.Name;

            return id.ToString();
        }

        /// <summary>
        /// 根据广告ID获取用户昵称
        /// </summary>
        /// <param name="adid"></param>
        /// <returns></returns>
        public string GetNickNameByAdId(object adid)
        {
            var info = AdPageInfoBLL.Instance.GetModelById(int.Parse(adid.ToString()));
            if(info!= null)
            {
                return GetNickNameByUserId(info.UserId);
            }

            return "";
        }
    }
}
