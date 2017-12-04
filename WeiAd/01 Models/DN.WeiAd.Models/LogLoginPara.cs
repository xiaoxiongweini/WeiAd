
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
    public partial class LogLoginPara : BasePager
    {
                 public int? Id { get; set; }

          public string LoginName { get; set; }

          public int? LoginState { get; set; }

          public string LoginDesc { get; set; }

          public DateTime? LoginDate { get; set; }

          public string ClientIp { get; set; }

          public string BrowseType { get; set; }

          public int? LoginType { get; set; }


    }
}
