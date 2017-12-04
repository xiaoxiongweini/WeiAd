
/*

skey edit by 2017-04-19 21:20:20

*/


using DN.Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DN.Framework.Core.CodeAttributes;
using System.Data;
using DN.Framework.Utility;

namespace DN.WeiAd.Models
{
    /// <summary>
    /// 用户登录日志
    /// </summary>
    public partial class ArticleInfoVO: IModel
    {
        public ArticleInfoVO() { }

        public ArticleInfoVO(IDataReader row)
        {
          Id = ConvertHelper.GetInt(row["Id"]);
          ChannelId = ConvertHelper.GetInt(row["ChannelId"]);
          ArticleTypeId = ConvertHelper.GetInt(row["ArticleTypeId"]);
          Title = ConvertHelper.GetString(row["Title"]);
          TitleImg = ConvertHelper.GetString(row["TitleImg"]);
          TitleShort = ConvertHelper.GetString(row["TitleShort"]);
          LinkUrl = ConvertHelper.GetString(row["LinkUrl"]);
          PageKey = ConvertHelper.GetString(row["PageKey"]);
          PageDesc = ConvertHelper.GetString(row["PageDesc"]);
          ConetntShort = ConvertHelper.GetString(row["ConetntShort"]);
          Content = ConvertHelper.GetString(row["Content"]);
          ContentGroup = ConvertHelper.GetString(row["ContentGroup"]);
          Lable = ConvertHelper.GetString(row["Lable"]);
          Source = ConvertHelper.GetString(row["Source"]);
          EditUser = ConvertHelper.GetString(row["EditUser"]);
          IsContributions = ConvertHelper.GetInt(row["IsContributions"]);
          IsState = ConvertHelper.GetInt(row["IsState"]);
          IsShow = ConvertHelper.GetInt(row["IsShow"]);
          ContributionsUserId = ConvertHelper.GetInt(row["ContributionsUserId"]);
          OrderIndex = ConvertHelper.GetInt(row["OrderIndex"]);
          IsHot = ConvertHelper.GetInt(row["IsHot"]);
          IsHeadline = ConvertHelper.GetInt(row["IsHeadline"]);
          IsTop = ConvertHelper.GetInt(row["IsTop"]);
          OpenCount = ConvertHelper.GetInt(row["OpenCount"]);
          CommentCount = ConvertHelper.GetInt(row["CommentCount"]);
          LikeCount = ConvertHelper.GetInt(row["LikeCount"]);
          StepCount = ConvertHelper.GetInt(row["StepCount"]);
          CreateDate = ConvertHelper.GetDateTime(row["CreateDate"]);
          LastDate = ConvertHelper.GetDateTime(row["LastDate"]);
          CreateUserId = ConvertHelper.GetInt(row["CreateUserId"]);
          AuditUserId = ConvertHelper.GetInt(row["AuditUserId"]);
          AuditState = ConvertHelper.GetInt(row["AuditState"]);
          AuditDate = ConvertHelper.GetDateTime(row["AuditDate"]);
          AuditDesc = ConvertHelper.GetString(row["AuditDesc"]);
          IsAd = ConvertHelper.GetInt(row["IsAd"]);

        }

        public ArticleInfoVO(DataRow row)
        {
          Id = ConvertHelper.GetInt(row["Id"]);
          ChannelId = ConvertHelper.GetInt(row["ChannelId"]);
          ArticleTypeId = ConvertHelper.GetInt(row["ArticleTypeId"]);
          Title = ConvertHelper.GetString(row["Title"]);
          TitleImg = ConvertHelper.GetString(row["TitleImg"]);
          TitleShort = ConvertHelper.GetString(row["TitleShort"]);
          LinkUrl = ConvertHelper.GetString(row["LinkUrl"]);
          PageKey = ConvertHelper.GetString(row["PageKey"]);
          PageDesc = ConvertHelper.GetString(row["PageDesc"]);
          ConetntShort = ConvertHelper.GetString(row["ConetntShort"]);
          Content = ConvertHelper.GetString(row["Content"]);
          ContentGroup = ConvertHelper.GetString(row["ContentGroup"]);
          Lable = ConvertHelper.GetString(row["Lable"]);
          Source = ConvertHelper.GetString(row["Source"]);
          EditUser = ConvertHelper.GetString(row["EditUser"]);
          IsContributions = ConvertHelper.GetInt(row["IsContributions"]);
          IsState = ConvertHelper.GetInt(row["IsState"]);
          IsShow = ConvertHelper.GetInt(row["IsShow"]);
          ContributionsUserId = ConvertHelper.GetInt(row["ContributionsUserId"]);
          OrderIndex = ConvertHelper.GetInt(row["OrderIndex"]);
          IsHot = ConvertHelper.GetInt(row["IsHot"]);
          IsHeadline = ConvertHelper.GetInt(row["IsHeadline"]);
          IsTop = ConvertHelper.GetInt(row["IsTop"]);
          OpenCount = ConvertHelper.GetInt(row["OpenCount"]);
          CommentCount = ConvertHelper.GetInt(row["CommentCount"]);
          LikeCount = ConvertHelper.GetInt(row["LikeCount"]);
          StepCount = ConvertHelper.GetInt(row["StepCount"]);
          CreateDate = ConvertHelper.GetDateTime(row["CreateDate"]);
          LastDate = ConvertHelper.GetDateTime(row["LastDate"]);
          CreateUserId = ConvertHelper.GetInt(row["CreateUserId"]);
          AuditUserId = ConvertHelper.GetInt(row["AuditUserId"]);
          AuditState = ConvertHelper.GetInt(row["AuditState"]);
          AuditDate = ConvertHelper.GetDateTime(row["AuditDate"]);
          AuditDesc = ConvertHelper.GetString(row["AuditDesc"]);
          IsAd = ConvertHelper.GetInt(row["IsAd"]);

        }

       [Column(IsPrimaryKey = true, IsAutoNumber = true)]
       public int Id { get; set; }
       public int ChannelId { get; set; }
       public int ArticleTypeId { get; set; }
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
       public int IsContributions { get; set; }
       public int IsState { get; set; }
       public int IsShow { get; set; }
       public int ContributionsUserId { get; set; }
       public int OrderIndex { get; set; }
       public int IsHot { get; set; }
       public int IsHeadline { get; set; }
       public int IsTop { get; set; }
       public int OpenCount { get; set; }
       public int CommentCount { get; set; }
       public int LikeCount { get; set; }
       public int StepCount { get; set; }
       public DateTime CreateDate { get; set; }
       public DateTime LastDate { get; set; }
       public int CreateUserId { get; set; }
       public int AuditUserId { get; set; }
       public int AuditState { get; set; }
       public DateTime AuditDate { get; set; }
       public string AuditDesc { get; set; }
       public int IsAd { get; set; }


        public object Clone()
        {
            ArticleInfoVO obj = new ArticleInfoVO();
            
			            obj.Id = this.Id;

            obj.ChannelId = this.ChannelId;

            obj.ArticleTypeId = this.ArticleTypeId;

            obj.Title = this.Title;

            obj.TitleImg = this.TitleImg;

            obj.TitleShort = this.TitleShort;

            obj.LinkUrl = this.LinkUrl;

            obj.PageKey = this.PageKey;

            obj.PageDesc = this.PageDesc;

            obj.ConetntShort = this.ConetntShort;

            obj.Content = this.Content;

            obj.ContentGroup = this.ContentGroup;

            obj.Lable = this.Lable;

            obj.Source = this.Source;

            obj.EditUser = this.EditUser;

            obj.IsContributions = this.IsContributions;

            obj.IsState = this.IsState;

            obj.IsShow = this.IsShow;

            obj.ContributionsUserId = this.ContributionsUserId;

            obj.OrderIndex = this.OrderIndex;

            obj.IsHot = this.IsHot;

            obj.IsHeadline = this.IsHeadline;

            obj.IsTop = this.IsTop;

            obj.OpenCount = this.OpenCount;

            obj.CommentCount = this.CommentCount;

            obj.LikeCount = this.LikeCount;

            obj.StepCount = this.StepCount;

            obj.CreateDate = this.CreateDate;

            obj.LastDate = this.LastDate;

            obj.CreateUserId = this.CreateUserId;

            obj.AuditUserId = this.AuditUserId;

            obj.AuditState = this.AuditState;

            obj.AuditDate = this.AuditDate;

            obj.AuditDesc = this.AuditDesc;

            obj.IsAd = this.IsAd;



            return obj;
        }
    }
}
