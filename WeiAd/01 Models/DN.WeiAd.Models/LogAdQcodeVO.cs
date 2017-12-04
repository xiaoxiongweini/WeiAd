
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
    public partial class LogAdQcodeVO: IModel
    {
        public LogAdQcodeVO() { }

        public LogAdQcodeVO(IDataReader row)
        {
          Id = ConvertHelper.GetInt(row["Id"]);
          AdId = ConvertHelper.GetInt(row["AdId"]);
          AdUserId = ConvertHelper.GetInt(row["AdUserId"]);
          QcodeId = ConvertHelper.GetInt(row["QcodeId"]);
          Url = ConvertHelper.GetString(row["Url"]);
          ClientIp = ConvertHelper.GetString(row["ClientIp"]);
          BrowseType = ConvertHelper.GetString(row["BrowseType"]);
          CreateDate = ConvertHelper.GetDateTime(row["CreateDate"]);
          Time = ConvertHelper.GetInt(row["Time"]);
          ClientId = ConvertHelper.GetString(row["ClientId"]);
          IsMobile = ConvertHelper.GetInt(row["IsMobile"]);
          ReferrerUrl = ConvertHelper.GetString(row["ReferrerUrl"]);
          BrowseName = ConvertHelper.GetString(row["BrowseName"]);
          BrowseVersion = ConvertHelper.GetString(row["BrowseVersion"]);
          OsName = ConvertHelper.GetString(row["OsName"]);

        }

        public LogAdQcodeVO(DataRow row)
        {
          Id = ConvertHelper.GetInt(row["Id"]);
          AdId = ConvertHelper.GetInt(row["AdId"]);
          AdUserId = ConvertHelper.GetInt(row["AdUserId"]);
          QcodeId = ConvertHelper.GetInt(row["QcodeId"]);
          Url = ConvertHelper.GetString(row["Url"]);
          ClientIp = ConvertHelper.GetString(row["ClientIp"]);
          BrowseType = ConvertHelper.GetString(row["BrowseType"]);
          CreateDate = ConvertHelper.GetDateTime(row["CreateDate"]);
          Time = ConvertHelper.GetInt(row["Time"]);
          ClientId = ConvertHelper.GetString(row["ClientId"]);
          IsMobile = ConvertHelper.GetInt(row["IsMobile"]);
          ReferrerUrl = ConvertHelper.GetString(row["ReferrerUrl"]);
          BrowseName = ConvertHelper.GetString(row["BrowseName"]);
          BrowseVersion = ConvertHelper.GetString(row["BrowseVersion"]);
          OsName = ConvertHelper.GetString(row["OsName"]);

        }

       [Column(IsPrimaryKey = true, IsAutoNumber = true)]
       public int Id { get; set; }
       public int AdId { get; set; }
       public int AdUserId { get; set; }
       public int QcodeId { get; set; }
       public string Url { get; set; }
       public string ClientIp { get; set; }
       public string BrowseType { get; set; }
       public DateTime CreateDate { get; set; }
       public int Time { get; set; }
       public string ClientId { get; set; }
       public int IsMobile { get; set; }
       public string ReferrerUrl { get; set; }
       public string BrowseName { get; set; }
       public string BrowseVersion { get; set; }
       public string OsName { get; set; }


        public object Clone()
        {
            LogAdQcodeVO obj = new LogAdQcodeVO();
            
			            obj.Id = this.Id;

            obj.AdId = this.AdId;

            obj.AdUserId = this.AdUserId;

            obj.QcodeId = this.QcodeId;

            obj.Url = this.Url;

            obj.ClientIp = this.ClientIp;

            obj.BrowseType = this.BrowseType;

            obj.CreateDate = this.CreateDate;

            obj.Time = this.Time;

            obj.ClientId = this.ClientId;

            obj.IsMobile = this.IsMobile;

            obj.ReferrerUrl = this.ReferrerUrl;

            obj.BrowseName = this.BrowseName;

            obj.BrowseVersion = this.BrowseVersion;

            obj.OsName = this.OsName;



            return obj;
        }
    }
}
