
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
    public partial class AdUserPageVO: IModel
    {
        public AdUserPageVO() { }

        public AdUserPageVO(IDataReader row)
        {
          Id = ConvertHelper.GetInt(row["Id"]);
          Gid = ConvertHelper.GetString(row["Gid"]);
          PageName = ConvertHelper.GetString(row["PageName"]);
          AdPageId = ConvertHelper.GetInt(row["AdPageId"]);
          AdUserId = ConvertHelper.GetInt(row["AdUserId"]);
          IsState = ConvertHelper.GetInt(row["IsState"]);
          CreateDate = ConvertHelper.GetDateTime(row["CreateDate"]);
          CreateUserId = ConvertHelper.GetInt(row["CreateUserId"]);
          FlowUserId = ConvertHelper.GetInt(row["FlowUserId"]);
          FlowLastDate = ConvertHelper.GetDateTime(row["FlowLastDate"]);

        }

        public AdUserPageVO(DataRow row)
        {
          Id = ConvertHelper.GetInt(row["Id"]);
          Gid = ConvertHelper.GetString(row["Gid"]);
          PageName = ConvertHelper.GetString(row["PageName"]);
          AdPageId = ConvertHelper.GetInt(row["AdPageId"]);
          AdUserId = ConvertHelper.GetInt(row["AdUserId"]);
          IsState = ConvertHelper.GetInt(row["IsState"]);
          CreateDate = ConvertHelper.GetDateTime(row["CreateDate"]);
          CreateUserId = ConvertHelper.GetInt(row["CreateUserId"]);
          FlowUserId = ConvertHelper.GetInt(row["FlowUserId"]);
          FlowLastDate = ConvertHelper.GetDateTime(row["FlowLastDate"]);

        }

       [Column(IsPrimaryKey = true, IsAutoNumber = true)]
       public int Id { get; set; }
       public string Gid { get; set; }
       public string PageName { get; set; }
       public int AdPageId { get; set; }
       public int AdUserId { get; set; }
       public int IsState { get; set; }
       public DateTime CreateDate { get; set; }
       public int CreateUserId { get; set; }
       public int FlowUserId { get; set; }
       public DateTime FlowLastDate { get; set; }


        public object Clone()
        {
            AdUserPageVO obj = new AdUserPageVO();
            
			            obj.Id = this.Id;

            obj.Gid = this.Gid;

            obj.PageName = this.PageName;

            obj.AdPageId = this.AdPageId;

            obj.AdUserId = this.AdUserId;

            obj.IsState = this.IsState;

            obj.CreateDate = this.CreateDate;

            obj.CreateUserId = this.CreateUserId;

            obj.FlowUserId = this.FlowUserId;

            obj.FlowLastDate = this.FlowLastDate;



            return obj;
        }
    }
}
