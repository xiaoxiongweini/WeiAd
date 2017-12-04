
/*

skey edit by 2017/5/16 18:51:33

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
    public partial class AdQcodeInfoPara : BasePager
    {
                 public int? Id { get; set; }

          public int? AdId { get; set; }

          public int? AdUserId { get; set; }

          public string Name { get; set; }

          public string QcodeUrl { get; set; }

          public DateTime? CreateDate { get; set; }

          public int? CreateUserId { get; set; }

          public string QcodeUrl2 { get; set; }


    }
}
