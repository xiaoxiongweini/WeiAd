
/*

skey edit by 2017/7/16 9:01:29

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
    public partial class SysAreaCityVO: IModel
    {
        public SysAreaCityVO() { }

        public SysAreaCityVO(IDataReader row)
        {
          Id = ConvertHelper.GetInt(row["Id"]);
          Name = ConvertHelper.GetString(row["Name"]);
          ParentId = ConvertHelper.GetInt(row["ParentId"]);
          ZipCode = ConvertHelper.GetString(row["ZipCode"]);
          CreateTime = ConvertHelper.GetDateTime(row["CreateTime"]);

        }

        public SysAreaCityVO(DataRow row)
        {
          Id = ConvertHelper.GetInt(row["Id"]);
          Name = ConvertHelper.GetString(row["Name"]);
          ParentId = ConvertHelper.GetInt(row["ParentId"]);
          ZipCode = ConvertHelper.GetString(row["ZipCode"]);
          CreateTime = ConvertHelper.GetDateTime(row["CreateTime"]);

        }

       [Column(IsPrimaryKey = true, IsAutoNumber = true)]
       public int Id { get; set; }
       public string Name { get; set; }
       public int ParentId { get; set; }
       public string ZipCode { get; set; }
       public DateTime CreateTime { get; set; }


        public object Clone()
        {
            SysAreaCityVO obj = new SysAreaCityVO();
            
			            obj.Id = this.Id;

            obj.Name = this.Name;

            obj.ParentId = this.ParentId;

            obj.ZipCode = this.ZipCode;

            obj.CreateTime = this.CreateTime;



            return obj;
        }
    }
}
