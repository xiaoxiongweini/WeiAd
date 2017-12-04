
/*

skey edit by 2017-04-24 20:20:39

*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DN.WeiAd.Models;
using DN.WeiAd.Interface;
using DN.Framework.Core;

namespace DN.WeiAd.Access.MsSqlAccess
{
    public partial class ArticleInfoAccess : ArticleInfoInterface
    {
        #region SQL

        /// <summary>
        /// 新增
        /// </summary>
        const string INSERT = "INSERT INTO ArticleInfo ([ChannelId],[ArticleTypeId],[Title],[TitleImg],[TitleShort],[LinkUrl],[PageKey],[PageDesc],[ConetntShort],[Content],[ContentGroup],[Lable],[Source],[EditUser],[IsContributions],[IsState],[IsShow],[ContributionsUserId],[OrderIndex],[IsHot],[IsHeadline],[IsTop],[OpenCount],[CommentCount],[LikeCount],[StepCount],[CreateDate],[LastDate],[CreateUserId],[AuditUserId],[AuditState],[AuditDate],[AuditDesc],[IsAd]) VALUES (@ChannelId,@ArticleTypeId,@Title,@TitleImg,@TitleShort,@LinkUrl,@PageKey,@PageDesc,@ConetntShort,@Content,@ContentGroup,@Lable,@Source,@EditUser,@IsContributions,@IsState,@IsShow,@ContributionsUserId,@OrderIndex,@IsHot,@IsHeadline,@IsTop,@OpenCount,@CommentCount,@LikeCount,@StepCount,@CreateDate,@LastDate,@CreateUserId,@AuditUserId,@AuditState,@AuditDate,@AuditDesc,@IsAd)";

        /// <summary>
        /// 修改
        /// </summary>
        const string EDIT = "UPDATE ArticleInfo SET [ChannelId]=@ChannelId,[ArticleTypeId]=@ArticleTypeId,[Title]=@Title,[TitleImg]=@TitleImg,[TitleShort]=@TitleShort,[LinkUrl]=@LinkUrl,[PageKey]=@PageKey,[PageDesc]=@PageDesc,[ConetntShort]=@ConetntShort,[Content]=@Content,[ContentGroup]=@ContentGroup,[Lable]=@Lable,[Source]=@Source,[EditUser]=@EditUser,[IsContributions]=@IsContributions,[IsState]=@IsState,[IsShow]=@IsShow,[ContributionsUserId]=@ContributionsUserId,[OrderIndex]=@OrderIndex,[IsHot]=@IsHot,[IsHeadline]=@IsHeadline,[IsTop]=@IsTop,[OpenCount]=@OpenCount,[CommentCount]=@CommentCount,[LikeCount]=@LikeCount,[StepCount]=@StepCount,[CreateDate]=@CreateDate,[LastDate]=@LastDate,[CreateUserId]=@CreateUserId,[AuditUserId]=@AuditUserId,[AuditState]=@AuditState,[AuditDate]=@AuditDate,[AuditDesc]=@AuditDesc,[IsAd]=@IsAd WHERE [Id]=@Id";

        /// <summary>
        /// 删除
        /// </summary>
        const string DELETE = "DELETE FROM ArticleInfo";

        /// <summary>
        /// 加载数据
        /// </summary>
        const string LOAD = "SELECT * FROM ArticleInfo @WHERE @ORDER";

        /// <summary>
        /// 分页查询
        /// </summary>
        const string QUERYPAGE = "SELECT TOP @PAGESIZE * FROM [ArticleInfo] @WHERE AND Id NOT IN (SELECT TOP @PTOP Id FROM [ArticleInfo] @WHERE @ORDER)  @ORDER";

        /// <summary>
        /// 查询记录数
        /// </summary>
        const string QUERYCOUNT = "SELECT COUNT(1) FROM ArticleInfo";


        #endregion

        public override bool Delete(ArticleInfoPara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            command.CommandText = DELETE + where;

            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override bool Edit(ArticleInfoVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = EDIT;

             command.Parameters.Add(new SqlParameter() { ParameterName = "@ChannelId", Value = ParameterHelper.ConvertValue(m.ChannelId) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@ArticleTypeId", Value = ParameterHelper.ConvertValue(m.ArticleTypeId) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@Title", Value = ParameterHelper.ConvertValue(m.Title) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@TitleImg", Value = ParameterHelper.ConvertValue(m.TitleImg) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@TitleShort", Value = ParameterHelper.ConvertValue(m.TitleShort) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@LinkUrl", Value = ParameterHelper.ConvertValue(m.LinkUrl) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@PageKey", Value = ParameterHelper.ConvertValue(m.PageKey) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@PageDesc", Value = ParameterHelper.ConvertValue(m.PageDesc) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@ConetntShort", Value = ParameterHelper.ConvertValue(m.ConetntShort) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@Content", Value = ParameterHelper.ConvertValue(m.Content) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@ContentGroup", Value = ParameterHelper.ConvertValue(m.ContentGroup) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@Lable", Value = ParameterHelper.ConvertValue(m.Lable) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@Source", Value = ParameterHelper.ConvertValue(m.Source) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@EditUser", Value = ParameterHelper.ConvertValue(m.EditUser) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@IsContributions", Value = ParameterHelper.ConvertValue(m.IsContributions) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@IsState", Value = ParameterHelper.ConvertValue(m.IsState) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@IsShow", Value = ParameterHelper.ConvertValue(m.IsShow) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@ContributionsUserId", Value = ParameterHelper.ConvertValue(m.ContributionsUserId) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@OrderIndex", Value = ParameterHelper.ConvertValue(m.OrderIndex) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@IsHot", Value = ParameterHelper.ConvertValue(m.IsHot) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@IsHeadline", Value = ParameterHelper.ConvertValue(m.IsHeadline) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@IsTop", Value = ParameterHelper.ConvertValue(m.IsTop) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@OpenCount", Value = ParameterHelper.ConvertValue(m.OpenCount) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@CommentCount", Value = ParameterHelper.ConvertValue(m.CommentCount) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@LikeCount", Value = ParameterHelper.ConvertValue(m.LikeCount) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@StepCount", Value = ParameterHelper.ConvertValue(m.StepCount) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateDate", Value = ParameterHelper.ConvertValue(m.CreateDate) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@LastDate", Value = ParameterHelper.ConvertValue(m.LastDate) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateUserId", Value = ParameterHelper.ConvertValue(m.CreateUserId) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@AuditUserId", Value = ParameterHelper.ConvertValue(m.AuditUserId) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@AuditState", Value = ParameterHelper.ConvertValue(m.AuditState) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@AuditDate", Value = ParameterHelper.ConvertValue(m.AuditDate) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@AuditDesc", Value = ParameterHelper.ConvertValue(m.AuditDesc) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@IsAd", Value = ParameterHelper.ConvertValue(m.IsAd) });
               command.Parameters.Add(new SqlParameter() { ParameterName = "@Id", Value = ParameterHelper.ConvertValue(m.Id) });


            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override string GetConditionByModel(ArticleInfoVO m)
        {
            return "";
        }

        public override string GetConditionByPara(ArticleInfoPara mp)
        {
            StringBuilder sb = new StringBuilder();

           if (mp.Id.HasValue) { sb.AppendFormat(" AND [Id]='{0}' ",mp.Id);}
           if (mp.ChannelId.HasValue) { sb.AppendFormat(" AND [ChannelId]='{0}' ",mp.ChannelId);}
           if (mp.ArticleTypeId.HasValue) { sb.AppendFormat(" AND [ArticleTypeId]='{0}' ",mp.ArticleTypeId);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.Title))){ sb.AppendFormat(" AND [Title]='{0}' ",mp.Title);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.TitleImg))){ sb.AppendFormat(" AND [TitleImg]='{0}' ",mp.TitleImg);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.TitleShort))){ sb.AppendFormat(" AND [TitleShort]='{0}' ",mp.TitleShort);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.LinkUrl))){ sb.AppendFormat(" AND [LinkUrl]='{0}' ",mp.LinkUrl);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.PageKey))){ sb.AppendFormat(" AND [PageKey]='{0}' ",mp.PageKey);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.PageDesc))){ sb.AppendFormat(" AND [PageDesc]='{0}' ",mp.PageDesc);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.ConetntShort))){ sb.AppendFormat(" AND [ConetntShort]='{0}' ",mp.ConetntShort);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.Content))){ sb.AppendFormat(" AND [Content]='{0}' ",mp.Content);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.ContentGroup))){ sb.AppendFormat(" AND [ContentGroup]='{0}' ",mp.ContentGroup);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.Lable))){ sb.AppendFormat(" AND [Lable]='{0}' ",mp.Lable);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.Source))){ sb.AppendFormat(" AND [Source]='{0}' ",mp.Source);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.EditUser))){ sb.AppendFormat(" AND [EditUser]='{0}' ",mp.EditUser);}
           if (mp.IsContributions.HasValue) { sb.AppendFormat(" AND [IsContributions]='{0}' ",mp.IsContributions);}
           if (mp.IsState.HasValue) { sb.AppendFormat(" AND [IsState]='{0}' ",mp.IsState);}
           if (mp.IsShow.HasValue) { sb.AppendFormat(" AND [IsShow]='{0}' ",mp.IsShow);}
           if (mp.ContributionsUserId.HasValue) { sb.AppendFormat(" AND [ContributionsUserId]='{0}' ",mp.ContributionsUserId);}
           if (mp.OrderIndex.HasValue) { sb.AppendFormat(" AND [OrderIndex]='{0}' ",mp.OrderIndex);}
           if (mp.IsHot.HasValue) { sb.AppendFormat(" AND [IsHot]='{0}' ",mp.IsHot);}
           if (mp.IsHeadline.HasValue) { sb.AppendFormat(" AND [IsHeadline]='{0}' ",mp.IsHeadline);}
           if (mp.IsTop.HasValue) { sb.AppendFormat(" AND [IsTop]='{0}' ",mp.IsTop);}
           if (mp.OpenCount.HasValue) { sb.AppendFormat(" AND [OpenCount]='{0}' ",mp.OpenCount);}
           if (mp.CommentCount.HasValue) { sb.AppendFormat(" AND [CommentCount]='{0}' ",mp.CommentCount);}
           if (mp.LikeCount.HasValue) { sb.AppendFormat(" AND [LikeCount]='{0}' ",mp.LikeCount);}
           if (mp.StepCount.HasValue) { sb.AppendFormat(" AND [StepCount]='{0}' ",mp.StepCount);}
           if (mp.CreateDate.HasValue) { sb.AppendFormat(" AND [CreateDate]='{0}' ",mp.CreateDate);}
           if (mp.LastDate.HasValue) { sb.AppendFormat(" AND [LastDate]='{0}' ",mp.LastDate);}
           if (mp.CreateUserId.HasValue) { sb.AppendFormat(" AND [CreateUserId]='{0}' ",mp.CreateUserId);}
           if (mp.AuditUserId.HasValue) { sb.AppendFormat(" AND [AuditUserId]='{0}' ",mp.AuditUserId);}
           if (mp.AuditState.HasValue) { sb.AppendFormat(" AND [AuditState]='{0}' ",mp.AuditState);}
           if (mp.AuditDate.HasValue) { sb.AppendFormat(" AND [AuditDate]='{0}' ",mp.AuditDate);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.AuditDesc))){ sb.AppendFormat(" AND [AuditDesc]='{0}' ",mp.AuditDesc);}
           if (mp.IsAd.HasValue) { sb.AppendFormat(" AND [IsAd]='{0}' ",mp.IsAd);}


            sb.Insert(0, " WHERE 1=1 ");

            return sb.ToString();
        }

        public override List<ArticleInfoVO> GetModels(ref ArticleInfoPara mp)
        {
            string where = GetConditionByPara(mp);

            int pStart = mp.PageIndex.Value * mp.PageSize.Value;
            int pEnd = mp.PageSize.Value;
            string cmd = QUERYPAGE
                .Replace("@PAGESIZE", pEnd.ToString())
                .Replace("@PTOP", pStart.ToString())
                .Replace("@WHERE", where)
                .Replace("@ORDER", GetOrderByPara(mp));

            CodeCommand command = new CodeCommand();
            command.CommandText = cmd;

            var table = DbProxyFactory.Instance.Proxy.ExecuteTable(command);

            List<ArticleInfoVO> list = new List<ArticleInfoVO>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(new ArticleInfoVO(table.Rows[i]));
            }

            if (!mp.Recount.HasValue)
            {
                mp.Recount = GetRecords(mp);
            }

            return list;
        }

        public override List<ArticleInfoVO> GetModels(ArticleInfoPara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            
			string cmd = LOAD
                .Replace("@WHERE", where)
                .Replace("@ORDER", GetOrderByPara(mp));
			command.CommandText = cmd;

            var table = DbProxyFactory.Instance.Proxy.ExecuteTable(command);

            List<ArticleInfoVO> list = new List<ArticleInfoVO>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(new ArticleInfoVO(table.Rows[i]));
            }

            return list;
        }

        public override string GetOrderByModel(ArticleInfoVO m)
        {
            return "";
        }

        public override string GetOrderByPara(ArticleInfoPara mp)
        {
            if(!string.IsNullOrEmpty(mp.OrderBy))
            {
                return string.Format(" order by {0}", mp.OrderBy);
            }

            return "";
        }

        public override string GetOtherConditionByModel(ArticleInfoVO m)
        {
            return "";
        }

        public override string GetOtherConditionByPara(ArticleInfoPara mp)
        {
            return "";
        }

        public override int GetRecords(ArticleInfoPara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            command.CommandText = QUERYCOUNT + where;

            var result = DbProxyFactory.Instance.Proxy.ExecuteScalar(command);

            return int.Parse(result.ToString());
        }

        public override ArticleInfoVO GetSingle(ArticleInfoPara mp)
        {
            var list = GetModels(mp);

            if (list.Count == 1)
                return list[0];

            return null;
        }

        public override bool Insert(ArticleInfoVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = INSERT;
         command.Parameters.Add(new SqlParameter() { ParameterName = "@ChannelId", Value = ParameterHelper.ConvertValue(m.ChannelId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@ArticleTypeId", Value = ParameterHelper.ConvertValue(m.ArticleTypeId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Title", Value = ParameterHelper.ConvertValue(m.Title) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@TitleImg", Value = ParameterHelper.ConvertValue(m.TitleImg) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@TitleShort", Value = ParameterHelper.ConvertValue(m.TitleShort) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@LinkUrl", Value = ParameterHelper.ConvertValue(m.LinkUrl) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@PageKey", Value = ParameterHelper.ConvertValue(m.PageKey) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@PageDesc", Value = ParameterHelper.ConvertValue(m.PageDesc) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@ConetntShort", Value = ParameterHelper.ConvertValue(m.ConetntShort) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Content", Value = ParameterHelper.ConvertValue(m.Content) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@ContentGroup", Value = ParameterHelper.ConvertValue(m.ContentGroup) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Lable", Value = ParameterHelper.ConvertValue(m.Lable) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Source", Value = ParameterHelper.ConvertValue(m.Source) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@EditUser", Value = ParameterHelper.ConvertValue(m.EditUser) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@IsContributions", Value = ParameterHelper.ConvertValue(m.IsContributions) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@IsState", Value = ParameterHelper.ConvertValue(m.IsState) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@IsShow", Value = ParameterHelper.ConvertValue(m.IsShow) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@ContributionsUserId", Value = ParameterHelper.ConvertValue(m.ContributionsUserId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@OrderIndex", Value = ParameterHelper.ConvertValue(m.OrderIndex) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@IsHot", Value = ParameterHelper.ConvertValue(m.IsHot) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@IsHeadline", Value = ParameterHelper.ConvertValue(m.IsHeadline) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@IsTop", Value = ParameterHelper.ConvertValue(m.IsTop) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@OpenCount", Value = ParameterHelper.ConvertValue(m.OpenCount) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CommentCount", Value = ParameterHelper.ConvertValue(m.CommentCount) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@LikeCount", Value = ParameterHelper.ConvertValue(m.LikeCount) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@StepCount", Value = ParameterHelper.ConvertValue(m.StepCount) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateDate", Value = ParameterHelper.ConvertValue(m.CreateDate) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@LastDate", Value = ParameterHelper.ConvertValue(m.LastDate) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateUserId", Value = ParameterHelper.ConvertValue(m.CreateUserId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@AuditUserId", Value = ParameterHelper.ConvertValue(m.AuditUserId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@AuditState", Value = ParameterHelper.ConvertValue(m.AuditState) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@AuditDate", Value = ParameterHelper.ConvertValue(m.AuditDate) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@AuditDesc", Value = ParameterHelper.ConvertValue(m.AuditDesc) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@IsAd", Value = ParameterHelper.ConvertValue(m.IsAd) });


            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override int InsertIdentityId(ArticleInfoVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = INSERT + "; select @@Identity";

         command.Parameters.Add(new SqlParameter() { ParameterName = "@ChannelId", Value = ParameterHelper.ConvertValue(m.ChannelId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@ArticleTypeId", Value = ParameterHelper.ConvertValue(m.ArticleTypeId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Title", Value = ParameterHelper.ConvertValue(m.Title) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@TitleImg", Value = ParameterHelper.ConvertValue(m.TitleImg) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@TitleShort", Value = ParameterHelper.ConvertValue(m.TitleShort) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@LinkUrl", Value = ParameterHelper.ConvertValue(m.LinkUrl) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@PageKey", Value = ParameterHelper.ConvertValue(m.PageKey) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@PageDesc", Value = ParameterHelper.ConvertValue(m.PageDesc) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@ConetntShort", Value = ParameterHelper.ConvertValue(m.ConetntShort) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Content", Value = ParameterHelper.ConvertValue(m.Content) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@ContentGroup", Value = ParameterHelper.ConvertValue(m.ContentGroup) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Lable", Value = ParameterHelper.ConvertValue(m.Lable) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Source", Value = ParameterHelper.ConvertValue(m.Source) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@EditUser", Value = ParameterHelper.ConvertValue(m.EditUser) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@IsContributions", Value = ParameterHelper.ConvertValue(m.IsContributions) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@IsState", Value = ParameterHelper.ConvertValue(m.IsState) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@IsShow", Value = ParameterHelper.ConvertValue(m.IsShow) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@ContributionsUserId", Value = ParameterHelper.ConvertValue(m.ContributionsUserId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@OrderIndex", Value = ParameterHelper.ConvertValue(m.OrderIndex) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@IsHot", Value = ParameterHelper.ConvertValue(m.IsHot) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@IsHeadline", Value = ParameterHelper.ConvertValue(m.IsHeadline) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@IsTop", Value = ParameterHelper.ConvertValue(m.IsTop) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@OpenCount", Value = ParameterHelper.ConvertValue(m.OpenCount) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CommentCount", Value = ParameterHelper.ConvertValue(m.CommentCount) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@LikeCount", Value = ParameterHelper.ConvertValue(m.LikeCount) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@StepCount", Value = ParameterHelper.ConvertValue(m.StepCount) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateDate", Value = ParameterHelper.ConvertValue(m.CreateDate) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@LastDate", Value = ParameterHelper.ConvertValue(m.LastDate) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateUserId", Value = ParameterHelper.ConvertValue(m.CreateUserId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@AuditUserId", Value = ParameterHelper.ConvertValue(m.AuditUserId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@AuditState", Value = ParameterHelper.ConvertValue(m.AuditState) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@AuditDate", Value = ParameterHelper.ConvertValue(m.AuditDate) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@AuditDesc", Value = ParameterHelper.ConvertValue(m.AuditDesc) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@IsAd", Value = ParameterHelper.ConvertValue(m.IsAd) });


            var result = DbProxyFactory.Instance.Proxy.ExecuteScalar(command);

            return int.Parse(result.ToString());
        }
    }
}
