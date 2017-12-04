
/*

skey edit by 2017-04-24 20:20:38

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
    public partial class AdSiteInfoPara : BasePager
    {
                 public int? Id { get; set; }

          public string Name { get; set; }

          public string Desc { get; set; }

          public string WebSite { get; set; }

          public int? UserId { get; set; }

          public DateTime? CreateDate { get; set; }

          public DateTime? LastDate { get; set; }

          public string PlatformType { get; set; }

          public string Contact { get; set; }


    }
}
