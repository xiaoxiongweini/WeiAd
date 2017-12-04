
/*

skey edit by 2017/9/21 10:02:13

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
    public partial class SummaryAdDayHistoryVO: IModel
    {
        public SummaryAdDayHistoryVO() { }

        public SummaryAdDayHistoryVO(IDataReader row)
        {
          Id = ConvertHelper.GetInt(row["Id"]);
          AdId = ConvertHelper.GetInt(row["AdId"]);
          UserId = ConvertHelper.GetInt(row["UserId"]);
          TimeId = ConvertHelper.GetInt(row["TimeId"]);
          PvCount = ConvertHelper.GetInt(row["PvCount"]);
          UvCount = ConvertHelper.GetInt(row["UvCount"]);
          IpCount = ConvertHelper.GetInt(row["IpCount"]);
          CreateDate = ConvertHelper.GetDateTime(row["CreateDate"]);
          CreateUserId = ConvertHelper.GetInt(row["CreateUserId"]);
          IsDelete = ConvertHelper.GetInt(row["IsDelete"]);

        }

        public SummaryAdDayHistoryVO(DataRow row)
        {
          Id = ConvertHelper.GetInt(row["Id"]);
          AdId = ConvertHelper.GetInt(row["AdId"]);
          UserId = ConvertHelper.GetInt(row["UserId"]);
          TimeId = ConvertHelper.GetInt(row["TimeId"]);
          PvCount = ConvertHelper.GetInt(row["PvCount"]);
          UvCount = ConvertHelper.GetInt(row["UvCount"]);
          IpCount = ConvertHelper.GetInt(row["IpCount"]);
          CreateDate = ConvertHelper.GetDateTime(row["CreateDate"]);
          CreateUserId = ConvertHelper.GetInt(row["CreateUserId"]);
          IsDelete = ConvertHelper.GetInt(row["IsDelete"]);

        }

       [Column(IsPrimaryKey = true, IsAutoNumber = true)]
       public int Id { get; set; }
       public int AdId { get; set; }
       public int UserId { get; set; }
       public int TimeId { get; set; }
       public int PvCount { get; set; }
       public int UvCount { get; set; }
       public int IpCount { get; set; }
       public DateTime CreateDate { get; set; }
       public int CreateUserId { get; set; }
       public int IsDelete { get; set; }


        public object Clone()
        {
            SummaryAdDayHistoryVO obj = new SummaryAdDayHistoryVO();
            
			            obj.Id = this.Id;

            obj.AdId = this.AdId;

            obj.UserId = this.UserId;

            obj.TimeId = this.TimeId;

            obj.PvCount = this.PvCount;

            obj.UvCount = this.UvCount;

            obj.IpCount = this.IpCount;

            obj.CreateDate = this.CreateDate;

            obj.CreateUserId = this.CreateUserId;

            obj.IsDelete = this.IsDelete;



            return obj;
        }
    }
}
