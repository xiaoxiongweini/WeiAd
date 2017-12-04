
/*

skey edit by 2017/7/20 12:01:18

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
    public partial class CpsUserInfoPara : BasePager
    {
                 public int? Id { get; set; }

          public int? CpsUserId { get; set; }

          public int? AdId { get; set; }

          public DateTime? CreateDate { get; set; }

          public int? CreateUserId { get; set; }

          public int? IsState { get; set; }


    }
}
