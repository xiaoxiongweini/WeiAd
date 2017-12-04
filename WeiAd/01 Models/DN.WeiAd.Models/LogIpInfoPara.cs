
/*

skey edit by 2017-04-29 23:14:13

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
    public partial class LogIpInfoPara : BasePager
    {
                 public int? Id { get; set; }

          public string Ip { get; set; }

          public string country { get; set; }

          public string area { get; set; }

          public string region { get; set; }

          public string city { get; set; }

          public string county { get; set; }

          public string isp { get; set; }

          public DateTime? CreateDate { get; set; }


    }
}
