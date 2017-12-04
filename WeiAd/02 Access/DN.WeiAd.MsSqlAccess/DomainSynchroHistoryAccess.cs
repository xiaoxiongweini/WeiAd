
/*

skey edit by 2017/7/27 18:07:24

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
    public partial class DomainSynchroHistoryAccess : DomainSynchroHistoryInterface
    {
        #region SQL

        /// <summary>
        /// 新增
        /// </summary>
        const string INSERT = "INSERT INTO DomainSynchroHistory ([ServerId],[Name],[MainDomain],[Domains],[DomainPath],[OperType],[IsSynchro],[SynchroDate],[ClientIp],[CreateDate],[CreateUserId],[UserId],[IsDelete]) VALUES (@ServerId,@Name,@MainDomain,@Domains,@DomainPath,@OperType,@IsSynchro,@SynchroDate,@ClientIp,@CreateDate,@CreateUserId,@UserId,@IsDelete)";

        /// <summary>
        /// 修改
        /// </summary>
        const string EDIT = "UPDATE DomainSynchroHistory SET [ServerId]=@ServerId,[Name]=@Name,[MainDomain]=@MainDomain,[Domains]=@Domains,[DomainPath]=@DomainPath,[OperType]=@OperType,[IsSynchro]=@IsSynchro,[SynchroDate]=@SynchroDate,[ClientIp]=@ClientIp,[CreateDate]=@CreateDate,[CreateUserId]=@CreateUserId,[UserId]=@UserId,[IsDelete]=@IsDelete WHERE [Id]=@Id";

        /// <summary>
        /// 删除
        /// </summary>
        const string DELETE = "DELETE FROM DomainSynchroHistory";

        /// <summary>
        /// 加载数据
        /// </summary>
        const string LOAD = "SELECT * FROM DomainSynchroHistory @WHERE @ORDER";

        /// <summary>
        /// 分页查询
        /// </summary>
        const string QUERYPAGE = "SELECT TOP @PAGESIZE * FROM [DomainSynchroHistory] @WHERE AND Id NOT IN (SELECT TOP @PTOP Id FROM [DomainSynchroHistory] @WHERE @ORDER)  @ORDER";

        /// <summary>
        /// 查询记录数
        /// </summary>
        const string QUERYCOUNT = "SELECT COUNT(1) FROM DomainSynchroHistory";


        #endregion

        public override bool Delete(DomainSynchroHistoryPara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            command.CommandText = DELETE + where;

            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override bool Edit(DomainSynchroHistoryVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = EDIT;

             command.Parameters.Add(new SqlParameter() { ParameterName = "@ServerId", Value = ParameterHelper.ConvertValue(m.ServerId) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@Name", Value = ParameterHelper.ConvertValue(m.Name) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@MainDomain", Value = ParameterHelper.ConvertValue(m.MainDomain) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@Domains", Value = ParameterHelper.ConvertValue(m.Domains) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@DomainPath", Value = ParameterHelper.ConvertValue(m.DomainPath) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@OperType", Value = ParameterHelper.ConvertValue(m.OperType) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@IsSynchro", Value = ParameterHelper.ConvertValue(m.IsSynchro) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@SynchroDate", Value = ParameterHelper.ConvertValue(m.SynchroDate) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@ClientIp", Value = ParameterHelper.ConvertValue(m.ClientIp) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateDate", Value = ParameterHelper.ConvertValue(m.CreateDate) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateUserId", Value = ParameterHelper.ConvertValue(m.CreateUserId) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@UserId", Value = ParameterHelper.ConvertValue(m.UserId) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@IsDelete", Value = ParameterHelper.ConvertValue(m.IsDelete) });
               command.Parameters.Add(new SqlParameter() { ParameterName = "@Id", Value = ParameterHelper.ConvertValue(m.Id) });


            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override string GetConditionByModel(DomainSynchroHistoryVO m)
        {
            return "";
        }

        public override string GetConditionByPara(DomainSynchroHistoryPara mp)
        {
            StringBuilder sb = new StringBuilder();

           if (mp.Id.HasValue) { sb.AppendFormat(" AND [Id]='{0}' ",mp.Id);}
           if (mp.ServerId.HasValue) { sb.AppendFormat(" AND [ServerId]='{0}' ",mp.ServerId);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.Name))){ sb.AppendFormat(" AND [Name]='{0}' ",mp.Name);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.MainDomain))){ sb.AppendFormat(" AND [MainDomain]='{0}' ",mp.MainDomain);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.Domains))){ sb.AppendFormat(" AND [Domains]='{0}' ",mp.Domains);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.DomainPath))){ sb.AppendFormat(" AND [DomainPath]='{0}' ",mp.DomainPath);}
           if (mp.OperType.HasValue) { sb.AppendFormat(" AND [OperType]='{0}' ",mp.OperType);}
           if (mp.IsSynchro.HasValue) { sb.AppendFormat(" AND [IsSynchro]='{0}' ",mp.IsSynchro);}
           if (mp.SynchroDate.HasValue) { sb.AppendFormat(" AND [SynchroDate]='{0}' ",mp.SynchroDate);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.ClientIp))){ sb.AppendFormat(" AND [ClientIp]='{0}' ",mp.ClientIp);}
           if (mp.CreateDate.HasValue) { sb.AppendFormat(" AND [CreateDate]='{0}' ",mp.CreateDate);}
           if (mp.CreateUserId.HasValue) { sb.AppendFormat(" AND [CreateUserId]='{0}' ",mp.CreateUserId);}
           if (mp.UserId.HasValue) { sb.AppendFormat(" AND [UserId]='{0}' ",mp.UserId);}
           if (mp.IsDelete.HasValue) { sb.AppendFormat(" AND [IsDelete]='{0}' ",mp.IsDelete);}


            sb.Insert(0, " WHERE 1=1 ");

            return sb.ToString();
        }

        public override List<DomainSynchroHistoryVO> GetModels(ref DomainSynchroHistoryPara mp)
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

            List<DomainSynchroHistoryVO> list = new List<DomainSynchroHistoryVO>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(new DomainSynchroHistoryVO(table.Rows[i]));
            }

            if (!mp.Recount.HasValue)
            {
                mp.Recount = GetRecords(mp);
            }

            return list;
        }

        public override List<DomainSynchroHistoryVO> GetModels(DomainSynchroHistoryPara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            
			string cmd = LOAD
                .Replace("@WHERE", where)
                .Replace("@ORDER", GetOrderByPara(mp));
			command.CommandText = cmd;

            var table = DbProxyFactory.Instance.Proxy.ExecuteTable(command);

            List<DomainSynchroHistoryVO> list = new List<DomainSynchroHistoryVO>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(new DomainSynchroHistoryVO(table.Rows[i]));
            }

            return list;
        }

        public override string GetOrderByModel(DomainSynchroHistoryVO m)
        {
            return "";
        }

        public override string GetOrderByPara(DomainSynchroHistoryPara mp)
        {
            if(!string.IsNullOrEmpty(mp.OrderBy))
            {
                return string.Format(" order by {0}", mp.OrderBy);
            }

            return "";
        }

        public override string GetOtherConditionByModel(DomainSynchroHistoryVO m)
        {
            return "";
        }

        public override string GetOtherConditionByPara(DomainSynchroHistoryPara mp)
        {
            return "";
        }

        public override int GetRecords(DomainSynchroHistoryPara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            command.CommandText = QUERYCOUNT + where;

            var result = DbProxyFactory.Instance.Proxy.ExecuteScalar(command);

            return int.Parse(result.ToString());
        }

        public override DomainSynchroHistoryVO GetSingle(DomainSynchroHistoryPara mp)
        {
            var list = GetModels(mp);

            if (list.Count == 1)
                return list[0];

            return null;
        }

        public override bool Insert(DomainSynchroHistoryVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = INSERT;
         command.Parameters.Add(new SqlParameter() { ParameterName = "@ServerId", Value = ParameterHelper.ConvertValue(m.ServerId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Name", Value = ParameterHelper.ConvertValue(m.Name) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@MainDomain", Value = ParameterHelper.ConvertValue(m.MainDomain) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Domains", Value = ParameterHelper.ConvertValue(m.Domains) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@DomainPath", Value = ParameterHelper.ConvertValue(m.DomainPath) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@OperType", Value = ParameterHelper.ConvertValue(m.OperType) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@IsSynchro", Value = ParameterHelper.ConvertValue(m.IsSynchro) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@SynchroDate", Value = ParameterHelper.ConvertValue(m.SynchroDate) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@ClientIp", Value = ParameterHelper.ConvertValue(m.ClientIp) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateDate", Value = ParameterHelper.ConvertValue(m.CreateDate) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateUserId", Value = ParameterHelper.ConvertValue(m.CreateUserId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@UserId", Value = ParameterHelper.ConvertValue(m.UserId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@IsDelete", Value = ParameterHelper.ConvertValue(m.IsDelete) });


            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override int InsertIdentityId(DomainSynchroHistoryVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = INSERT + "; select @@Identity";

         command.Parameters.Add(new SqlParameter() { ParameterName = "@ServerId", Value = ParameterHelper.ConvertValue(m.ServerId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Name", Value = ParameterHelper.ConvertValue(m.Name) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@MainDomain", Value = ParameterHelper.ConvertValue(m.MainDomain) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Domains", Value = ParameterHelper.ConvertValue(m.Domains) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@DomainPath", Value = ParameterHelper.ConvertValue(m.DomainPath) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@OperType", Value = ParameterHelper.ConvertValue(m.OperType) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@IsSynchro", Value = ParameterHelper.ConvertValue(m.IsSynchro) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@SynchroDate", Value = ParameterHelper.ConvertValue(m.SynchroDate) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@ClientIp", Value = ParameterHelper.ConvertValue(m.ClientIp) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateDate", Value = ParameterHelper.ConvertValue(m.CreateDate) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateUserId", Value = ParameterHelper.ConvertValue(m.CreateUserId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@UserId", Value = ParameterHelper.ConvertValue(m.UserId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@IsDelete", Value = ParameterHelper.ConvertValue(m.IsDelete) });


            var result = DbProxyFactory.Instance.Proxy.ExecuteScalar(command);

            return int.Parse(result.ToString());
        }
    }
}
