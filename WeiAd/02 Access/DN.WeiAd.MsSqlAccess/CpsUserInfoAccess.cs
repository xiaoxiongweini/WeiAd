
/*

skey edit by 2017/7/20 12:01:19

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
    public partial class CpsUserInfoAccess : CpsUserInfoInterface
    {
        #region SQL

        /// <summary>
        /// 新增
        /// </summary>
        const string INSERT = "INSERT INTO CpsUserInfo ([CpsUserId],[AdId],[CreateDate],[CreateUserId],[IsState]) VALUES (@CpsUserId,@AdId,@CreateDate,@CreateUserId,@IsState)";

        /// <summary>
        /// 修改
        /// </summary>
        const string EDIT = "UPDATE CpsUserInfo SET [CpsUserId]=@CpsUserId,[AdId]=@AdId,[CreateDate]=@CreateDate,[CreateUserId]=@CreateUserId,[IsState]=@IsState WHERE [Id]=@Id";

        /// <summary>
        /// 删除
        /// </summary>
        const string DELETE = "DELETE FROM CpsUserInfo";

        /// <summary>
        /// 加载数据
        /// </summary>
        const string LOAD = "SELECT * FROM CpsUserInfo @WHERE @ORDER";

        /// <summary>
        /// 分页查询
        /// </summary>
        const string QUERYPAGE = "SELECT TOP @PAGESIZE * FROM [CpsUserInfo] @WHERE AND Id NOT IN (SELECT TOP @PTOP Id FROM [CpsUserInfo] @WHERE @ORDER)  @ORDER";

        /// <summary>
        /// 查询记录数
        /// </summary>
        const string QUERYCOUNT = "SELECT COUNT(1) FROM CpsUserInfo";


        #endregion

        public override bool Delete(CpsUserInfoPara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            command.CommandText = DELETE + where;

            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override bool Edit(CpsUserInfoVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = EDIT;

             command.Parameters.Add(new SqlParameter() { ParameterName = "@CpsUserId", Value = ParameterHelper.ConvertValue(m.CpsUserId) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@AdId", Value = ParameterHelper.ConvertValue(m.AdId) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateDate", Value = ParameterHelper.ConvertValue(m.CreateDate) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateUserId", Value = ParameterHelper.ConvertValue(m.CreateUserId) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@IsState", Value = ParameterHelper.ConvertValue(m.IsState) });
               command.Parameters.Add(new SqlParameter() { ParameterName = "@Id", Value = ParameterHelper.ConvertValue(m.Id) });


            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override string GetConditionByModel(CpsUserInfoVO m)
        {
            return "";
        }

        public override string GetConditionByPara(CpsUserInfoPara mp)
        {
            StringBuilder sb = new StringBuilder();

           if (mp.Id.HasValue) { sb.AppendFormat(" AND [Id]='{0}' ",mp.Id);}
           if (mp.CpsUserId.HasValue) { sb.AppendFormat(" AND [CpsUserId]='{0}' ",mp.CpsUserId);}
           if (mp.AdId.HasValue) { sb.AppendFormat(" AND [AdId]='{0}' ",mp.AdId);}
           if (mp.CreateDate.HasValue) { sb.AppendFormat(" AND [CreateDate]='{0}' ",mp.CreateDate);}
           if (mp.CreateUserId.HasValue) { sb.AppendFormat(" AND [CreateUserId]='{0}' ",mp.CreateUserId);}
           if (mp.IsState.HasValue) { sb.AppendFormat(" AND [IsState]='{0}' ",mp.IsState);}


            sb.Insert(0, " WHERE 1=1 ");

            return sb.ToString();
        }

        public override List<CpsUserInfoVO> GetModels(ref CpsUserInfoPara mp)
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

            List<CpsUserInfoVO> list = new List<CpsUserInfoVO>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(new CpsUserInfoVO(table.Rows[i]));
            }

            if (!mp.Recount.HasValue)
            {
                mp.Recount = GetRecords(mp);
            }

            return list;
        }

        public override List<CpsUserInfoVO> GetModels(CpsUserInfoPara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            
			string cmd = LOAD
                .Replace("@WHERE", where)
                .Replace("@ORDER", GetOrderByPara(mp));
			command.CommandText = cmd;

            var table = DbProxyFactory.Instance.Proxy.ExecuteTable(command);

            List<CpsUserInfoVO> list = new List<CpsUserInfoVO>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(new CpsUserInfoVO(table.Rows[i]));
            }

            return list;
        }

        public override string GetOrderByModel(CpsUserInfoVO m)
        {
            return "";
        }

        public override string GetOrderByPara(CpsUserInfoPara mp)
        {
            if(!string.IsNullOrEmpty(mp.OrderBy))
            {
                return string.Format(" order by {0}", mp.OrderBy);
            }

            return "";
        }

        public override string GetOtherConditionByModel(CpsUserInfoVO m)
        {
            return "";
        }

        public override string GetOtherConditionByPara(CpsUserInfoPara mp)
        {
            return "";
        }

        public override int GetRecords(CpsUserInfoPara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            command.CommandText = QUERYCOUNT + where;

            var result = DbProxyFactory.Instance.Proxy.ExecuteScalar(command);

            return int.Parse(result.ToString());
        }

        public override CpsUserInfoVO GetSingle(CpsUserInfoPara mp)
        {
            var list = GetModels(mp);

            if (list.Count == 1)
                return list[0];

            return null;
        }

        public override bool Insert(CpsUserInfoVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = INSERT;
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CpsUserId", Value = ParameterHelper.ConvertValue(m.CpsUserId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@AdId", Value = ParameterHelper.ConvertValue(m.AdId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateDate", Value = ParameterHelper.ConvertValue(m.CreateDate) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateUserId", Value = ParameterHelper.ConvertValue(m.CreateUserId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@IsState", Value = ParameterHelper.ConvertValue(m.IsState) });


            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override int InsertIdentityId(CpsUserInfoVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = INSERT + "; select @@Identity";

         command.Parameters.Add(new SqlParameter() { ParameterName = "@CpsUserId", Value = ParameterHelper.ConvertValue(m.CpsUserId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@AdId", Value = ParameterHelper.ConvertValue(m.AdId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateDate", Value = ParameterHelper.ConvertValue(m.CreateDate) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateUserId", Value = ParameterHelper.ConvertValue(m.CreateUserId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@IsState", Value = ParameterHelper.ConvertValue(m.IsState) });


            var result = DbProxyFactory.Instance.Proxy.ExecuteScalar(command);

            return int.Parse(result.ToString());
        }
    }
}
