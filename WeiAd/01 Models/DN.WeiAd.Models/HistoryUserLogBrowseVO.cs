
/*

skey edit by 2017/7/4 16:41:46

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
    public partial class HistoryUserLogBrowseVO: IModel
    {
        public HistoryUserLogBrowseVO() { }

        public HistoryUserLogBrowseVO(IDataReader row)
        {
          Id = ConvertHelper.GetInt(row["Id"]);
          Time = ConvertHelper.GetInt(row["Time"]);
          AdId = ConvertHelper.GetInt(row["AdId"]);
          UserId = ConvertHelper.GetInt(row["UserId"]);
          PvCount = ConvertHelper.GetInt(row["PvCount"]);
          UvCount = ConvertHelper.GetInt(row["UvCount"]);
          IpCount = ConvertHelper.GetInt(row["IpCount"]);
          Price = ConvertHelper.GetDecimal(row["Price"]);
          Money = ConvertHelper.GetDecimal(row["Money"]);
          CreateDate = ConvertHelper.GetDateTime(row["CreateDate"]);
          CreateUserId = ConvertHelper.GetInt(row["CreateUserId"]);

        }

        public HistoryUserLogBrowseVO(DataRow row)
        {
          Id = ConvertHelper.GetInt(row["Id"]);
          Time = ConvertHelper.GetInt(row["Time"]);
          AdId = ConvertHelper.GetInt(row["AdId"]);
          UserId = ConvertHelper.GetInt(row["UserId"]);
          PvCount = ConvertHelper.GetInt(row["PvCount"]);
          UvCount = ConvertHelper.GetInt(row["UvCount"]);
          IpCount = ConvertHelper.GetInt(row["IpCount"]);
          Price = ConvertHelper.GetDecimal(row["Price"]);
          Money = ConvertHelper.GetDecimal(row["Money"]);
          CreateDate = ConvertHelper.GetDateTime(row["CreateDate"]);
          CreateUserId = ConvertHelper.GetInt(row["CreateUserId"]);

        }

       [Column(IsPrimaryKey = true, IsAutoNumber = true)]
       public int Id { get; set; }
       public int Time { get; set; }
       public int AdId { get; set; }
       public int UserId { get; set; }
       public int PvCount { get; set; }
       public int UvCount { get; set; }
       public int IpCount { get; set; }
       public decimal Price { get; set; }
       public decimal Money { get; set; }
       public DateTime CreateDate { get; set; }
       public int CreateUserId { get; set; }


        public object Clone()
        {
            HistoryUserLogBrowseVO obj = new HistoryUserLogBrowseVO();
            
			            obj.Id = this.Id;

            obj.Time = this.Time;

            obj.AdId = this.AdId;

            obj.UserId = this.UserId;

            obj.PvCount = this.PvCount;

            obj.UvCount = this.UvCount;

            obj.IpCount = this.IpCount;

            obj.Price = this.Price;

            obj.Money = this.Money;

            obj.CreateDate = this.CreateDate;

            obj.CreateUserId = this.CreateUserId;



            return obj;
        }
    }
}
