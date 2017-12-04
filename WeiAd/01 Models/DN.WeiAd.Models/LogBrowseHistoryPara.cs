
/*

skey edit by 2017/7/4 11:20:59

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
    public partial class LogBrowseHistoryPara : BasePager
    {
                 public int? Id { get; set; }

          public string Url { get; set; }

          public string ClientIp { get; set; }

          public string BrowseType { get; set; }

          public DateTime? CreateDate { get; set; }

          public int? AdId { get; set; }

          public int? AdUserId { get; set; }

          public int? FlowUserId { get; set; }

          public string AdUrl { get; set; }

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
