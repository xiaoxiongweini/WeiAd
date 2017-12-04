
/*

skey edit by 2017/7/28 8:34:36

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
    public partial class ServerInfoVO: IModel
    {
        public ServerInfoVO() { }

        public ServerInfoVO(IDataReader row)
        {
          Id = ConvertHelper.GetInt(row["Id"]);
          ServerId = ConvertHelper.GetString(row["ServerId"]);
          Name = ConvertHelper.GetString(row["Name"]);
          Desc = ConvertHelper.GetString(row["Desc"]);
          Ip = ConvertHelper.GetString(row["Ip"]);
          CreateDate = ConvertHelper.GetDateTime(row["CreateDate"]);
          IsState = ConvertHelper.GetInt(row["IsState"]);
          UpdateDate = ConvertHelper.GetDateTime(row["UpdateDate"]);
          UserId = ConvertHelper.GetInt(row["UserId"]);

        }

        public ServerInfoVO(DataRow row)
        {
          Id = ConvertHelper.GetInt(row["Id"]);
          ServerId = ConvertHelper.GetString(row["ServerId"]);
          Name = ConvertHelper.GetString(row["Name"]);
          Desc = ConvertHelper.GetString(row["Desc"]);
          Ip = ConvertHelper.GetString(row["Ip"]);
          CreateDate = ConvertHelper.GetDateTime(row["CreateDate"]);
          IsState = ConvertHelper.GetInt(row["IsState"]);
          UpdateDate = ConvertHelper.GetDateTime(row["UpdateDate"]);
          UserId = ConvertHelper.GetInt(row["UserId"]);

        }

       [Column(IsPrimaryKey = true, IsAutoNumber = true)]
       public int Id { get; set; }
       public string ServerId { get; set; }
       public string Name { get; set; }
       public string Desc { get; set; }
       public string Ip { get; set; }
       public DateTime CreateDate { get; set; }
       public int IsState { get; set; }
       public DateTime UpdateDate { get; set; }
       public int UserId { get; set; }


        public object Clone()
        {
            ServerInfoVO obj = new ServerInfoVO();
            
			            obj.Id = this.Id;

            obj.ServerId = this.ServerId;

            obj.Name = this.Name;

            obj.Desc = this.Desc;

            obj.Ip = this.Ip;

            obj.CreateDate = this.CreateDate;

            obj.IsState = this.IsState;

            obj.UpdateDate = this.UpdateDate;

            obj.UserId = this.UserId;



            return obj;
        }
    }
}
