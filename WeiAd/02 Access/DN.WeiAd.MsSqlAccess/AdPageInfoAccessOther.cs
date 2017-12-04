using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DN.WeiAd.Models;
using DN.Framework.Core;

namespace DN.WeiAd.Access.MsSqlAccess
{
    internal class AdPageInfoAccessOther
    {
        public static string GetConditionByPara(AdPageInfoPara mp)
        {
            StringBuilder sb = new StringBuilder();

            if(mp.FlowUserTask.HasValue)
            {
                sb.AppendFormat(" AND NOT ID IN (select AdPageId from [dbo].[AdUserPage] where FlowUserId={0})", mp.FlowUserTask);
            }
            if (mp.FlowUserRunning.HasValue)
            {
                sb.AppendFormat(" AND NOT ID IN (select AdPageId from [dbo].[AdUserPage] where FlowUserId={0} AND IsState=0 )", mp.FlowUserRunning);
            }
            if (mp.FlowUserClosed.HasValue)
            {
                sb.AppendFormat(" AND NOT ID IN (select AdPageId from [dbo].[AdUserPage] where FlowUserId={0} AND IsState=1 )", mp.FlowUserClosed);
            }

            if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.LikeDesc)))
            {
                sb.AppendFormat(" AND [Desc]  like '%{0}%' ", mp.LikeDesc);
            }

            return sb.ToString();
        }
    }
}
