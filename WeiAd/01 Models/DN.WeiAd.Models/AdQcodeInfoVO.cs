
/*

skey edit by 2017/5/16 18:51:31

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
    public partial class AdQcodeInfoVO: IModel
    {
        public AdQcodeInfoVO() { }

        public AdQcodeInfoVO(IDataReader row)
        {
          Id = ConvertHelper.GetInt(row["Id"]);
          AdId = ConvertHelper.GetInt(row["AdId"]);
          AdUserId = ConvertHelper.GetInt(row["AdUserId"]);
          Name = ConvertHelper.GetString(row["Name"]);
          QcodeUrl = ConvertHelper.GetString(row["QcodeUrl"]);
          CreateDate = ConvertHelper.GetDateTime(row["CreateDate"]);
          CreateUserId = ConvertHelper.GetInt(row["CreateUserId"]);
          QcodeUrl2 = ConvertHelper.GetString(row["QcodeUrl2"]);

        }

        public AdQcodeInfoVO(DataRow row)
        {
          Id = ConvertHelper.GetInt(row["Id"]);
          AdId = ConvertHelper.GetInt(row["AdId"]);
          AdUserId = ConvertHelper.GetInt(row["AdUserId"]);
          Name = ConvertHelper.GetString(row["Name"]);
          QcodeUrl = ConvertHelper.GetString(row["QcodeUrl"]);
          CreateDate = ConvertHelper.GetDateTime(row["CreateDate"]);
          CreateUserId = ConvertHelper.GetInt(row["CreateUserId"]);
          QcodeUrl2 = ConvertHelper.GetString(row["QcodeUrl2"]);

        }

       [Column(IsPrimaryKey = true, IsAutoNumber = true)]
       public int Id { get; set; }
       public int AdId { get; set; }
       public int AdUserId { get; set; }
       public string Name { get; set; }
       public string QcodeUrl { get; set; }
       public DateTime CreateDate { get; set; }
       public int CreateUserId { get; set; }
       public string QcodeUrl2 { get; set; }


        public object Clone()
        {
            AdQcodeInfoVO obj = new AdQcodeInfoVO();
            
			            obj.Id = this.Id;

            obj.AdId = this.AdId;

            obj.AdUserId = this.AdUserId;

            obj.Name = this.Name;

            obj.QcodeUrl = this.QcodeUrl;

            obj.CreateDate = this.CreateDate;

            obj.CreateUserId = this.CreateUserId;

            obj.QcodeUrl2 = this.QcodeUrl2;



            return obj;
        }
    }
}
