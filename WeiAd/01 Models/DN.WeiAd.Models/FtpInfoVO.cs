
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
    public partial class FtpInfoVO: IModel
    {
        public FtpInfoVO() { }

        public FtpInfoVO(IDataReader row)
        {
          Id = ConvertHelper.GetInt(row["Id"]);
          Name = ConvertHelper.GetString(row["Name"]);
          Desc = ConvertHelper.GetString(row["Desc"]);
          Domains = ConvertHelper.GetString(row["Domains"]);
          FtpServer = ConvertHelper.GetString(row["FtpServer"]);
          FtpUserName = ConvertHelper.GetString(row["FtpUserName"]);
          FtpPassword = ConvertHelper.GetString(row["FtpPassword"]);
          IsSynchronization = ConvertHelper.GetInt(row["IsSynchronization"]);
          CreateDate = ConvertHelper.GetDateTime(row["CreateDate"]);
          CloseDate = ConvertHelper.GetDateTime(row["CloseDate"]);

        }

        public FtpInfoVO(DataRow row)
        {
          Id = ConvertHelper.GetInt(row["Id"]);
          Name = ConvertHelper.GetString(row["Name"]);
          Desc = ConvertHelper.GetString(row["Desc"]);
          Domains = ConvertHelper.GetString(row["Domains"]);
          FtpServer = ConvertHelper.GetString(row["FtpServer"]);
          FtpUserName = ConvertHelper.GetString(row["FtpUserName"]);
          FtpPassword = ConvertHelper.GetString(row["FtpPassword"]);
          IsSynchronization = ConvertHelper.GetInt(row["IsSynchronization"]);
          CreateDate = ConvertHelper.GetDateTime(row["CreateDate"]);
          CloseDate = ConvertHelper.GetDateTime(row["CloseDate"]);

        }

       [Column(IsPrimaryKey = true, IsAutoNumber = true)]
       public int Id { get; set; }
       public string Name { get; set; }
       public string Desc { get; set; }
       public string Domains { get; set; }
       public string FtpServer { get; set; }
       public string FtpUserName { get; set; }
       public string FtpPassword { get; set; }
       public int IsSynchronization { get; set; }
       public DateTime CreateDate { get; set; }
       public DateTime CloseDate { get; set; }


        public object Clone()
        {
            FtpInfoVO obj = new FtpInfoVO();
            
			            obj.Id = this.Id;

            obj.Name = this.Name;

            obj.Desc = this.Desc;

            obj.Domains = this.Domains;

            obj.FtpServer = this.FtpServer;

            obj.FtpUserName = this.FtpUserName;

            obj.FtpPassword = this.FtpPassword;

            obj.IsSynchronization = this.IsSynchronization;

            obj.CreateDate = this.CreateDate;

            obj.CloseDate = this.CloseDate;



            return obj;
        }
    }
}
