
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
    public partial class ArticleInfoPara : BasePager
    {
                 public int? Id { get; set; }

          public int? ChannelId { get; set; }

          public int? ArticleTypeId { get; set; }

          public string Title { get; set; }

          public string TitleImg { get; set; }

          public string TitleShort { get; set; }

          public string LinkUrl { get; set; }

          public string PageKey { get; set; }

          public string PageDesc { get; set; }

          public string ConetntShort { get; set; }

          public string Content { get; set; }

          public string ContentGroup { get; set; }

          public string Lable { get; set; }

          public string Source { get; set; }

          public string EditUser { get; set; }

          public int? IsContributions { get; set; }

          public int? IsState { get; set; }

          public int? IsShow { get; set; }

          public int? ContributionsUserId { get; set; }

          public int? OrderIndex { get; set; }

          public int? IsHot { get; set; }

          public int? IsHeadline { get; set; }

          public int? IsTop { get; set; }

          public int? OpenCount { get; set; }

          public int? CommentCount { get; set; }

          public int? LikeCount { get; set; }

          public int? StepCount { get; set; }

          public DateTime? CreateDate { get; set; }

          public DateTime? LastDate { get; set; }

          public int? CreateUserId { get; set; }

          public int? AuditUserId { get; set; }

          public int? AuditState { get; set; }

          public DateTime? AuditDate { get; set; }

          public string AuditDesc { get; set; }

          public int? IsAd { get; set; }


    }
}
