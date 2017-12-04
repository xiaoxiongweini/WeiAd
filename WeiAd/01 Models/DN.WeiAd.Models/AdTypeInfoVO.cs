
/*

skey edit by 2017-04-24 20:20:38

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
    public partial class AdTypeInfoVO: IModel
    {
        public AdTypeInfoVO() { }

        public AdTypeInfoVO(IDataReader row)
        {
          Id = ConvertHelper.GetInt(row["Id"]);
          Name = ConvertHelper.GetString(row["Name"]);
          Desc = ConvertHelper.GetString(row["Desc"]);
          UserId = ConvertHelper.GetInt(row["UserId"]);
          CreateDate = ConvertHelper.GetDateTime(row["CreateDate"]);
          LastDate = ConvertHelper.GetDateTime(row["LastDate"]);

        }

        public AdTypeInfoVO(DataRow row)
        {
          Id = ConvertHelper.GetInt(row["Id"]);
          Name = ConvertHelper.GetString(row["Name"]);
          Desc = ConvertHelper.GetString(row["Desc"]);
          UserId = ConvertHelper.GetInt(row["UserId"]);
          CreateDate = ConvertHelper.GetDateTime(row["CreateDate"]);
          LastDate = ConvertHelper.GetDateTime(row["LastDate"]);

        }

       [Column(IsPrimaryKey = true, IsAutoNumber = true)]
       public int Id { get; set; }
       public string Name { get; set; }
       public string Desc { get; set; }
       public int UserId { get; set; }
       public DateTime CreateDate { get; set; }
       public DateTime LastDate { get; set; }


        public object Clone()
        {
            AdTypeInfoVO obj = new AdTypeInfoVO();
            
			            obj.Id = this.Id;

            obj.Name = this.Name;

            obj.Desc = this.Desc;

            obj.UserId = this.UserId;

            obj.CreateDate = this.CreateDate;

            obj.LastDate = this.LastDate;



            return obj;
        }
    }
}
