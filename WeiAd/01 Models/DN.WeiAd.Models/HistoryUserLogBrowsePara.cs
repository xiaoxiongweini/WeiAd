
/*

skey edit by 2017/7/4 16:41:46

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
    public partial class HistoryUserLogBrowsePara : BasePager
    {
                 public int? Id { get; set; }

          public int? Time { get; set; }

          public int? AdId { get; set; }

          public int? UserId { get; set; }

          public int? PvCount { get; set; }

          public int? UvCount { get; set; }

          public int? IpCount { get; set; }

          public decimal? Price { get; set; }

          public decimal? Money { get; set; }

          public DateTime? CreateDate { get; set; }

          public int? CreateUserId { get; set; }


    }
}
