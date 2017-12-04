using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DN.WeiAd.Models;
using DN.WeiAd.Business;

namespace DN.WeiAd.Business.Sdk
{
    public class SdkBLL
    {
        #region 实例

        static SdkBLL m_proxy = null;

        public static SdkBLL Instance
        {
            get
            {
                if (m_proxy == null)
                {
                    m_proxy = new SdkBLL();
                }

                return m_proxy;
            }
        }

        #endregion

        public ApiResult Run(QueryPara para)
        {
            ApiResult result = new ApiResult();

            return result;
        }
    }
}
