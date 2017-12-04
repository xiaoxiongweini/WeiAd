
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
    public partial class VirAdLogBrowsePara : BasePager
    {
                 public int? Id { get; set; }

          public int? Name { get; set; }

          public int? ShowCount { get; set; }

          public int? ClickCount { get; set; }

          public int? VaildClickCount { get; set; }

          public int? IpCount { get; set; }

          public DateTime? CreateDate { get; set; }

          public int? CreateUserId { get; set; }


    }
}
