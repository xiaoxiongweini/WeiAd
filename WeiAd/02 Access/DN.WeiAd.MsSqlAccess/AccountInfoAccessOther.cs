using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DN.WeiAd.Models;

namespace DN.WeiAd.Access.MsSqlAccess
{
    public partial class AccountInfoAccessOther
    {
        public static string GetConditionByPara(AccountInfoPara mp)
        {
            StringBuilder sb = new StringBuilder();

            if (mp.UserTypes!= null && mp.UserTypes.Count !=0)
            {
                sb.AppendFormat(" AND UserType IN ({0})", string.Join(",", mp.UserTypes));
            }

            if(mp.IsNotAdmin.HasValue)
            {
                if (mp.IsNotAdmin.Value)
                {
                    sb.AppendFormat(" AND UserType <> 100 ");
                }
                else
                {
                    sb.AppendFormat(" AND UserType  = 100 ");
                }
            }

            return sb.ToString();
        }
    }
}
