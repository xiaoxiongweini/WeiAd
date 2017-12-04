
/*

skey edit by 2017-04-29 23:14:21

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
    public partial class LogIpInfoAccess : LogIpInfoInterface
    {
        #region SQL

        /// <summary>
        /// 新增
        /// </summary>
        const string INSERT = "INSERT INTO LogIpInfo ([Ip],[country],[area],[region],[city],[county],[isp],[CreateDate]) VALUES (@Ip,@country,@area,@region,@city,@county,@isp,@CreateDate)";

        /// <summary>
        /// 修改
        /// </summary>
        const string EDIT = "UPDATE LogIpInfo SET [Ip]=@Ip,[country]=@country,[area]=@area,[region]=@region,[city]=@city,[county]=@county,[isp]=@isp,[CreateDate]=@CreateDate WHERE [Id]=@Id";

        /// <summary>
        /// 删除
        /// </summary>
        const string DELETE = "DELETE FROM LogIpInfo";

        /// <summary>
        /// 加载数据
        /// </summary>
        const string LOAD = "SELECT * FROM LogIpInfo @WHERE @ORDER";

        /// <summary>
        /// 分页查询
        /// </summary>
        const string QUERYPAGE = "SELECT TOP @PAGESIZE * FROM [LogIpInfo] @WHERE AND Id NOT IN (SELECT TOP @PTOP Id FROM [LogIpInfo] @WHERE @ORDER)  @ORDER";

        /// <summary>
        /// 查询记录数
        /// </summary>
        const string QUERYCOUNT = "SELECT COUNT(1) FROM LogIpInfo";


        #endregion

        public override bool Delete(LogIpInfoPara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            command.CommandText = DELETE + where;

            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override bool Edit(LogIpInfoVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = EDIT;

             command.Parameters.Add(new SqlParameter() { ParameterName = "@Ip", Value = ParameterHelper.ConvertValue(m.Ip) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@country", Value = ParameterHelper.ConvertValue(m.country) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@area", Value = ParameterHelper.ConvertValue(m.area) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@region", Value = ParameterHelper.ConvertValue(m.region) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@city", Value = ParameterHelper.ConvertValue(m.city) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@county", Value = ParameterHelper.ConvertValue(m.county) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@isp", Value = ParameterHelper.ConvertValue(m.isp) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateDate", Value = ParameterHelper.ConvertValue(m.CreateDate) });
               command.Parameters.Add(new SqlParameter() { ParameterName = "@Id", Value = ParameterHelper.ConvertValue(m.Id) });


            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override string GetConditionByModel(LogIpInfoVO m)
        {
            return "";
        }

        public override string GetConditionByPara(LogIpInfoPara mp)
        {
            StringBuilder sb = new StringBuilder();

           if (mp.Id.HasValue) { sb.AppendFormat(" AND [Id]='{0}' ",mp.Id);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.Ip))){ sb.AppendFormat(" AND [Ip]='{0}' ",mp.Ip);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.country))){ sb.AppendFormat(" AND [country]='{0}' ",mp.country);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.area))){ sb.AppendFormat(" AND [area]='{0}' ",mp.area);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.region))){ sb.AppendFormat(" AND [region]='{0}' ",mp.region);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.city))){ sb.AppendFormat(" AND [city]='{0}' ",mp.city);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.county))){ sb.AppendFormat(" AND [county]='{0}' ",mp.county);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.isp))){ sb.AppendFormat(" AND [isp]='{0}' ",mp.isp);}
           if (mp.CreateDate.HasValue) { sb.AppendFormat(" AND [CreateDate]='{0}' ",mp.CreateDate);}


            sb.Insert(0, " WHERE 1=1 ");

            return sb.ToString();
        }

        public override List<LogIpInfoVO> GetModels(ref LogIpInfoPara mp)
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

            List<LogIpInfoVO> list = new List<LogIpInfoVO>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(new LogIpInfoVO(table.Rows[i]));
            }

            if (!mp.Recount.HasValue)
            {
                mp.Recount = GetRecords(mp);
            }

            return list;
        }

        public override List<LogIpInfoVO> GetModels(LogIpInfoPara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            
			string cmd = LOAD
                .Replace("@WHERE", where)
                .Replace("@ORDER", GetOrderByPara(mp));
			command.CommandText = cmd;

            var table = DbProxyFactory.Instance.Proxy.ExecuteTable(command);

            List<LogIpInfoVO> list = new List<LogIpInfoVO>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(new LogIpInfoVO(table.Rows[i]));
            }

            return list;
        }

        public override string GetOrderByModel(LogIpInfoVO m)
        {
            return "";
        }

        public override string GetOrderByPara(LogIpInfoPara mp)
        {
            if(!string.IsNullOrEmpty(mp.OrderBy))
            {
                return string.Format(" order by {0}", mp.OrderBy);
            }

            return "";
        }

        public override string GetOtherConditionByModel(LogIpInfoVO m)
        {
            return "";
        }

        public override string GetOtherConditionByPara(LogIpInfoPara mp)
        {
            return "";
        }

        public override int GetRecords(LogIpInfoPara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            command.CommandText = QUERYCOUNT + where;

            var result = DbProxyFactory.Instance.Proxy.ExecuteScalar(command);

            return int.Parse(result.ToString());
        }

        public override LogIpInfoVO GetSingle(LogIpInfoPara mp)
        {
            var list = GetModels(mp);

            if (list.Count == 1)
                return list[0];

            return null;
        }

        public override bool Insert(LogIpInfoVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = INSERT;
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Ip", Value = ParameterHelper.ConvertValue(m.Ip) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@country", Value = ParameterHelper.ConvertValue(m.country) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@area", Value = ParameterHelper.ConvertValue(m.area) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@region", Value = ParameterHelper.ConvertValue(m.region) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@city", Value = ParameterHelper.ConvertValue(m.city) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@county", Value = ParameterHelper.ConvertValue(m.county) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@isp", Value = ParameterHelper.ConvertValue(m.isp) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateDate", Value = ParameterHelper.ConvertValue(m.CreateDate) });


            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override int InsertIdentityId(LogIpInfoVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = INSERT + "; select @@Identity";

         command.Parameters.Add(new SqlParameter() { ParameterName = "@Ip", Value = ParameterHelper.ConvertValue(m.Ip) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@country", Value = ParameterHelper.ConvertValue(m.country) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@area", Value = ParameterHelper.ConvertValue(m.area) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@region", Value = ParameterHelper.ConvertValue(m.region) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@city", Value = ParameterHelper.ConvertValue(m.city) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@county", Value = ParameterHelper.ConvertValue(m.county) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@isp", Value = ParameterHelper.ConvertValue(m.isp) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateDate", Value = ParameterHelper.ConvertValue(m.CreateDate) });


            var result = DbProxyFactory.Instance.Proxy.ExecuteScalar(command);

            return int.Parse(result.ToString());
        }
    }
}
