
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
    public partial class AdUserPagePara : BasePager
    {
                 public int? Id { get; set; }

          public string Gid { get; set; }

          public string PageName { get; set; }

          public int? AdPageId { get; set; }

          public int? AdUserId { get; set; }

          public int? IsState { get; set; }

          public DateTime? CreateDate { get; set; }

          public int? CreateUserId { get; set; }

          public int? FlowUserId { get; set; }

          public DateTime? FlowLastDate { get; set; }


    }
}
