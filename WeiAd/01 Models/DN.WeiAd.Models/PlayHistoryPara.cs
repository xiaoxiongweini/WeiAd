
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
    public partial class PlayHistoryPara : BasePager
    {
                 public int? Id { get; set; }

          public int? AdUserId { get; set; }

          public int? FlowUserId { get; set; }

          public int? AdId { get; set; }

          public string AdUrl { get; set; }

          public int? Time { get; set; }

          public decimal? Money { get; set; }

          public DateTime? CreateDate { get; set; }

          public int? CreateUserId { get; set; }

          public int? ClientIp { get; set; }

          public int? ClientUv { get; set; }

          public int? ClientPv { get; set; }

          public decimal? Price { get; set; }


    }
}
