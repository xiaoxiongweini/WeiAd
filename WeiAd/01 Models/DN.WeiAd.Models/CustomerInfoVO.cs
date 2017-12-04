
/*

skey edit by 2017/8/21 15:16:48

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
    public partial class CustomerInfoVO: IModel
    {
        public CustomerInfoVO() { }

        public CustomerInfoVO(IDataReader row)
        {
          Id = ConvertHelper.GetInt(row["Id"]);
          AdUrl = ConvertHelper.GetString(row["AdUrl"]);
          AdId = ConvertHelper.GetInt(row["AdId"]);
          AdUserId = ConvertHelper.GetInt(row["AdUserId"]);
          RealName = ConvertHelper.GetString(row["RealName"]);
          Phone = ConvertHelper.GetString(row["Phone"]);
          WeiXinNum = ConvertHelper.GetString(row["WeiXinNum"]);
          Remark = ConvertHelper.GetString(row["Remark"]);
          Address = ConvertHelper.GetString(row["Address"]);
          UserCountry = ConvertHelper.GetString(row["UserCountry"]);
          UserRegion = ConvertHelper.GetString(row["UserRegion"]);
          UserCity = ConvertHelper.GetString(row["UserCity"]);
          ClientIp = ConvertHelper.GetString(row["ClientIp"]);
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
          CreateDate = ConvertHelper.GetDateTime(row["CreateDate"]);
          Num = ConvertHelper.GetInt(row["Num"]);
          Price = ConvertHelper.GetDecimal(row["Price"]);
          ProducteName = ConvertHelper.GetString(row["ProducteName"]);
          Color = ConvertHelper.GetString(row["Color"]);
          Size = ConvertHelper.GetString(row["Size"]);
          IsDelete = ConvertHelper.GetInt(row["IsDelete"]);
          UserAttr = ConvertHelper.GetString(row["UserAttr"]);
          CheckState = ConvertHelper.GetInt(row["CheckState"]);
          CheckRemark = ConvertHelper.GetString(row["CheckRemark"]);
          IsExport = ConvertHelper.GetInt(row["IsExport"]);
          ExportUserId = ConvertHelper.GetInt(row["ExportUserId"]);
          ExportDate = ConvertHelper.GetDateTime(row["ExportDate"]);

        }

        public CustomerInfoVO(DataRow row)
        {
          Id = ConvertHelper.GetInt(row["Id"]);
          AdUrl = ConvertHelper.GetString(row["AdUrl"]);
          AdId = ConvertHelper.GetInt(row["AdId"]);
          AdUserId = ConvertHelper.GetInt(row["AdUserId"]);
          RealName = ConvertHelper.GetString(row["RealName"]);
          Phone = ConvertHelper.GetString(row["Phone"]);
          WeiXinNum = ConvertHelper.GetString(row["WeiXinNum"]);
          Remark = ConvertHelper.GetString(row["Remark"]);
          Address = ConvertHelper.GetString(row["Address"]);
          UserCountry = ConvertHelper.GetString(row["UserCountry"]);
          UserRegion = ConvertHelper.GetString(row["UserRegion"]);
          UserCity = ConvertHelper.GetString(row["UserCity"]);
          ClientIp = ConvertHelper.GetString(row["ClientIp"]);
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
          CreateDate = ConvertHelper.GetDateTime(row["CreateDate"]);
          Num = ConvertHelper.GetInt(row["Num"]);
          Price = ConvertHelper.GetDecimal(row["Price"]);
          ProducteName = ConvertHelper.GetString(row["ProducteName"]);
          Color = ConvertHelper.GetString(row["Color"]);
          Size = ConvertHelper.GetString(row["Size"]);
          IsDelete = ConvertHelper.GetInt(row["IsDelete"]);
          UserAttr = ConvertHelper.GetString(row["UserAttr"]);
          CheckState = ConvertHelper.GetInt(row["CheckState"]);
          CheckRemark = ConvertHelper.GetString(row["CheckRemark"]);
          IsExport = ConvertHelper.GetInt(row["IsExport"]);
          ExportUserId = ConvertHelper.GetInt(row["ExportUserId"]);
          ExportDate = ConvertHelper.GetDateTime(row["ExportDate"]);

        }

       [Column(IsPrimaryKey = true, IsAutoNumber = true)]
       public int Id { get; set; }
       public string AdUrl { get; set; }
       public int AdId { get; set; }
       public int AdUserId { get; set; }
       public string RealName { get; set; }
       public string Phone { get; set; }
       public string WeiXinNum { get; set; }
       public string Remark { get; set; }
       public string Address { get; set; }
       public string UserCountry { get; set; }
       public string UserRegion { get; set; }
       public string UserCity { get; set; }
       public string ClientIp { get; set; }
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
       public DateTime CreateDate { get; set; }
       public int Num { get; set; }
       public decimal Price { get; set; }
       public string ProducteName { get; set; }
       public string Color { get; set; }
       public string Size { get; set; }
       public int IsDelete { get; set; }
       public string UserAttr { get; set; }
       public int CheckState { get; set; }
       public string CheckRemark { get; set; }
       public int IsExport { get; set; }
       public int ExportUserId { get; set; }
       public DateTime ExportDate { get; set; }


        public object Clone()
        {
            CustomerInfoVO obj = new CustomerInfoVO();
            
			            obj.Id = this.Id;

            obj.AdUrl = this.AdUrl;

            obj.AdId = this.AdId;

            obj.AdUserId = this.AdUserId;

            obj.RealName = this.RealName;

            obj.Phone = this.Phone;

            obj.WeiXinNum = this.WeiXinNum;

            obj.Remark = this.Remark;

            obj.Address = this.Address;

            obj.UserCountry = this.UserCountry;

            obj.UserRegion = this.UserRegion;

            obj.UserCity = this.UserCity;

            obj.ClientIp = this.ClientIp;

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

            obj.CreateDate = this.CreateDate;

            obj.Num = this.Num;

            obj.Price = this.Price;

            obj.ProducteName = this.ProducteName;

            obj.Color = this.Color;

            obj.Size = this.Size;

            obj.IsDelete = this.IsDelete;

            obj.UserAttr = this.UserAttr;

            obj.CheckState = this.CheckState;

            obj.CheckRemark = this.CheckRemark;

            obj.IsExport = this.IsExport;

            obj.ExportUserId = this.ExportUserId;

            obj.ExportDate = this.ExportDate;



            return obj;
        }
    }
}
