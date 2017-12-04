
/*

skey edit by 2017/7/16 9:01:30

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
    public partial class SysAreaCityAccess : SysAreaCityInterface
    {
        #region SQL

        /// <summary>
        /// 新增
        /// </summary>
        const string INSERT = "INSERT INTO SysAreaCity ([Id],[Name],[ParentId],[ZipCode],[CreateTime]) VALUES (@Id,@Name,@ParentId,@ZipCode,@CreateTime)";

        /// <summary>
        /// 修改
        /// </summary>
        const string EDIT = "UPDATE SysAreaCity SET [Id]=@Id,[Name]=@Name,[ParentId]=@ParentId,[ZipCode]=@ZipCode,[CreateTime]=@CreateTime WHERE [Id]=@Id";

        /// <summary>
        /// 删除
        /// </summary>
        const string DELETE = "DELETE FROM SysAreaCity";

        /// <summary>
        /// 加载数据
        /// </summary>
        const string LOAD = "SELECT * FROM SysAreaCity @WHERE @ORDER";

        /// <summary>
        /// 分页查询
        /// </summary>
        const string QUERYPAGE = "SELECT TOP @PAGESIZE * FROM [SysAreaCity] @WHERE AND Id NOT IN (SELECT TOP @PTOP Id FROM [SysAreaCity] @WHERE @ORDER)  @ORDER";

        /// <summary>
        /// 查询记录数
        /// </summary>
        const string QUERYCOUNT = "SELECT COUNT(1) FROM SysAreaCity";


        #endregion

        public override bool Delete(SysAreaCityPara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            command.CommandText = DELETE + where;

            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override bool Edit(SysAreaCityVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = EDIT;

             command.Parameters.Add(new SqlParameter() { ParameterName = "@Id", Value = ParameterHelper.ConvertValue(m.Id) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@Name", Value = ParameterHelper.ConvertValue(m.Name) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@ParentId", Value = ParameterHelper.ConvertValue(m.ParentId) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@ZipCode", Value = ParameterHelper.ConvertValue(m.ZipCode) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateTime", Value = ParameterHelper.ConvertValue(m.CreateTime) });


            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override string GetConditionByModel(SysAreaCityVO m)
        {
            return "";
        }

        public override string GetConditionByPara(SysAreaCityPara mp)
        {
            StringBuilder sb = new StringBuilder();

           if (mp.Id.HasValue) { sb.AppendFormat(" AND [Id]='{0}' ",mp.Id);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.Name))){ sb.AppendFormat(" AND [Name]='{0}' ",mp.Name);}
           if (mp.ParentId.HasValue) { sb.AppendFormat(" AND [ParentId]='{0}' ",mp.ParentId);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.ZipCode))){ sb.AppendFormat(" AND [ZipCode]='{0}' ",mp.ZipCode);}
           if (mp.CreateTime.HasValue) { sb.AppendFormat(" AND [CreateTime]='{0}' ",mp.CreateTime);}


            sb.Insert(0, " WHERE 1=1 ");

            return sb.ToString();
        }

        public override List<SysAreaCityVO> GetModels(ref SysAreaCityPara mp)
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

            List<SysAreaCityVO> list = new List<SysAreaCityVO>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(new SysAreaCityVO(table.Rows[i]));
            }

            if (!mp.Recount.HasValue)
            {
                mp.Recount = GetRecords(mp);
            }

            return list;
        }

        public override List<SysAreaCityVO> GetModels(SysAreaCityPara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            
			string cmd = LOAD
                .Replace("@WHERE", where)
                .Replace("@ORDER", GetOrderByPara(mp));
			command.CommandText = cmd;

            var table = DbProxyFactory.Instance.Proxy.ExecuteTable(command);

            List<SysAreaCityVO> list = new List<SysAreaCityVO>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(new SysAreaCityVO(table.Rows[i]));
            }

            return list;
        }

        public override string GetOrderByModel(SysAreaCityVO m)
        {
            return "";
        }

        public override string GetOrderByPara(SysAreaCityPara mp)
        {
            if(!string.IsNullOrEmpty(mp.OrderBy))
            {
                return string.Format(" order by {0}", mp.OrderBy);
            }

            return "";
        }

        public override string GetOtherConditionByModel(SysAreaCityVO m)
        {
            return "";
        }

        public override string GetOtherConditionByPara(SysAreaCityPara mp)
        {
            return "";
        }

        public override int GetRecords(SysAreaCityPara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            command.CommandText = QUERYCOUNT + where;

            var result = DbProxyFactory.Instance.Proxy.ExecuteScalar(command);

            return int.Parse(result.ToString());
        }

        public override SysAreaCityVO GetSingle(SysAreaCityPara mp)
        {
            var list = GetModels(mp);

            if (list.Count == 1)
                return list[0];

            return null;
        }

        public override bool Insert(SysAreaCityVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = INSERT;
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Id", Value = ParameterHelper.ConvertValue(m.Id) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Name", Value = ParameterHelper.ConvertValue(m.Name) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@ParentId", Value = ParameterHelper.ConvertValue(m.ParentId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@ZipCode", Value = ParameterHelper.ConvertValue(m.ZipCode) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateTime", Value = ParameterHelper.ConvertValue(m.CreateTime) });


            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override int InsertIdentityId(SysAreaCityVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = INSERT + "; select @@Identity";

         command.Parameters.Add(new SqlParameter() { ParameterName = "@Id", Value = ParameterHelper.ConvertValue(m.Id) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Name", Value = ParameterHelper.ConvertValue(m.Name) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@ParentId", Value = ParameterHelper.ConvertValue(m.ParentId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@ZipCode", Value = ParameterHelper.ConvertValue(m.ZipCode) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateTime", Value = ParameterHelper.ConvertValue(m.CreateTime) });


            var result = DbProxyFactory.Instance.Proxy.ExecuteScalar(command);

            return int.Parse(result.ToString());
        }
    }
}
