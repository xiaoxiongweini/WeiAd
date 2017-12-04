
/*

skey edit by 2017/5/17 7:00:25

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
    public partial class AdPageInfoAccess : AdPageInfoInterface
    {
        #region SQL

        /// <summary>
        /// 新增
        /// </summary>
        const string INSERT = "INSERT INTO AdPageInfo ([WeiXinUrl],[Title],[TitleImg],[QcodeImg],[Content],[AdType],[CreateDate],[LastDate],[UserId],[ViewPage],[UserCodeId],[UserCodeIds],[IsState],[Money],[SaleType],[PlanIp],[StartTime],[PlanTerminal],[MoneyCount],[BuyMoney],[OrderIndex],[UserCode],[TitleShort],[BuyIp],[TemplateName],[IsDel],[IsAuth],[StaticContent],[CreateUserId],[MiddlePage],[AdTimeStart],[AdTimeEnd],[UserAdTypeId],[Desc],[SiteTypeId],[PlatformType],[DeleteDate],[DefaultQcode],[QcodeCount],[PageCount],[QcodeImg2],[DefaultQcode2],[DomainList]) VALUES (@WeiXinUrl,@Title,@TitleImg,@QcodeImg,@Content,@AdType,@CreateDate,@LastDate,@UserId,@ViewPage,@UserCodeId,@UserCodeIds,@IsState,@Money,@SaleType,@PlanIp,@StartTime,@PlanTerminal,@MoneyCount,@BuyMoney,@OrderIndex,@UserCode,@TitleShort,@BuyIp,@TemplateName,@IsDel,@IsAuth,@StaticContent,@CreateUserId,@MiddlePage,@AdTimeStart,@AdTimeEnd,@UserAdTypeId,@Desc,@SiteTypeId,@PlatformType,@DeleteDate,@DefaultQcode,@QcodeCount,@PageCount,@QcodeImg2,@DefaultQcode2,@DomainList)";

        /// <summary>
        /// 修改
        /// </summary>
        const string EDIT = "UPDATE AdPageInfo SET [WeiXinUrl]=@WeiXinUrl,[Title]=@Title,[TitleImg]=@TitleImg,[QcodeImg]=@QcodeImg,[Content]=@Content,[AdType]=@AdType,[CreateDate]=@CreateDate,[LastDate]=@LastDate,[UserId]=@UserId,[ViewPage]=@ViewPage,[UserCodeId]=@UserCodeId,[UserCodeIds]=@UserCodeIds,[IsState]=@IsState,[Money]=@Money,[SaleType]=@SaleType,[PlanIp]=@PlanIp,[StartTime]=@StartTime,[PlanTerminal]=@PlanTerminal,[MoneyCount]=@MoneyCount,[BuyMoney]=@BuyMoney,[OrderIndex]=@OrderIndex,[UserCode]=@UserCode,[TitleShort]=@TitleShort,[BuyIp]=@BuyIp,[TemplateName]=@TemplateName,[IsDel]=@IsDel,[IsAuth]=@IsAuth,[StaticContent]=@StaticContent,[CreateUserId]=@CreateUserId,[MiddlePage]=@MiddlePage,[AdTimeStart]=@AdTimeStart,[AdTimeEnd]=@AdTimeEnd,[UserAdTypeId]=@UserAdTypeId,[Desc]=@Desc,[SiteTypeId]=@SiteTypeId,[PlatformType]=@PlatformType,[DeleteDate]=@DeleteDate,[DefaultQcode]=@DefaultQcode,[QcodeCount]=@QcodeCount,[PageCount]=@PageCount,[QcodeImg2]=@QcodeImg2,[DefaultQcode2]=@DefaultQcode2,[DomainList]=@DomainList WHERE [Id]=@Id";

        /// <summary>
        /// 删除
        /// </summary>
        const string DELETE = "DELETE FROM AdPageInfo";

        /// <summary>
        /// 加载数据
        /// </summary>
        const string LOAD = "SELECT * FROM AdPageInfo @WHERE @ORDER";

        /// <summary>
        /// 分页查询
        /// </summary>
        const string QUERYPAGE = "SELECT TOP @PAGESIZE * FROM [AdPageInfo] @WHERE AND Id NOT IN (SELECT TOP @PTOP Id FROM [AdPageInfo] @WHERE @ORDER)  @ORDER";

        /// <summary>
        /// 查询记录数
        /// </summary>
        const string QUERYCOUNT = "SELECT COUNT(1) FROM AdPageInfo";


        #endregion

        public override bool Delete(AdPageInfoPara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            command.CommandText = DELETE + where;

            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override bool Edit(AdPageInfoVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = EDIT;

            command.Parameters.Add(new SqlParameter() { ParameterName = "@WeiXinUrl", Value = ParameterHelper.ConvertValue(m.WeiXinUrl) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@Title", Value = ParameterHelper.ConvertValue(m.Title) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@TitleImg", Value = ParameterHelper.ConvertValue(m.TitleImg) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@QcodeImg", Value = ParameterHelper.ConvertValue(m.QcodeImg) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@Content", Value = ParameterHelper.ConvertValue(m.Content) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@AdType", Value = ParameterHelper.ConvertValue(m.AdType) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateDate", Value = ParameterHelper.ConvertValue(m.CreateDate) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@LastDate", Value = ParameterHelper.ConvertValue(m.LastDate) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@UserId", Value = ParameterHelper.ConvertValue(m.UserId) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@ViewPage", Value = ParameterHelper.ConvertValue(m.ViewPage) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@UserCodeId", Value = ParameterHelper.ConvertValue(m.UserCodeId) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@UserCodeIds", Value = ParameterHelper.ConvertValue(m.UserCodeIds) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@IsState", Value = ParameterHelper.ConvertValue(m.IsState) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@Money", Value = ParameterHelper.ConvertValue(m.Money) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@SaleType", Value = ParameterHelper.ConvertValue(m.SaleType) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@PlanIp", Value = ParameterHelper.ConvertValue(m.PlanIp) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@StartTime", Value = ParameterHelper.ConvertValue(m.StartTime) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@PlanTerminal", Value = ParameterHelper.ConvertValue(m.PlanTerminal) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@MoneyCount", Value = ParameterHelper.ConvertValue(m.MoneyCount) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@BuyMoney", Value = ParameterHelper.ConvertValue(m.BuyMoney) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@OrderIndex", Value = ParameterHelper.ConvertValue(m.OrderIndex) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@UserCode", Value = ParameterHelper.ConvertValue(m.UserCode) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@TitleShort", Value = ParameterHelper.ConvertValue(m.TitleShort) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@BuyIp", Value = ParameterHelper.ConvertValue(m.BuyIp) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@TemplateName", Value = ParameterHelper.ConvertValue(m.TemplateName) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@IsDel", Value = ParameterHelper.ConvertValue(m.IsDel) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@IsAuth", Value = ParameterHelper.ConvertValue(m.IsAuth) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@StaticContent", Value = ParameterHelper.ConvertValue(m.StaticContent) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateUserId", Value = ParameterHelper.ConvertValue(m.CreateUserId) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@MiddlePage", Value = ParameterHelper.ConvertValue(m.MiddlePage) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@AdTimeStart", Value = ParameterHelper.ConvertValue(m.AdTimeStart) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@AdTimeEnd", Value = ParameterHelper.ConvertValue(m.AdTimeEnd) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@UserAdTypeId", Value = ParameterHelper.ConvertValue(m.UserAdTypeId) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@Desc", Value = ParameterHelper.ConvertValue(m.Desc) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@SiteTypeId", Value = ParameterHelper.ConvertValue(m.SiteTypeId) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@PlatformType", Value = ParameterHelper.ConvertValue(m.PlatformType) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@DeleteDate", Value = ParameterHelper.ConvertValue(m.DeleteDate) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@DefaultQcode", Value = ParameterHelper.ConvertValue(m.DefaultQcode) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@QcodeCount", Value = ParameterHelper.ConvertValue(m.QcodeCount) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@PageCount", Value = ParameterHelper.ConvertValue(m.PageCount) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@QcodeImg2", Value = ParameterHelper.ConvertValue(m.QcodeImg2) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@DefaultQcode2", Value = ParameterHelper.ConvertValue(m.DefaultQcode2) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@DomainList", Value = ParameterHelper.ConvertValue(m.DomainList) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@Id", Value = ParameterHelper.ConvertValue(m.Id) });


            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override string GetConditionByModel(AdPageInfoVO m)
        {
            return "";
        }

        public override string GetConditionByPara(AdPageInfoPara mp)
        {
            StringBuilder sb = new StringBuilder();

            if (mp.Id.HasValue) { sb.AppendFormat(" AND [Id]='{0}' ", mp.Id); }
            if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.WeiXinUrl))) { sb.AppendFormat(" AND [WeiXinUrl]='{0}' ", mp.WeiXinUrl); }
            if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.Title))) { sb.AppendFormat(" AND [Title]='{0}' ", mp.Title); }
            if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.TitleImg))) { sb.AppendFormat(" AND [TitleImg]='{0}' ", mp.TitleImg); }
            if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.QcodeImg))) { sb.AppendFormat(" AND [QcodeImg]='{0}' ", mp.QcodeImg); }
            if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.Content))) { sb.AppendFormat(" AND [Content]='{0}' ", mp.Content); }
            if (mp.AdType.HasValue) { sb.AppendFormat(" AND [AdType]='{0}' ", mp.AdType); }
            if (mp.CreateDate.HasValue) { sb.AppendFormat(" AND [CreateDate]='{0}' ", mp.CreateDate); }
            if (mp.LastDate.HasValue) { sb.AppendFormat(" AND [LastDate]='{0}' ", mp.LastDate); }
            if (mp.UserId.HasValue) { sb.AppendFormat(" AND [UserId]='{0}' ", mp.UserId); }
            if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.ViewPage))) { sb.AppendFormat(" AND [ViewPage]='{0}' ", mp.ViewPage); }
            if (mp.UserCodeId.HasValue) { sb.AppendFormat(" AND [UserCodeId]='{0}' ", mp.UserCodeId); }
            if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.UserCodeIds))) { sb.AppendFormat(" AND [UserCodeIds]='{0}' ", mp.UserCodeIds); }
            if (mp.IsState.HasValue) { sb.AppendFormat(" AND [IsState]='{0}' ", mp.IsState); }
            if (mp.Money.HasValue) { sb.AppendFormat(" AND [Money]='{0}' ", mp.Money); }
            if (mp.SaleType.HasValue) { sb.AppendFormat(" AND [SaleType]='{0}' ", mp.SaleType); }
            if (mp.PlanIp.HasValue) { sb.AppendFormat(" AND [PlanIp]='{0}' ", mp.PlanIp); }
            if (mp.StartTime.HasValue) { sb.AppendFormat(" AND [StartTime]='{0}' ", mp.StartTime); }
            if (mp.PlanTerminal.HasValue) { sb.AppendFormat(" AND [PlanTerminal]='{0}' ", mp.PlanTerminal); }
            if (mp.MoneyCount.HasValue) { sb.AppendFormat(" AND [MoneyCount]='{0}' ", mp.MoneyCount); }
            if (mp.BuyMoney.HasValue) { sb.AppendFormat(" AND [BuyMoney]='{0}' ", mp.BuyMoney); }
            if (mp.OrderIndex.HasValue) { sb.AppendFormat(" AND [OrderIndex]='{0}' ", mp.OrderIndex); }
            if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.UserCode))) { sb.AppendFormat(" AND [UserCode]='{0}' ", mp.UserCode); }
            if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.TitleShort))) { sb.AppendFormat(" AND [TitleShort]='{0}' ", mp.TitleShort); }
            if (mp.BuyIp.HasValue) { sb.AppendFormat(" AND [BuyIp]='{0}' ", mp.BuyIp); }
            if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.TemplateName))) { sb.AppendFormat(" AND [TemplateName]='{0}' ", mp.TemplateName); }
            if (mp.IsDel.HasValue) { sb.AppendFormat(" AND [IsDel]='{0}' ", mp.IsDel); }
            if (mp.IsAuth.HasValue) { sb.AppendFormat(" AND [IsAuth]='{0}' ", mp.IsAuth); }
            if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.StaticContent))) { sb.AppendFormat(" AND [StaticContent]='{0}' ", mp.StaticContent); }
            if (mp.CreateUserId.HasValue) { sb.AppendFormat(" AND [CreateUserId]='{0}' ", mp.CreateUserId); }
            if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.MiddlePage))) { sb.AppendFormat(" AND [MiddlePage]='{0}' ", mp.MiddlePage); }
            if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.AdTimeStart))) { sb.AppendFormat(" AND [AdTimeStart]='{0}' ", mp.AdTimeStart); }
            if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.AdTimeEnd))) { sb.AppendFormat(" AND [AdTimeEnd]='{0}' ", mp.AdTimeEnd); }
            if (mp.UserAdTypeId.HasValue) { sb.AppendFormat(" AND [UserAdTypeId]='{0}' ", mp.UserAdTypeId); }
            if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.Desc))) { sb.AppendFormat(" AND [Desc]='{0}' ", mp.Desc); }
            if (mp.SiteTypeId.HasValue) { sb.AppendFormat(" AND [SiteTypeId]='{0}' ", mp.SiteTypeId); }
            if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.PlatformType))) { sb.AppendFormat(" AND [PlatformType]='{0}' ", mp.PlatformType); }
            if (mp.DeleteDate.HasValue) { sb.AppendFormat(" AND [DeleteDate]='{0}' ", mp.DeleteDate); }
            if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.DefaultQcode))) { sb.AppendFormat(" AND [DefaultQcode]='{0}' ", mp.DefaultQcode); }
            if (mp.QcodeCount.HasValue) { sb.AppendFormat(" AND [QcodeCount]='{0}' ", mp.QcodeCount); }
            if (mp.PageCount.HasValue) { sb.AppendFormat(" AND [PageCount]='{0}' ", mp.PageCount); }
            if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.QcodeImg2))) { sb.AppendFormat(" AND [QcodeImg2]='{0}' ", mp.QcodeImg2); }
            if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.DefaultQcode2))) { sb.AppendFormat(" AND [DefaultQcode2]='{0}' ", mp.DefaultQcode2); }
            if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.DomainList))) { sb.AppendFormat(" AND [DomainList]='{0}' ", mp.DomainList); }

            sb.Append(AdPageInfoAccessOther.GetConditionByPara(mp));

            sb.Insert(0, " WHERE 1=1 ");

            return sb.ToString();
        }

        public override List<AdPageInfoVO> GetModels(ref AdPageInfoPara mp)
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

            List<AdPageInfoVO> list = new List<AdPageInfoVO>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(new AdPageInfoVO(table.Rows[i]));
            }

            if (!mp.Recount.HasValue)
            {
                mp.Recount = GetRecords(mp);
            }

            return list;
        }

        public override List<AdPageInfoVO> GetModels(AdPageInfoPara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();

            string cmd = LOAD
                .Replace("@WHERE", where)
                .Replace("@ORDER", GetOrderByPara(mp));
            command.CommandText = cmd;

            var table = DbProxyFactory.Instance.Proxy.ExecuteTable(command);

            List<AdPageInfoVO> list = new List<AdPageInfoVO>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(new AdPageInfoVO(table.Rows[i]));
            }

            return list;
        }

        public override string GetOrderByModel(AdPageInfoVO m)
        {
            return "";
        }

        public override string GetOrderByPara(AdPageInfoPara mp)
        {
            if (!string.IsNullOrEmpty(mp.OrderBy))
            {
                return string.Format(" order by {0}", mp.OrderBy);
            }

            return "";
        }

        public override string GetOtherConditionByModel(AdPageInfoVO m)
        {
            return "";
        }

        public override string GetOtherConditionByPara(AdPageInfoPara mp)
        {
            return "";
        }

        public override int GetRecords(AdPageInfoPara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            command.CommandText = QUERYCOUNT + where;

            var result = DbProxyFactory.Instance.Proxy.ExecuteScalar(command);

            return int.Parse(result.ToString());
        }

        public override AdPageInfoVO GetSingle(AdPageInfoPara mp)
        {
            var list = GetModels(mp);

            if (list.Count == 1)
                return list[0];

            return null;
        }

        public override bool Insert(AdPageInfoVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = INSERT;
            command.Parameters.Add(new SqlParameter() { ParameterName = "@WeiXinUrl", Value = ParameterHelper.ConvertValue(m.WeiXinUrl) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@Title", Value = ParameterHelper.ConvertValue(m.Title) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@TitleImg", Value = ParameterHelper.ConvertValue(m.TitleImg) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@QcodeImg", Value = ParameterHelper.ConvertValue(m.QcodeImg) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@Content", Value = ParameterHelper.ConvertValue(m.Content) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@AdType", Value = ParameterHelper.ConvertValue(m.AdType) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateDate", Value = ParameterHelper.ConvertValue(m.CreateDate) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@LastDate", Value = ParameterHelper.ConvertValue(m.LastDate) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@UserId", Value = ParameterHelper.ConvertValue(m.UserId) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@ViewPage", Value = ParameterHelper.ConvertValue(m.ViewPage) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@UserCodeId", Value = ParameterHelper.ConvertValue(m.UserCodeId) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@UserCodeIds", Value = ParameterHelper.ConvertValue(m.UserCodeIds) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@IsState", Value = ParameterHelper.ConvertValue(m.IsState) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@Money", Value = ParameterHelper.ConvertValue(m.Money) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@SaleType", Value = ParameterHelper.ConvertValue(m.SaleType) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@PlanIp", Value = ParameterHelper.ConvertValue(m.PlanIp) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@StartTime", Value = ParameterHelper.ConvertValue(m.StartTime) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@PlanTerminal", Value = ParameterHelper.ConvertValue(m.PlanTerminal) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@MoneyCount", Value = ParameterHelper.ConvertValue(m.MoneyCount) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@BuyMoney", Value = ParameterHelper.ConvertValue(m.BuyMoney) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@OrderIndex", Value = ParameterHelper.ConvertValue(m.OrderIndex) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@UserCode", Value = ParameterHelper.ConvertValue(m.UserCode) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@TitleShort", Value = ParameterHelper.ConvertValue(m.TitleShort) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@BuyIp", Value = ParameterHelper.ConvertValue(m.BuyIp) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@TemplateName", Value = ParameterHelper.ConvertValue(m.TemplateName) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@IsDel", Value = ParameterHelper.ConvertValue(m.IsDel) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@IsAuth", Value = ParameterHelper.ConvertValue(m.IsAuth) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@StaticContent", Value = ParameterHelper.ConvertValue(m.StaticContent) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateUserId", Value = ParameterHelper.ConvertValue(m.CreateUserId) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@MiddlePage", Value = ParameterHelper.ConvertValue(m.MiddlePage) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@AdTimeStart", Value = ParameterHelper.ConvertValue(m.AdTimeStart) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@AdTimeEnd", Value = ParameterHelper.ConvertValue(m.AdTimeEnd) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@UserAdTypeId", Value = ParameterHelper.ConvertValue(m.UserAdTypeId) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@Desc", Value = ParameterHelper.ConvertValue(m.Desc) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@SiteTypeId", Value = ParameterHelper.ConvertValue(m.SiteTypeId) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@PlatformType", Value = ParameterHelper.ConvertValue(m.PlatformType) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@DeleteDate", Value = ParameterHelper.ConvertValue(m.DeleteDate) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@DefaultQcode", Value = ParameterHelper.ConvertValue(m.DefaultQcode) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@QcodeCount", Value = ParameterHelper.ConvertValue(m.QcodeCount) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@PageCount", Value = ParameterHelper.ConvertValue(m.PageCount) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@QcodeImg2", Value = ParameterHelper.ConvertValue(m.QcodeImg2) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@DefaultQcode2", Value = ParameterHelper.ConvertValue(m.DefaultQcode2) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@DomainList", Value = ParameterHelper.ConvertValue(m.DomainList) });


            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override int InsertIdentityId(AdPageInfoVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = INSERT + "; select @@Identity";

            command.Parameters.Add(new SqlParameter() { ParameterName = "@WeiXinUrl", Value = ParameterHelper.ConvertValue(m.WeiXinUrl) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@Title", Value = ParameterHelper.ConvertValue(m.Title) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@TitleImg", Value = ParameterHelper.ConvertValue(m.TitleImg) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@QcodeImg", Value = ParameterHelper.ConvertValue(m.QcodeImg) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@Content", Value = ParameterHelper.ConvertValue(m.Content) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@AdType", Value = ParameterHelper.ConvertValue(m.AdType) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateDate", Value = ParameterHelper.ConvertValue(m.CreateDate) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@LastDate", Value = ParameterHelper.ConvertValue(m.LastDate) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@UserId", Value = ParameterHelper.ConvertValue(m.UserId) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@ViewPage", Value = ParameterHelper.ConvertValue(m.ViewPage) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@UserCodeId", Value = ParameterHelper.ConvertValue(m.UserCodeId) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@UserCodeIds", Value = ParameterHelper.ConvertValue(m.UserCodeIds) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@IsState", Value = ParameterHelper.ConvertValue(m.IsState) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@Money", Value = ParameterHelper.ConvertValue(m.Money) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@SaleType", Value = ParameterHelper.ConvertValue(m.SaleType) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@PlanIp", Value = ParameterHelper.ConvertValue(m.PlanIp) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@StartTime", Value = ParameterHelper.ConvertValue(m.StartTime) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@PlanTerminal", Value = ParameterHelper.ConvertValue(m.PlanTerminal) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@MoneyCount", Value = ParameterHelper.ConvertValue(m.MoneyCount) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@BuyMoney", Value = ParameterHelper.ConvertValue(m.BuyMoney) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@OrderIndex", Value = ParameterHelper.ConvertValue(m.OrderIndex) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@UserCode", Value = ParameterHelper.ConvertValue(m.UserCode) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@TitleShort", Value = ParameterHelper.ConvertValue(m.TitleShort) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@BuyIp", Value = ParameterHelper.ConvertValue(m.BuyIp) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@TemplateName", Value = ParameterHelper.ConvertValue(m.TemplateName) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@IsDel", Value = ParameterHelper.ConvertValue(m.IsDel) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@IsAuth", Value = ParameterHelper.ConvertValue(m.IsAuth) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@StaticContent", Value = ParameterHelper.ConvertValue(m.StaticContent) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateUserId", Value = ParameterHelper.ConvertValue(m.CreateUserId) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@MiddlePage", Value = ParameterHelper.ConvertValue(m.MiddlePage) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@AdTimeStart", Value = ParameterHelper.ConvertValue(m.AdTimeStart) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@AdTimeEnd", Value = ParameterHelper.ConvertValue(m.AdTimeEnd) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@UserAdTypeId", Value = ParameterHelper.ConvertValue(m.UserAdTypeId) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@Desc", Value = ParameterHelper.ConvertValue(m.Desc) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@SiteTypeId", Value = ParameterHelper.ConvertValue(m.SiteTypeId) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@PlatformType", Value = ParameterHelper.ConvertValue(m.PlatformType) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@DeleteDate", Value = ParameterHelper.ConvertValue(m.DeleteDate) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@DefaultQcode", Value = ParameterHelper.ConvertValue(m.DefaultQcode) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@QcodeCount", Value = ParameterHelper.ConvertValue(m.QcodeCount) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@PageCount", Value = ParameterHelper.ConvertValue(m.PageCount) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@QcodeImg2", Value = ParameterHelper.ConvertValue(m.QcodeImg2) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@DefaultQcode2", Value = ParameterHelper.ConvertValue(m.DefaultQcode2) });
            command.Parameters.Add(new SqlParameter() { ParameterName = "@DomainList", Value = ParameterHelper.ConvertValue(m.DomainList) });


            var result = DbProxyFactory.Instance.Proxy.ExecuteScalar(command);

            return int.Parse(result.ToString());
        }
    }
}
