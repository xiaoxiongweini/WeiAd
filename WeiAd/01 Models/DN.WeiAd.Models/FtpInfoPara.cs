
/*

skey edit by 2017-05-01 15:14:56

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
    public partial class FtpInfoPara : BasePager
    {
                 public int? Id { get; set; }

          public string Name { get; set; }

          public string Desc { get; set; }

          public string Domains { get; set; }

          public string FtpServer { get; set; }

          public string FtpUserName { get; set; }

          public string FtpPassword { get; set; }

          public int? IsSynchronization { get; set; }

          public DateTime? CreateDate { get; set; }

          public DateTime? CloseDate { get; set; }


    }
}
