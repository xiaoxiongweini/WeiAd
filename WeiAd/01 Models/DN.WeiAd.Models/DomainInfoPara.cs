
/*

skey edit by 2017/7/19 15:50:42

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
    public partial class DomainInfoPara : BasePager
    {
                 public int? Id { get; set; }

          public string Name { get; set; }

          public string Domain { get; set; }

          public string PageName { get; set; }

          public int? IsState { get; set; }

          public int? IsAuth { get; set; }

          public string CityName { get; set; }

          public DateTime? CreateDate { get; set; }

          public int? CreateUserId { get; set; }

          public int? IsColse { get; set; }

          public DateTime? ColseDate { get; set; }

          public int? CloseUserId { get; set; }

          public int? AdUserId { get; set; }

          public int? IsResolution { get; set; }

          public DateTime? ResolutionDate { get; set; }

          public string SerName { get; set; }

          public int? ResolutionType { get; set; }


    }
}
