
/*

skey edit by 2017/7/6 12:42:03

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
    public partial class ChannelInfoAccess : ChannelInfoInterface
    {
        #region SQL

        /// <summary>
        /// 新增
        /// </summary>
        const string INSERT = "INSERT INTO ChannelInfo ([Name],[Desc],[LinkUrl],[ImgUrl],[IsShow],[IsHot],[IsTop],[ColorValue],[CreateDate],[LastDate],[CreateUserId]) VALUES (@Name,@Desc,@LinkUrl,@ImgUrl,@IsShow,@IsHot,@IsTop,@ColorValue,@CreateDate,@LastDate,@CreateUserId)";

        /// <summary>
        /// 修改
        /// </summary>
        const string EDIT = "UPDATE ChannelInfo SET [Name]=@Name,[Desc]=@Desc,[LinkUrl]=@LinkUrl,[ImgUrl]=@ImgUrl,[IsShow]=@IsShow,[IsHot]=@IsHot,[IsTop]=@IsTop,[ColorValue]=@ColorValue,[CreateDate]=@CreateDate,[LastDate]=@LastDate,[CreateUserId]=@CreateUserId WHERE [Id]=@Id";

        /// <summary>
        /// 删除
        /// </summary>
        const string DELETE = "DELETE FROM ChannelInfo";

        /// <summary>
        /// 加载数据
        /// </summary>
        const string LOAD = "SELECT * FROM ChannelInfo @WHERE @ORDER";

        /// <summary>
        /// 分页查询
        /// </summary>
        const string QUERYPAGE = "SELECT TOP @PAGESIZE * FROM [ChannelInfo] @WHERE AND Id NOT IN (SELECT TOP @PTOP Id FROM [ChannelInfo] @WHERE @ORDER)  @ORDER";

        /// <summary>
        /// 查询记录数
        /// </summary>
        const string QUERYCOUNT = "SELECT COUNT(1) FROM ChannelInfo";


        #endregion

        public override bool Delete(ChannelInfoPara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            command.CommandText = DELETE + where;

            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override bool Edit(ChannelInfoVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = EDIT;

             command.Parameters.Add(new SqlParameter() { ParameterName = "@Name", Value = ParameterHelper.ConvertValue(m.Name) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@Desc", Value = ParameterHelper.ConvertValue(m.Desc) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@LinkUrl", Value = ParameterHelper.ConvertValue(m.LinkUrl) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@ImgUrl", Value = ParameterHelper.ConvertValue(m.ImgUrl) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@IsShow", Value = ParameterHelper.ConvertValue(m.IsShow) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@IsHot", Value = ParameterHelper.ConvertValue(m.IsHot) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@IsTop", Value = ParameterHelper.ConvertValue(m.IsTop) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@ColorValue", Value = ParameterHelper.ConvertValue(m.ColorValue) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateDate", Value = ParameterHelper.ConvertValue(m.CreateDate) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@LastDate", Value = ParameterHelper.ConvertValue(m.LastDate) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateUserId", Value = ParameterHelper.ConvertValue(m.CreateUserId) });
               command.Parameters.Add(new SqlParameter() { ParameterName = "@Id", Value = ParameterHelper.ConvertValue(m.Id) });


            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override string GetConditionByModel(ChannelInfoVO m)
        {
            return "";
        }

        public override string GetConditionByPara(ChannelInfoPara mp)
        {
            StringBuilder sb = new StringBuilder();

           if (mp.Id.HasValue) { sb.AppendFormat(" AND [Id]='{0}' ",mp.Id);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.Name))){ sb.AppendFormat(" AND [Name]='{0}' ",mp.Name);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.Desc))){ sb.AppendFormat(" AND [Desc]='{0}' ",mp.Desc);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.LinkUrl))){ sb.AppendFormat(" AND [LinkUrl]='{0}' ",mp.LinkUrl);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.ImgUrl))){ sb.AppendFormat(" AND [ImgUrl]='{0}' ",mp.ImgUrl);}
           if (mp.IsShow.HasValue) { sb.AppendFormat(" AND [IsShow]='{0}' ",mp.IsShow);}
           if (mp.IsHot.HasValue) { sb.AppendFormat(" AND [IsHot]='{0}' ",mp.IsHot);}
           if (mp.IsTop.HasValue) { sb.AppendFormat(" AND [IsTop]='{0}' ",mp.IsTop);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.ColorValue))){ sb.AppendFormat(" AND [ColorValue]='{0}' ",mp.ColorValue);}
           if (mp.CreateDate.HasValue) { sb.AppendFormat(" AND [CreateDate]='{0}' ",mp.CreateDate);}
           if (mp.LastDate.HasValue) { sb.AppendFormat(" AND [LastDate]='{0}' ",mp.LastDate);}
           if (mp.CreateUserId.HasValue) { sb.AppendFormat(" AND [CreateUserId]='{0}' ",mp.CreateUserId);}


            sb.Insert(0, " WHERE 1=1 ");

            return sb.ToString();
        }

        public override List<ChannelInfoVO> GetModels(ref ChannelInfoPara mp)
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

            List<ChannelInfoVO> list = new List<ChannelInfoVO>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(new ChannelInfoVO(table.Rows[i]));
            }

            if (!mp.Recount.HasValue)
            {
                mp.Recount = GetRecords(mp);
            }

            return list;
        }

        public override List<ChannelInfoVO> GetModels(ChannelInfoPara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            
			string cmd = LOAD
                .Replace("@WHERE", where)
                .Replace("@ORDER", GetOrderByPara(mp));
			command.CommandText = cmd;

            var table = DbProxyFactory.Instance.Proxy.ExecuteTable(command);

            List<ChannelInfoVO> list = new List<ChannelInfoVO>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(new ChannelInfoVO(table.Rows[i]));
            }

            return list;
        }

        public override string GetOrderByModel(ChannelInfoVO m)
        {
            return "";
        }

        public override string GetOrderByPara(ChannelInfoPara mp)
        {
            if(!string.IsNullOrEmpty(mp.OrderBy))
            {
                return string.Format(" order by {0}", mp.OrderBy);
            }

            return "";
        }

        public override string GetOtherConditionByModel(ChannelInfoVO m)
        {
            return "";
        }

        public override string GetOtherConditionByPara(ChannelInfoPara mp)
        {
            return "";
        }

        public override int GetRecords(ChannelInfoPara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            command.CommandText = QUERYCOUNT + where;

            var result = DbProxyFactory.Instance.Proxy.ExecuteScalar(command);

            return int.Parse(result.ToString());
        }

        public override ChannelInfoVO GetSingle(ChannelInfoPara mp)
        {
            var list = GetModels(mp);

            if (list.Count == 1)
                return list[0];

            return null;
        }

        public override bool Insert(ChannelInfoVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = INSERT;
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Name", Value = ParameterHelper.ConvertValue(m.Name) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Desc", Value = ParameterHelper.ConvertValue(m.Desc) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@LinkUrl", Value = ParameterHelper.ConvertValue(m.LinkUrl) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@ImgUrl", Value = ParameterHelper.ConvertValue(m.ImgUrl) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@IsShow", Value = ParameterHelper.ConvertValue(m.IsShow) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@IsHot", Value = ParameterHelper.ConvertValue(m.IsHot) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@IsTop", Value = ParameterHelper.ConvertValue(m.IsTop) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@ColorValue", Value = ParameterHelper.ConvertValue(m.ColorValue) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateDate", Value = ParameterHelper.ConvertValue(m.CreateDate) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@LastDate", Value = ParameterHelper.ConvertValue(m.LastDate) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateUserId", Value = ParameterHelper.ConvertValue(m.CreateUserId) });


            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override int InsertIdentityId(ChannelInfoVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = INSERT + "; select @@Identity";

         command.Parameters.Add(new SqlParameter() { ParameterName = "@Name", Value = ParameterHelper.ConvertValue(m.Name) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Desc", Value = ParameterHelper.ConvertValue(m.Desc) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@LinkUrl", Value = ParameterHelper.ConvertValue(m.LinkUrl) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@ImgUrl", Value = ParameterHelper.ConvertValue(m.ImgUrl) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@IsShow", Value = ParameterHelper.ConvertValue(m.IsShow) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@IsHot", Value = ParameterHelper.ConvertValue(m.IsHot) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@IsTop", Value = ParameterHelper.ConvertValue(m.IsTop) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@ColorValue", Value = ParameterHelper.ConvertValue(m.ColorValue) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateDate", Value = ParameterHelper.ConvertValue(m.CreateDate) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@LastDate", Value = ParameterHelper.ConvertValue(m.LastDate) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateUserId", Value = ParameterHelper.ConvertValue(m.CreateUserId) });


            var result = DbProxyFactory.Instance.Proxy.ExecuteScalar(command);

            return int.Parse(result.ToString());
        }
    }
}
