
/*

skey edit by 2017/5/17 7:00:20

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
    public partial class AdPageInfoPara : BasePager
    {
                 public int? Id { get; set; }

          public string WeiXinUrl { get; set; }

          public string Title { get; set; }

          public string TitleImg { get; set; }

          public string QcodeImg { get; set; }

          public string Content { get; set; }

          public int? AdType { get; set; }

          public DateTime? CreateDate { get; set; }

          public DateTime? LastDate { get; set; }

          public int? UserId { get; set; }

          public string ViewPage { get; set; }

          public int? UserCodeId { get; set; }

          public string UserCodeIds { get; set; }

          public int? IsState { get; set; }

          public decimal? Money { get; set; }

          public int? SaleType { get; set; }

          public int? PlanIp { get; set; }

          public DateTime? StartTime { get; set; }

          public int? PlanTerminal { get; set; }

          public decimal? MoneyCount { get; set; }

          public decimal? BuyMoney { get; set; }

          public int? OrderIndex { get; set; }

          public string UserCode { get; set; }

          public string TitleShort { get; set; }

          public int? BuyIp { get; set; }

          public string TemplateName { get; set; }

          public int? IsDel { get; set; }

          public int? IsAuth { get; set; }

          public string StaticContent { get; set; }

          public int? CreateUserId { get; set; }

          public string MiddlePage { get; set; }

          public string AdTimeStart { get; set; }

          public string AdTimeEnd { get; set; }

          public int? UserAdTypeId { get; set; }

          public string Desc { get; set; }

          public int? SiteTypeId { get; set; }

          public string PlatformType { get; set; }

          public DateTime? DeleteDate { get; set; }

          public string DefaultQcode { get; set; }

          public int? QcodeCount { get; set; }

          public int? PageCount { get; set; }

          public string QcodeImg2 { get; set; }

          public string DefaultQcode2 { get; set; }

          public string DomainList { get; set; }


    }
}
