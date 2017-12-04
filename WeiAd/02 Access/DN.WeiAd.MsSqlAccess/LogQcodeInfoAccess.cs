
/*

skey edit by 2017/12/4 12:00:28

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
    public partial class LogQcodeInfoAccess : LogQcodeInfoInterface
    {
        #region SQL

        /// <summary>
        /// 新增
        /// </summary>
        const string INSERT = "INSERT INTO LogQcodeInfo ([CopyText],[Url],[ClientIp],[BrowseType],[CreateDate],[Money],[IsMoney],[Time],[ClientId],[IsMobile],[ReferrerUrl],[BrowseName],[BrowseVersion],[OsName],[Country],[Area],[Region],[City],[County],[Isp],[IpSource]) VALUES (@CopyText,@Url,@ClientIp,@BrowseType,@CreateDate,@Money,@IsMoney,@Time,@ClientId,@IsMobile,@ReferrerUrl,@BrowseName,@BrowseVersion,@OsName,@Country,@Area,@Region,@City,@County,@Isp,@IpSource)";

        /// <summary>
        /// 修改
        /// </summary>
        const string EDIT = "UPDATE LogQcodeInfo SET [CopyText]=@CopyText,[Url]=@Url,[ClientIp]=@ClientIp,[BrowseType]=@BrowseType,[CreateDate]=@CreateDate,[Money]=@Money,[IsMoney]=@IsMoney,[Time]=@Time,[ClientId]=@ClientId,[IsMobile]=@IsMobile,[ReferrerUrl]=@ReferrerUrl,[BrowseName]=@BrowseName,[BrowseVersion]=@BrowseVersion,[OsName]=@OsName,[Country]=@Country,[Area]=@Area,[Region]=@Region,[City]=@City,[County]=@County,[Isp]=@Isp,[IpSource]=@IpSource WHERE [Id]=@Id";

        /// <summary>
        /// 删除
        /// </summary>
        const string DELETE = "DELETE FROM LogQcodeInfo";

        /// <summary>
        /// 加载数据
        /// </summary>
        const string LOAD = "SELECT * FROM LogQcodeInfo @WHERE @ORDER";

        /// <summary>
        /// 分页查询
        /// </summary>
        const string QUERYPAGE = "SELECT TOP @PAGESIZE * FROM [LogQcodeInfo] @WHERE AND Id NOT IN (SELECT TOP @PTOP Id FROM [LogQcodeInfo] @WHERE @ORDER)  @ORDER";

        /// <summary>
        /// 查询记录数
        /// </summary>
        const string QUERYCOUNT = "SELECT COUNT(1) FROM LogQcodeInfo";


        #endregion

        public override bool Delete(LogQcodeInfoPara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            command.CommandText = DELETE + where;

            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override bool Edit(LogQcodeInfoVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = EDIT;

             command.Parameters.Add(new SqlParameter() { ParameterName = "@CopyText", Value = ParameterHelper.ConvertValue(m.CopyText) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@Url", Value = ParameterHelper.ConvertValue(m.Url) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@ClientIp", Value = ParameterHelper.ConvertValue(m.ClientIp) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@BrowseType", Value = ParameterHelper.ConvertValue(m.BrowseType) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateDate", Value = ParameterHelper.ConvertValue(m.CreateDate) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@Money", Value = ParameterHelper.ConvertValue(m.Money) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@IsMoney", Value = ParameterHelper.ConvertValue(m.IsMoney) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@Time", Value = ParameterHelper.ConvertValue(m.Time) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@ClientId", Value = ParameterHelper.ConvertValue(m.ClientId) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@IsMobile", Value = ParameterHelper.ConvertValue(m.IsMobile) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@ReferrerUrl", Value = ParameterHelper.ConvertValue(m.ReferrerUrl) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@BrowseName", Value = ParameterHelper.ConvertValue(m.BrowseName) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@BrowseVersion", Value = ParameterHelper.ConvertValue(m.BrowseVersion) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@OsName", Value = ParameterHelper.ConvertValue(m.OsName) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@Country", Value = ParameterHelper.ConvertValue(m.Country) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@Area", Value = ParameterHelper.ConvertValue(m.Area) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@Region", Value = ParameterHelper.ConvertValue(m.Region) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@City", Value = ParameterHelper.ConvertValue(m.City) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@County", Value = ParameterHelper.ConvertValue(m.County) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@Isp", Value = ParameterHelper.ConvertValue(m.Isp) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@IpSource", Value = ParameterHelper.ConvertValue(m.IpSource) });
               command.Parameters.Add(new SqlParameter() { ParameterName = "@Id", Value = ParameterHelper.ConvertValue(m.Id) });


            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override string GetConditionByModel(LogQcodeInfoVO m)
        {
            return "";
        }

        public override string GetConditionByPara(LogQcodeInfoPara mp)
        {
            StringBuilder sb = new StringBuilder();

           if (mp.Id.HasValue) { sb.AppendFormat(" AND [Id]='{0}' ",mp.Id);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.CopyText))){ sb.AppendFormat(" AND [CopyText]='{0}' ",mp.CopyText);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.Url))){ sb.AppendFormat(" AND [Url]='{0}' ",mp.Url);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.ClientIp))){ sb.AppendFormat(" AND [ClientIp]='{0}' ",mp.ClientIp);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.BrowseType))){ sb.AppendFormat(" AND [BrowseType]='{0}' ",mp.BrowseType);}
           if (mp.CreateDate.HasValue) { sb.AppendFormat(" AND convert(varchar(10), [CreateDate], 120) = convert(varchar(10), '{0}',120) ",mp.CreateDate.Value.ToString("yyyy-MM-dd"));}
           if (mp.Money.HasValue) { sb.AppendFormat(" AND [Money]='{0}' ",mp.Money);}
           if (mp.IsMoney.HasValue) { sb.AppendFormat(" AND [IsMoney]='{0}' ",mp.IsMoney);}
           if (mp.Time.HasValue) { sb.AppendFormat(" AND [Time]='{0}' ",mp.Time);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.ClientId))){ sb.AppendFormat(" AND [ClientId]='{0}' ",mp.ClientId);}
           if (mp.IsMobile.HasValue) { sb.AppendFormat(" AND [IsMobile]='{0}' ",mp.IsMobile);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.ReferrerUrl))){ sb.AppendFormat(" AND [ReferrerUrl]='{0}' ",mp.ReferrerUrl);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.BrowseName))){ sb.AppendFormat(" AND [BrowseName]='{0}' ",mp.BrowseName);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.BrowseVersion))){ sb.AppendFormat(" AND [BrowseVersion]='{0}' ",mp.BrowseVersion);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.OsName))){ sb.AppendFormat(" AND [OsName]='{0}' ",mp.OsName);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.Country))){ sb.AppendFormat(" AND [Country]='{0}' ",mp.Country);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.Area))){ sb.AppendFormat(" AND [Area]='{0}' ",mp.Area);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.Region))){ sb.AppendFormat(" AND [Region]='{0}' ",mp.Region);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.City))){ sb.AppendFormat(" AND [City]='{0}' ",mp.City);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.County))){ sb.AppendFormat(" AND [County]='{0}' ",mp.County);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.Isp))){ sb.AppendFormat(" AND [Isp]='{0}' ",mp.Isp);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.IpSource))){ sb.AppendFormat(" AND [IpSource]='{0}' ",mp.IpSource);}


            sb.Insert(0, " WHERE 1=1 ");

            return sb.ToString();
        }

        public override List<LogQcodeInfoVO> GetModels(ref LogQcodeInfoPara mp)
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

            List<LogQcodeInfoVO> list = new List<LogQcodeInfoVO>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(new LogQcodeInfoVO(table.Rows[i]));
            }

            if (!mp.Recount.HasValue)
            {
                mp.Recount = GetRecords(mp);
            }

            return list;
        }

        public override List<LogQcodeInfoVO> GetModels(LogQcodeInfoPara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            
			string cmd = LOAD
                .Replace("@WHERE", where)
                .Replace("@ORDER", GetOrderByPara(mp));
			command.CommandText = cmd;

            var table = DbProxyFactory.Instance.Proxy.ExecuteTable(command);

            List<LogQcodeInfoVO> list = new List<LogQcodeInfoVO>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(new LogQcodeInfoVO(table.Rows[i]));
            }

            return list;
        }

        public override string GetOrderByModel(LogQcodeInfoVO m)
        {
            return "";
        }

        public override string GetOrderByPara(LogQcodeInfoPara mp)
        {
            if(!string.IsNullOrEmpty(mp.OrderBy))
            {
                return string.Format(" order by {0}", mp.OrderBy);
            }

            return "";
        }

        public override string GetOtherConditionByModel(LogQcodeInfoVO m)
        {
            return "";
        }

        public override string GetOtherConditionByPara(LogQcodeInfoPara mp)
        {
            return "";
        }

        public override int GetRecords(LogQcodeInfoPara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            command.CommandText = QUERYCOUNT + where;

            var result = DbProxyFactory.Instance.Proxy.ExecuteScalar(command);

            return int.Parse(result.ToString());
        }

        public override LogQcodeInfoVO GetSingle(LogQcodeInfoPara mp)
        {
            var list = GetModels(mp);

            if (list.Count == 1)
                return list[0];

            return null;
        }

        public override bool Insert(LogQcodeInfoVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = INSERT;
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CopyText", Value = ParameterHelper.ConvertValue(m.CopyText) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Url", Value = ParameterHelper.ConvertValue(m.Url) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@ClientIp", Value = ParameterHelper.ConvertValue(m.ClientIp) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@BrowseType", Value = ParameterHelper.ConvertValue(m.BrowseType) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateDate", Value = ParameterHelper.ConvertValue(m.CreateDate) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Money", Value = ParameterHelper.ConvertValue(m.Money) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@IsMoney", Value = ParameterHelper.ConvertValue(m.IsMoney) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Time", Value = ParameterHelper.ConvertValue(m.Time) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@ClientId", Value = ParameterHelper.ConvertValue(m.ClientId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@IsMobile", Value = ParameterHelper.ConvertValue(m.IsMobile) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@ReferrerUrl", Value = ParameterHelper.ConvertValue(m.ReferrerUrl) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@BrowseName", Value = ParameterHelper.ConvertValue(m.BrowseName) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@BrowseVersion", Value = ParameterHelper.ConvertValue(m.BrowseVersion) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@OsName", Value = ParameterHelper.ConvertValue(m.OsName) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Country", Value = ParameterHelper.ConvertValue(m.Country) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Area", Value = ParameterHelper.ConvertValue(m.Area) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Region", Value = ParameterHelper.ConvertValue(m.Region) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@City", Value = ParameterHelper.ConvertValue(m.City) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@County", Value = ParameterHelper.ConvertValue(m.County) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Isp", Value = ParameterHelper.ConvertValue(m.Isp) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@IpSource", Value = ParameterHelper.ConvertValue(m.IpSource) });


            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override int InsertIdentityId(LogQcodeInfoVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = INSERT + "; select @@Identity";

         command.Parameters.Add(new SqlParameter() { ParameterName = "@CopyText", Value = ParameterHelper.ConvertValue(m.CopyText) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Url", Value = ParameterHelper.ConvertValue(m.Url) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@ClientIp", Value = ParameterHelper.ConvertValue(m.ClientIp) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@BrowseType", Value = ParameterHelper.ConvertValue(m.BrowseType) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateDate", Value = ParameterHelper.ConvertValue(m.CreateDate) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Money", Value = ParameterHelper.ConvertValue(m.Money) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@IsMoney", Value = ParameterHelper.ConvertValue(m.IsMoney) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Time", Value = ParameterHelper.ConvertValue(m.Time) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@ClientId", Value = ParameterHelper.ConvertValue(m.ClientId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@IsMobile", Value = ParameterHelper.ConvertValue(m.IsMobile) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@ReferrerUrl", Value = ParameterHelper.ConvertValue(m.ReferrerUrl) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@BrowseName", Value = ParameterHelper.ConvertValue(m.BrowseName) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@BrowseVersion", Value = ParameterHelper.ConvertValue(m.BrowseVersion) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@OsName", Value = ParameterHelper.ConvertValue(m.OsName) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Country", Value = ParameterHelper.ConvertValue(m.Country) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Area", Value = ParameterHelper.ConvertValue(m.Area) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Region", Value = ParameterHelper.ConvertValue(m.Region) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@City", Value = ParameterHelper.ConvertValue(m.City) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@County", Value = ParameterHelper.ConvertValue(m.County) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Isp", Value = ParameterHelper.ConvertValue(m.Isp) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@IpSource", Value = ParameterHelper.ConvertValue(m.IpSource) });


            var result = DbProxyFactory.Instance.Proxy.ExecuteScalar(command);

            return int.Parse(result.ToString());
        }
    }
}
