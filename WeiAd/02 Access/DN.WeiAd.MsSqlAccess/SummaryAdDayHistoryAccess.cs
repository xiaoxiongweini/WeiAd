
/*

skey edit by 2017/9/21 10:02:13

mail:skey111@foxmail.com

version edit by v1.0.3

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
    public partial class SummaryAdDayHistoryAccess : SummaryAdDayHistoryInterface
    {
        #region SQL

        /// <summary>
        /// 新增
        /// </summary>
        const string INSERT = "INSERT INTO SummaryAdDayHistory ([AdId],[UserId],[TimeId],[PvCount],[UvCount],[IpCount],[CreateDate],[CreateUserId],[IsDelete]) VALUES (@AdId,@UserId,@TimeId,@PvCount,@UvCount,@IpCount,@CreateDate,@CreateUserId,@IsDelete)";

        /// <summary>
        /// 修改
        /// </summary>
        const string EDIT = "UPDATE SummaryAdDayHistory SET [AdId]=@AdId,[UserId]=@UserId,[TimeId]=@TimeId,[PvCount]=@PvCount,[UvCount]=@UvCount,[IpCount]=@IpCount,[CreateDate]=@CreateDate,[CreateUserId]=@CreateUserId,[IsDelete]=@IsDelete WHERE [Id]=@Id";

        /// <summary>
        /// 删除
        /// </summary>
        const string DELETE = "DELETE FROM SummaryAdDayHistory";

        /// <summary>
        /// 加载数据
        /// </summary>
        const string LOAD = "SELECT * FROM SummaryAdDayHistory @WHERE @ORDER";

        /// <summary>
        /// 分页查询
        /// </summary>
        const string QUERYPAGE = "SELECT TOP @PAGESIZE * FROM [SummaryAdDayHistory] @WHERE AND Id NOT IN (SELECT TOP @PTOP Id FROM [SummaryAdDayHistory] @WHERE @ORDER)  @ORDER";

        /// <summary>
        /// 查询记录数
        /// </summary>
        const string QUERYCOUNT = "SELECT COUNT(1) FROM SummaryAdDayHistory";


        #endregion

        public override bool Delete(SummaryAdDayHistoryPara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            command.CommandText = DELETE + where;

            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override bool Edit(SummaryAdDayHistoryVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = EDIT;

             command.Parameters.Add(new SqlParameter() { ParameterName = "@AdId", Value = ParameterHelper.ConvertValue(m.AdId) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@UserId", Value = ParameterHelper.ConvertValue(m.UserId) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@TimeId", Value = ParameterHelper.ConvertValue(m.TimeId) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@PvCount", Value = ParameterHelper.ConvertValue(m.PvCount) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@UvCount", Value = ParameterHelper.ConvertValue(m.UvCount) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@IpCount", Value = ParameterHelper.ConvertValue(m.IpCount) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateDate", Value = ParameterHelper.ConvertValue(m.CreateDate) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateUserId", Value = ParameterHelper.ConvertValue(m.CreateUserId) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@IsDelete", Value = ParameterHelper.ConvertValue(m.IsDelete) });
               command.Parameters.Add(new SqlParameter() { ParameterName = "@Id", Value = ParameterHelper.ConvertValue(m.Id) });


            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override string GetConditionByModel(SummaryAdDayHistoryVO m)
        {
            return "";
        }

        public override string GetConditionByPara(SummaryAdDayHistoryPara mp)
        {
            StringBuilder sb = new StringBuilder();

           if (mp.Id.HasValue) { sb.AppendFormat(" AND [Id]='{0}' ",mp.Id);}
           if (mp.AdId.HasValue) { sb.AppendFormat(" AND [AdId]='{0}' ",mp.AdId);}
           if (mp.UserId.HasValue) { sb.AppendFormat(" AND [UserId]='{0}' ",mp.UserId);}
           if (mp.TimeId.HasValue) { sb.AppendFormat(" AND [TimeId]='{0}' ",mp.TimeId);}
           if (mp.PvCount.HasValue) { sb.AppendFormat(" AND [PvCount]='{0}' ",mp.PvCount);}
           if (mp.UvCount.HasValue) { sb.AppendFormat(" AND [UvCount]='{0}' ",mp.UvCount);}
           if (mp.IpCount.HasValue) { sb.AppendFormat(" AND [IpCount]='{0}' ",mp.IpCount);}
           if (mp.CreateDate.HasValue) { sb.AppendFormat(" AND convert(varchar(10), [CreateDate], 120) = convert(varchar(10), '{0}',120) ",mp.CreateDate.Value.ToString("yyyy-MM-dd"));}
           if (mp.CreateUserId.HasValue) { sb.AppendFormat(" AND [CreateUserId]='{0}' ",mp.CreateUserId);}
           if (mp.IsDelete.HasValue) { sb.AppendFormat(" AND [IsDelete]='{0}' ",mp.IsDelete);}


            sb.Insert(0, " WHERE 1=1 ");

            return sb.ToString();
        }

        public override List<SummaryAdDayHistoryVO> GetModels(ref SummaryAdDayHistoryPara mp)
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

            List<SummaryAdDayHistoryVO> list = new List<SummaryAdDayHistoryVO>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(new SummaryAdDayHistoryVO(table.Rows[i]));
            }

            if (!mp.Recount.HasValue)
            {
                mp.Recount = GetRecords(mp);
            }

            return list;
        }

        public override List<SummaryAdDayHistoryVO> GetModels(SummaryAdDayHistoryPara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            
			string cmd = LOAD
                .Replace("@WHERE", where)
                .Replace("@ORDER", GetOrderByPara(mp));
			command.CommandText = cmd;

            var table = DbProxyFactory.Instance.Proxy.ExecuteTable(command);

            List<SummaryAdDayHistoryVO> list = new List<SummaryAdDayHistoryVO>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(new SummaryAdDayHistoryVO(table.Rows[i]));
            }

            return list;
        }

        public override string GetOrderByModel(SummaryAdDayHistoryVO m)
        {
            return "";
        }

        public override string GetOrderByPara(SummaryAdDayHistoryPara mp)
        {
            if(!string.IsNullOrEmpty(mp.OrderBy))
            {
                return string.Format(" order by {0}", mp.OrderBy);
            }

            return "";
        }

        public override string GetOtherConditionByModel(SummaryAdDayHistoryVO m)
        {
            return "";
        }

        public override string GetOtherConditionByPara(SummaryAdDayHistoryPara mp)
        {
            return "";
        }

        public override int GetRecords(SummaryAdDayHistoryPara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            command.CommandText = QUERYCOUNT + where;

            var result = DbProxyFactory.Instance.Proxy.ExecuteScalar(command);

            return int.Parse(result.ToString());
        }

        public override SummaryAdDayHistoryVO GetSingle(SummaryAdDayHistoryPara mp)
        {
            var list = GetModels(mp);

            if (list.Count == 1)
                return list[0];

            return null;
        }

        public override bool Insert(SummaryAdDayHistoryVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = INSERT;
         command.Parameters.Add(new SqlParameter() { ParameterName = "@AdId", Value = ParameterHelper.ConvertValue(m.AdId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@UserId", Value = ParameterHelper.ConvertValue(m.UserId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@TimeId", Value = ParameterHelper.ConvertValue(m.TimeId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@PvCount", Value = ParameterHelper.ConvertValue(m.PvCount) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@UvCount", Value = ParameterHelper.ConvertValue(m.UvCount) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@IpCount", Value = ParameterHelper.ConvertValue(m.IpCount) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateDate", Value = ParameterHelper.ConvertValue(m.CreateDate) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateUserId", Value = ParameterHelper.ConvertValue(m.CreateUserId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@IsDelete", Value = ParameterHelper.ConvertValue(m.IsDelete) });


            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override int InsertIdentityId(SummaryAdDayHistoryVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = INSERT + "; select @@Identity";

         command.Parameters.Add(new SqlParameter() { ParameterName = "@AdId", Value = ParameterHelper.ConvertValue(m.AdId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@UserId", Value = ParameterHelper.ConvertValue(m.UserId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@TimeId", Value = ParameterHelper.ConvertValue(m.TimeId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@PvCount", Value = ParameterHelper.ConvertValue(m.PvCount) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@UvCount", Value = ParameterHelper.ConvertValue(m.UvCount) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@IpCount", Value = ParameterHelper.ConvertValue(m.IpCount) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateDate", Value = ParameterHelper.ConvertValue(m.CreateDate) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateUserId", Value = ParameterHelper.ConvertValue(m.CreateUserId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@IsDelete", Value = ParameterHelper.ConvertValue(m.IsDelete) });


            var result = DbProxyFactory.Instance.Proxy.ExecuteScalar(command);

            return int.Parse(result.ToString());
        }
    }
}
