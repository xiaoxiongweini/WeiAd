using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DN.WeiAd.Models;

namespace DN.WeiAd.Access.MsSql
{
    internal class AdBrowseAccessother
    {

        public static string GetConditionByPara(AdBrowsePara mp)
        {
            StringBuilder sb = new StringBuilder();

            if (mp.IsNotDay.HasValue)
            {
                if (mp.IsNotDay.Value)
                {
                    sb.AppendFormat(" AND [Time] <> {0} ", DateTime.Now.ToString("yyyyMMdd"));
                }
                else
                {
                    sb.AppendFormat(" AND [Time] = {0} ", DateTime.Now.ToString("yyyyMMdd"));
                }
            }

            if(mp.Ids!= null && mp.Ids.Count !=0)
            {
                sb.AppendFormat(" and  [Id] ({0}) ", string.Join(",", mp.Ids));
            }

            return sb.ToString();

        }
    }
}
