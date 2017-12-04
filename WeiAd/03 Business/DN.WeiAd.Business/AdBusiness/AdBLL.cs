using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DN.WeiAd.Models;
using DN.WeiAd.Business;

namespace DN.WeiAd.Business.AdBusiness
{
    public class AdInfoItem
    {
        /// <summary>
        /// 广告链接
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string TitleShort { get; set; }

        /// <summary>
        /// 图片
        /// </summary>
        public string TitleImg { get; set; }


    }

    /// <summary>
    /// 广告业务类
    /// </summary>
    public class AdBLL
    {
        #region 实例

        static AdBLL m_proxy = null;
         
        public static AdBLL Instance
        {
            get
            {
                if (m_proxy == null)
                {
                    m_proxy = new AdBLL();
                }

                return m_proxy;
            }
        }

        #endregion

        public List<AdInfoItem> GetAdInfo(int articelid)
        {
            //获取IP，根据IP做广告推荐或是相关资讯推荐

            List<AdInfoItem> list = new List<AdInfoItem>();

            //推荐新闻
            ArticleInfoPara aip = new ArticleInfoPara();
            aip.PageIndex = 0;
            aip.PageSize = 2;
            aip.OrderBy = " newid() ";

            var alist = ArticleInfoBLL.Instance.GetModels(ref aip);
            foreach (var item in alist)
            {
                AdInfoItem info = new AdInfoItem();

                info.Url = "/Wap/Detail.aspx?id=" + item.Id.ToString();
                info.Title = item.Title;
                info.TitleImg = item.TitleImg;
                info.TitleShort = item.TitleShort;

                list.Add(info);
            }
            
            return list;
        }
    }
}
