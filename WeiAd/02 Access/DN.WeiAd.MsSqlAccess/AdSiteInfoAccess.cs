
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
    public partial class AdSiteInfoAccess : AdSiteInfoInterface
    {
        #region SQL

        /// <summary>
        /// 新增
        /// </summary>
        const string INSERT = "INSERT INTO AdSiteInfo ([Name],[Desc],[WebSite],[UserId],[CreateDate],[LastDate],[PlatformType],[Contact]) VALUES (@Name,@Desc,@WebSite,@UserId,@CreateDate,@LastDate,@PlatformType,@Contact)";

        /// <summary>
        /// 修改
        /// </summary>
        const string EDIT = "UPDATE AdSiteInfo SET [Name]=@Name,[Desc]=@Desc,[WebSite]=@WebSite,[UserId]=@UserId,[CreateDate]=@CreateDate,[LastDate]=@LastDate,[PlatformType]=@PlatformType,[Contact]=@Contact WHERE [Id]=@Id";

        /// <summary>
        /// 删除
        /// </summary>
        const string DELETE = "DELETE FROM AdSiteInfo";

        /// <summary>
        /// 加载数据
        /// </summary>
        const string LOAD = "SELECT * FROM AdSiteInfo @WHERE @ORDER";

        /// <summary>
        /// 分页查询
        /// </summary>
        const string QUERYPAGE = "SELECT TOP @PAGESIZE * FROM [AdSiteInfo] @WHERE AND Id NOT IN (SELECT TOP @PTOP Id FROM [AdSiteInfo] @WHERE @ORDER)  @ORDER";

        /// <summary>
        /// 查询记录数
        /// </summary>
        const string QUERYCOUNT = "SELECT COUNT(1) FROM AdSiteInfo";


        #endregion

        public override bool Delete(AdSiteInfoPara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            command.CommandText = DELETE + where;

            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override bool Edit(AdSiteInfoVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = EDIT;

             command.Parameters.Add(new SqlParameter() { ParameterName = "@Name", Value = ParameterHelper.ConvertValue(m.Name) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@Desc", Value = ParameterHelper.ConvertValue(m.Desc) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@WebSite", Value = ParameterHelper.ConvertValue(m.WebSite) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@UserId", Value = ParameterHelper.ConvertValue(m.UserId) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateDate", Value = ParameterHelper.ConvertValue(m.CreateDate) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@LastDate", Value = ParameterHelper.ConvertValue(m.LastDate) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@PlatformType", Value = ParameterHelper.ConvertValue(m.PlatformType) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@Contact", Value = ParameterHelper.ConvertValue(m.Contact) });
               command.Parameters.Add(new SqlParameter() { ParameterName = "@Id", Value = ParameterHelper.ConvertValue(m.Id) });


            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override string GetConditionByModel(AdSiteInfoVO m)
        {
            return "";
        }

        public override string GetConditionByPara(AdSiteInfoPara mp)
        {
            StringBuilder sb = new StringBuilder();

           if (mp.Id.HasValue) { sb.AppendFormat(" AND [Id]='{0}' ",mp.Id);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.Name))){ sb.AppendFormat(" AND [Name]='{0}' ",mp.Name);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.Desc))){ sb.AppendFormat(" AND [Desc]='{0}' ",mp.Desc);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.WebSite))){ sb.AppendFormat(" AND [WebSite]='{0}' ",mp.WebSite);}
           if (mp.UserId.HasValue) { sb.AppendFormat(" AND [UserId]='{0}' ",mp.UserId);}
           if (mp.CreateDate.HasValue) { sb.AppendFormat(" AND [CreateDate]='{0}' ",mp.CreateDate);}
           if (mp.LastDate.HasValue) { sb.AppendFormat(" AND [LastDate]='{0}' ",mp.LastDate);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.PlatformType))){ sb.AppendFormat(" AND [PlatformType]='{0}' ",mp.PlatformType);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.Contact))){ sb.AppendFormat(" AND [Contact]='{0}' ",mp.Contact);}


            sb.Insert(0, " WHERE 1=1 ");

            return sb.ToString();
        }

        public override List<AdSiteInfoVO> GetModels(ref AdSiteInfoPara mp)
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

            List<AdSiteInfoVO> list = new List<AdSiteInfoVO>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(new AdSiteInfoVO(table.Rows[i]));
            }

            if (!mp.Recount.HasValue)
            {
                mp.Recount = GetRecords(mp);
            }

            return list;
        }

        public override List<AdSiteInfoVO> GetModels(AdSiteInfoPara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            
			string cmd = LOAD
                .Replace("@WHERE", where)
                .Replace("@ORDER", GetOrderByPara(mp));
			command.CommandText = cmd;

            var table = DbProxyFactory.Instance.Proxy.ExecuteTable(command);

            List<AdSiteInfoVO> list = new List<AdSiteInfoVO>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(new AdSiteInfoVO(table.Rows[i]));
            }

            return list;
        }

        public override string GetOrderByModel(AdSiteInfoVO m)
        {
            return "";
        }

        public override string GetOrderByPara(AdSiteInfoPara mp)
        {
            if(!string.IsNullOrEmpty(mp.OrderBy))
            {
                return string.Format(" order by {0}", mp.OrderBy);
            }

            return "";
        }

        public override string GetOtherConditionByModel(AdSiteInfoVO m)
        {
            return "";
        }

        public override string GetOtherConditionByPara(AdSiteInfoPara mp)
        {
            return "";
        }

        public override int GetRecords(AdSiteInfoPara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            command.CommandText = QUERYCOUNT + where;

            var result = DbProxyFactory.Instance.Proxy.ExecuteScalar(command);

            return int.Parse(result.ToString());
        }

        public override AdSiteInfoVO GetSingle(AdSiteInfoPara mp)
        {
            var list = GetModels(mp);

            if (list.Count == 1)
                return list[0];

            return null;
        }

        public override bool Insert(AdSiteInfoVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = INSERT;
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Name", Value = ParameterHelper.ConvertValue(m.Name) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Desc", Value = ParameterHelper.ConvertValue(m.Desc) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@WebSite", Value = ParameterHelper.ConvertValue(m.WebSite) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@UserId", Value = ParameterHelper.ConvertValue(m.UserId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateDate", Value = ParameterHelper.ConvertValue(m.CreateDate) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@LastDate", Value = ParameterHelper.ConvertValue(m.LastDate) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@PlatformType", Value = ParameterHelper.ConvertValue(m.PlatformType) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Contact", Value = ParameterHelper.ConvertValue(m.Contact) });


            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override int InsertIdentityId(AdSiteInfoVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = INSERT + "; select @@Identity";

         command.Parameters.Add(new SqlParameter() { ParameterName = "@Name", Value = ParameterHelper.ConvertValue(m.Name) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Desc", Value = ParameterHelper.ConvertValue(m.Desc) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@WebSite", Value = ParameterHelper.ConvertValue(m.WebSite) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@UserId", Value = ParameterHelper.ConvertValue(m.UserId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateDate", Value = ParameterHelper.ConvertValue(m.CreateDate) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@LastDate", Value = ParameterHelper.ConvertValue(m.LastDate) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@PlatformType", Value = ParameterHelper.ConvertValue(m.PlatformType) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Contact", Value = ParameterHelper.ConvertValue(m.Contact) });


            var result = DbProxyFactory.Instance.Proxy.ExecuteScalar(command);

            return int.Parse(result.ToString());
        }
    }
}
