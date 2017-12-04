
/*

skey edit by 2017/7/27 18:07:22

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
    public partial class DomainSynchroHistoryPara : BasePager
    {
                 public int? Id { get; set; }

          public int? ServerId { get; set; }

          public string Name { get; set; }

          public string MainDomain { get; set; }

          public string Domains { get; set; }

          public string DomainPath { get; set; }

          public int? OperType { get; set; }

          public int? IsSynchro { get; set; }

          public DateTime? SynchroDate { get; set; }

          public string ClientIp { get; set; }

          public DateTime? CreateDate { get; set; }

          public int? CreateUserId { get; set; }

          public int? UserId { get; set; }

          public int? IsDelete { get; set; }


    }
}
