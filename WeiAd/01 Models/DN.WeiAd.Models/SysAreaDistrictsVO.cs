
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
    public partial class SysAreaDistrictsVO: IModel
    {
        public SysAreaDistrictsVO() { }

        public SysAreaDistrictsVO(IDataReader row)
        {
          Id = ConvertHelper.GetInt(row["Id"]);
          Name = ConvertHelper.GetString(row["Name"]);
          CityId = ConvertHelper.GetInt(row["CityId"]);
          ProvincesId = ConvertHelper.GetInt(row["ProvincesId"]);
          CreateTime = ConvertHelper.GetDateTime(row["CreateTime"]);

        }

        public SysAreaDistrictsVO(DataRow row)
        {
          Id = ConvertHelper.GetInt(row["Id"]);
          Name = ConvertHelper.GetString(row["Name"]);
          CityId = ConvertHelper.GetInt(row["CityId"]);
          ProvincesId = ConvertHelper.GetInt(row["ProvincesId"]);
          CreateTime = ConvertHelper.GetDateTime(row["CreateTime"]);

        }

       [Column(IsPrimaryKey = true, IsAutoNumber = true)]
       public int Id { get; set; }
       public string Name { get; set; }
       public int CityId { get; set; }
       public int ProvincesId { get; set; }
       public DateTime CreateTime { get; set; }


        public object Clone()
        {
            SysAreaDistrictsVO obj = new SysAreaDistrictsVO();
            
			            obj.Id = this.Id;

            obj.Name = this.Name;

            obj.CityId = this.CityId;

            obj.ProvincesId = this.ProvincesId;

            obj.CreateTime = this.CreateTime;



            return obj;
        }
    }
}
