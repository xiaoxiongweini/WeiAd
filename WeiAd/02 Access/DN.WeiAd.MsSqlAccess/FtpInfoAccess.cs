
/*

skey edit by 2017-05-01 15:15:03

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
    public partial class FtpInfoAccess : FtpInfoInterface
    {
        #region SQL

        /// <summary>
        /// 新增
        /// </summary>
        const string INSERT = "INSERT INTO FtpInfo ([Name],[Desc],[Domains],[FtpServer],[FtpUserName],[FtpPassword],[IsSynchronization],[CreateDate],[CloseDate]) VALUES (@Name,@Desc,@Domains,@FtpServer,@FtpUserName,@FtpPassword,@IsSynchronization,@CreateDate,@CloseDate)";

        /// <summary>
        /// 修改
        /// </summary>
        const string EDIT = "UPDATE FtpInfo SET [Name]=@Name,[Desc]=@Desc,[Domains]=@Domains,[FtpServer]=@FtpServer,[FtpUserName]=@FtpUserName,[FtpPassword]=@FtpPassword,[IsSynchronization]=@IsSynchronization,[CreateDate]=@CreateDate,[CloseDate]=@CloseDate WHERE [Id]=@Id";

        /// <summary>
        /// 删除
        /// </summary>
        const string DELETE = "DELETE FROM FtpInfo";

        /// <summary>
        /// 加载数据
        /// </summary>
        const string LOAD = "SELECT * FROM FtpInfo @WHERE @ORDER";

        /// <summary>
        /// 分页查询
        /// </summary>
        const string QUERYPAGE = "SELECT TOP @PAGESIZE * FROM [FtpInfo] @WHERE AND Id NOT IN (SELECT TOP @PTOP Id FROM [FtpInfo] @WHERE @ORDER)  @ORDER";

        /// <summary>
        /// 查询记录数
        /// </summary>
        const string QUERYCOUNT = "SELECT COUNT(1) FROM FtpInfo";


        #endregion

        public override bool Delete(FtpInfoPara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            command.CommandText = DELETE + where;

            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override bool Edit(FtpInfoVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = EDIT;

             command.Parameters.Add(new SqlParameter() { ParameterName = "@Name", Value = ParameterHelper.ConvertValue(m.Name) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@Desc", Value = ParameterHelper.ConvertValue(m.Desc) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@Domains", Value = ParameterHelper.ConvertValue(m.Domains) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@FtpServer", Value = ParameterHelper.ConvertValue(m.FtpServer) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@FtpUserName", Value = ParameterHelper.ConvertValue(m.FtpUserName) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@FtpPassword", Value = ParameterHelper.ConvertValue(m.FtpPassword) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@IsSynchronization", Value = ParameterHelper.ConvertValue(m.IsSynchronization) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateDate", Value = ParameterHelper.ConvertValue(m.CreateDate) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@CloseDate", Value = ParameterHelper.ConvertValue(m.CloseDate) });
               command.Parameters.Add(new SqlParameter() { ParameterName = "@Id", Value = ParameterHelper.ConvertValue(m.Id) });


            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override string GetConditionByModel(FtpInfoVO m)
        {
            return "";
        }

        public override string GetConditionByPara(FtpInfoPara mp)
        {
            StringBuilder sb = new StringBuilder();

           if (mp.Id.HasValue) { sb.AppendFormat(" AND [Id]='{0}' ",mp.Id);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.Name))){ sb.AppendFormat(" AND [Name]='{0}' ",mp.Name);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.Desc))){ sb.AppendFormat(" AND [Desc]='{0}' ",mp.Desc);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.Domains))){ sb.AppendFormat(" AND [Domains]='{0}' ",mp.Domains);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.FtpServer))){ sb.AppendFormat(" AND [FtpServer]='{0}' ",mp.FtpServer);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.FtpUserName))){ sb.AppendFormat(" AND [FtpUserName]='{0}' ",mp.FtpUserName);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.FtpPassword))){ sb.AppendFormat(" AND [FtpPassword]='{0}' ",mp.FtpPassword);}
           if (mp.IsSynchronization.HasValue) { sb.AppendFormat(" AND [IsSynchronization]='{0}' ",mp.IsSynchronization);}
           if (mp.CreateDate.HasValue) { sb.AppendFormat(" AND [CreateDate]='{0}' ",mp.CreateDate);}
           if (mp.CloseDate.HasValue) { sb.AppendFormat(" AND [CloseDate]='{0}' ",mp.CloseDate);}


            sb.Insert(0, " WHERE 1=1 ");

            return sb.ToString();
        }

        public override List<FtpInfoVO> GetModels(ref FtpInfoPara mp)
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

            List<FtpInfoVO> list = new List<FtpInfoVO>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(new FtpInfoVO(table.Rows[i]));
            }

            if (!mp.Recount.HasValue)
            {
                mp.Recount = GetRecords(mp);
            }

            return list;
        }

        public override List<FtpInfoVO> GetModels(FtpInfoPara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            
			string cmd = LOAD
                .Replace("@WHERE", where)
                .Replace("@ORDER", GetOrderByPara(mp));
			command.CommandText = cmd;

            var table = DbProxyFactory.Instance.Proxy.ExecuteTable(command);

            List<FtpInfoVO> list = new List<FtpInfoVO>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(new FtpInfoVO(table.Rows[i]));
            }

            return list;
        }

        public override string GetOrderByModel(FtpInfoVO m)
        {
            return "";
        }

        public override string GetOrderByPara(FtpInfoPara mp)
        {
            if(!string.IsNullOrEmpty(mp.OrderBy))
            {
                return string.Format(" order by {0}", mp.OrderBy);
            }

            return "";
        }

        public override string GetOtherConditionByModel(FtpInfoVO m)
        {
            return "";
        }

        public override string GetOtherConditionByPara(FtpInfoPara mp)
        {
            return "";
        }

        public override int GetRecords(FtpInfoPara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            command.CommandText = QUERYCOUNT + where;

            var result = DbProxyFactory.Instance.Proxy.ExecuteScalar(command);

            return int.Parse(result.ToString());
        }

        public override FtpInfoVO GetSingle(FtpInfoPara mp)
        {
            var list = GetModels(mp);

            if (list.Count == 1)
                return list[0];

            return null;
        }

        public override bool Insert(FtpInfoVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = INSERT;
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Name", Value = ParameterHelper.ConvertValue(m.Name) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Desc", Value = ParameterHelper.ConvertValue(m.Desc) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Domains", Value = ParameterHelper.ConvertValue(m.Domains) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@FtpServer", Value = ParameterHelper.ConvertValue(m.FtpServer) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@FtpUserName", Value = ParameterHelper.ConvertValue(m.FtpUserName) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@FtpPassword", Value = ParameterHelper.ConvertValue(m.FtpPassword) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@IsSynchronization", Value = ParameterHelper.ConvertValue(m.IsSynchronization) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateDate", Value = ParameterHelper.ConvertValue(m.CreateDate) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CloseDate", Value = ParameterHelper.ConvertValue(m.CloseDate) });


            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override int InsertIdentityId(FtpInfoVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = INSERT + "; select @@Identity";

         command.Parameters.Add(new SqlParameter() { ParameterName = "@Name", Value = ParameterHelper.ConvertValue(m.Name) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Desc", Value = ParameterHelper.ConvertValue(m.Desc) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Domains", Value = ParameterHelper.ConvertValue(m.Domains) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@FtpServer", Value = ParameterHelper.ConvertValue(m.FtpServer) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@FtpUserName", Value = ParameterHelper.ConvertValue(m.FtpUserName) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@FtpPassword", Value = ParameterHelper.ConvertValue(m.FtpPassword) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@IsSynchronization", Value = ParameterHelper.ConvertValue(m.IsSynchronization) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateDate", Value = ParameterHelper.ConvertValue(m.CreateDate) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CloseDate", Value = ParameterHelper.ConvertValue(m.CloseDate) });


            var result = DbProxyFactory.Instance.Proxy.ExecuteScalar(command);

            return int.Parse(result.ToString());
        }
    }
}
