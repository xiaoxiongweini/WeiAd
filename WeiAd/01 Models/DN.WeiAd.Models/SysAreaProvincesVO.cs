
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
    public partial class SysAreaProvincesVO: IModel
    {
        public SysAreaProvincesVO() { }

        public SysAreaProvincesVO(IDataReader row)
        {
          Id = ConvertHelper.GetInt(row["Id"]);
          Name = ConvertHelper.GetString(row["Name"]);
          CreateTime = ConvertHelper.GetDateTime(row["CreateTime"]);

        }

        public SysAreaProvincesVO(DataRow row)
        {
          Id = ConvertHelper.GetInt(row["Id"]);
          Name = ConvertHelper.GetString(row["Name"]);
          CreateTime = ConvertHelper.GetDateTime(row["CreateTime"]);

        }

       [Column(IsPrimaryKey = true, IsAutoNumber = true)]
       public int Id { get; set; }
       public string Name { get; set; }
       public DateTime CreateTime { get; set; }


        public object Clone()
        {
            SysAreaProvincesVO obj = new SysAreaProvincesVO();
            
			            obj.Id = this.Id;

            obj.Name = this.Name;

            obj.CreateTime = this.CreateTime;



            return obj;
        }
    }
}
