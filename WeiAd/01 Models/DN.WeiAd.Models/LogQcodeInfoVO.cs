
/*

skey edit by 2017/12/4 12:00:28

mail:skey111@foxmail.com

version edit by v1.0.3

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
    public partial class LogQcodeInfoVO: IModel
    {
        public LogQcodeInfoVO() { }

        public LogQcodeInfoVO(IDataReader row)
        {
          Id = ConvertHelper.GetInt(row["Id"]);
          CopyText = ConvertHelper.GetString(row["CopyText"]);
          Url = ConvertHelper.GetString(row["Url"]);
          ClientIp = ConvertHelper.GetString(row["ClientIp"]);
          BrowseType = ConvertHelper.GetString(row["BrowseType"]);
          CreateDate = ConvertHelper.GetDateTime(row["CreateDate"]);
          Money = ConvertHelper.GetDecimal(row["Money"]);
          IsMoney = ConvertHelper.GetInt(row["IsMoney"]);
          Time = ConvertHelper.GetInt(row["Time"]);
          ClientId = ConvertHelper.GetString(row["ClientId"]);
          IsMobile = ConvertHelper.GetInt(row["IsMobile"]);
          ReferrerUrl = ConvertHelper.GetString(row["ReferrerUrl"]);
          BrowseName = ConvertHelper.GetString(row["BrowseName"]);
          BrowseVersion = ConvertHelper.GetString(row["BrowseVersion"]);
          OsName = ConvertHelper.GetString(row["OsName"]);
          Country = ConvertHelper.GetString(row["Country"]);
          Area = ConvertHelper.GetString(row["Area"]);
          Region = ConvertHelper.GetString(row["Region"]);
          City = ConvertHelper.GetString(row["City"]);
          County = ConvertHelper.GetString(row["County"]);
          Isp = ConvertHelper.GetString(row["Isp"]);
          IpSource = ConvertHelper.GetString(row["IpSource"]);

        }

        public LogQcodeInfoVO(DataRow row)
        {
          Id = ConvertHelper.GetInt(row["Id"]);
          CopyText = ConvertHelper.GetString(row["CopyText"]);
          Url = ConvertHelper.GetString(row["Url"]);
          ClientIp = ConvertHelper.GetString(row["ClientIp"]);
          BrowseType = ConvertHelper.GetString(row["BrowseType"]);
          CreateDate = ConvertHelper.GetDateTime(row["CreateDate"]);
          Money = ConvertHelper.GetDecimal(row["Money"]);
          IsMoney = ConvertHelper.GetInt(row["IsMoney"]);
          Time = ConvertHelper.GetInt(row["Time"]);
          ClientId = ConvertHelper.GetString(row["ClientId"]);
          IsMobile = ConvertHelper.GetInt(row["IsMobile"]);
          ReferrerUrl = ConvertHelper.GetString(row["ReferrerUrl"]);
          BrowseName = ConvertHelper.GetString(row["BrowseName"]);
          BrowseVersion = ConvertHelper.GetString(row["BrowseVersion"]);
          OsName = ConvertHelper.GetString(row["OsName"]);
          Country = ConvertHelper.GetString(row["Country"]);
          Area = ConvertHelper.GetString(row["Area"]);
          Region = ConvertHelper.GetString(row["Region"]);
          City = ConvertHelper.GetString(row["City"]);
          County = ConvertHelper.GetString(row["County"]);
          Isp = ConvertHelper.GetString(row["Isp"]);
          IpSource = ConvertHelper.GetString(row["IpSource"]);

        }

       [Column(IsPrimaryKey = true, IsAutoNumber = true)]
       public int Id { get; set; }
       public string CopyText { get; set; }
       public string Url { get; set; }
       public string ClientIp { get; set; }
       public string BrowseType { get; set; }
       public DateTime CreateDate { get; set; }
       public decimal Money { get; set; }
       public int IsMoney { get; set; }
       public int Time { get; set; }
       public string ClientId { get; set; }
       public int IsMobile { get; set; }
       public string ReferrerUrl { get; set; }
       public string BrowseName { get; set; }
       public string BrowseVersion { get; set; }
       public string OsName { get; set; }
       public string Country { get; set; }
       public string Area { get; set; }
       public string Region { get; set; }
       public string City { get; set; }
       public string County { get; set; }
       public string Isp { get; set; }
       public string IpSource { get; set; }


        public object Clone()
        {
            LogQcodeInfoVO obj = new LogQcodeInfoVO();
            
			            obj.Id = this.Id;

            obj.CopyText = this.CopyText;

            obj.Url = this.Url;

            obj.ClientIp = this.ClientIp;

            obj.BrowseType = this.BrowseType;

            obj.CreateDate = this.CreateDate;

            obj.Money = this.Money;

            obj.IsMoney = this.IsMoney;

            obj.Time = this.Time;

            obj.ClientId = this.ClientId;

            obj.IsMobile = this.IsMobile;

            obj.ReferrerUrl = this.ReferrerUrl;

            obj.BrowseName = this.BrowseName;

            obj.BrowseVersion = this.BrowseVersion;

            obj.OsName = this.OsName;

            obj.Country = this.Country;

            obj.Area = this.Area;

            obj.Region = this.Region;

            obj.City = this.City;

            obj.County = this.County;

            obj.Isp = this.Isp;

            obj.IpSource = this.IpSource;



            return obj;
        }
    }
}
