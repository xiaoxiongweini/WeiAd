
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
    public partial class PlayHistoryAccess : PlayHistoryInterface
    {
        #region SQL

        /// <summary>
        /// 新增
        /// </summary>
        const string INSERT = "INSERT INTO PlayHistory ([AdUserId],[FlowUserId],[AdId],[AdUrl],[Time],[Money],[CreateDate],[CreateUserId],[ClientIp],[ClientUv],[ClientPv],[Price]) VALUES (@AdUserId,@FlowUserId,@AdId,@AdUrl,@Time,@Money,@CreateDate,@CreateUserId,@ClientIp,@ClientUv,@ClientPv,@Price)";

        /// <summary>
        /// 修改
        /// </summary>
        const string EDIT = "UPDATE PlayHistory SET [AdUserId]=@AdUserId,[FlowUserId]=@FlowUserId,[AdId]=@AdId,[AdUrl]=@AdUrl,[Time]=@Time,[Money]=@Money,[CreateDate]=@CreateDate,[CreateUserId]=@CreateUserId,[ClientIp]=@ClientIp,[ClientUv]=@ClientUv,[ClientPv]=@ClientPv,[Price]=@Price WHERE [Id]=@Id";

        /// <summary>
        /// 删除
        /// </summary>
        const string DELETE = "DELETE FROM PlayHistory";

        /// <summary>
        /// 加载数据
        /// </summary>
        const string LOAD = "SELECT * FROM PlayHistory @WHERE @ORDER";

        /// <summary>
        /// 分页查询
        /// </summary>
        const string QUERYPAGE = "SELECT TOP @PAGESIZE * FROM [PlayHistory] @WHERE AND Id NOT IN (SELECT TOP @PTOP Id FROM [PlayHistory] @WHERE @ORDER)  @ORDER";

        /// <summary>
        /// 查询记录数
        /// </summary>
        const string QUERYCOUNT = "SELECT COUNT(1) FROM PlayHistory";


        #endregion

        public override bool Delete(PlayHistoryPara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            command.CommandText = DELETE + where;

            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override bool Edit(PlayHistoryVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = EDIT;

             command.Parameters.Add(new SqlParameter() { ParameterName = "@AdUserId", Value = ParameterHelper.ConvertValue(m.AdUserId) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@FlowUserId", Value = ParameterHelper.ConvertValue(m.FlowUserId) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@AdId", Value = ParameterHelper.ConvertValue(m.AdId) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@AdUrl", Value = ParameterHelper.ConvertValue(m.AdUrl) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@Time", Value = ParameterHelper.ConvertValue(m.Time) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@Money", Value = ParameterHelper.ConvertValue(m.Money) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateDate", Value = ParameterHelper.ConvertValue(m.CreateDate) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateUserId", Value = ParameterHelper.ConvertValue(m.CreateUserId) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@ClientIp", Value = ParameterHelper.ConvertValue(m.ClientIp) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@ClientUv", Value = ParameterHelper.ConvertValue(m.ClientUv) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@ClientPv", Value = ParameterHelper.ConvertValue(m.ClientPv) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@Price", Value = ParameterHelper.ConvertValue(m.Price) });
               command.Parameters.Add(new SqlParameter() { ParameterName = "@Id", Value = ParameterHelper.ConvertValue(m.Id) });


            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override string GetConditionByModel(PlayHistoryVO m)
        {
            return "";
        }

        public override string GetConditionByPara(PlayHistoryPara mp)
        {
            StringBuilder sb = new StringBuilder();

           if (mp.Id.HasValue) { sb.AppendFormat(" AND [Id]='{0}' ",mp.Id);}
           if (mp.AdUserId.HasValue) { sb.AppendFormat(" AND [AdUserId]='{0}' ",mp.AdUserId);}
           if (mp.FlowUserId.HasValue) { sb.AppendFormat(" AND [FlowUserId]='{0}' ",mp.FlowUserId);}
           if (mp.AdId.HasValue) { sb.AppendFormat(" AND [AdId]='{0}' ",mp.AdId);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.AdUrl))){ sb.AppendFormat(" AND [AdUrl]='{0}' ",mp.AdUrl);}
           if (mp.Time.HasValue) { sb.AppendFormat(" AND [Time]='{0}' ",mp.Time);}
           if (mp.Money.HasValue) { sb.AppendFormat(" AND [Money]='{0}' ",mp.Money);}
           if (mp.CreateDate.HasValue) { sb.AppendFormat(" AND [CreateDate]='{0}' ",mp.CreateDate);}
           if (mp.CreateUserId.HasValue) { sb.AppendFormat(" AND [CreateUserId]='{0}' ",mp.CreateUserId);}
           if (mp.ClientIp.HasValue) { sb.AppendFormat(" AND [ClientIp]='{0}' ",mp.ClientIp);}
           if (mp.ClientUv.HasValue) { sb.AppendFormat(" AND [ClientUv]='{0}' ",mp.ClientUv);}
           if (mp.ClientPv.HasValue) { sb.AppendFormat(" AND [ClientPv]='{0}' ",mp.ClientPv);}
           if (mp.Price.HasValue) { sb.AppendFormat(" AND [Price]='{0}' ",mp.Price);}


            sb.Insert(0, " WHERE 1=1 ");

            return sb.ToString();
        }

        public override List<PlayHistoryVO> GetModels(ref PlayHistoryPara mp)
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

            List<PlayHistoryVO> list = new List<PlayHistoryVO>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(new PlayHistoryVO(table.Rows[i]));
            }

            if (!mp.Recount.HasValue)
            {
                mp.Recount = GetRecords(mp);
            }

            return list;
        }

        public override List<PlayHistoryVO> GetModels(PlayHistoryPara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            
			string cmd = LOAD
                .Replace("@WHERE", where)
                .Replace("@ORDER", GetOrderByPara(mp));
			command.CommandText = cmd;

            var table = DbProxyFactory.Instance.Proxy.ExecuteTable(command);

            List<PlayHistoryVO> list = new List<PlayHistoryVO>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(new PlayHistoryVO(table.Rows[i]));
            }

            return list;
        }

        public override string GetOrderByModel(PlayHistoryVO m)
        {
            return "";
        }

        public override string GetOrderByPara(PlayHistoryPara mp)
        {
            if(!string.IsNullOrEmpty(mp.OrderBy))
            {
                return string.Format(" order by {0}", mp.OrderBy);
            }

            return "";
        }

        public override string GetOtherConditionByModel(PlayHistoryVO m)
        {
            return "";
        }

        public override string GetOtherConditionByPara(PlayHistoryPara mp)
        {
            return "";
        }

        public override int GetRecords(PlayHistoryPara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            command.CommandText = QUERYCOUNT + where;

            var result = DbProxyFactory.Instance.Proxy.ExecuteScalar(command);

            return int.Parse(result.ToString());
        }

        public override PlayHistoryVO GetSingle(PlayHistoryPara mp)
        {
            var list = GetModels(mp);

            if (list.Count == 1)
                return list[0];

            return null;
        }

        public override bool Insert(PlayHistoryVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = INSERT;
         command.Parameters.Add(new SqlParameter() { ParameterName = "@AdUserId", Value = ParameterHelper.ConvertValue(m.AdUserId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@FlowUserId", Value = ParameterHelper.ConvertValue(m.FlowUserId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@AdId", Value = ParameterHelper.ConvertValue(m.AdId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@AdUrl", Value = ParameterHelper.ConvertValue(m.AdUrl) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Time", Value = ParameterHelper.ConvertValue(m.Time) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Money", Value = ParameterHelper.ConvertValue(m.Money) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateDate", Value = ParameterHelper.ConvertValue(m.CreateDate) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateUserId", Value = ParameterHelper.ConvertValue(m.CreateUserId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@ClientIp", Value = ParameterHelper.ConvertValue(m.ClientIp) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@ClientUv", Value = ParameterHelper.ConvertValue(m.ClientUv) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@ClientPv", Value = ParameterHelper.ConvertValue(m.ClientPv) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Price", Value = ParameterHelper.ConvertValue(m.Price) });


            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override int InsertIdentityId(PlayHistoryVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = INSERT + "; select @@Identity";

         command.Parameters.Add(new SqlParameter() { ParameterName = "@AdUserId", Value = ParameterHelper.ConvertValue(m.AdUserId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@FlowUserId", Value = ParameterHelper.ConvertValue(m.FlowUserId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@AdId", Value = ParameterHelper.ConvertValue(m.AdId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@AdUrl", Value = ParameterHelper.ConvertValue(m.AdUrl) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Time", Value = ParameterHelper.ConvertValue(m.Time) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Money", Value = ParameterHelper.ConvertValue(m.Money) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateDate", Value = ParameterHelper.ConvertValue(m.CreateDate) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateUserId", Value = ParameterHelper.ConvertValue(m.CreateUserId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@ClientIp", Value = ParameterHelper.ConvertValue(m.ClientIp) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@ClientUv", Value = ParameterHelper.ConvertValue(m.ClientUv) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@ClientPv", Value = ParameterHelper.ConvertValue(m.ClientPv) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Price", Value = ParameterHelper.ConvertValue(m.Price) });


            var result = DbProxyFactory.Instance.Proxy.ExecuteScalar(command);

            return int.Parse(result.ToString());
        }
    }
}
