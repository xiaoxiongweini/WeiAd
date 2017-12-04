
/*

skey edit by 2017/7/4 16:41:47

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
    public partial class HistoryUserLogBrowseAccess : HistoryUserLogBrowseInterface
    {
        #region SQL

        /// <summary>
        /// 新增
        /// </summary>
        const string INSERT = "INSERT INTO HistoryUserLogBrowse ([Time],[AdId],[UserId],[PvCount],[UvCount],[IpCount],[Price],[Money],[CreateDate],[CreateUserId]) VALUES (@Time,@AdId,@UserId,@PvCount,@UvCount,@IpCount,@Price,@Money,@CreateDate,@CreateUserId)";

        /// <summary>
        /// 修改
        /// </summary>
        const string EDIT = "UPDATE HistoryUserLogBrowse SET [Time]=@Time,[AdId]=@AdId,[UserId]=@UserId,[PvCount]=@PvCount,[UvCount]=@UvCount,[IpCount]=@IpCount,[Price]=@Price,[Money]=@Money,[CreateDate]=@CreateDate,[CreateUserId]=@CreateUserId WHERE [Id]=@Id";

        /// <summary>
        /// 删除
        /// </summary>
        const string DELETE = "DELETE FROM HistoryUserLogBrowse";

        /// <summary>
        /// 加载数据
        /// </summary>
        const string LOAD = "SELECT * FROM HistoryUserLogBrowse @WHERE @ORDER";

        /// <summary>
        /// 分页查询
        /// </summary>
        const string QUERYPAGE = "SELECT TOP @PAGESIZE * FROM [HistoryUserLogBrowse] @WHERE AND Id NOT IN (SELECT TOP @PTOP Id FROM [HistoryUserLogBrowse] @WHERE @ORDER)  @ORDER";

        /// <summary>
        /// 查询记录数
        /// </summary>
        const string QUERYCOUNT = "SELECT COUNT(1) FROM HistoryUserLogBrowse";


        #endregion

        public override bool Delete(HistoryUserLogBrowsePara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            command.CommandText = DELETE + where;

            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override bool Edit(HistoryUserLogBrowseVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = EDIT;

             command.Parameters.Add(new SqlParameter() { ParameterName = "@Time", Value = ParameterHelper.ConvertValue(m.Time) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@AdId", Value = ParameterHelper.ConvertValue(m.AdId) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@UserId", Value = ParameterHelper.ConvertValue(m.UserId) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@PvCount", Value = ParameterHelper.ConvertValue(m.PvCount) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@UvCount", Value = ParameterHelper.ConvertValue(m.UvCount) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@IpCount", Value = ParameterHelper.ConvertValue(m.IpCount) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@Price", Value = ParameterHelper.ConvertValue(m.Price) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@Money", Value = ParameterHelper.ConvertValue(m.Money) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateDate", Value = ParameterHelper.ConvertValue(m.CreateDate) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateUserId", Value = ParameterHelper.ConvertValue(m.CreateUserId) });
               command.Parameters.Add(new SqlParameter() { ParameterName = "@Id", Value = ParameterHelper.ConvertValue(m.Id) });


            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override string GetConditionByModel(HistoryUserLogBrowseVO m)
        {
            return "";
        }

        public override string GetConditionByPara(HistoryUserLogBrowsePara mp)
        {
            StringBuilder sb = new StringBuilder();

           if (mp.Id.HasValue) { sb.AppendFormat(" AND [Id]='{0}' ",mp.Id);}
           if (mp.Time.HasValue) { sb.AppendFormat(" AND [Time]='{0}' ",mp.Time);}
           if (mp.AdId.HasValue) { sb.AppendFormat(" AND [AdId]='{0}' ",mp.AdId);}
           if (mp.UserId.HasValue) { sb.AppendFormat(" AND [UserId]='{0}' ",mp.UserId);}
           if (mp.PvCount.HasValue) { sb.AppendFormat(" AND [PvCount]='{0}' ",mp.PvCount);}
           if (mp.UvCount.HasValue) { sb.AppendFormat(" AND [UvCount]='{0}' ",mp.UvCount);}
           if (mp.IpCount.HasValue) { sb.AppendFormat(" AND [IpCount]='{0}' ",mp.IpCount);}
           if (mp.Price.HasValue) { sb.AppendFormat(" AND [Price]='{0}' ",mp.Price);}
           if (mp.Money.HasValue) { sb.AppendFormat(" AND [Money]='{0}' ",mp.Money);}
           if (mp.CreateDate.HasValue) { sb.AppendFormat(" AND [CreateDate]='{0}' ",mp.CreateDate);}
           if (mp.CreateUserId.HasValue) { sb.AppendFormat(" AND [CreateUserId]='{0}' ",mp.CreateUserId);}


            sb.Insert(0, " WHERE 1=1 ");

            return sb.ToString();
        }

        public override List<HistoryUserLogBrowseVO> GetModels(ref HistoryUserLogBrowsePara mp)
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

            List<HistoryUserLogBrowseVO> list = new List<HistoryUserLogBrowseVO>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(new HistoryUserLogBrowseVO(table.Rows[i]));
            }

            if (!mp.Recount.HasValue)
            {
                mp.Recount = GetRecords(mp);
            }

            return list;
        }

        public override List<HistoryUserLogBrowseVO> GetModels(HistoryUserLogBrowsePara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            
			string cmd = LOAD
                .Replace("@WHERE", where)
                .Replace("@ORDER", GetOrderByPara(mp));
			command.CommandText = cmd;

            var table = DbProxyFactory.Instance.Proxy.ExecuteTable(command);

            List<HistoryUserLogBrowseVO> list = new List<HistoryUserLogBrowseVO>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(new HistoryUserLogBrowseVO(table.Rows[i]));
            }

            return list;
        }

        public override string GetOrderByModel(HistoryUserLogBrowseVO m)
        {
            return "";
        }

        public override string GetOrderByPara(HistoryUserLogBrowsePara mp)
        {
            if(!string.IsNullOrEmpty(mp.OrderBy))
            {
                return string.Format(" order by {0}", mp.OrderBy);
            }

            return "";
        }

        public override string GetOtherConditionByModel(HistoryUserLogBrowseVO m)
        {
            return "";
        }

        public override string GetOtherConditionByPara(HistoryUserLogBrowsePara mp)
        {
            return "";
        }

        public override int GetRecords(HistoryUserLogBrowsePara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            command.CommandText = QUERYCOUNT + where;

            var result = DbProxyFactory.Instance.Proxy.ExecuteScalar(command);

            return int.Parse(result.ToString());
        }

        public override HistoryUserLogBrowseVO GetSingle(HistoryUserLogBrowsePara mp)
        {
            var list = GetModels(mp);

            if (list.Count == 1)
                return list[0];

            return null;
        }

        public override bool Insert(HistoryUserLogBrowseVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = INSERT;
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Time", Value = ParameterHelper.ConvertValue(m.Time) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@AdId", Value = ParameterHelper.ConvertValue(m.AdId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@UserId", Value = ParameterHelper.ConvertValue(m.UserId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@PvCount", Value = ParameterHelper.ConvertValue(m.PvCount) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@UvCount", Value = ParameterHelper.ConvertValue(m.UvCount) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@IpCount", Value = ParameterHelper.ConvertValue(m.IpCount) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Price", Value = ParameterHelper.ConvertValue(m.Price) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Money", Value = ParameterHelper.ConvertValue(m.Money) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateDate", Value = ParameterHelper.ConvertValue(m.CreateDate) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateUserId", Value = ParameterHelper.ConvertValue(m.CreateUserId) });


            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override int InsertIdentityId(HistoryUserLogBrowseVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = INSERT + "; select @@Identity";

         command.Parameters.Add(new SqlParameter() { ParameterName = "@Time", Value = ParameterHelper.ConvertValue(m.Time) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@AdId", Value = ParameterHelper.ConvertValue(m.AdId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@UserId", Value = ParameterHelper.ConvertValue(m.UserId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@PvCount", Value = ParameterHelper.ConvertValue(m.PvCount) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@UvCount", Value = ParameterHelper.ConvertValue(m.UvCount) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@IpCount", Value = ParameterHelper.ConvertValue(m.IpCount) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Price", Value = ParameterHelper.ConvertValue(m.Price) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Money", Value = ParameterHelper.ConvertValue(m.Money) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateDate", Value = ParameterHelper.ConvertValue(m.CreateDate) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateUserId", Value = ParameterHelper.ConvertValue(m.CreateUserId) });


            var result = DbProxyFactory.Instance.Proxy.ExecuteScalar(command);

            return int.Parse(result.ToString());
        }
    }
}
