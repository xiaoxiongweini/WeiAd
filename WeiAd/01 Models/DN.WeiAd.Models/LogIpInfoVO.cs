
/*

skey edit by 2017-04-29 23:14:11

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
    public partial class LogIpInfoVO: IModel
    {
        public LogIpInfoVO() { }

        public LogIpInfoVO(IDataReader row)
        {
          Id = ConvertHelper.GetInt(row["Id"]);
          Ip = ConvertHelper.GetString(row["Ip"]);
          country = ConvertHelper.GetString(row["country"]);
          area = ConvertHelper.GetString(row["area"]);
          region = ConvertHelper.GetString(row["region"]);
          city = ConvertHelper.GetString(row["city"]);
          county = ConvertHelper.GetString(row["county"]);
          isp = ConvertHelper.GetString(row["isp"]);
          CreateDate = ConvertHelper.GetDateTimeNullable(row["CreateDate"]);

        }

        public LogIpInfoVO(DataRow row)
        {
          Id = ConvertHelper.GetInt(row["Id"]);
          Ip = ConvertHelper.GetString(row["Ip"]);
          country = ConvertHelper.GetString(row["country"]);
          area = ConvertHelper.GetString(row["area"]);
          region = ConvertHelper.GetString(row["region"]);
          city = ConvertHelper.GetString(row["city"]);
          county = ConvertHelper.GetString(row["county"]);
          isp = ConvertHelper.GetString(row["isp"]);
          CreateDate = ConvertHelper.GetDateTimeNullable(row["CreateDate"]);

        }

       [Column(IsPrimaryKey = true, IsAutoNumber = true)]
       public int Id { get; set; }
       public string Ip { get; set; }
       public string country { get; set; }
       public string area { get; set; }
       public string region { get; set; }
       public string city { get; set; }
       public string county { get; set; }
       public string isp { get; set; }
       public DateTime? CreateDate { get; set; }


        public object Clone()
        {
            LogIpInfoVO obj = new LogIpInfoVO();
            
			            obj.Id = this.Id;

            obj.Ip = this.Ip;

            obj.country = this.country;

            obj.area = this.area;

            obj.region = this.region;

            obj.city = this.city;

            obj.county = this.county;

            obj.isp = this.isp;

            obj.CreateDate = this.CreateDate;



            return obj;
        }
    }
}
