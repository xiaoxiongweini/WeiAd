
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
    public partial class AdUserPageAccess : AdUserPageInterface
    {
        #region SQL

        /// <summary>
        /// 新增
        /// </summary>
        const string INSERT = "INSERT INTO AdUserPage ([Gid],[PageName],[AdPageId],[AdUserId],[IsState],[CreateDate],[CreateUserId],[FlowUserId],[FlowLastDate]) VALUES (@Gid,@PageName,@AdPageId,@AdUserId,@IsState,@CreateDate,@CreateUserId,@FlowUserId,@FlowLastDate)";

        /// <summary>
        /// 修改
        /// </summary>
        const string EDIT = "UPDATE AdUserPage SET [Gid]=@Gid,[PageName]=@PageName,[AdPageId]=@AdPageId,[AdUserId]=@AdUserId,[IsState]=@IsState,[CreateDate]=@CreateDate,[CreateUserId]=@CreateUserId,[FlowUserId]=@FlowUserId,[FlowLastDate]=@FlowLastDate WHERE [Id]=@Id";

        /// <summary>
        /// 删除
        /// </summary>
        const string DELETE = "DELETE FROM AdUserPage";

        /// <summary>
        /// 加载数据
        /// </summary>
        const string LOAD = "SELECT * FROM AdUserPage @WHERE @ORDER";

        /// <summary>
        /// 分页查询
        /// </summary>
        const string QUERYPAGE = "SELECT TOP @PAGESIZE * FROM [AdUserPage] @WHERE AND Id NOT IN (SELECT TOP @PTOP Id FROM [AdUserPage] @WHERE @ORDER)  @ORDER";

        /// <summary>
        /// 查询记录数
        /// </summary>
        const string QUERYCOUNT = "SELECT COUNT(1) FROM AdUserPage";


        #endregion

        public override bool Delete(AdUserPagePara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            command.CommandText = DELETE + where;

            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override bool Edit(AdUserPageVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = EDIT;

             command.Parameters.Add(new SqlParameter() { ParameterName = "@Gid", Value = ParameterHelper.ConvertValue(m.Gid) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@PageName", Value = ParameterHelper.ConvertValue(m.PageName) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@AdPageId", Value = ParameterHelper.ConvertValue(m.AdPageId) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@AdUserId", Value = ParameterHelper.ConvertValue(m.AdUserId) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@IsState", Value = ParameterHelper.ConvertValue(m.IsState) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateDate", Value = ParameterHelper.ConvertValue(m.CreateDate) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateUserId", Value = ParameterHelper.ConvertValue(m.CreateUserId) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@FlowUserId", Value = ParameterHelper.ConvertValue(m.FlowUserId) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@FlowLastDate", Value = ParameterHelper.ConvertValue(m.FlowLastDate) });
               command.Parameters.Add(new SqlParameter() { ParameterName = "@Id", Value = ParameterHelper.ConvertValue(m.Id) });


            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override string GetConditionByModel(AdUserPageVO m)
        {
            return "";
        }

        public override string GetConditionByPara(AdUserPagePara mp)
        {
            StringBuilder sb = new StringBuilder();

           if (mp.Id.HasValue) { sb.AppendFormat(" AND [Id]='{0}' ",mp.Id);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.Gid))){ sb.AppendFormat(" AND [Gid]='{0}' ",mp.Gid);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.PageName))){ sb.AppendFormat(" AND [PageName]='{0}' ",mp.PageName);}
           if (mp.AdPageId.HasValue) { sb.AppendFormat(" AND [AdPageId]='{0}' ",mp.AdPageId);}
           if (mp.AdUserId.HasValue) { sb.AppendFormat(" AND [AdUserId]='{0}' ",mp.AdUserId);}
           if (mp.IsState.HasValue) { sb.AppendFormat(" AND [IsState]='{0}' ",mp.IsState);}
           if (mp.CreateDate.HasValue) { sb.AppendFormat(" AND [CreateDate]='{0}' ",mp.CreateDate);}
           if (mp.CreateUserId.HasValue) { sb.AppendFormat(" AND [CreateUserId]='{0}' ",mp.CreateUserId);}
           if (mp.FlowUserId.HasValue) { sb.AppendFormat(" AND [FlowUserId]='{0}' ",mp.FlowUserId);}
           if (mp.FlowLastDate.HasValue) { sb.AppendFormat(" AND [FlowLastDate]='{0}' ",mp.FlowLastDate);}


            sb.Insert(0, " WHERE 1=1 ");

            return sb.ToString();
        }

        public override List<AdUserPageVO> GetModels(ref AdUserPagePara mp)
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

            List<AdUserPageVO> list = new List<AdUserPageVO>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(new AdUserPageVO(table.Rows[i]));
            }

            if (!mp.Recount.HasValue)
            {
                mp.Recount = GetRecords(mp);
            }

            return list;
        }

        public override List<AdUserPageVO> GetModels(AdUserPagePara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            
			string cmd = LOAD
                .Replace("@WHERE", where)
                .Replace("@ORDER", GetOrderByPara(mp));
			command.CommandText = cmd;

            var table = DbProxyFactory.Instance.Proxy.ExecuteTable(command);

            List<AdUserPageVO> list = new List<AdUserPageVO>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(new AdUserPageVO(table.Rows[i]));
            }

            return list;
        }

        public override string GetOrderByModel(AdUserPageVO m)
        {
            return "";
        }

        public override string GetOrderByPara(AdUserPagePara mp)
        {
            if(!string.IsNullOrEmpty(mp.OrderBy))
            {
                return string.Format(" order by {0}", mp.OrderBy);
            }

            return "";
        }

        public override string GetOtherConditionByModel(AdUserPageVO m)
        {
            return "";
        }

        public override string GetOtherConditionByPara(AdUserPagePara mp)
        {
            return "";
        }

        public override int GetRecords(AdUserPagePara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            command.CommandText = QUERYCOUNT + where;

            var result = DbProxyFactory.Instance.Proxy.ExecuteScalar(command);

            return int.Parse(result.ToString());
        }

        public override AdUserPageVO GetSingle(AdUserPagePara mp)
        {
            var list = GetModels(mp);

            if (list.Count == 1)
                return list[0];

            return null;
        }

        public override bool Insert(AdUserPageVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = INSERT;
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Gid", Value = ParameterHelper.ConvertValue(m.Gid) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@PageName", Value = ParameterHelper.ConvertValue(m.PageName) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@AdPageId", Value = ParameterHelper.ConvertValue(m.AdPageId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@AdUserId", Value = ParameterHelper.ConvertValue(m.AdUserId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@IsState", Value = ParameterHelper.ConvertValue(m.IsState) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateDate", Value = ParameterHelper.ConvertValue(m.CreateDate) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateUserId", Value = ParameterHelper.ConvertValue(m.CreateUserId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@FlowUserId", Value = ParameterHelper.ConvertValue(m.FlowUserId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@FlowLastDate", Value = ParameterHelper.ConvertValue(m.FlowLastDate) });


            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override int InsertIdentityId(AdUserPageVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = INSERT + "; select @@Identity";

         command.Parameters.Add(new SqlParameter() { ParameterName = "@Gid", Value = ParameterHelper.ConvertValue(m.Gid) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@PageName", Value = ParameterHelper.ConvertValue(m.PageName) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@AdPageId", Value = ParameterHelper.ConvertValue(m.AdPageId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@AdUserId", Value = ParameterHelper.ConvertValue(m.AdUserId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@IsState", Value = ParameterHelper.ConvertValue(m.IsState) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateDate", Value = ParameterHelper.ConvertValue(m.CreateDate) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateUserId", Value = ParameterHelper.ConvertValue(m.CreateUserId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@FlowUserId", Value = ParameterHelper.ConvertValue(m.FlowUserId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@FlowLastDate", Value = ParameterHelper.ConvertValue(m.FlowLastDate) });


            var result = DbProxyFactory.Instance.Proxy.ExecuteScalar(command);

            return int.Parse(result.ToString());
        }
    }
}
