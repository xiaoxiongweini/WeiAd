
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
    public partial class LogLoginAccess : LogLoginInterface
    {
        #region SQL

        /// <summary>
        /// 新增
        /// </summary>
        const string INSERT = "INSERT INTO LogLogin ([LoginName],[LoginState],[LoginDesc],[LoginDate],[ClientIp],[BrowseType],[LoginType]) VALUES (@LoginName,@LoginState,@LoginDesc,@LoginDate,@ClientIp,@BrowseType,@LoginType)";

        /// <summary>
        /// 修改
        /// </summary>
        const string EDIT = "UPDATE LogLogin SET [LoginName]=@LoginName,[LoginState]=@LoginState,[LoginDesc]=@LoginDesc,[LoginDate]=@LoginDate,[ClientIp]=@ClientIp,[BrowseType]=@BrowseType,[LoginType]=@LoginType WHERE [Id]=@Id";

        /// <summary>
        /// 删除
        /// </summary>
        const string DELETE = "DELETE FROM LogLogin";

        /// <summary>
        /// 加载数据
        /// </summary>
        const string LOAD = "SELECT * FROM LogLogin @WHERE @ORDER";

        /// <summary>
        /// 分页查询
        /// </summary>
        const string QUERYPAGE = "SELECT TOP @PAGESIZE * FROM [LogLogin] @WHERE AND Id NOT IN (SELECT TOP @PTOP Id FROM [LogLogin] @WHERE @ORDER)  @ORDER";

        /// <summary>
        /// 查询记录数
        /// </summary>
        const string QUERYCOUNT = "SELECT COUNT(1) FROM LogLogin";


        #endregion

        public override bool Delete(LogLoginPara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            command.CommandText = DELETE + where;

            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override bool Edit(LogLoginVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = EDIT;

             command.Parameters.Add(new SqlParameter() { ParameterName = "@LoginName", Value = ParameterHelper.ConvertValue(m.LoginName) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@LoginState", Value = ParameterHelper.ConvertValue(m.LoginState) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@LoginDesc", Value = ParameterHelper.ConvertValue(m.LoginDesc) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@LoginDate", Value = ParameterHelper.ConvertValue(m.LoginDate) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@ClientIp", Value = ParameterHelper.ConvertValue(m.ClientIp) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@BrowseType", Value = ParameterHelper.ConvertValue(m.BrowseType) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@LoginType", Value = ParameterHelper.ConvertValue(m.LoginType) });
               command.Parameters.Add(new SqlParameter() { ParameterName = "@Id", Value = ParameterHelper.ConvertValue(m.Id) });


            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override string GetConditionByModel(LogLoginVO m)
        {
            return "";
        }

        public override string GetConditionByPara(LogLoginPara mp)
        {
            StringBuilder sb = new StringBuilder();

           if (mp.Id.HasValue) { sb.AppendFormat(" AND [Id]='{0}' ",mp.Id);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.LoginName))){ sb.AppendFormat(" AND [LoginName]='{0}' ",mp.LoginName);}
           if (mp.LoginState.HasValue) { sb.AppendFormat(" AND [LoginState]='{0}' ",mp.LoginState);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.LoginDesc))){ sb.AppendFormat(" AND [LoginDesc]='{0}' ",mp.LoginDesc);}
           if (mp.LoginDate.HasValue) { sb.AppendFormat(" AND [LoginDate]='{0}' ",mp.LoginDate);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.ClientIp))){ sb.AppendFormat(" AND [ClientIp]='{0}' ",mp.ClientIp);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.BrowseType))){ sb.AppendFormat(" AND [BrowseType]='{0}' ",mp.BrowseType);}
           if (mp.LoginType.HasValue) { sb.AppendFormat(" AND [LoginType]='{0}' ",mp.LoginType);}


            sb.Insert(0, " WHERE 1=1 ");

            return sb.ToString();
        }

        public override List<LogLoginVO> GetModels(ref LogLoginPara mp)
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

            List<LogLoginVO> list = new List<LogLoginVO>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(new LogLoginVO(table.Rows[i]));
            }

            if (!mp.Recount.HasValue)
            {
                mp.Recount = GetRecords(mp);
            }

            return list;
        }

        public override List<LogLoginVO> GetModels(LogLoginPara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            
			string cmd = LOAD
                .Replace("@WHERE", where)
                .Replace("@ORDER", GetOrderByPara(mp));
			command.CommandText = cmd;

            var table = DbProxyFactory.Instance.Proxy.ExecuteTable(command);

            List<LogLoginVO> list = new List<LogLoginVO>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(new LogLoginVO(table.Rows[i]));
            }

            return list;
        }

        public override string GetOrderByModel(LogLoginVO m)
        {
            return "";
        }

        public override string GetOrderByPara(LogLoginPara mp)
        {
            if(!string.IsNullOrEmpty(mp.OrderBy))
            {
                return string.Format(" order by {0}", mp.OrderBy);
            }

            return "";
        }

        public override string GetOtherConditionByModel(LogLoginVO m)
        {
            return "";
        }

        public override string GetOtherConditionByPara(LogLoginPara mp)
        {
            return "";
        }

        public override int GetRecords(LogLoginPara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            command.CommandText = QUERYCOUNT + where;

            var result = DbProxyFactory.Instance.Proxy.ExecuteScalar(command);

            return int.Parse(result.ToString());
        }

        public override LogLoginVO GetSingle(LogLoginPara mp)
        {
            var list = GetModels(mp);

            if (list.Count == 1)
                return list[0];

            return null;
        }

        public override bool Insert(LogLoginVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = INSERT;
         command.Parameters.Add(new SqlParameter() { ParameterName = "@LoginName", Value = ParameterHelper.ConvertValue(m.LoginName) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@LoginState", Value = ParameterHelper.ConvertValue(m.LoginState) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@LoginDesc", Value = ParameterHelper.ConvertValue(m.LoginDesc) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@LoginDate", Value = ParameterHelper.ConvertValue(m.LoginDate) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@ClientIp", Value = ParameterHelper.ConvertValue(m.ClientIp) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@BrowseType", Value = ParameterHelper.ConvertValue(m.BrowseType) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@LoginType", Value = ParameterHelper.ConvertValue(m.LoginType) });


            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override int InsertIdentityId(LogLoginVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = INSERT + "; select @@Identity";

         command.Parameters.Add(new SqlParameter() { ParameterName = "@LoginName", Value = ParameterHelper.ConvertValue(m.LoginName) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@LoginState", Value = ParameterHelper.ConvertValue(m.LoginState) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@LoginDesc", Value = ParameterHelper.ConvertValue(m.LoginDesc) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@LoginDate", Value = ParameterHelper.ConvertValue(m.LoginDate) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@ClientIp", Value = ParameterHelper.ConvertValue(m.ClientIp) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@BrowseType", Value = ParameterHelper.ConvertValue(m.BrowseType) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@LoginType", Value = ParameterHelper.ConvertValue(m.LoginType) });


            var result = DbProxyFactory.Instance.Proxy.ExecuteScalar(command);

            return int.Parse(result.ToString());
        }
    }
}
