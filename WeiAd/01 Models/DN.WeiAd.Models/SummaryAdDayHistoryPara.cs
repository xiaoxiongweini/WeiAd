
/*

skey edit by 2017/9/21 10:02:13

mail:skey111@foxmail.com

version edit by v1.0.3

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
    public partial class SummaryAdDayHistoryPara : BasePager
    {
                 public int? Id { get; set; }

          public int? AdId { get; set; }

          public int? UserId { get; set; }

          public int? TimeId { get; set; }

          public int? PvCount { get; set; }

          public int? UvCount { get; set; }

          public int? IpCount { get; set; }

          public DateTime? CreateDate { get; set; }

          public int? CreateUserId { get; set; }

          public int? IsDelete { get; set; }


    }
}
