
/*

skey edit by 2017/8/21 15:16:48

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
    public partial class CustomerInfoPara : BasePager
    {
                 public int? Id { get; set; }

          public string AdUrl { get; set; }

          public int? AdId { get; set; }

          public int? AdUserId { get; set; }

          public string RealName { get; set; }

          public string Phone { get; set; }

          public string WeiXinNum { get; set; }

          public string Remark { get; set; }

          public string Address { get; set; }

          public string UserCountry { get; set; }

          public string UserRegion { get; set; }

          public string UserCity { get; set; }

          public string ClientIp { get; set; }

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

          public DateTime? CreateDate { get; set; }

          public int? Num { get; set; }

          public decimal? Price { get; set; }

          public string ProducteName { get; set; }

          public string Color { get; set; }

          public string Size { get; set; }

          public int? IsDelete { get; set; }

          public string UserAttr { get; set; }

          public int? CheckState { get; set; }

          public string CheckRemark { get; set; }

          public int? IsExport { get; set; }

          public int? ExportUserId { get; set; }

          public DateTime? ExportDate { get; set; }


    }
}
