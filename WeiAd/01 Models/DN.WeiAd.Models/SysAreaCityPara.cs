
/*

skey edit by 2017/7/16 9:01:29

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
    public partial class SysAreaCityPara : BasePager
    {
                 public int? Id { get; set; }

          public string Name { get; set; }

          public int? ParentId { get; set; }

          public string ZipCode { get; set; }

          public DateTime? CreateTime { get; set; }


    }
}
