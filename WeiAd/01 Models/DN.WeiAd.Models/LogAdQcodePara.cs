
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
    public partial class LogAdQcodePara : BasePager
    {
                 public int? Id { get; set; }

          public int? AdId { get; set; }

          public int? AdUserId { get; set; }

          public int? QcodeId { get; set; }

          public string Url { get; set; }

          public string ClientIp { get; set; }

          public string BrowseType { get; set; }

          public DateTime? CreateDate { get; set; }

          public int? Time { get; set; }

          public string ClientId { get; set; }

          public int? IsMobile { get; set; }

          public string ReferrerUrl { get; set; }

          public string BrowseName { get; set; }

          public string BrowseVersion { get; set; }

          public string OsName { get; set; }


    }
}
