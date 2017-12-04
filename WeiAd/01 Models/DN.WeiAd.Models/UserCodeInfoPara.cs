
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
    public partial class UserCodeInfoPara : BasePager
    {
                 public int? Id { get; set; }

          public string Name { get; set; }

          public int? UserId { get; set; }

          public int? TypeId { get; set; }

          public string CodeContent { get; set; }

          public DateTime? CreateDate { get; set; }


    }
}