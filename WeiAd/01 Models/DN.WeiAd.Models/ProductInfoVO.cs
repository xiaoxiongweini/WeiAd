
/*

skey edit by 2017/7/24 9:27:32

*/


using DN.Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DN.Framework.Core.CodeAttributes;
using System.Data;
using DN.Framework.Utility;

namespace DN.WeiAd.Models
{
    /// <summary>
    /// 用户登录日志
    /// </summary>
    public partial class ProductInfoVO: IModel
    {
        public ProductInfoVO() { }

        public ProductInfoVO(IDataReader row)
        {
          Id = ConvertHelper.GetInt(row["Id"]);
          Name = ConvertHelper.GetString(row["Name"]);
          Desc = ConvertHelper.GetString(row["Desc"]);
          AdId = ConvertHelper.GetInt(row["AdId"]);
          Price = ConvertHelper.GetInt(row["Price"]);
          AttrText = ConvertHelper.GetString(row["AttrText"]);
          AttrStyle = ConvertHelper.GetString(row["AttrStyle"]);
          IsState = ConvertHelper.GetInt(row["IsState"]);
          IsDelete = ConvertHelper.GetInt(row["IsDelete"]);
          CreateUserId = ConvertHelper.GetInt(row["CreateUserId"]);
          CreateDate = ConvertHelper.GetDateTime(row["CreateDate"]);

        }

        public ProductInfoVO(DataRow row)
        {
          Id = ConvertHelper.GetInt(row["Id"]);
          Name = ConvertHelper.GetString(row["Name"]);
          Desc = ConvertHelper.GetString(row["Desc"]);
          AdId = ConvertHelper.GetInt(row["AdId"]);
          Price = ConvertHelper.GetInt(row["Price"]);
          AttrText = ConvertHelper.GetString(row["AttrText"]);
          AttrStyle = ConvertHelper.GetString(row["AttrStyle"]);
          IsState = ConvertHelper.GetInt(row["IsState"]);
          IsDelete = ConvertHelper.GetInt(row["IsDelete"]);
          CreateUserId = ConvertHelper.GetInt(row["CreateUserId"]);
          CreateDate = ConvertHelper.GetDateTime(row["CreateDate"]);

        }

       [Column(IsPrimaryKey = true, IsAutoNumber = true)]
       public int Id { get; set; }
       public string Name { get; set; }
       public string Desc { get; set; }
       public int AdId { get; set; }
       public int Price { get; set; }
       public string AttrText { get; set; }
       public string AttrStyle { get; set; }
       public int IsState { get; set; }
       public int IsDelete { get; set; }
       public int CreateUserId { get; set; }
       public DateTime CreateDate { get; set; }


        public object Clone()
        {
            ProductInfoVO obj = new ProductInfoVO();
            
			            obj.Id = this.Id;

            obj.Name = this.Name;

            obj.Desc = this.Desc;

            obj.AdId = this.AdId;

            obj.Price = this.Price;

            obj.AttrText = this.AttrText;

            obj.AttrStyle = this.AttrStyle;

            obj.IsState = this.IsState;

            obj.IsDelete = this.IsDelete;

            obj.CreateUserId = this.CreateUserId;

            obj.CreateDate = this.CreateDate;



            return obj;
        }
    }
}
