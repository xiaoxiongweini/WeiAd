
/*

skey edit by 2017/7/19 15:50:43

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
    public partial class DomainInfoAccess : DomainInfoInterface
    {
        #region SQL

        /// <summary>
        /// 新增
        /// </summary>
        const string INSERT = "INSERT INTO DomainInfo ([Name],[Domain],[PageName],[IsState],[IsAuth],[CityName],[CreateDate],[CreateUserId],[IsColse],[ColseDate],[CloseUserId],[AdUserId],[IsResolution],[ResolutionDate],[SerName],[ResolutionType]) VALUES (@Name,@Domain,@PageName,@IsState,@IsAuth,@CityName,@CreateDate,@CreateUserId,@IsColse,@ColseDate,@CloseUserId,@AdUserId,@IsResolution,@ResolutionDate,@SerName,@ResolutionType)";

        /// <summary>
        /// 修改
        /// </summary>
        const string EDIT = "UPDATE DomainInfo SET [Name]=@Name,[Domain]=@Domain,[PageName]=@PageName,[IsState]=@IsState,[IsAuth]=@IsAuth,[CityName]=@CityName,[CreateDate]=@CreateDate,[CreateUserId]=@CreateUserId,[IsColse]=@IsColse,[ColseDate]=@ColseDate,[CloseUserId]=@CloseUserId,[AdUserId]=@AdUserId,[IsResolution]=@IsResolution,[ResolutionDate]=@ResolutionDate,[SerName]=@SerName,[ResolutionType]=@ResolutionType WHERE [Id]=@Id";

        /// <summary>
        /// 删除
        /// </summary>
        const string DELETE = "DELETE FROM DomainInfo";

        /// <summary>
        /// 加载数据
        /// </summary>
        const string LOAD = "SELECT * FROM DomainInfo @WHERE @ORDER";

        /// <summary>
        /// 分页查询
        /// </summary>
        const string QUERYPAGE = "SELECT TOP @PAGESIZE * FROM [DomainInfo] @WHERE AND Id NOT IN (SELECT TOP @PTOP Id FROM [DomainInfo] @WHERE @ORDER)  @ORDER";

        /// <summary>
        /// 查询记录数
        /// </summary>
        const string QUERYCOUNT = "SELECT COUNT(1) FROM DomainInfo";


        #endregion

        public override bool Delete(DomainInfoPara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            command.CommandText = DELETE + where;

            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override bool Edit(DomainInfoVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = EDIT;

             command.Parameters.Add(new SqlParameter() { ParameterName = "@Name", Value = ParameterHelper.ConvertValue(m.Name) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@Domain", Value = ParameterHelper.ConvertValue(m.Domain) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@PageName", Value = ParameterHelper.ConvertValue(m.PageName) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@IsState", Value = ParameterHelper.ConvertValue(m.IsState) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@IsAuth", Value = ParameterHelper.ConvertValue(m.IsAuth) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@CityName", Value = ParameterHelper.ConvertValue(m.CityName) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateDate", Value = ParameterHelper.ConvertValue(m.CreateDate) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateUserId", Value = ParameterHelper.ConvertValue(m.CreateUserId) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@IsColse", Value = ParameterHelper.ConvertValue(m.IsColse) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@ColseDate", Value = ParameterHelper.ConvertValue(m.ColseDate) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@CloseUserId", Value = ParameterHelper.ConvertValue(m.CloseUserId) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@AdUserId", Value = ParameterHelper.ConvertValue(m.AdUserId) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@IsResolution", Value = ParameterHelper.ConvertValue(m.IsResolution) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@ResolutionDate", Value = ParameterHelper.ConvertValue(m.ResolutionDate) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@SerName", Value = ParameterHelper.ConvertValue(m.SerName) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@ResolutionType", Value = ParameterHelper.ConvertValue(m.ResolutionType) });
               command.Parameters.Add(new SqlParameter() { ParameterName = "@Id", Value = ParameterHelper.ConvertValue(m.Id) });


            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override string GetConditionByModel(DomainInfoVO m)
        {
            return "";
        }

        public override string GetConditionByPara(DomainInfoPara mp)
        {
            StringBuilder sb = new StringBuilder();

           if (mp.Id.HasValue) { sb.AppendFormat(" AND [Id]='{0}' ",mp.Id);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.Name))){ sb.AppendFormat(" AND [Name]='{0}' ",mp.Name);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.Domain))){ sb.AppendFormat(" AND [Domain]='{0}' ",mp.Domain);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.PageName))){ sb.AppendFormat(" AND [PageName]='{0}' ",mp.PageName);}
           if (mp.IsState.HasValue) { sb.AppendFormat(" AND [IsState]='{0}' ",mp.IsState);}
           if (mp.IsAuth.HasValue) { sb.AppendFormat(" AND [IsAuth]='{0}' ",mp.IsAuth);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.CityName))){ sb.AppendFormat(" AND [CityName]='{0}' ",mp.CityName);}
           if (mp.CreateDate.HasValue) { sb.AppendFormat(" AND [CreateDate]='{0}' ",mp.CreateDate);}
           if (mp.CreateUserId.HasValue) { sb.AppendFormat(" AND [CreateUserId]='{0}' ",mp.CreateUserId);}
           if (mp.IsColse.HasValue) { sb.AppendFormat(" AND [IsColse]='{0}' ",mp.IsColse);}
           if (mp.ColseDate.HasValue) { sb.AppendFormat(" AND [ColseDate]='{0}' ",mp.ColseDate);}
           if (mp.CloseUserId.HasValue) { sb.AppendFormat(" AND [CloseUserId]='{0}' ",mp.CloseUserId);}
           if (mp.AdUserId.HasValue) { sb.AppendFormat(" AND [AdUserId]='{0}' ",mp.AdUserId);}
           if (mp.IsResolution.HasValue) { sb.AppendFormat(" AND [IsResolution]='{0}' ",mp.IsResolution);}
           if (mp.ResolutionDate.HasValue) { sb.AppendFormat(" AND [ResolutionDate]='{0}' ",mp.ResolutionDate);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.SerName))){ sb.AppendFormat(" AND [SerName]='{0}' ",mp.SerName);}
           if (mp.ResolutionType.HasValue) { sb.AppendFormat(" AND [ResolutionType]='{0}' ",mp.ResolutionType);}


            sb.Insert(0, " WHERE 1=1 ");

            return sb.ToString();
        }

        public override List<DomainInfoVO> GetModels(ref DomainInfoPara mp)
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

            List<DomainInfoVO> list = new List<DomainInfoVO>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(new DomainInfoVO(table.Rows[i]));
            }

            if (!mp.Recount.HasValue)
            {
                mp.Recount = GetRecords(mp);
            }

            return list;
        }

        public override List<DomainInfoVO> GetModels(DomainInfoPara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            
			string cmd = LOAD
                .Replace("@WHERE", where)
                .Replace("@ORDER", GetOrderByPara(mp));
			command.CommandText = cmd;

            var table = DbProxyFactory.Instance.Proxy.ExecuteTable(command);

            List<DomainInfoVO> list = new List<DomainInfoVO>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(new DomainInfoVO(table.Rows[i]));
            }

            return list;
        }

        public override string GetOrderByModel(DomainInfoVO m)
        {
            return "";
        }

        public override string GetOrderByPara(DomainInfoPara mp)
        {
            if(!string.IsNullOrEmpty(mp.OrderBy))
            {
                return string.Format(" order by {0}", mp.OrderBy);
            }

            return "";
        }

        public override string GetOtherConditionByModel(DomainInfoVO m)
        {
            return "";
        }

        public override string GetOtherConditionByPara(DomainInfoPara mp)
        {
            return "";
        }

        public override int GetRecords(DomainInfoPara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            command.CommandText = QUERYCOUNT + where;

            var result = DbProxyFactory.Instance.Proxy.ExecuteScalar(command);

            return int.Parse(result.ToString());
        }

        public override DomainInfoVO GetSingle(DomainInfoPara mp)
        {
            var list = GetModels(mp);

            if (list.Count == 1)
                return list[0];

            return null;
        }

        public override bool Insert(DomainInfoVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = INSERT;
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Name", Value = ParameterHelper.ConvertValue(m.Name) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Domain", Value = ParameterHelper.ConvertValue(m.Domain) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@PageName", Value = ParameterHelper.ConvertValue(m.PageName) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@IsState", Value = ParameterHelper.ConvertValue(m.IsState) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@IsAuth", Value = ParameterHelper.ConvertValue(m.IsAuth) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CityName", Value = ParameterHelper.ConvertValue(m.CityName) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateDate", Value = ParameterHelper.ConvertValue(m.CreateDate) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateUserId", Value = ParameterHelper.ConvertValue(m.CreateUserId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@IsColse", Value = ParameterHelper.ConvertValue(m.IsColse) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@ColseDate", Value = ParameterHelper.ConvertValue(m.ColseDate) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CloseUserId", Value = ParameterHelper.ConvertValue(m.CloseUserId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@AdUserId", Value = ParameterHelper.ConvertValue(m.AdUserId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@IsResolution", Value = ParameterHelper.ConvertValue(m.IsResolution) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@ResolutionDate", Value = ParameterHelper.ConvertValue(m.ResolutionDate) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@SerName", Value = ParameterHelper.ConvertValue(m.SerName) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@ResolutionType", Value = ParameterHelper.ConvertValue(m.ResolutionType) });


            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override int InsertIdentityId(DomainInfoVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = INSERT + "; select @@Identity";

         command.Parameters.Add(new SqlParameter() { ParameterName = "@Name", Value = ParameterHelper.ConvertValue(m.Name) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Domain", Value = ParameterHelper.ConvertValue(m.Domain) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@PageName", Value = ParameterHelper.ConvertValue(m.PageName) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@IsState", Value = ParameterHelper.ConvertValue(m.IsState) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@IsAuth", Value = ParameterHelper.ConvertValue(m.IsAuth) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CityName", Value = ParameterHelper.ConvertValue(m.CityName) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateDate", Value = ParameterHelper.ConvertValue(m.CreateDate) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateUserId", Value = ParameterHelper.ConvertValue(m.CreateUserId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@IsColse", Value = ParameterHelper.ConvertValue(m.IsColse) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@ColseDate", Value = ParameterHelper.ConvertValue(m.ColseDate) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CloseUserId", Value = ParameterHelper.ConvertValue(m.CloseUserId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@AdUserId", Value = ParameterHelper.ConvertValue(m.AdUserId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@IsResolution", Value = ParameterHelper.ConvertValue(m.IsResolution) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@ResolutionDate", Value = ParameterHelper.ConvertValue(m.ResolutionDate) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@SerName", Value = ParameterHelper.ConvertValue(m.SerName) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@ResolutionType", Value = ParameterHelper.ConvertValue(m.ResolutionType) });


            var result = DbProxyFactory.Instance.Proxy.ExecuteScalar(command);

            return int.Parse(result.ToString());
        }
    }
}
