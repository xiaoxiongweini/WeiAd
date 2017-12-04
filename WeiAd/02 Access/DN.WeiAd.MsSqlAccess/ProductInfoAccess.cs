
/*

skey edit by 2017/7/24 9:27:34

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
    public partial class ProductInfoAccess : ProductInfoInterface
    {
        #region SQL

        /// <summary>
        /// 新增
        /// </summary>
        const string INSERT = "INSERT INTO ProductInfo ([Name],[Desc],[AdId],[Price],[AttrText],[AttrStyle],[IsState],[IsDelete],[CreateUserId],[CreateDate]) VALUES (@Name,@Desc,@AdId,@Price,@AttrText,@AttrStyle,@IsState,@IsDelete,@CreateUserId,@CreateDate)";

        /// <summary>
        /// 修改
        /// </summary>
        const string EDIT = "UPDATE ProductInfo SET [Name]=@Name,[Desc]=@Desc,[AdId]=@AdId,[Price]=@Price,[AttrText]=@AttrText,[AttrStyle]=@AttrStyle,[IsState]=@IsState,[IsDelete]=@IsDelete,[CreateUserId]=@CreateUserId,[CreateDate]=@CreateDate WHERE [Id]=@Id";

        /// <summary>
        /// 删除
        /// </summary>
        const string DELETE = "DELETE FROM ProductInfo";

        /// <summary>
        /// 加载数据
        /// </summary>
        const string LOAD = "SELECT * FROM ProductInfo @WHERE @ORDER";

        /// <summary>
        /// 分页查询
        /// </summary>
        const string QUERYPAGE = "SELECT TOP @PAGESIZE * FROM [ProductInfo] @WHERE AND Id NOT IN (SELECT TOP @PTOP Id FROM [ProductInfo] @WHERE @ORDER)  @ORDER";

        /// <summary>
        /// 查询记录数
        /// </summary>
        const string QUERYCOUNT = "SELECT COUNT(1) FROM ProductInfo";


        #endregion

        public override bool Delete(ProductInfoPara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            command.CommandText = DELETE + where;

            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override bool Edit(ProductInfoVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = EDIT;

             command.Parameters.Add(new SqlParameter() { ParameterName = "@Name", Value = ParameterHelper.ConvertValue(m.Name) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@Desc", Value = ParameterHelper.ConvertValue(m.Desc) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@AdId", Value = ParameterHelper.ConvertValue(m.AdId) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@Price", Value = ParameterHelper.ConvertValue(m.Price) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@AttrText", Value = ParameterHelper.ConvertValue(m.AttrText) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@AttrStyle", Value = ParameterHelper.ConvertValue(m.AttrStyle) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@IsState", Value = ParameterHelper.ConvertValue(m.IsState) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@IsDelete", Value = ParameterHelper.ConvertValue(m.IsDelete) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateUserId", Value = ParameterHelper.ConvertValue(m.CreateUserId) });
             command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateDate", Value = ParameterHelper.ConvertValue(m.CreateDate) });
               command.Parameters.Add(new SqlParameter() { ParameterName = "@Id", Value = ParameterHelper.ConvertValue(m.Id) });


            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override string GetConditionByModel(ProductInfoVO m)
        {
            return "";
        }

        public override string GetConditionByPara(ProductInfoPara mp)
        {
            StringBuilder sb = new StringBuilder();

           if (mp.Id.HasValue) { sb.AppendFormat(" AND [Id]='{0}' ",mp.Id);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.Name))){ sb.AppendFormat(" AND [Name]='{0}' ",mp.Name);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.Desc))){ sb.AppendFormat(" AND [Desc]='{0}' ",mp.Desc);}
           if (mp.AdId.HasValue) { sb.AppendFormat(" AND [AdId]='{0}' ",mp.AdId);}
           if (mp.Price.HasValue) { sb.AppendFormat(" AND [Price]='{0}' ",mp.Price);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.AttrText))){ sb.AppendFormat(" AND [AttrText]='{0}' ",mp.AttrText);}
           if (!string.IsNullOrEmpty(SqlFilterHelper.CheckPropertyName(mp.AttrStyle))){ sb.AppendFormat(" AND [AttrStyle]='{0}' ",mp.AttrStyle);}
           if (mp.IsState.HasValue) { sb.AppendFormat(" AND [IsState]='{0}' ",mp.IsState);}
           if (mp.IsDelete.HasValue) { sb.AppendFormat(" AND [IsDelete]='{0}' ",mp.IsDelete);}
           if (mp.CreateUserId.HasValue) { sb.AppendFormat(" AND [CreateUserId]='{0}' ",mp.CreateUserId);}
           if (mp.CreateDate.HasValue) { sb.AppendFormat(" AND [CreateDate]='{0}' ",mp.CreateDate);}


            sb.Insert(0, " WHERE 1=1 ");

            return sb.ToString();
        }

        public override List<ProductInfoVO> GetModels(ref ProductInfoPara mp)
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

            List<ProductInfoVO> list = new List<ProductInfoVO>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(new ProductInfoVO(table.Rows[i]));
            }

            if (!mp.Recount.HasValue)
            {
                mp.Recount = GetRecords(mp);
            }

            return list;
        }

        public override List<ProductInfoVO> GetModels(ProductInfoPara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            
			string cmd = LOAD
                .Replace("@WHERE", where)
                .Replace("@ORDER", GetOrderByPara(mp));
			command.CommandText = cmd;

            var table = DbProxyFactory.Instance.Proxy.ExecuteTable(command);

            List<ProductInfoVO> list = new List<ProductInfoVO>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(new ProductInfoVO(table.Rows[i]));
            }

            return list;
        }

        public override string GetOrderByModel(ProductInfoVO m)
        {
            return "";
        }

        public override string GetOrderByPara(ProductInfoPara mp)
        {
            if(!string.IsNullOrEmpty(mp.OrderBy))
            {
                return string.Format(" order by {0}", mp.OrderBy);
            }

            return "";
        }

        public override string GetOtherConditionByModel(ProductInfoVO m)
        {
            return "";
        }

        public override string GetOtherConditionByPara(ProductInfoPara mp)
        {
            return "";
        }

        public override int GetRecords(ProductInfoPara mp)
        {
            string where = GetConditionByPara(mp);

            CodeCommand command = new CodeCommand();
            command.CommandText = QUERYCOUNT + where;

            var result = DbProxyFactory.Instance.Proxy.ExecuteScalar(command);

            return int.Parse(result.ToString());
        }

        public override ProductInfoVO GetSingle(ProductInfoPara mp)
        {
            var list = GetModels(mp);

            if (list.Count == 1)
                return list[0];

            return null;
        }

        public override bool Insert(ProductInfoVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = INSERT;
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Name", Value = ParameterHelper.ConvertValue(m.Name) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Desc", Value = ParameterHelper.ConvertValue(m.Desc) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@AdId", Value = ParameterHelper.ConvertValue(m.AdId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Price", Value = ParameterHelper.ConvertValue(m.Price) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@AttrText", Value = ParameterHelper.ConvertValue(m.AttrText) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@AttrStyle", Value = ParameterHelper.ConvertValue(m.AttrStyle) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@IsState", Value = ParameterHelper.ConvertValue(m.IsState) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@IsDelete", Value = ParameterHelper.ConvertValue(m.IsDelete) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateUserId", Value = ParameterHelper.ConvertValue(m.CreateUserId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateDate", Value = ParameterHelper.ConvertValue(m.CreateDate) });


            int result = DbProxyFactory.Instance.Proxy.ExecuteNonQuery(command);

            if (result >= 1) return true;

            return false;
        }

        public override int InsertIdentityId(ProductInfoVO m)
        {
            CodeCommand command = new CodeCommand();

            command.CommandText = INSERT + "; select @@Identity";

         command.Parameters.Add(new SqlParameter() { ParameterName = "@Name", Value = ParameterHelper.ConvertValue(m.Name) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Desc", Value = ParameterHelper.ConvertValue(m.Desc) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@AdId", Value = ParameterHelper.ConvertValue(m.AdId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@Price", Value = ParameterHelper.ConvertValue(m.Price) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@AttrText", Value = ParameterHelper.ConvertValue(m.AttrText) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@AttrStyle", Value = ParameterHelper.ConvertValue(m.AttrStyle) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@IsState", Value = ParameterHelper.ConvertValue(m.IsState) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@IsDelete", Value = ParameterHelper.ConvertValue(m.IsDelete) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateUserId", Value = ParameterHelper.ConvertValue(m.CreateUserId) });
         command.Parameters.Add(new SqlParameter() { ParameterName = "@CreateDate", Value = ParameterHelper.ConvertValue(m.CreateDate) });


            var result = DbProxyFactory.Instance.Proxy.ExecuteScalar(command);

            return int.Parse(result.ToString());
        }
    }
}
