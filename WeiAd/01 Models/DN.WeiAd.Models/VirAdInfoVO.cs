
/*

skey edit by 2017/7/17 16:02:27

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
    public partial class VirAdInfoVO: IModel
    {
        public VirAdInfoVO() { }

        public VirAdInfoVO(IDataReader row)
        {
          Id = ConvertHelper.GetInt(row["Id"]);
          Name = ConvertHelper.GetString(row["Name"]);
          UserId = ConvertHelper.GetInt(row["UserId"]);
          Desc = ConvertHelper.GetString(row["Desc"]);
          LinkUrl = ConvertHelper.GetInt(row["LinkUrl"]);
          Price = ConvertHelper.GetDecimal(row["Price"]);
          ShowCount = ConvertHelper.GetInt(row["ShowCount"]);
          ClickCount = ConvertHelper.GetInt(row["ClickCount"]);
          VaildClickCount = ConvertHelper.GetInt(row["VaildClickCount"]);
          IpCount = ConvertHelper.GetInt(row["IpCount"]);
          MaxCount = ConvertHelper.GetInt(row["MaxCount"]);
          CreateDate = ConvertHelper.GetDateTime(row["CreateDate"]);
          CreateUserId = ConvertHelper.GetInt(row["CreateUserId"]);

        }

        public VirAdInfoVO(DataRow row)
        {
          Id = ConvertHelper.GetInt(row["Id"]);
          Name = ConvertHelper.GetString(row["Name"]);
          UserId = ConvertHelper.GetInt(row["UserId"]);
          Desc = ConvertHelper.GetString(row["Desc"]);
          LinkUrl = ConvertHelper.GetInt(row["LinkUrl"]);
          Price = ConvertHelper.GetDecimal(row["Price"]);
          ShowCount = ConvertHelper.GetInt(row["ShowCount"]);
          ClickCount = ConvertHelper.GetInt(row["ClickCount"]);
          VaildClickCount = ConvertHelper.GetInt(row["VaildClickCount"]);
          IpCount = ConvertHelper.GetInt(row["IpCount"]);
          MaxCount = ConvertHelper.GetInt(row["MaxCount"]);
          CreateDate = ConvertHelper.GetDateTime(row["CreateDate"]);
          CreateUserId = ConvertHelper.GetInt(row["CreateUserId"]);

        }

       [Column(IsPrimaryKey = true, IsAutoNumber = true)]
       public int Id { get; set; }
       public string Name { get; set; }
       public int UserId { get; set; }
       public string Desc { get; set; }
       public int LinkUrl { get; set; }
       public decimal Price { get; set; }
       public int ShowCount { get; set; }
       public int ClickCount { get; set; }
       public int VaildClickCount { get; set; }
       public int IpCount { get; set; }
       public int MaxCount { get; set; }
       public DateTime CreateDate { get; set; }
       public int CreateUserId { get; set; }


        public object Clone()
        {
            VirAdInfoVO obj = new VirAdInfoVO();
            
			            obj.Id = this.Id;

            obj.Name = this.Name;

            obj.UserId = this.UserId;

            obj.Desc = this.Desc;

            obj.LinkUrl = this.LinkUrl;

            obj.Price = this.Price;

            obj.ShowCount = this.ShowCount;

            obj.ClickCount = this.ClickCount;

            obj.VaildClickCount = this.VaildClickCount;

            obj.IpCount = this.IpCount;

            obj.MaxCount = this.MaxCount;

            obj.CreateDate = this.CreateDate;

            obj.CreateUserId = this.CreateUserId;



            return obj;
        }
    }
}
