using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.WeiAd.Business.AdData
{
    /// <summary>
    /// 获取取三方广告数据服务配置信息
    /// </summary>
    public class AdDataBLL
    {
        #region 实例

        static AdDataBLL m_proxy = null;
        public static AdDataBLL Instance
        {
            get
            {
                if (m_proxy == null)
                {
                    m_proxy = new AdDataBLL();
                }

                return m_proxy;
            }
        }

        #endregion

        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        public List<AdDataItem> GetALL()
        {
            List<AdDataItem> list = new List<AdDataItem>();
            string url = "/Resources/AdData/AdData.json";
            list = DN.Framework.Utility.ConfigJsonHelper.GetTypesByUrl<AdDataItem>(url);
            return list;
        }
    }
}
