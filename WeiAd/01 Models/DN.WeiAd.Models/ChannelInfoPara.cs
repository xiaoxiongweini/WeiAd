
/*

skey edit by 2017/7/6 12:42:02

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
    public partial class ChannelInfoPara : BasePager
    {
                 public int? Id { get; set; }

          public string Name { get; set; }

          public string Desc { get; set; }

          public string LinkUrl { get; set; }

          public string ImgUrl { get; set; }

          public int? IsShow { get; set; }

          public int? IsHot { get; set; }

          public int? IsTop { get; set; }

          public string ColorValue { get; set; }

          public DateTime? CreateDate { get; set; }

          public DateTime? LastDate { get; set; }

          public int? CreateUserId { get; set; }


    }
}
