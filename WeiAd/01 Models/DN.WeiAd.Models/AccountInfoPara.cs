
/*

skey edit by 2017-04-19 21:20:20

*/


using DN.Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DN.Framework.Core.CodeAttributes;

namespace DN.WeiAd.Models
{
    /// <summary>
    /// 查询参数
    /// </summary>
    public partial class AccountInfoPara : BasePager
    {
        public int? Id { get; set; }

        public string UserName { get; set; }

        public string NickName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int? UserType { get; set; }

        public string UserPwd { get; set; }

        public string UserImg { get; set; }

        public DateTime? RegDate { get; set; }

        public string RegIp { get; set; }

        public int? IsLock { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public int? AccountType { get; set; }

        public string OpenId { get; set; }

        public float? ConsumptionMoney { get; set; }

        public float? Money { get; set; }

        public float? MoneyFree { get; set; }

        public float? MoneyCount { get; set; }

        public DateTime? LastMoneyDate { get; set; }


    }
}
