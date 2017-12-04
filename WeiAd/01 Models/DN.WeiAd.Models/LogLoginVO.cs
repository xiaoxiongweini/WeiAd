
/*

skey edit by 2017-04-19 21:20:19

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
    public partial class LogLoginVO: IModel
    {
        public LogLoginVO() { }

        public LogLoginVO(IDataReader row)
        {
          Id = ConvertHelper.GetInt(row["Id"]);
          LoginName = ConvertHelper.GetString(row["LoginName"]);
          LoginState = ConvertHelper.GetInt(row["LoginState"]);
          LoginDesc = ConvertHelper.GetString(row["LoginDesc"]);
          LoginDate = ConvertHelper.GetDateTime(row["LoginDate"]);
          ClientIp = ConvertHelper.GetString(row["ClientIp"]);
          BrowseType = ConvertHelper.GetString(row["BrowseType"]);
          LoginType = ConvertHelper.GetInt(row["LoginType"]);

        }

        public LogLoginVO(DataRow row)
        {
          Id = ConvertHelper.GetInt(row["Id"]);
          LoginName = ConvertHelper.GetString(row["LoginName"]);
          LoginState = ConvertHelper.GetInt(row["LoginState"]);
          LoginDesc = ConvertHelper.GetString(row["LoginDesc"]);
          LoginDate = ConvertHelper.GetDateTime(row["LoginDate"]);
          ClientIp = ConvertHelper.GetString(row["ClientIp"]);
          BrowseType = ConvertHelper.GetString(row["BrowseType"]);
          LoginType = ConvertHelper.GetInt(row["LoginType"]);

        }

       [Column(IsPrimaryKey = true, IsAutoNumber = true)]
       public int Id { get; set; }
       public string LoginName { get; set; }
       public int LoginState { get; set; }
       public string LoginDesc { get; set; }
       public DateTime LoginDate { get; set; }
       public string ClientIp { get; set; }
       public string BrowseType { get; set; }
       public int LoginType { get; set; }


        public object Clone()
        {
            LogLoginVO obj = new LogLoginVO();
            
			            obj.Id = this.Id;

            obj.LoginName = this.LoginName;

            obj.LoginState = this.LoginState;

            obj.LoginDesc = this.LoginDesc;

            obj.LoginDate = this.LoginDate;

            obj.ClientIp = this.ClientIp;

            obj.BrowseType = this.BrowseType;

            obj.LoginType = this.LoginType;



            return obj;
        }
    }
}
