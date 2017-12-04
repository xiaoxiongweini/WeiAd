
/*

skey edit by 2017-05-01 15:14:56

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
    public partial class VersionInfoPara : BasePager
    {
                 public int? Id { get; set; }

          public string Name { get; set; }

          public string Desc { get; set; }

          public DateTime? CreateDate { get; set; }


    }
}
