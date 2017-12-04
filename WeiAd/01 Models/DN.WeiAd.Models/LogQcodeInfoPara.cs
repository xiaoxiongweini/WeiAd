
/*

skey edit by 2017/12/4 12:00:28

mail:skey111@foxmail.com

version edit by v1.0.3

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
    public partial class LogQcodeInfoPara : BasePager
    {
                 public int? Id { get; set; }

          public string CopyText { get; set; }

          public string Url { get; set; }

          public string ClientIp { get; set; }

          public string BrowseType { get; set; }

          public DateTime? CreateDate { get; set; }

          public decimal? Money { get; set; }

          public int? IsMoney { get; set; }

          public int? Time { get; set; }

          public string ClientId { get; set; }

          public int? IsMobile { get; set; }

          public string ReferrerUrl { get; set; }

          public string BrowseName { get; set; }

          public string BrowseVersion { get; set; }

          public string OsName { get; set; }

          public string Country { get; set; }

          public string Area { get; set; }

          public string Region { get; set; }

          public string City { get; set; }

          public string County { get; set; }

          public string Isp { get; set; }

          public string IpSource { get; set; }


    }
}