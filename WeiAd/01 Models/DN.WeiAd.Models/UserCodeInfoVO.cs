
/*

skey edit by 2017-04-19 21:20:20

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
    public partial class UserCodeInfoVO: IModel
    {
        public UserCodeInfoVO() { }

        public UserCodeInfoVO(IDataReader row)
        {
          Id = ConvertHelper.GetInt(row["Id"]);
          Name = ConvertHelper.GetString(row["Name"]);
          UserId = ConvertHelper.GetInt(row["UserId"]);
          TypeId = ConvertHelper.GetInt(row["TypeId"]);
          CodeContent = ConvertHelper.GetString(row["CodeContent"]);
          CreateDate = ConvertHelper.GetDateTime(row["CreateDate"]);

        }

        public UserCodeInfoVO(DataRow row)
        {
          Id = ConvertHelper.GetInt(row["Id"]);
          Name = ConvertHelper.GetString(row["Name"]);
          UserId = ConvertHelper.GetInt(row["UserId"]);
          TypeId = ConvertHelper.GetInt(row["TypeId"]);
          CodeContent = ConvertHelper.GetString(row["CodeContent"]);
          CreateDate = ConvertHelper.GetDateTime(row["CreateDate"]);

        }

       [Column(IsPrimaryKey = true, IsAutoNumber = true)]
       public int Id { get; set; }
       public string Name { get; set; }
       public int UserId { get; set; }
       public int TypeId { get; set; }
       public string CodeContent { get; set; }
       public DateTime CreateDate { get; set; }


        public object Clone()
        {
            UserCodeInfoVO obj = new UserCodeInfoVO();
            
			            obj.Id = this.Id;

            obj.Name = this.Name;

            obj.UserId = this.UserId;

            obj.TypeId = this.TypeId;

            obj.CodeContent = this.CodeContent;

            obj.CreateDate = this.CreateDate;



            return obj;
        }
    }
}
