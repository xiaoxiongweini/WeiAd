
/*

skey edit by 2017/7/17 16:02:28

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
    public partial class VirAdLogBrowseAccess : VirAdLogBrowseInterface
    {
        #region SQL

        /// <summary>
        /// 新增
        /// </summary>
        const string INSERT = "INSERT INTO VirAdLogBrowse ([Name],[ShowCount],[ClickCount],[VaildClickCount],[IpCount],[CreateDate],[CreateUserId]) VALUES (@Name,@ShowCount,@ClickCount,@VaildClickCount,@IpCount,@CreateDate,@CreateUserId)";

        /// <summary>
        /// 修改
        /// </summary>
        const string EDIT = "UPDATE VirAdLogBrowse SET [Name]=@Name,[ShowCount]=@ShowCount,[ClickCount]=@ClickCount,[VaildClickCount]=@VaildClickCount,[IpCount]=@IpCount,[CreateDate]=@CreateDate,[CreateUserId]=@CreateUserId WHERE [Id]=@Id";

        /// <summary>
        /// 删除
        /// </summary>
        const string DELETE = "DELETE FROM VirAdLogBrowse";

        /// <summary>
        /// 加载数据
        /// </summary>
        const string LOAD = "SELECT * FROM VirAdLogBrowse @WHERE @ORDER";

        /// <summary>
        /// 分页查询
        /// </summary>
        const string QUERYPAGE = "SELECT TOP @PAGESIZE * FROM [VirAdLogBrowse] @WHERE AND Id NOT IN (SELECT TOP @PTOP Id FROM [VirAdLogBrowse] @WHERE @ORDER)  @ORDER";

        /// <summary>
        /// 查询记录数
        /// </summary>
        const string QUERYCOUNT = "SELECT COUNT(1) FROM VirAdLogBrowse";


        #endregion

        public override bool Delete(VirAdLogBrowsePara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            command.CommandText = DELETE + where;

            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override bool Edit(VirAdLogBrowseVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = EDIT;

             command.Parameters.Add(new SqlParameter() { ParameterName = "@Name", Value = ParameterHelper.ConvertValue(m.Name) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@ShowCount", Value = ParameterHelper.ConvertValue(m.ShowCount) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@ClickCount", Value = ParameterHelper.ConvertValue(m.ClickCount) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@VaildClickCount", Value = ParameterHelper.ConvertValue(m.VaildClickCount) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@IpCount", Value = ParameterHelper.ConvertValue(m.IpCount) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateDate", Value = ParameterHelper.ConvertValue(m.CreateDate) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateUserId", Value = ParameterHelper.ConvertValue(m.CreateUserId) });
               command.Parameters.Add(new SqlParameter() { ParameterName = "@Id", Value = ParameterHelper.ConvertValue(m.Id) });


            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override string GetConditionByModel(VirAdLogBrowseVO m)
        {
            return "";
        }

        public override string GetConditionByPara(VirAdLogBrowsePara mp)
        {
            StringBuilder sb = new StringBuilder();

           if (mp.Id.HasValue) { sb.AppendFormat(" AND [Id]='{0}' ",mp.Id);}
           if (mp.Name.HasValue) { sb.AppendFormat(" AND [Name]='{0}' ",mp.Name);}
           if (mp.ShowCount.HasValue) { sb.AppendFormat(" AND [ShowCount]='{0}' ",mp.ShowCount);}
           if (mp.ClickCount.HasValue) { sb.AppendFormat(" AND [ClickCount]='{0}' ",mp.ClickCount);}
           if (mp.VaildClickCount.HasValue) { sb.AppendFormat(" AND [VaildClickCount]='{0}' ",mp.VaildClickCount);}
           if (mp.IpCount.HasValue) { sb.AppendFormat(" AND [IpCount]='{0}' ",mp.IpCount);}
           if (mp.CreateDate.HasValue) { sb.AppendFormat(" AND [CreateDate]='{0}' ",mp.CreateDate);}
           if (mp.CreateUserId.HasValue) { sb.AppendFormat(" AND [CreateUserId]='{0}' ",mp.CreateUserId);}


            sb.Insert(0, " WHERE 1=1 ");

            return sb.ToString();
        }

        public override List<VirAdLogBrowseVO> GetModels(ref VirAdLogBrowsePara mp)
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

            List<VirAdLogBrowseVO> list = new List<VirAdLogBrowseVO>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(new VirAdLogBrowseVO(table.Rows[i]));
            }

            if (!mp.Recount.HasValue)
            {
                mp.Recount = GetRecords(mp);
            }

            return list;
        }

        public override List<VirAdLogBrowseVO> GetModels(VirAdLogBrowsePara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            
			string cmd = LOAD
                .Replace("@WHERE", where)
                .Replace("@ORDER", GetOrderByPara(mp));
			command.CommandText = cmd;

            var table = DbProxyFactory.Instance.Proxy.ExecuteTable(command);

            List<VirAdLogBrowseVO> list = new List<VirAdLogBrowseVO>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(new VirAdLogBrowseVO(table.Rows[i]));
            }

            return list;
        }

        public override string GetOrderByModel(VirAdLogBrowseVO m)
        {
            return "";
        }

        public override string GetOrderByPara(VirAdLogBrowsePara mp)
        {
            if(!string.IsNullOrEmpty(mp.OrderBy))
            {
                return string.Format(" order by {0}", mp.OrderBy);
            }

            return "";
        }

        public override string GetOtherConditionByModel(VirAdLogBrowseVO m)
        {
            return "";
        }

        public override string GetOtherConditionByPara(VirAdLogBrowsePara mp)
        {
            return "";
        }

        public override int GetRecords(VirAdLogBrowsePara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            command.CommandText = QUERYCOUNT + where;

            var result = DbProxyFactory.Instance.Proxy.ExecuteScalar(command);

            return int.Parse(result.ToString());
        }

        public override VirAdLogBrowseVO GetSingle(VirAdLogBrowsePara mp)
        {
            var list = GetModels(mp);

            if (list.Count == 1)
                return list[0];

            return null;
        }

        public override bool Insert(VirAdLogBrowseVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = INSERT;
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Name", Value = ParameterHelper.ConvertValue(m.Name) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@ShowCount", Value = ParameterHelper.ConvertValue(m.ShowCount) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@ClickCount", Value = ParameterHelper.ConvertValue(m.ClickCount) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@VaildClickCount", Value = ParameterHelper.ConvertValue(m.VaildClickCount) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@IpCount", Value = ParameterHelper.ConvertValue(m.IpCount) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateDate", Value = ParameterHelper.ConvertValue(m.CreateDate) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateUserId", Value = ParameterHelper.ConvertValue(m.CreateUserId) });


            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override int InsertIdentityId(VirAdLogBrowseVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = INSERT + "; select @@Identity";

         command.Parameters.Add(new SqlParameter() { ParameterName = "@Name", Value = ParameterHelper.ConvertValue(m.Name) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@ShowCount", Value = ParameterHelper.ConvertValue(m.ShowCount) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@ClickCount", Value = ParameterHelper.ConvertValue(m.ClickCount) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@VaildClickCount", Value = ParameterHelper.ConvertValue(m.VaildClickCount) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@IpCount", Value = ParameterHelper.ConvertValue(m.IpCount) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateDate", Value = ParameterHelper.ConvertValue(m.CreateDate) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateUserId", Value = ParameterHelper.ConvertValue(m.CreateUserId) });


            var result = DbProxyFactory.Instance.Proxy.ExecuteScalar(command);

            return int.Parse(result.ToString());
        }
    }
}
