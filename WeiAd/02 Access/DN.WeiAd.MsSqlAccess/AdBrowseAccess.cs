
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
    public partial class AdBrowseAccess : AdBrowseInterface
    {
        #region SQL

        /// <summary>
        /// 新增
        /// </summary>
        const string INSERT = "INSERT INTO AdBrowse ([Url],[ClientIp],[BrowseType],[CreateDate],[AdId],[AdUserId],[FlowUserId],[AdUrl],[Money],[IsMoney],[Time],[ClientId],[IsMobile],[ReferrerUrl],[BrowseName],[BrowseVersion],[OsName]) VALUES (@Url,@ClientIp,@BrowseType,@CreateDate,@AdId,@AdUserId,@FlowUserId,@AdUrl,@Money,@IsMoney,@Time,@ClientId,@IsMobile,@ReferrerUrl,@BrowseName,@BrowseVersion,@OsName)";

        /// <summary>
        /// 修改
        /// </summary>
        const string EDIT = "UPDATE AdBrowse SET [Url]=@Url,[ClientIp]=@ClientIp,[BrowseType]=@BrowseType,[CreateDate]=@CreateDate,[AdId]=@AdId,[AdUserId]=@AdUserId,[FlowUserId]=@FlowUserId,[AdUrl]=@AdUrl,[Money]=@Money,[IsMoney]=@IsMoney,[Time]=@Time,[ClientId]=@ClientId,[IsMobile]=@IsMobile,[ReferrerUrl]=@ReferrerUrl,[BrowseName]=@BrowseName,[BrowseVersion]=@BrowseVersion,[OsName]=@OsName WHERE [Id]=@Id";

        /// <summary>
        /// 删除
        /// </summary>
        const string DELETE = "DELETE FROM AdBrowse";

        /// <summary>
        /// 加载数据
        /// </summary>
        const string LOAD = "SELECT * FROM AdBrowse @WHERE @ORDER";

        /// <summary>
        /// 分页查询
        /// </summary>
        const string QUERYPAGE = "SELECT TOP @PAGESIZE * FROM [AdBrowse] @WHERE AND Id NOT IN (SELECT TOP @PTOP Id FROM [AdBrowse] @WHERE @ORDER)  @ORDER";

        /// <summary>
        /// 查询记录数
        /// </summary>
        const string QUERYCOUNT = "SELECT COUNT(1) FROM AdBrowse";


        #endregion

        public override bool Delete(AdBrowsePara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            command.CommandText = DELETE + where;

            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override bool Edit(AdBrowseVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = EDIT;

             command.Parameters.Add(new SqlParameter() { ParameterName = "@Url", Value = ParameterHelper.ConvertValue(m.Url) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@ClientIp", Value = ParameterHelper.ConvertValue(m.ClientIp) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@BrowseType", Value = ParameterHelper.ConvertValue(m.BrowseType) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateDate", Value = ParameterHelper.ConvertValue(m.CreateDate) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@AdId", Value = ParameterHelper.ConvertValue(m.AdId) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@AdUserId", Value = ParameterHelper.ConvertValue(m.AdUserId) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@FlowUserId", Value = ParameterHelper.ConvertValue(m.FlowUserId) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@AdUrl", Value = ParameterHelper.ConvertValue(m.AdUrl) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@Money", Value = ParameterHelper.ConvertValue(m.Money) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@IsMoney", Value = ParameterHelper.ConvertValue(m.IsMoney) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@Time", Value = ParameterHelper.ConvertValue(m.Time) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@ClientId", Value = ParameterHelper.ConvertValue(m.ClientId) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@IsMobile", Value = ParameterHelper.ConvertValue(m.IsMobile) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@ReferrerUrl", Value = ParameterHelper.ConvertValue(m.ReferrerUrl) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@BrowseName", Value = ParameterHelper.ConvertValue(m.BrowseName) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@BrowseVersion", Value = ParameterHelper.ConvertValue(m.BrowseVersion) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@OsName", Value = ParameterHelper.ConvertValue(m.OsName) });
               command.Parameters.Add(new SqlParameter() { ParameterName = "@Id", Value = ParameterHelper.ConvertValue(m.Id) });


            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override string GetConditionByModel(AdBrowseVO m)
        {
            return "";
        }

        public override string GetConditionByPara(AdBrowsePara mp)
        {
            StringBuilder sb = new StringBuilder();

           if (mp.Id.HasValue) { sb.AppendFormat(" AND [Id]='{0}' ",mp.Id);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.Url))){ sb.AppendFormat(" AND [Url]='{0}' ",mp.Url);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.ClientIp))){ sb.AppendFormat(" AND [ClientIp]='{0}' ",mp.ClientIp);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.BrowseType))){ sb.AppendFormat(" AND [BrowseType]='{0}' ",mp.BrowseType);}
           if (mp.CreateDate.HasValue) { sb.AppendFormat(" AND [CreateDate]='{0}' ",mp.CreateDate);}
           if (mp.AdId.HasValue) { sb.AppendFormat(" AND [AdId]='{0}' ",mp.AdId);}
           if (mp.AdUserId.HasValue) { sb.AppendFormat(" AND [AdUserId]='{0}' ",mp.AdUserId);}
           if (mp.FlowUserId.HasValue) { sb.AppendFormat(" AND [FlowUserId]='{0}' ",mp.FlowUserId);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.AdUrl))){ sb.AppendFormat(" AND [AdUrl]='{0}' ",mp.AdUrl);}
           if (mp.Money.HasValue) { sb.AppendFormat(" AND [Money]='{0}' ",mp.Money);}
           if (mp.IsMoney.HasValue) { sb.AppendFormat(" AND [IsMoney]='{0}' ",mp.IsMoney);}
           if (mp.Time.HasValue) { sb.AppendFormat(" AND [Time]='{0}' ",mp.Time);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.ClientId))){ sb.AppendFormat(" AND [ClientId]='{0}' ",mp.ClientId);}
           if (mp.IsMobile.HasValue) { sb.AppendFormat(" AND [IsMobile]='{0}' ",mp.IsMobile);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.ReferrerUrl))){ sb.AppendFormat(" AND [ReferrerUrl]='{0}' ",mp.ReferrerUrl);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.BrowseName))){ sb.AppendFormat(" AND [BrowseName]='{0}' ",mp.BrowseName);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.BrowseVersion))){ sb.AppendFormat(" AND [BrowseVersion]='{0}' ",mp.BrowseVersion);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.OsName))){ sb.AppendFormat(" AND [OsName]='{0}' ",mp.OsName);}


            sb.Insert(0, " WHERE 1=1 ");

            return sb.ToString();
        }

        public override List<AdBrowseVO> GetModels(ref AdBrowsePara mp)
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

            List<AdBrowseVO> list = new List<AdBrowseVO>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(new AdBrowseVO(table.Rows[i]));
            }

            if (!mp.Recount.HasValue)
            {
                mp.Recount = GetRecords(mp);
            }

            return list;
        }

        public override List<AdBrowseVO> GetModels(AdBrowsePara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            
			string cmd = LOAD
                .Replace("@WHERE", where)
                .Replace("@ORDER", GetOrderByPara(mp));
			command.CommandText = cmd;

            var table = DbProxyFactory.Instance.Proxy.ExecuteTable(command);

            List<AdBrowseVO> list = new List<AdBrowseVO>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(new AdBrowseVO(table.Rows[i]));
            }

            return list;
        }

        public override string GetOrderByModel(AdBrowseVO m)
        {
            return "";
        }

        public override string GetOrderByPara(AdBrowsePara mp)
        {
            if(!string.IsNullOrEmpty(mp.OrderBy))
            {
                return string.Format(" order by {0}", mp.OrderBy);
            }

            return "";
        }

        public override string GetOtherConditionByModel(AdBrowseVO m)
        {
            return "";
        }

        public override string GetOtherConditionByPara(AdBrowsePara mp)
        {
            return "";
        }

        public override int GetRecords(AdBrowsePara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            command.CommandText = QUERYCOUNT + where;

            var result = DbProxyFactory.Instance.Proxy.ExecuteScalar(command);

            return int.Parse(result.ToString());
        }

        public override AdBrowseVO GetSingle(AdBrowsePara mp)
        {
            var list = GetModels(mp);

            if (list.Count == 1)
                return list[0];

            return null;
        }

        public override bool Insert(AdBrowseVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = INSERT;
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Url", Value = ParameterHelper.ConvertValue(m.Url) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@ClientIp", Value = ParameterHelper.ConvertValue(m.ClientIp) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@BrowseType", Value = ParameterHelper.ConvertValue(m.BrowseType) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateDate", Value = ParameterHelper.ConvertValue(m.CreateDate) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@AdId", Value = ParameterHelper.ConvertValue(m.AdId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@AdUserId", Value = ParameterHelper.ConvertValue(m.AdUserId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@FlowUserId", Value = ParameterHelper.ConvertValue(m.FlowUserId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@AdUrl", Value = ParameterHelper.ConvertValue(m.AdUrl) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Money", Value = ParameterHelper.ConvertValue(m.Money) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@IsMoney", Value = ParameterHelper.ConvertValue(m.IsMoney) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Time", Value = ParameterHelper.ConvertValue(m.Time) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@ClientId", Value = ParameterHelper.ConvertValue(m.ClientId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@IsMobile", Value = ParameterHelper.ConvertValue(m.IsMobile) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@ReferrerUrl", Value = ParameterHelper.ConvertValue(m.ReferrerUrl) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@BrowseName", Value = ParameterHelper.ConvertValue(m.BrowseName) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@BrowseVersion", Value = ParameterHelper.ConvertValue(m.BrowseVersion) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@OsName", Value = ParameterHelper.ConvertValue(m.OsName) });


            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override int InsertIdentityId(AdBrowseVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = INSERT + "; select @@Identity";

         command.Parameters.Add(new SqlParameter() { ParameterName = "@Url", Value = ParameterHelper.ConvertValue(m.Url) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@ClientIp", Value = ParameterHelper.ConvertValue(m.ClientIp) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@BrowseType", Value = ParameterHelper.ConvertValue(m.BrowseType) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateDate", Value = ParameterHelper.ConvertValue(m.CreateDate) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@AdId", Value = ParameterHelper.ConvertValue(m.AdId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@AdUserId", Value = ParameterHelper.ConvertValue(m.AdUserId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@FlowUserId", Value = ParameterHelper.ConvertValue(m.FlowUserId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@AdUrl", Value = ParameterHelper.ConvertValue(m.AdUrl) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Money", Value = ParameterHelper.ConvertValue(m.Money) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@IsMoney", Value = ParameterHelper.ConvertValue(m.IsMoney) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Time", Value = ParameterHelper.ConvertValue(m.Time) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@ClientId", Value = ParameterHelper.ConvertValue(m.ClientId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@IsMobile", Value = ParameterHelper.ConvertValue(m.IsMobile) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@ReferrerUrl", Value = ParameterHelper.ConvertValue(m.ReferrerUrl) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@BrowseName", Value = ParameterHelper.ConvertValue(m.BrowseName) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@BrowseVersion", Value = ParameterHelper.ConvertValue(m.BrowseVersion) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@OsName", Value = ParameterHelper.ConvertValue(m.OsName) });


            var result = DbProxyFactory.Instance.Proxy.ExecuteScalar(command);

            return int.Parse(result.ToString());
        }
    }
}
