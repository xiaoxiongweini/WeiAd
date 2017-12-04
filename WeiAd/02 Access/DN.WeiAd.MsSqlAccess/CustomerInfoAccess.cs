
/*

skey edit by 2017/8/21 15:16:49

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
    public partial class CustomerInfoAccess : CustomerInfoInterface
    {
        #region SQL

        /// <summary>
        /// 新增
        /// </summary>
        const string INSERT = "INSERT INTO CustomerInfo ([AdUrl],[AdId],[AdUserId],[RealName],[Phone],[WeiXinNum],[Remark],[Address],[UserCountry],[UserRegion],[UserCity],[ClientIp],[ClientId],[IsMobile],[ReferrerUrl],[BrowseName],[BrowseVersion],[OsName],[Country],[Area],[Region],[City],[County],[Isp],[IpSource],[CreateDate],[Num],[Price],[ProducteName],[Color],[Size],[IsDelete],[UserAttr],[CheckState],[CheckRemark],[IsExport],[ExportUserId],[ExportDate]) VALUES (@AdUrl,@AdId,@AdUserId,@RealName,@Phone,@WeiXinNum,@Remark,@Address,@UserCountry,@UserRegion,@UserCity,@ClientIp,@ClientId,@IsMobile,@ReferrerUrl,@BrowseName,@BrowseVersion,@OsName,@Country,@Area,@Region,@City,@County,@Isp,@IpSource,@CreateDate,@Num,@Price,@ProducteName,@Color,@Size,@IsDelete,@UserAttr,@CheckState,@CheckRemark,@IsExport,@ExportUserId,@ExportDate)";

        /// <summary>
        /// 修改
        /// </summary>
        const string EDIT = "UPDATE CustomerInfo SET [AdUrl]=@AdUrl,[AdId]=@AdId,[AdUserId]=@AdUserId,[RealName]=@RealName,[Phone]=@Phone,[WeiXinNum]=@WeiXinNum,[Remark]=@Remark,[Address]=@Address,[UserCountry]=@UserCountry,[UserRegion]=@UserRegion,[UserCity]=@UserCity,[ClientIp]=@ClientIp,[ClientId]=@ClientId,[IsMobile]=@IsMobile,[ReferrerUrl]=@ReferrerUrl,[BrowseName]=@BrowseName,[BrowseVersion]=@BrowseVersion,[OsName]=@OsName,[Country]=@Country,[Area]=@Area,[Region]=@Region,[City]=@City,[County]=@County,[Isp]=@Isp,[IpSource]=@IpSource,[CreateDate]=@CreateDate,[Num]=@Num,[Price]=@Price,[ProducteName]=@ProducteName,[Color]=@Color,[Size]=@Size,[IsDelete]=@IsDelete,[UserAttr]=@UserAttr,[CheckState]=@CheckState,[CheckRemark]=@CheckRemark,[IsExport]=@IsExport,[ExportUserId]=@ExportUserId,[ExportDate]=@ExportDate WHERE [Id]=@Id";

        /// <summary>
        /// 删除
        /// </summary>
        const string DELETE = "DELETE FROM CustomerInfo";

        /// <summary>
        /// 加载数据
        /// </summary>
        const string LOAD = "SELECT * FROM CustomerInfo @WHERE @ORDER";

        /// <summary>
        /// 分页查询
        /// </summary>
        const string QUERYPAGE = "SELECT TOP @PAGESIZE * FROM [CustomerInfo] @WHERE AND Id NOT IN (SELECT TOP @PTOP Id FROM [CustomerInfo] @WHERE @ORDER)  @ORDER";

        /// <summary>
        /// 查询记录数
        /// </summary>
        const string QUERYCOUNT = "SELECT COUNT(1) FROM CustomerInfo";


        #endregion

        public override bool Delete(CustomerInfoPara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            command.CommandText = DELETE + where;

            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override bool Edit(CustomerInfoVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = EDIT;

            command.Parameters.Add(new SqlParameter() { ParameterName = "@AdUrl", Value = ParameterHelper.ConvertValue(m.AdUrl) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@AdId", Value = ParameterHelper.ConvertValue(m.AdId) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@AdUserId", Value = ParameterHelper.ConvertValue(m.AdUserId) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@RealName", Value = ParameterHelper.ConvertValue(m.RealName) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@Phone", Value = ParameterHelper.ConvertValue(m.Phone) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@WeiXinNum", Value = ParameterHelper.ConvertValue(m.WeiXinNum) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@Remark", Value = ParameterHelper.ConvertValue(m.Remark) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@Address", Value = ParameterHelper.ConvertValue(m.Address) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@UserCountry", Value = ParameterHelper.ConvertValue(m.UserCountry) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@UserRegion", Value = ParameterHelper.ConvertValue(m.UserRegion) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@UserCity", Value = ParameterHelper.ConvertValue(m.UserCity) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@ClientIp", Value = ParameterHelper.ConvertValue(m.ClientIp) });
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
            command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateDate", Value = ParameterHelper.ConvertValue(m.CreateDate) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@Num", Value = ParameterHelper.ConvertValue(m.Num) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@Price", Value = ParameterHelper.ConvertValue(m.Price) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@ProducteName", Value = ParameterHelper.ConvertValue(m.ProducteName) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@Color", Value = ParameterHelper.ConvertValue(m.Color) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@Size", Value = ParameterHelper.ConvertValue(m.Size) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@IsDelete", Value = ParameterHelper.ConvertValue(m.IsDelete) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@UserAttr", Value = ParameterHelper.ConvertValue(m.UserAttr) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@CheckState", Value = ParameterHelper.ConvertValue(m.CheckState) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@CheckRemark", Value = ParameterHelper.ConvertValue(m.CheckRemark) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@IsExport", Value = ParameterHelper.ConvertValue(m.IsExport) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@ExportUserId", Value = ParameterHelper.ConvertValue(m.ExportUserId) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@ExportDate", Value = ParameterHelper.ConvertValue(m.ExportDate) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@Id", Value = ParameterHelper.ConvertValue(m.Id) });


            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override string GetConditionByModel(CustomerInfoVO m)
        {
            return "";
        }

        public override string GetConditionByPara(CustomerInfoPara mp)
        {
            StringBuilder sb = new StringBuilder();

            if (mp.Id.HasValue) { sb.AppendFormat(" AND [Id]='{0}' ", mp.Id); }
            if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.AdUrl))) { sb.AppendFormat(" AND [AdUrl]='{0}' ", mp.AdUrl); }
            if (mp.AdId.HasValue) { sb.AppendFormat(" AND [AdId]='{0}' ", mp.AdId); }
            if (mp.AdUserId.HasValue) { sb.AppendFormat(" AND [AdUserId]='{0}' ", mp.AdUserId); }
            if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.RealName))) { sb.AppendFormat(" AND [RealName]='{0}' ", mp.RealName); }
            if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.Phone))) { sb.AppendFormat(" AND [Phone]='{0}' ", mp.Phone); }
            if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.WeiXinNum))) { sb.AppendFormat(" AND [WeiXinNum]='{0}' ", mp.WeiXinNum); }
            if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.Remark))) { sb.AppendFormat(" AND [Remark]='{0}' ", mp.Remark); }
            if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.Address))) { sb.AppendFormat(" AND [Address]='{0}' ", mp.Address); }
            if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.UserCountry))) { sb.AppendFormat(" AND [UserCountry]='{0}' ", mp.UserCountry); }
            if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.UserRegion))) { sb.AppendFormat(" AND [UserRegion]='{0}' ", mp.UserRegion); }
            if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.UserCity))) { sb.AppendFormat(" AND [UserCity]='{0}' ", mp.UserCity); }
            if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.ClientIp))) { sb.AppendFormat(" AND [ClientIp]='{0}' ", mp.ClientIp); }
            if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.ClientId))) { sb.AppendFormat(" AND [ClientId]='{0}' ", mp.ClientId); }
            if (mp.IsMobile.HasValue) { sb.AppendFormat(" AND [IsMobile]='{0}' ", mp.IsMobile); }
            if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.ReferrerUrl))) { sb.AppendFormat(" AND [ReferrerUrl]='{0}' ", mp.ReferrerUrl); }
            if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.BrowseName))) { sb.AppendFormat(" AND [BrowseName]='{0}' ", mp.BrowseName); }
            if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.BrowseVersion))) { sb.AppendFormat(" AND [BrowseVersion]='{0}' ", mp.BrowseVersion); }
            if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.OsName))) { sb.AppendFormat(" AND [OsName]='{0}' ", mp.OsName); }
            if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.Country))) { sb.AppendFormat(" AND [Country]='{0}' ", mp.Country); }
            if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.Area))) { sb.AppendFormat(" AND [Area]='{0}' ", mp.Area); }
            if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.Region))) { sb.AppendFormat(" AND [Region]='{0}' ", mp.Region); }
            if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.City))) { sb.AppendFormat(" AND [City]='{0}' ", mp.City); }
            if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.County))) { sb.AppendFormat(" AND [County]='{0}' ", mp.County); }
            if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.Isp))) { sb.AppendFormat(" AND [Isp]='{0}' ", mp.Isp); }
            if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.IpSource))) { sb.AppendFormat(" AND [IpSource]='{0}' ", mp.IpSource); }
            if (mp.CreateDate.HasValue) { sb.AppendFormat(" AND convert(varchar(10), [CreateDate], 120) = convert(varchar(10), '{0}',120) ", mp.CreateDate.Value.ToString("yyyy-MM-dd")); }
            if (mp.Num.HasValue) { sb.AppendFormat(" AND [Num]='{0}' ", mp.Num); }
            if (mp.Price.HasValue) { sb.AppendFormat(" AND [Price]='{0}' ", mp.Price); }
            if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.ProducteName))) { sb.AppendFormat(" AND [ProducteName]='{0}' ", mp.ProducteName); }
            if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.Color))) { sb.AppendFormat(" AND [Color]='{0}' ", mp.Color); }
            if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.Size))) { sb.AppendFormat(" AND [Size]='{0}' ", mp.Size); }
            if (mp.IsDelete.HasValue) { sb.AppendFormat(" AND [IsDelete]='{0}' ", mp.IsDelete); }
            if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.UserAttr))) { sb.AppendFormat(" AND [UserAttr]='{0}' ", mp.UserAttr); }
            if (mp.CheckState.HasValue) { sb.AppendFormat(" AND [CheckState]='{0}' ", mp.CheckState); }
            if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.CheckRemark))) { sb.AppendFormat(" AND [CheckRemark]='{0}' ", mp.CheckRemark); }
            if (mp.IsExport.HasValue) { sb.AppendFormat(" AND [IsExport]='{0}' ", mp.IsExport); }
            if (mp.ExportUserId.HasValue) { sb.AppendFormat(" AND [ExportUserId]='{0}' ", mp.ExportUserId); }
            if (mp.ExportDate.HasValue) { sb.AppendFormat(" AND convert(varchar(10), [ExportDate], 120) = convert(varchar(10), '{0}',120) ", mp.ExportDate.Value.ToString("yyyy-MM-dd")); }

            sb.Append(CustomerInfoAccessOther.GetConditionByPara(mp));

            sb.Insert(0, " WHERE 1=1 ");

            return sb.ToString();
        }

        public override List<CustomerInfoVO> GetModels(ref CustomerInfoPara mp)
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

            List<CustomerInfoVO> list = new List<CustomerInfoVO>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(new CustomerInfoVO(table.Rows[i]));
            }

            if (!mp.Recount.HasValue)
            {
                mp.Recount = GetRecords(mp);
            }

            return list;
        }

        public override List<CustomerInfoVO> GetModels(CustomerInfoPara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();

            string cmd = LOAD
                .Replace("@WHERE", where)
                .Replace("@ORDER", GetOrderByPara(mp));
            command.CommandText = cmd;

            var table = DbProxyFactory.Instance.Proxy.ExecuteTable(command);

            List<CustomerInfoVO> list = new List<CustomerInfoVO>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(new CustomerInfoVO(table.Rows[i]));
            }

            return list;
        }

        public override string GetOrderByModel(CustomerInfoVO m)
        {
            return "";
        }

        public override string GetOrderByPara(CustomerInfoPara mp)
        {
            if (!string.IsNullOrEmpty(mp.OrderBy))
            {
                return string.Format(" order by {0}", mp.OrderBy);
            }

            return "";
        }

        public override string GetOtherConditionByModel(CustomerInfoVO m)
        {
            return "";
        }

        public override string GetOtherConditionByPara(CustomerInfoPara mp)
        {
            return "";
        }

        public override int GetRecords(CustomerInfoPara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            command.CommandText = QUERYCOUNT + where;

            var result = DbProxyFactory.Instance.Proxy.ExecuteScalar(command);

            return int.Parse(result.ToString());
        }

        public override CustomerInfoVO GetSingle(CustomerInfoPara mp)
        {
            var list = GetModels(mp);

            if (list.Count == 1)
                return list[0];

            return null;
        }

        public override bool Insert(CustomerInfoVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = INSERT;
            command.Parameters.Add(new SqlParameter() { ParameterName = "@AdUrl", Value = ParameterHelper.ConvertValue(m.AdUrl) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@AdId", Value = ParameterHelper.ConvertValue(m.AdId) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@AdUserId", Value = ParameterHelper.ConvertValue(m.AdUserId) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@RealName", Value = ParameterHelper.ConvertValue(m.RealName) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@Phone", Value = ParameterHelper.ConvertValue(m.Phone) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@WeiXinNum", Value = ParameterHelper.ConvertValue(m.WeiXinNum) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@Remark", Value = ParameterHelper.ConvertValue(m.Remark) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@Address", Value = ParameterHelper.ConvertValue(m.Address) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@UserCountry", Value = ParameterHelper.ConvertValue(m.UserCountry) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@UserRegion", Value = ParameterHelper.ConvertValue(m.UserRegion) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@UserCity", Value = ParameterHelper.ConvertValue(m.UserCity) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@ClientIp", Value = ParameterHelper.ConvertValue(m.ClientIp) });
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
            command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateDate", Value = ParameterHelper.ConvertValue(m.CreateDate) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@Num", Value = ParameterHelper.ConvertValue(m.Num) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@Price", Value = ParameterHelper.ConvertValue(m.Price) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@ProducteName", Value = ParameterHelper.ConvertValue(m.ProducteName) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@Color", Value = ParameterHelper.ConvertValue(m.Color) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@Size", Value = ParameterHelper.ConvertValue(m.Size) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@IsDelete", Value = ParameterHelper.ConvertValue(m.IsDelete) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@UserAttr", Value = ParameterHelper.ConvertValue(m.UserAttr) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@CheckState", Value = ParameterHelper.ConvertValue(m.CheckState) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@CheckRemark", Value = ParameterHelper.ConvertValue(m.CheckRemark) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@IsExport", Value = ParameterHelper.ConvertValue(m.IsExport) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@ExportUserId", Value = ParameterHelper.ConvertValue(m.ExportUserId) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@ExportDate", Value = ParameterHelper.ConvertValue(m.ExportDate) });


            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override int InsertIdentityId(CustomerInfoVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = INSERT + "; select @@Identity";

            command.Parameters.Add(new SqlParameter() { ParameterName = "@AdUrl", Value = ParameterHelper.ConvertValue(m.AdUrl) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@AdId", Value = ParameterHelper.ConvertValue(m.AdId) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@AdUserId", Value = ParameterHelper.ConvertValue(m.AdUserId) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@RealName", Value = ParameterHelper.ConvertValue(m.RealName) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@Phone", Value = ParameterHelper.ConvertValue(m.Phone) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@WeiXinNum", Value = ParameterHelper.ConvertValue(m.WeiXinNum) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@Remark", Value = ParameterHelper.ConvertValue(m.Remark) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@Address", Value = ParameterHelper.ConvertValue(m.Address) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@UserCountry", Value = ParameterHelper.ConvertValue(m.UserCountry) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@UserRegion", Value = ParameterHelper.ConvertValue(m.UserRegion) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@UserCity", Value = ParameterHelper.ConvertValue(m.UserCity) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@ClientIp", Value = ParameterHelper.ConvertValue(m.ClientIp) });
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
            command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateDate", Value = ParameterHelper.ConvertValue(m.CreateDate) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@Num", Value = ParameterHelper.ConvertValue(m.Num) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@Price", Value = ParameterHelper.ConvertValue(m.Price) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@ProducteName", Value = ParameterHelper.ConvertValue(m.ProducteName) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@Color", Value = ParameterHelper.ConvertValue(m.Color) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@Size", Value = ParameterHelper.ConvertValue(m.Size) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@IsDelete", Value = ParameterHelper.ConvertValue(m.IsDelete) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@UserAttr", Value = ParameterHelper.ConvertValue(m.UserAttr) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@CheckState", Value = ParameterHelper.ConvertValue(m.CheckState) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@CheckRemark", Value = ParameterHelper.ConvertValue(m.CheckRemark) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@IsExport", Value = ParameterHelper.ConvertValue(m.IsExport) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@ExportUserId", Value = ParameterHelper.ConvertValue(m.ExportUserId) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@ExportDate", Value = ParameterHelper.ConvertValue(m.ExportDate) });


            var result = DbProxyFactory.Instance.Proxy.ExecuteScalar(command);

            return int.Parse(result.ToString());
        }
    }
}
