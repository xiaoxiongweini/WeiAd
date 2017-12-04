
/*

skey edit by 2017-05-01 15:14:53

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
    public partial class VersionInfoVO: IModel
    {
        public VersionInfoVO() { }

        public VersionInfoVO(IDataReader row)
        {
          Id = ConvertHelper.GetInt(row["Id"]);
          Name = ConvertHelper.GetString(row["Name"]);
          Desc = ConvertHelper.GetString(row["Desc"]);
          CreateDate = ConvertHelper.GetDateTime(row["CreateDate"]);

        }

        public VersionInfoVO(DataRow row)
        {
          Id = ConvertHelper.GetInt(row["Id"]);
          Name = ConvertHelper.GetString(row["Name"]);
          Desc = ConvertHelper.GetString(row["Desc"]);
          CreateDate = ConvertHelper.GetDateTime(row["CreateDate"]);

        }

       [Column(IsPrimaryKey = true, IsAutoNumber = true)]
       public int Id { get; set; }
       public string Name { get; set; }
       public string Desc { get; set; }
       public DateTime CreateDate { get; set; }


        public object Clone()
        {
            VersionInfoVO obj = new VersionInfoVO();
            
			            obj.Id = this.Id;

            obj.Name = this.Name;

            obj.Desc = this.Desc;

            obj.CreateDate = this.CreateDate;



            return obj;
        }
    }
}
