using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DN.WeiAd.Models;

namespace DN.WeiAd.Business
{
    public partial class AdSiteInfoBLL
    {
        List<AdSiteInfoVO> m_list = new List<AdSiteInfoVO>();

        /// <summary>
        /// 通过广告获取平台名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetNameByAdId(object id)
        {
            AdPageInfoVO info = AdPageInfoBLL.Instance.GetModelById(int.Parse(id.ToString()));
            if (info == null)
            {
                info = AdPageInfoBLL.Instance.GetSingle(new AdPageInfoPara() { Id = int.Parse(id.ToString()) });

            }

            if (info != null)
            {
                return GetNameById(info.SiteTypeId);
            }

            return id.ToString();
        }

        /// <summary>
        /// 能过名称获取平台名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetNameById(object id)
        {
            AdSiteInfoVO info = null;

            info = m_list.SingleOrDefault(p => p.Id == int.Parse(id.ToString()));

            if (info == null)
            {
                info = GetSingle(new AdSiteInfoPara() { Id = int.Parse(id.ToString()) });
                if (info != null)
                {
                    m_list.Add(info);
                    return info.Name;
                }
            }
            else
            {
                return info.Name;
            }

            return id.ToString();
        }
    }
}
