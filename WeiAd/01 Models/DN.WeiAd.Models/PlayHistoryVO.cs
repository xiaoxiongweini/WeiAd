
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
    public partial class PlayHistoryVO: IModel
    {
        public PlayHistoryVO() { }

        public PlayHistoryVO(IDataReader row)
        {
          Id = ConvertHelper.GetInt(row["Id"]);
          AdUserId = ConvertHelper.GetInt(row["AdUserId"]);
          FlowUserId = ConvertHelper.GetInt(row["FlowUserId"]);
          AdId = ConvertHelper.GetInt(row["AdId"]);
          AdUrl = ConvertHelper.GetString(row["AdUrl"]);
          Time = ConvertHelper.GetInt(row["Time"]);
          Money = ConvertHelper.GetDecimal(row["Money"]);
          CreateDate = ConvertHelper.GetDateTime(row["CreateDate"]);
          CreateUserId = ConvertHelper.GetInt(row["CreateUserId"]);
          ClientIp = ConvertHelper.GetInt(row["ClientIp"]);
          ClientUv = ConvertHelper.GetInt(row["ClientUv"]);
          ClientPv = ConvertHelper.GetInt(row["ClientPv"]);
          Price = ConvertHelper.GetDecimal(row["Price"]);

        }

        public PlayHistoryVO(DataRow row)
        {
          Id = ConvertHelper.GetInt(row["Id"]);
          AdUserId = ConvertHelper.GetInt(row["AdUserId"]);
          FlowUserId = ConvertHelper.GetInt(row["FlowUserId"]);
          AdId = ConvertHelper.GetInt(row["AdId"]);
          AdUrl = ConvertHelper.GetString(row["AdUrl"]);
          Time = ConvertHelper.GetInt(row["Time"]);
          Money = ConvertHelper.GetDecimal(row["Money"]);
          CreateDate = ConvertHelper.GetDateTime(row["CreateDate"]);
          CreateUserId = ConvertHelper.GetInt(row["CreateUserId"]);
          ClientIp = ConvertHelper.GetInt(row["ClientIp"]);
          ClientUv = ConvertHelper.GetInt(row["ClientUv"]);
          ClientPv = ConvertHelper.GetInt(row["ClientPv"]);
          Price = ConvertHelper.GetDecimal(row["Price"]);

        }

       [Column(IsPrimaryKey = true, IsAutoNumber = true)]
       public int Id { get; set; }
       public int AdUserId { get; set; }
       public int FlowUserId { get; set; }
       public int AdId { get; set; }
       public string AdUrl { get; set; }
       public int Time { get; set; }
       public decimal Money { get; set; }
       public DateTime CreateDate { get; set; }
       public int CreateUserId { get; set; }
       public int ClientIp { get; set; }
       public int ClientUv { get; set; }
       public int ClientPv { get; set; }
       public decimal Price { get; set; }


        public object Clone()
        {
            PlayHistoryVO obj = new PlayHistoryVO();
            
			            obj.Id = this.Id;

            obj.AdUserId = this.AdUserId;

            obj.FlowUserId = this.FlowUserId;

            obj.AdId = this.AdId;

            obj.AdUrl = this.AdUrl;

            obj.Time = this.Time;

            obj.Money = this.Money;

            obj.CreateDate = this.CreateDate;

            obj.CreateUserId = this.CreateUserId;

            obj.ClientIp = this.ClientIp;

            obj.ClientUv = this.ClientUv;

            obj.ClientPv = this.ClientPv;

            obj.Price = this.Price;



            return obj;
        }
    }
}
