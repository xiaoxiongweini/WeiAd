
/*

skey edit by 2017/7/28 8:34:36

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
    public partial class ServerInfoPara : BasePager
    {
                 public int? Id { get; set; }

          public string ServerId { get; set; }

          public string Name { get; set; }

          public string Desc { get; set; }

          public string Ip { get; set; }

          public DateTime? CreateDate { get; set; }

          public int? IsState { get; set; }

          public DateTime? UpdateDate { get; set; }

          public int? UserId { get; set; }


    }
}
