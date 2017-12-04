
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
    public partial class AdBrowseVO: IModel
    {
        public AdBrowseVO() { }

        public AdBrowseVO(IDataReader row)
        {
          Id = ConvertHelper.GetInt(row["Id"]);
          Url = ConvertHelper.GetString(row["Url"]);
          ClientIp = ConvertHelper.GetString(row["ClientIp"]);
          BrowseType = ConvertHelper.GetString(row["BrowseType"]);
          CreateDate = ConvertHelper.GetDateTime(row["CreateDate"]);
          AdId = ConvertHelper.GetInt(row["AdId"]);
          AdUserId = ConvertHelper.GetInt(row["AdUserId"]);
          FlowUserId = ConvertHelper.GetInt(row["FlowUserId"]);
          AdUrl = ConvertHelper.GetString(row["AdUrl"]);
          Money = ConvertHelper.GetDecimal(row["Money"]);
          IsMoney = ConvertHelper.GetInt(row["IsMoney"]);
          Time = ConvertHelper.GetInt(row["Time"]);
          ClientId = ConvertHelper.GetString(row["ClientId"]);
          IsMobile = ConvertHelper.GetInt(row["IsMobile"]);
          ReferrerUrl = ConvertHelper.GetString(row["ReferrerUrl"]);
          BrowseName = ConvertHelper.GetString(row["BrowseName"]);
          BrowseVersion = ConvertHelper.GetString(row["BrowseVersion"]);
          OsName = ConvertHelper.GetString(row["OsName"]);

        }

        public AdBrowseVO(DataRow row)
        {
          Id = ConvertHelper.GetInt(row["Id"]);
          Url = ConvertHelper.GetString(row["Url"]);
          ClientIp = ConvertHelper.GetString(row["ClientIp"]);
          BrowseType = ConvertHelper.GetString(row["BrowseType"]);
          CreateDate = ConvertHelper.GetDateTime(row["CreateDate"]);
          AdId = ConvertHelper.GetInt(row["AdId"]);
          AdUserId = ConvertHelper.GetInt(row["AdUserId"]);
          FlowUserId = ConvertHelper.GetInt(row["FlowUserId"]);
          AdUrl = ConvertHelper.GetString(row["AdUrl"]);
          Money = ConvertHelper.GetDecimal(row["Money"]);
          IsMoney = ConvertHelper.GetInt(row["IsMoney"]);
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
       public string Url { get; set; }
       public string ClientIp { get; set; }
       public string BrowseType { get; set; }
       public DateTime CreateDate { get; set; }
       public int AdId { get; set; }
       public int AdUserId { get; set; }
       public int FlowUserId { get; set; }
       public string AdUrl { get; set; }
       public decimal Money { get; set; }
       public int IsMoney { get; set; }
       public int Time { get; set; }
       public string ClientId { get; set; }
       public int IsMobile { get; set; }
       public string ReferrerUrl { get; set; }
       public string BrowseName { get; set; }
       public string BrowseVersion { get; set; }
       public string OsName { get; set; }


        public object Clone()
        {
            AdBrowseVO obj = new AdBrowseVO();
            
			            obj.Id = this.Id;

            obj.Url = this.Url;

            obj.ClientIp = this.ClientIp;

            obj.BrowseType = this.BrowseType;

            obj.CreateDate = this.CreateDate;

            obj.AdId = this.AdId;

            obj.AdUserId = this.AdUserId;

            obj.FlowUserId = this.FlowUserId;

            obj.AdUrl = this.AdUrl;

            obj.Money = this.Money;

            obj.IsMoney = this.IsMoney;

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