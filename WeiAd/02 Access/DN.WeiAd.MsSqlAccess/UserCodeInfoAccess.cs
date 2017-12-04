
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
    public partial class UserCodeInfoAccess : UserCodeInfoInterface
    {
        #region SQL

        /// <summary>
        /// 新增
        /// </summary>
        const string INSERT = "INSERT INTO UserCodeInfo ([Name],[UserId],[TypeId],[CodeContent],[CreateDate]) VALUES (@Name,@UserId,@TypeId,@CodeContent,@CreateDate)";

        /// <summary>
        /// 修改
        /// </summary>
        const string EDIT = "UPDATE UserCodeInfo SET [Name]=@Name,[UserId]=@UserId,[TypeId]=@TypeId,[CodeContent]=@CodeContent,[CreateDate]=@CreateDate WHERE [Id]=@Id";

        /// <summary>
        /// 删除
        /// </summary>
        const string DELETE = "DELETE FROM UserCodeInfo";

        /// <summary>
        /// 加载数据
        /// </summary>
        const string LOAD = "SELECT * FROM UserCodeInfo @WHERE @ORDER";

        /// <summary>
        /// 分页查询
        /// </summary>
        const string QUERYPAGE = "SELECT TOP @PAGESIZE * FROM [UserCodeInfo] @WHERE AND Id NOT IN (SELECT TOP @PTOP Id FROM [UserCodeInfo] @WHERE @ORDER)  @ORDER";

        /// <summary>
        /// 查询记录数
        /// </summary>
        const string QUERYCOUNT = "SELECT COUNT(1) FROM UserCodeInfo";


        #endregion

        public override bool Delete(UserCodeInfoPara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            command.CommandText = DELETE + where;

            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override bool Edit(UserCodeInfoVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = EDIT;

             command.Parameters.Add(new SqlParameter() { ParameterName = "@Name", Value = ParameterHelper.ConvertValue(m.Name) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@UserId", Value = ParameterHelper.ConvertValue(m.UserId) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@TypeId", Value = ParameterHelper.ConvertValue(m.TypeId) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@CodeContent", Value = ParameterHelper.ConvertValue(m.CodeContent) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateDate", Value = ParameterHelper.ConvertValue(m.CreateDate) });
               command.Parameters.Add(new SqlParameter() { ParameterName = "@Id", Value = ParameterHelper.ConvertValue(m.Id) });


            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override string GetConditionByModel(UserCodeInfoVO m)
        {
            return "";
        }

        public override string GetConditionByPara(UserCodeInfoPara mp)
        {
            StringBuilder sb = new StringBuilder();

           if (mp.Id.HasValue) { sb.AppendFormat(" AND [Id]='{0}' ",mp.Id);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.Name))){ sb.AppendFormat(" AND [Name]='{0}' ",mp.Name);}
           if (mp.UserId.HasValue) { sb.AppendFormat(" AND [UserId]='{0}' ",mp.UserId);}
           if (mp.TypeId.HasValue) { sb.AppendFormat(" AND [TypeId]='{0}' ",mp.TypeId);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.CodeContent))){ sb.AppendFormat(" AND [CodeContent]='{0}' ",mp.CodeContent);}
           if (mp.CreateDate.HasValue) { sb.AppendFormat(" AND [CreateDate]='{0}' ",mp.CreateDate);}


            sb.Insert(0, " WHERE 1=1 ");

            return sb.ToString();
        }

        public override List<UserCodeInfoVO> GetModels(ref UserCodeInfoPara mp)
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

            List<UserCodeInfoVO> list = new List<UserCodeInfoVO>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(new UserCodeInfoVO(table.Rows[i]));
            }

            if (!mp.Recount.HasValue)
            {
                mp.Recount = GetRecords(mp);
            }

            return list;
        }

        public override List<UserCodeInfoVO> GetModels(UserCodeInfoPara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            
			string cmd = LOAD
                .Replace("@WHERE", where)
                .Replace("@ORDER", GetOrderByPara(mp));
			command.CommandText = cmd;

            var table = DbProxyFactory.Instance.Proxy.ExecuteTable(command);

            List<UserCodeInfoVO> list = new List<UserCodeInfoVO>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(new UserCodeInfoVO(table.Rows[i]));
            }

            return list;
        }

        public override string GetOrderByModel(UserCodeInfoVO m)
        {
            return "";
        }

        public override string GetOrderByPara(UserCodeInfoPara mp)
        {
            if(!string.IsNullOrEmpty(mp.OrderBy))
            {
                return string.Format(" order by {0}", mp.OrderBy);
            }

            return "";
        }

        public override string GetOtherConditionByModel(UserCodeInfoVO m)
        {
            return "";
        }

        public override string GetOtherConditionByPara(UserCodeInfoPara mp)
        {
            return "";
        }

        public override int GetRecords(UserCodeInfoPara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            command.CommandText = QUERYCOUNT + where;

            var result = DbProxyFactory.Instance.Proxy.ExecuteScalar(command);

            return int.Parse(result.ToString());
        }

        public override UserCodeInfoVO GetSingle(UserCodeInfoPara mp)
        {
            var list = GetModels(mp);

            if (list.Count == 1)
                return list[0];

            return null;
        }

        public override bool Insert(UserCodeInfoVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = INSERT;
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Name", Value = ParameterHelper.ConvertValue(m.Name) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@UserId", Value = ParameterHelper.ConvertValue(m.UserId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@TypeId", Value = ParameterHelper.ConvertValue(m.TypeId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CodeContent", Value = ParameterHelper.ConvertValue(m.CodeContent) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateDate", Value = ParameterHelper.ConvertValue(m.CreateDate) });


            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override int InsertIdentityId(UserCodeInfoVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = INSERT + "; select @@Identity";

         command.Parameters.Add(new SqlParameter() { ParameterName = "@Name", Value = ParameterHelper.ConvertValue(m.Name) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@UserId", Value = ParameterHelper.ConvertValue(m.UserId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@TypeId", Value = ParameterHelper.ConvertValue(m.TypeId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CodeContent", Value = ParameterHelper.ConvertValue(m.CodeContent) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateDate", Value = ParameterHelper.ConvertValue(m.CreateDate) });


            var result = DbProxyFactory.Instance.Proxy.ExecuteScalar(command);

            return int.Parse(result.ToString());
        }
    }
}
