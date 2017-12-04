
/*

skey edit by 2017/7/19 15:50:42

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
    public partial class DomainInfoVO: IModel
    {
        public DomainInfoVO() { }

        public DomainInfoVO(IDataReader row)
        {
          Id = ConvertHelper.GetInt(row["Id"]);
          Name = ConvertHelper.GetString(row["Name"]);
          Domain = ConvertHelper.GetString(row["Domain"]);
          PageName = ConvertHelper.GetString(row["PageName"]);
          IsState = ConvertHelper.GetInt(row["IsState"]);
          IsAuth = ConvertHelper.GetInt(row["IsAuth"]);
          CityName = ConvertHelper.GetString(row["CityName"]);
          CreateDate = ConvertHelper.GetDateTime(row["CreateDate"]);
          CreateUserId = ConvertHelper.GetInt(row["CreateUserId"]);
          IsColse = ConvertHelper.GetInt(row["IsColse"]);
          ColseDate = ConvertHelper.GetDateTime(row["ColseDate"]);
          CloseUserId = ConvertHelper.GetInt(row["CloseUserId"]);
          AdUserId = ConvertHelper.GetInt(row["AdUserId"]);
          IsResolution = ConvertHelper.GetInt(row["IsResolution"]);
          ResolutionDate = ConvertHelper.GetDateTime(row["ResolutionDate"]);
          SerName = ConvertHelper.GetString(row["SerName"]);
          ResolutionType = ConvertHelper.GetInt(row["ResolutionType"]);

        }

        public DomainInfoVO(DataRow row)
        {
          Id = ConvertHelper.GetInt(row["Id"]);
          Name = ConvertHelper.GetString(row["Name"]);
          Domain = ConvertHelper.GetString(row["Domain"]);
          PageName = ConvertHelper.GetString(row["PageName"]);
          IsState = ConvertHelper.GetInt(row["IsState"]);
          IsAuth = ConvertHelper.GetInt(row["IsAuth"]);
          CityName = ConvertHelper.GetString(row["CityName"]);
          CreateDate = ConvertHelper.GetDateTime(row["CreateDate"]);
          CreateUserId = ConvertHelper.GetInt(row["CreateUserId"]);
          IsColse = ConvertHelper.GetInt(row["IsColse"]);
          ColseDate = ConvertHelper.GetDateTime(row["ColseDate"]);
          CloseUserId = ConvertHelper.GetInt(row["CloseUserId"]);
          AdUserId = ConvertHelper.GetInt(row["AdUserId"]);
          IsResolution = ConvertHelper.GetInt(row["IsResolution"]);
          ResolutionDate = ConvertHelper.GetDateTime(row["ResolutionDate"]);
          SerName = ConvertHelper.GetString(row["SerName"]);
          ResolutionType = ConvertHelper.GetInt(row["ResolutionType"]);

        }

       [Column(IsPrimaryKey = true, IsAutoNumber = true)]
       public int Id { get; set; }
       public string Name { get; set; }
       public string Domain { get; set; }
       public string PageName { get; set; }
       public int IsState { get; set; }
       public int IsAuth { get; set; }
       public string CityName { get; set; }
       public DateTime CreateDate { get; set; }
       public int CreateUserId { get; set; }
       public int IsColse { get; set; }
       public DateTime ColseDate { get; set; }
       public int CloseUserId { get; set; }
       public int AdUserId { get; set; }
       public int IsResolution { get; set; }
       public DateTime ResolutionDate { get; set; }
       public string SerName { get; set; }
       public int ResolutionType { get; set; }


        public object Clone()
        {
            DomainInfoVO obj = new DomainInfoVO();
            
			            obj.Id = this.Id;

            obj.Name = this.Name;

            obj.Domain = this.Domain;

            obj.PageName = this.PageName;

            obj.IsState = this.IsState;

            obj.IsAuth = this.IsAuth;

            obj.CityName = this.CityName;

            obj.CreateDate = this.CreateDate;

            obj.CreateUserId = this.CreateUserId;

            obj.IsColse = this.IsColse;

            obj.ColseDate = this.ColseDate;

            obj.CloseUserId = this.CloseUserId;

            obj.AdUserId = this.AdUserId;

            obj.IsResolution = this.IsResolution;

            obj.ResolutionDate = this.ResolutionDate;

            obj.SerName = this.SerName;

            obj.ResolutionType = this.ResolutionType;



            return obj;
        }
    }
}
