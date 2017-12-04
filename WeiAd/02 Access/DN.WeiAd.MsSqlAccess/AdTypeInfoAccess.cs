
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
    public partial class AdTypeInfoAccess : AdTypeInfoInterface
    {
        #region SQL

        /// <summary>
        /// 新增
        /// </summary>
        const string INSERT = "INSERT INTO AdTypeInfo ([Name],[Desc],[UserId],[CreateDate],[LastDate]) VALUES (@Name,@Desc,@UserId,@CreateDate,@LastDate)";

        /// <summary>
        /// 修改
        /// </summary>
        const string EDIT = "UPDATE AdTypeInfo SET [Name]=@Name,[Desc]=@Desc,[UserId]=@UserId,[CreateDate]=@CreateDate,[LastDate]=@LastDate WHERE [Id]=@Id";

        /// <summary>
        /// 删除
        /// </summary>
        const string DELETE = "DELETE FROM AdTypeInfo";

        /// <summary>
        /// 加载数据
        /// </summary>
        const string LOAD = "SELECT * FROM AdTypeInfo @WHERE @ORDER";

        /// <summary>
        /// 分页查询
        /// </summary>
        const string QUERYPAGE = "SELECT TOP @PAGESIZE * FROM [AdTypeInfo] @WHERE AND Id NOT IN (SELECT TOP @PTOP Id FROM [AdTypeInfo] @WHERE @ORDER)  @ORDER";

        /// <summary>
        /// 查询记录数
        /// </summary>
        const string QUERYCOUNT = "SELECT COUNT(1) FROM AdTypeInfo";


        #endregion

        public override bool Delete(AdTypeInfoPara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            command.CommandText = DELETE + where;

            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override bool Edit(AdTypeInfoVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = EDIT;

             command.Parameters.Add(new SqlParameter() { ParameterName = "@Name", Value = ParameterHelper.ConvertValue(m.Name) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@Desc", Value = ParameterHelper.ConvertValue(m.Desc) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@UserId", Value = ParameterHelper.ConvertValue(m.UserId) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateDate", Value = ParameterHelper.ConvertValue(m.CreateDate) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@LastDate", Value = ParameterHelper.ConvertValue(m.LastDate) });
               command.Parameters.Add(new SqlParameter() { ParameterName = "@Id", Value = ParameterHelper.ConvertValue(m.Id) });


            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override string GetConditionByModel(AdTypeInfoVO m)
        {
            return "";
        }

        public override string GetConditionByPara(AdTypeInfoPara mp)
        {
            StringBuilder sb = new StringBuilder();

           if (mp.Id.HasValue) { sb.AppendFormat(" AND [Id]='{0}' ",mp.Id);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.Name))){ sb.AppendFormat(" AND [Name]='{0}' ",mp.Name);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.Desc))){ sb.AppendFormat(" AND [Desc]='{0}' ",mp.Desc);}
           if (mp.UserId.HasValue) { sb.AppendFormat(" AND [UserId]='{0}' ",mp.UserId);}
           if (mp.CreateDate.HasValue) { sb.AppendFormat(" AND [CreateDate]='{0}' ",mp.CreateDate);}
           if (mp.LastDate.HasValue) { sb.AppendFormat(" AND [LastDate]='{0}' ",mp.LastDate);}


            sb.Insert(0, " WHERE 1=1 ");

            return sb.ToString();
        }

        public override List<AdTypeInfoVO> GetModels(ref AdTypeInfoPara mp)
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

            List<AdTypeInfoVO> list = new List<AdTypeInfoVO>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(new AdTypeInfoVO(table.Rows[i]));
            }

            if (!mp.Recount.HasValue)
            {
                mp.Recount = GetRecords(mp);
            }

            return list;
        }

        public override List<AdTypeInfoVO> GetModels(AdTypeInfoPara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            
			string cmd = LOAD
                .Replace("@WHERE", where)
                .Replace("@ORDER", GetOrderByPara(mp));
			command.CommandText = cmd;

            var table = DbProxyFactory.Instance.Proxy.ExecuteTable(command);

            List<AdTypeInfoVO> list = new List<AdTypeInfoVO>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(new AdTypeInfoVO(table.Rows[i]));
            }

            return list;
        }

        public override string GetOrderByModel(AdTypeInfoVO m)
        {
            return "";
        }

        public override string GetOrderByPara(AdTypeInfoPara mp)
        {
            if(!string.IsNullOrEmpty(mp.OrderBy))
            {
                return string.Format(" order by {0}", mp.OrderBy);
            }

            return "";
        }

        public override string GetOtherConditionByModel(AdTypeInfoVO m)
        {
            return "";
        }

        public override string GetOtherConditionByPara(AdTypeInfoPara mp)
        {
            return "";
        }

        public override int GetRecords(AdTypeInfoPara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            command.CommandText = QUERYCOUNT + where;

            var result = DbProxyFactory.Instance.Proxy.ExecuteScalar(command);

            return int.Parse(result.ToString());
        }

        public override AdTypeInfoVO GetSingle(AdTypeInfoPara mp)
        {
            var list = GetModels(mp);

            if (list.Count == 1)
                return list[0];

            return null;
        }

        public override bool Insert(AdTypeInfoVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = INSERT;
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Name", Value = ParameterHelper.ConvertValue(m.Name) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Desc", Value = ParameterHelper.ConvertValue(m.Desc) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@UserId", Value = ParameterHelper.ConvertValue(m.UserId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateDate", Value = ParameterHelper.ConvertValue(m.CreateDate) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@LastDate", Value = ParameterHelper.ConvertValue(m.LastDate) });


            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override int InsertIdentityId(AdTypeInfoVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = INSERT + "; select @@Identity";

         command.Parameters.Add(new SqlParameter() { ParameterName = "@Name", Value = ParameterHelper.ConvertValue(m.Name) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Desc", Value = ParameterHelper.ConvertValue(m.Desc) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@UserId", Value = ParameterHelper.ConvertValue(m.UserId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateDate", Value = ParameterHelper.ConvertValue(m.CreateDate) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@LastDate", Value = ParameterHelper.ConvertValue(m.LastDate) });


            var result = DbProxyFactory.Instance.Proxy.ExecuteScalar(command);

            return int.Parse(result.ToString());
        }
    }
}
