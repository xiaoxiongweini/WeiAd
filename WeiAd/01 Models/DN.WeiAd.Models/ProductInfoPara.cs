
/*

skey edit by 2017/7/24 9:27:33

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
    public partial class ProductInfoPara : BasePager
    {
                 public int? Id { get; set; }

          public string Name { get; set; }

          public string Desc { get; set; }

          public int? AdId { get; set; }

          public int? Price { get; set; }

          public string AttrText { get; set; }

          public string AttrStyle { get; set; }

          public int? IsState { get; set; }

          public int? IsDelete { get; set; }

          public int? CreateUserId { get; set; }

          public DateTime? CreateDate { get; set; }


    }
}
