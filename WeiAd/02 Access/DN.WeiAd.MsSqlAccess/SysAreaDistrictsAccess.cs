
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
    public partial class SysAreaDistrictsAccess : SysAreaDistrictsInterface
    {
        #region SQL

        /// <summary>
        /// 新增
        /// </summary>
        const string INSERT = "INSERT INTO SysAreaDistricts ([Id],[Name],[CityId],[ProvincesId],[CreateTime]) VALUES (@Id,@Name,@CityId,@ProvincesId,@CreateTime)";

        /// <summary>
        /// 修改
        /// </summary>
        const string EDIT = "UPDATE SysAreaDistricts SET [Id]=@Id,[Name]=@Name,[CityId]=@CityId,[ProvincesId]=@ProvincesId,[CreateTime]=@CreateTime WHERE [Id]=@Id";

        /// <summary>
        /// 删除
        /// </summary>
        const string DELETE = "DELETE FROM SysAreaDistricts";

        /// <summary>
        /// 加载数据
        /// </summary>
        const string LOAD = "SELECT * FROM SysAreaDistricts @WHERE @ORDER";

        /// <summary>
        /// 分页查询
        /// </summary>
        const string QUERYPAGE = "SELECT TOP @PAGESIZE * FROM [SysAreaDistricts] @WHERE AND Id NOT IN (SELECT TOP @PTOP Id FROM [SysAreaDistricts] @WHERE @ORDER)  @ORDER";

        /// <summary>
        /// 查询记录数
        /// </summary>
        const string QUERYCOUNT = "SELECT COUNT(1) FROM SysAreaDistricts";


        #endregion

        public override bool Delete(SysAreaDistrictsPara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            command.CommandText = DELETE + where;

            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override bool Edit(SysAreaDistrictsVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = EDIT;

             command.Parameters.Add(new SqlParameter() { ParameterName = "@Id", Value = ParameterHelper.ConvertValue(m.Id) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@Name", Value = ParameterHelper.ConvertValue(m.Name) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@CityId", Value = ParameterHelper.ConvertValue(m.CityId) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@ProvincesId", Value = ParameterHelper.ConvertValue(m.ProvincesId) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateTime", Value = ParameterHelper.ConvertValue(m.CreateTime) });


            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override string GetConditionByModel(SysAreaDistrictsVO m)
        {
            return "";
        }

        public override string GetConditionByPara(SysAreaDistrictsPara mp)
        {
            StringBuilder sb = new StringBuilder();

           if (mp.Id.HasValue) { sb.AppendFormat(" AND [Id]='{0}' ",mp.Id);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.Name))){ sb.AppendFormat(" AND [Name]='{0}' ",mp.Name);}
           if (mp.CityId.HasValue) { sb.AppendFormat(" AND [CityId]='{0}' ",mp.CityId);}
           if (mp.ProvincesId.HasValue) { sb.AppendFormat(" AND [ProvincesId]='{0}' ",mp.ProvincesId);}
           if (mp.CreateTime.HasValue) { sb.AppendFormat(" AND [CreateTime]='{0}' ",mp.CreateTime);}


            sb.Insert(0, " WHERE 1=1 ");

            return sb.ToString();
        }

        public override List<SysAreaDistrictsVO> GetModels(ref SysAreaDistrictsPara mp)
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

            List<SysAreaDistrictsVO> list = new List<SysAreaDistrictsVO>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(new SysAreaDistrictsVO(table.Rows[i]));
            }

            if (!mp.Recount.HasValue)
            {
                mp.Recount = GetRecords(mp);
            }

            return list;
        }

        public override List<SysAreaDistrictsVO> GetModels(SysAreaDistrictsPara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            
			string cmd = LOAD
                .Replace("@WHERE", where)
                .Replace("@ORDER", GetOrderByPara(mp));
			command.CommandText = cmd;

            var table = DbProxyFactory.Instance.Proxy.ExecuteTable(command);

            List<SysAreaDistrictsVO> list = new List<SysAreaDistrictsVO>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(new SysAreaDistrictsVO(table.Rows[i]));
            }

            return list;
        }

        public override string GetOrderByModel(SysAreaDistrictsVO m)
        {
            return "";
        }

        public override string GetOrderByPara(SysAreaDistrictsPara mp)
        {
            if(!string.IsNullOrEmpty(mp.OrderBy))
            {
                return string.Format(" order by {0}", mp.OrderBy);
            }

            return "";
        }

        public override string GetOtherConditionByModel(SysAreaDistrictsVO m)
        {
            return "";
        }

        public override string GetOtherConditionByPara(SysAreaDistrictsPara mp)
        {
            return "";
        }

        public override int GetRecords(SysAreaDistrictsPara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            command.CommandText = QUERYCOUNT + where;

            var result = DbProxyFactory.Instance.Proxy.ExecuteScalar(command);

            return int.Parse(result.ToString());
        }

        public override SysAreaDistrictsVO GetSingle(SysAreaDistrictsPara mp)
        {
            var list = GetModels(mp);

            if (list.Count == 1)
                return list[0];

            return null;
        }

        public override bool Insert(SysAreaDistrictsVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = INSERT;
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Id", Value = ParameterHelper.ConvertValue(m.Id) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Name", Value = ParameterHelper.ConvertValue(m.Name) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CityId", Value = ParameterHelper.ConvertValue(m.CityId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@ProvincesId", Value = ParameterHelper.ConvertValue(m.ProvincesId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateTime", Value = ParameterHelper.ConvertValue(m.CreateTime) });


            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override int InsertIdentityId(SysAreaDistrictsVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = INSERT + "; select @@Identity";

         command.Parameters.Add(new SqlParameter() { ParameterName = "@Id", Value = ParameterHelper.ConvertValue(m.Id) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Name", Value = ParameterHelper.ConvertValue(m.Name) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CityId", Value = ParameterHelper.ConvertValue(m.CityId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@ProvincesId", Value = ParameterHelper.ConvertValue(m.ProvincesId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateTime", Value = ParameterHelper.ConvertValue(m.CreateTime) });


            var result = DbProxyFactory.Instance.Proxy.ExecuteScalar(command);

            return int.Parse(result.ToString());
        }
    }
}
