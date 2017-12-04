
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
    public partial class UserFinanceHistoryAccess : UserFinanceHistoryInterface
    {
        #region SQL

        /// <summary>
        /// 新增
        /// </summary>
        const string INSERT = "INSERT INTO UserFinanceHistory ([UserId],[RechargeType],[Money],[MoneyType],[CreateDate],[CreateUserId]) VALUES (@UserId,@RechargeType,@Money,@MoneyType,@CreateDate,@CreateUserId)";

        /// <summary>
        /// 修改
        /// </summary>
        const string EDIT = "UPDATE UserFinanceHistory SET [UserId]=@UserId,[RechargeType]=@RechargeType,[Money]=@Money,[MoneyType]=@MoneyType,[CreateDate]=@CreateDate,[CreateUserId]=@CreateUserId WHERE [Id]=@Id";

        /// <summary>
        /// 删除
        /// </summary>
        const string DELETE = "DELETE FROM UserFinanceHistory";

        /// <summary>
        /// 加载数据
        /// </summary>
        const string LOAD = "SELECT * FROM UserFinanceHistory @WHERE @ORDER";

        /// <summary>
        /// 分页查询
        /// </summary>
        const string QUERYPAGE = "SELECT TOP @PAGESIZE * FROM [UserFinanceHistory] @WHERE AND Id NOT IN (SELECT TOP @PTOP Id FROM [UserFinanceHistory] @WHERE @ORDER)  @ORDER";

        /// <summary>
        /// 查询记录数
        /// </summary>
        const string QUERYCOUNT = "SELECT COUNT(1) FROM UserFinanceHistory";


        #endregion

        public override bool Delete(UserFinanceHistoryPara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            command.CommandText = DELETE + where;

            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override bool Edit(UserFinanceHistoryVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = EDIT;

             command.Parameters.Add(new SqlParameter() { ParameterName = "@UserId", Value = ParameterHelper.ConvertValue(m.UserId) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@RechargeType", Value = ParameterHelper.ConvertValue(m.RechargeType) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@Money", Value = ParameterHelper.ConvertValue(m.Money) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@MoneyType", Value = ParameterHelper.ConvertValue(m.MoneyType) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateDate", Value = ParameterHelper.ConvertValue(m.CreateDate) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateUserId", Value = ParameterHelper.ConvertValue(m.CreateUserId) });
               command.Parameters.Add(new SqlParameter() { ParameterName = "@Id", Value = ParameterHelper.ConvertValue(m.Id) });


            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override string GetConditionByModel(UserFinanceHistoryVO m)
        {
            return "";
        }

        public override string GetConditionByPara(UserFinanceHistoryPara mp)
        {
            StringBuilder sb = new StringBuilder();

           if (mp.Id.HasValue) { sb.AppendFormat(" AND [Id]='{0}' ",mp.Id);}
           if (mp.UserId.HasValue) { sb.AppendFormat(" AND [UserId]='{0}' ",mp.UserId);}
           if (mp.RechargeType.HasValue) { sb.AppendFormat(" AND [RechargeType]='{0}' ",mp.RechargeType);}
           if (mp.Money.HasValue) { sb.AppendFormat(" AND [Money]='{0}' ",mp.Money);}
           if (mp.MoneyType.HasValue) { sb.AppendFormat(" AND [MoneyType]='{0}' ",mp.MoneyType);}
           if (mp.CreateDate.HasValue) { sb.AppendFormat(" AND [CreateDate]='{0}' ",mp.CreateDate);}
           if (mp.CreateUserId.HasValue) { sb.AppendFormat(" AND [CreateUserId]='{0}' ",mp.CreateUserId);}


            sb.Insert(0, " WHERE 1=1 ");

            return sb.ToString();
        }

        public override List<UserFinanceHistoryVO> GetModels(ref UserFinanceHistoryPara mp)
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

            List<UserFinanceHistoryVO> list = new List<UserFinanceHistoryVO>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(new UserFinanceHistoryVO(table.Rows[i]));
            }

            if (!mp.Recount.HasValue)
            {
                mp.Recount = GetRecords(mp);
            }

            return list;
        }

        public override List<UserFinanceHistoryVO> GetModels(UserFinanceHistoryPara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            
			string cmd = LOAD
                .Replace("@WHERE", where)
                .Replace("@ORDER", GetOrderByPara(mp));
			command.CommandText = cmd;

            var table = DbProxyFactory.Instance.Proxy.ExecuteTable(command);

            List<UserFinanceHistoryVO> list = new List<UserFinanceHistoryVO>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(new UserFinanceHistoryVO(table.Rows[i]));
            }

            return list;
        }

        public override string GetOrderByModel(UserFinanceHistoryVO m)
        {
            return "";
        }

        public override string GetOrderByPara(UserFinanceHistoryPara mp)
        {
            if(!string.IsNullOrEmpty(mp.OrderBy))
            {
                return string.Format(" order by {0}", mp.OrderBy);
            }

            return "";
        }

        public override string GetOtherConditionByModel(UserFinanceHistoryVO m)
        {
            return "";
        }

        public override string GetOtherConditionByPara(UserFinanceHistoryPara mp)
        {
            return "";
        }

        public override int GetRecords(UserFinanceHistoryPara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            command.CommandText = QUERYCOUNT + where;

            var result = DbProxyFactory.Instance.Proxy.ExecuteScalar(command);

            return int.Parse(result.ToString());
        }

        public override UserFinanceHistoryVO GetSingle(UserFinanceHistoryPara mp)
        {
            var list = GetModels(mp);

            if (list.Count == 1)
                return list[0];

            return null;
        }

        public override bool Insert(UserFinanceHistoryVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = INSERT;
         command.Parameters.Add(new SqlParameter() { ParameterName = "@UserId", Value = ParameterHelper.ConvertValue(m.UserId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@RechargeType", Value = ParameterHelper.ConvertValue(m.RechargeType) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Money", Value = ParameterHelper.ConvertValue(m.Money) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@MoneyType", Value = ParameterHelper.ConvertValue(m.MoneyType) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateDate", Value = ParameterHelper.ConvertValue(m.CreateDate) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateUserId", Value = ParameterHelper.ConvertValue(m.CreateUserId) });


            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override int InsertIdentityId(UserFinanceHistoryVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = INSERT + "; select @@Identity";

         command.Parameters.Add(new SqlParameter() { ParameterName = "@UserId", Value = ParameterHelper.ConvertValue(m.UserId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@RechargeType", Value = ParameterHelper.ConvertValue(m.RechargeType) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Money", Value = ParameterHelper.ConvertValue(m.Money) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@MoneyType", Value = ParameterHelper.ConvertValue(m.MoneyType) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateDate", Value = ParameterHelper.ConvertValue(m.CreateDate) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateUserId", Value = ParameterHelper.ConvertValue(m.CreateUserId) });


            var result = DbProxyFactory.Instance.Proxy.ExecuteScalar(command);

            return int.Parse(result.ToString());
        }
    }
}
