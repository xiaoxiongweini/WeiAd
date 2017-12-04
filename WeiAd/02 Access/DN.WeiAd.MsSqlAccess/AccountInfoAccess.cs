
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
    public partial class AccountInfoAccess : AccountInfoInterface
    {
        #region SQL

        /// <summary>
        /// 新增
        /// </summary>
        const string INSERT = "INSERT INTO AccountInfo ([UserName],[NickName],[Email],[Phone],[UserType],[UserPwd],[UserImg],[RegDate],[RegIp],[IsLock],[LastLoginDate],[AccountType],[OpenId],[ConsumptionMoney],[Money],[MoneyFree],[MoneyCount],[LastMoneyDate]) VALUES (@UserName,@NickName,@Email,@Phone,@UserType,@UserPwd,@UserImg,@RegDate,@RegIp,@IsLock,@LastLoginDate,@AccountType,@OpenId,@ConsumptionMoney,@Money,@MoneyFree,@MoneyCount,@LastMoneyDate)";

        /// <summary>
        /// 修改
        /// </summary>
        const string EDIT = "UPDATE AccountInfo SET [UserName]=@UserName,[NickName]=@NickName,[Email]=@Email,[Phone]=@Phone,[UserType]=@UserType,[UserPwd]=@UserPwd,[UserImg]=@UserImg,[RegDate]=@RegDate,[RegIp]=@RegIp,[IsLock]=@IsLock,[LastLoginDate]=@LastLoginDate,[AccountType]=@AccountType,[OpenId]=@OpenId,[ConsumptionMoney]=@ConsumptionMoney,[Money]=@Money,[MoneyFree]=@MoneyFree,[MoneyCount]=@MoneyCount,[LastMoneyDate]=@LastMoneyDate WHERE [Id]=@Id";

        /// <summary>
        /// 删除
        /// </summary>
        const string DELETE = "DELETE FROM AccountInfo";

        /// <summary>
        /// 加载数据
        /// </summary>
        const string LOAD = "SELECT * FROM AccountInfo @WHERE @ORDER";

        /// <summary>
        /// 分页查询
        /// </summary>
        const string QUERYPAGE = "SELECT TOP @PAGESIZE * FROM [AccountInfo] @WHERE AND Id NOT IN (SELECT TOP @PTOP Id FROM [AccountInfo] @WHERE @ORDER)  @ORDER";

        /// <summary>
        /// 查询记录数
        /// </summary>
        const string QUERYCOUNT = "SELECT COUNT(1) FROM AccountInfo";


        #endregion

        public override bool Delete(AccountInfoPara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            command.CommandText = DELETE + where;

            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override bool Edit(AccountInfoVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = EDIT;

            command.Parameters.Add(new SqlParameter() { ParameterName = "@UserName", Value = ParameterHelper.ConvertValue(m.UserName) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@NickName", Value = ParameterHelper.ConvertValue(m.NickName) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@Email", Value = ParameterHelper.ConvertValue(m.Email) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@Phone", Value = ParameterHelper.ConvertValue(m.Phone) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@UserType", Value = ParameterHelper.ConvertValue(m.UserType) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@UserPwd", Value = ParameterHelper.ConvertValue(m.UserPwd) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@UserImg", Value = ParameterHelper.ConvertValue(m.UserImg) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@RegDate", Value = ParameterHelper.ConvertValue(m.RegDate) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@RegIp", Value = ParameterHelper.ConvertValue(m.RegIp) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@IsLock", Value = ParameterHelper.ConvertValue(m.IsLock) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@LastLoginDate", Value = ParameterHelper.ConvertValue(m.LastLoginDate) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@AccountType", Value = ParameterHelper.ConvertValue(m.AccountType) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@OpenId", Value = ParameterHelper.ConvertValue(m.OpenId) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@ConsumptionMoney", Value = ParameterHelper.ConvertValue(m.ConsumptionMoney) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@Money", Value = ParameterHelper.ConvertValue(m.Money) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@MoneyFree", Value = ParameterHelper.ConvertValue(m.MoneyFree) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@MoneyCount", Value = ParameterHelper.ConvertValue(m.MoneyCount) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@LastMoneyDate", Value = ParameterHelper.ConvertValue(m.LastMoneyDate) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@Id", Value = ParameterHelper.ConvertValue(m.Id) });


            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override string GetConditionByModel(AccountInfoVO m)
        {
            return "";
        }

        public override string GetConditionByPara(AccountInfoPara mp)
        {
            StringBuilder sb = new StringBuilder();

            if (mp.Id.HasValue) { sb.AppendFormat(" AND [Id]='{0}' ", mp.Id); }
            if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.UserName))) { sb.AppendFormat(" AND [UserName]='{0}' ", mp.UserName); }
            if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.NickName))) { sb.AppendFormat(" AND [NickName]='{0}' ", mp.NickName); }
            if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.Email))) { sb.AppendFormat(" AND [Email]='{0}' ", mp.Email); }
            if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.Phone))) { sb.AppendFormat(" AND [Phone]='{0}' ", mp.Phone); }
            if (mp.UserType.HasValue) { sb.AppendFormat(" AND [UserType]='{0}' ", mp.UserType); }
            if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.UserPwd))) { sb.AppendFormat(" AND [UserPwd]='{0}' ", mp.UserPwd); }
            if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.UserImg))) { sb.AppendFormat(" AND [UserImg]='{0}' ", mp.UserImg); }
            if (mp.RegDate.HasValue) { sb.AppendFormat(" AND [RegDate]='{0}' ", mp.RegDate); }
            if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.RegIp))) { sb.AppendFormat(" AND [RegIp]='{0}' ", mp.RegIp); }
            if (mp.IsLock.HasValue) { sb.AppendFormat(" AND [IsLock]='{0}' ", mp.IsLock); }
            if (mp.LastLoginDate.HasValue) { sb.AppendFormat(" AND [LastLoginDate]='{0}' ", mp.LastLoginDate); }
            if (mp.AccountType.HasValue) { sb.AppendFormat(" AND [AccountType]='{0}' ", mp.AccountType); }
            if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.OpenId))) { sb.AppendFormat(" AND [OpenId]='{0}' ", mp.OpenId); }
            if (mp.ConsumptionMoney.HasValue) { sb.AppendFormat(" AND [ConsumptionMoney]='{0}' ", mp.ConsumptionMoney); }
            if (mp.Money.HasValue) { sb.AppendFormat(" AND [Money]='{0}' ", mp.Money); }
            if (mp.MoneyFree.HasValue) { sb.AppendFormat(" AND [MoneyFree]='{0}' ", mp.MoneyFree); }
            if (mp.MoneyCount.HasValue) { sb.AppendFormat(" AND [MoneyCount]='{0}' ", mp.MoneyCount); }
            if (mp.LastMoneyDate.HasValue) { sb.AppendFormat(" AND [LastMoneyDate]='{0}' ", mp.LastMoneyDate); }

            sb.AppendLine(AccountInfoAccessOther.GetConditionByPara(mp));

            sb.Insert(0, " WHERE 1=1 ");

            return sb.ToString();
        }

        public override List<AccountInfoVO> GetModels(ref AccountInfoPara mp)
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

            List<AccountInfoVO> list = new List<AccountInfoVO>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(new AccountInfoVO(table.Rows[i]));
            }

            if (!mp.Recount.HasValue)
            {
                mp.Recount = GetRecords(mp);
            }

            return list;
        }

        public override List<AccountInfoVO> GetModels(AccountInfoPara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();

            string cmd = LOAD
                .Replace("@WHERE", where)
                .Replace("@ORDER", GetOrderByPara(mp));
            command.CommandText = cmd;

            var table = DbProxyFactory.Instance.Proxy.ExecuteTable(command);

            List<AccountInfoVO> list = new List<AccountInfoVO>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(new AccountInfoVO(table.Rows[i]));
            }

            return list;
        }

        public override string GetOrderByModel(AccountInfoVO m)
        {
            return "";
        }

        public override string GetOrderByPara(AccountInfoPara mp)
        {
            if (!string.IsNullOrEmpty(mp.OrderBy))
            {
                return string.Format(" order by {0}", mp.OrderBy);
            }

            return "";
        }

        public override string GetOtherConditionByModel(AccountInfoVO m)
        {
            return "";
        }

        public override string GetOtherConditionByPara(AccountInfoPara mp)
        {
            return "";
        }

        public override int GetRecords(AccountInfoPara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            command.CommandText = QUERYCOUNT + where;

            var result = DbProxyFactory.Instance.Proxy.ExecuteScalar(command);

            return int.Parse(result.ToString());
        }

        public override AccountInfoVO GetSingle(AccountInfoPara mp)
        {
            var list = GetModels(mp);

            if (list.Count == 1)
                return list[0];

            return null;
        }

        public override bool Insert(AccountInfoVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = INSERT;
            command.Parameters.Add(new SqlParameter() { ParameterName = "@UserName", Value = ParameterHelper.ConvertValue(m.UserName) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@NickName", Value = ParameterHelper.ConvertValue(m.NickName) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@Email", Value = ParameterHelper.ConvertValue(m.Email) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@Phone", Value = ParameterHelper.ConvertValue(m.Phone) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@UserType", Value = ParameterHelper.ConvertValue(m.UserType) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@UserPwd", Value = ParameterHelper.ConvertValue(m.UserPwd) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@UserImg", Value = ParameterHelper.ConvertValue(m.UserImg) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@RegDate", Value = ParameterHelper.ConvertValue(m.RegDate) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@RegIp", Value = ParameterHelper.ConvertValue(m.RegIp) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@IsLock", Value = ParameterHelper.ConvertValue(m.IsLock) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@LastLoginDate", Value = ParameterHelper.ConvertValue(m.LastLoginDate) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@AccountType", Value = ParameterHelper.ConvertValue(m.AccountType) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@OpenId", Value = ParameterHelper.ConvertValue(m.OpenId) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@ConsumptionMoney", Value = ParameterHelper.ConvertValue(m.ConsumptionMoney) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@Money", Value = ParameterHelper.ConvertValue(m.Money) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@MoneyFree", Value = ParameterHelper.ConvertValue(m.MoneyFree) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@MoneyCount", Value = ParameterHelper.ConvertValue(m.MoneyCount) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@LastMoneyDate", Value = ParameterHelper.ConvertValue(m.LastMoneyDate) });


            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override int InsertIdentityId(AccountInfoVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = INSERT + "; select @@Identity";

            command.Parameters.Add(new SqlParameter() { ParameterName = "@UserName", Value = ParameterHelper.ConvertValue(m.UserName) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@NickName", Value = ParameterHelper.ConvertValue(m.NickName) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@Email", Value = ParameterHelper.ConvertValue(m.Email) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@Phone", Value = ParameterHelper.ConvertValue(m.Phone) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@UserType", Value = ParameterHelper.ConvertValue(m.UserType) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@UserPwd", Value = ParameterHelper.ConvertValue(m.UserPwd) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@UserImg", Value = ParameterHelper.ConvertValue(m.UserImg) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@RegDate", Value = ParameterHelper.ConvertValue(m.RegDate) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@RegIp", Value = ParameterHelper.ConvertValue(m.RegIp) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@IsLock", Value = ParameterHelper.ConvertValue(m.IsLock) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@LastLoginDate", Value = ParameterHelper.ConvertValue(m.LastLoginDate) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@AccountType", Value = ParameterHelper.ConvertValue(m.AccountType) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@OpenId", Value = ParameterHelper.ConvertValue(m.OpenId) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@ConsumptionMoney", Value = ParameterHelper.ConvertValue(m.ConsumptionMoney) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@Money", Value = ParameterHelper.ConvertValue(m.Money) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@MoneyFree", Value = ParameterHelper.ConvertValue(m.MoneyFree) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@MoneyCount", Value = ParameterHelper.ConvertValue(m.MoneyCount) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@LastMoneyDate", Value = ParameterHelper.ConvertValue(m.LastMoneyDate) });


            var result = DbProxyFactory.Instance.Proxy.ExecuteScalar(command);

            return int.Parse(result.ToString());
        }
    }
}
