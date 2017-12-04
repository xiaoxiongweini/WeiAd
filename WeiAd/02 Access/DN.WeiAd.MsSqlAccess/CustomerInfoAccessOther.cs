using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DN.WeiAd.Models;

namespace DN.WeiAd.Access.MsSqlAccess
{
    public partial class CustomerInfoAccessOther
    {
        public static string GetConditionByPara(CustomerInfoPara mp)
        {
            StringBuilder sb = new StringBuilder();

            if(mp.CpsUserId.HasValue)
            {
                if (mp.CpsUserId.HasValue)
                {
                    sb.AppendFormat(" AND AdId IN (select AdId from [dbo].[CpsUserInfo] where CpsUserId={0})", mp.CpsUserId);
                }
            }

            if(!string.IsNullOrEmpty(mp.LikeKey))
            {
                sb.AppendFormat(" AND ([AdUrl] like '%{0}%' or [RealName] like '%{0}%' or [ProducteName] like '%{0}%' or [Phone] like '%{0}%')", mp.LikeKey);
            }

            return sb.ToString();
        }
    }
}