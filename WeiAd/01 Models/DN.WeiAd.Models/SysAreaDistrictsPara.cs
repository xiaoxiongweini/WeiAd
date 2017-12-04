
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
    public partial class SysAreaDistrictsPara : BasePager
    {
                 public int? Id { get; set; }

          public string Name { get; set; }

          public int? CityId { get; set; }

          public int? ProvincesId { get; set; }

          public DateTime? CreateTime { get; set; }


    }
}
