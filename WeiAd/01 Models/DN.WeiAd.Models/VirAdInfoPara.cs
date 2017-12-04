
/*

skey edit by 2017/7/17 16:02:27

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
    public partial class VirAdInfoPara : BasePager
    {
                 public int? Id { get; set; }

          public string Name { get; set; }

          public int? UserId { get; set; }

          public string Desc { get; set; }

          public int? LinkUrl { get; set; }

          public decimal? Price { get; set; }

          public int? ShowCount { get; set; }

          public int? ClickCount { get; set; }

          public int? VaildClickCount { get; set; }

          public int? IpCount { get; set; }

          public int? MaxCount { get; set; }

          public DateTime? CreateDate { get; set; }

          public int? CreateUserId { get; set; }


    }
}
