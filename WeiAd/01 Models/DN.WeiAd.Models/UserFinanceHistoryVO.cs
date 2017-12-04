
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
    public partial class UserFinanceHistoryVO: IModel
    {
        public UserFinanceHistoryVO() { }

        public UserFinanceHistoryVO(IDataReader row)
        {
          Id = ConvertHelper.GetInt(row["Id"]);
          UserId = ConvertHelper.GetInt(row["UserId"]);
          RechargeType = ConvertHelper.GetInt(row["RechargeType"]);
          Money = ConvertHelper.GetDecimal(row["Money"]);
          MoneyType = ConvertHelper.GetInt(row["MoneyType"]);
          CreateDate = ConvertHelper.GetDateTime(row["CreateDate"]);
          CreateUserId = ConvertHelper.GetInt(row["CreateUserId"]);

        }

        public UserFinanceHistoryVO(DataRow row)
        {
          Id = ConvertHelper.GetInt(row["Id"]);
          UserId = ConvertHelper.GetInt(row["UserId"]);
          RechargeType = ConvertHelper.GetInt(row["RechargeType"]);
          Money = ConvertHelper.GetDecimal(row["Money"]);
          MoneyType = ConvertHelper.GetInt(row["MoneyType"]);
          CreateDate = ConvertHelper.GetDateTime(row["CreateDate"]);
          CreateUserId = ConvertHelper.GetInt(row["CreateUserId"]);

        }

       [Column(IsPrimaryKey = true, IsAutoNumber = true)]
       public int Id { get; set; }
       public int UserId { get; set; }
       public int RechargeType { get; set; }
       public decimal Money { get; set; }
       public int MoneyType { get; set; }
       public DateTime CreateDate { get; set; }
       public int CreateUserId { get; set; }


        public object Clone()
        {
            UserFinanceHistoryVO obj = new UserFinanceHistoryVO();
            
			            obj.Id = this.Id;

            obj.UserId = this.UserId;

            obj.RechargeType = this.RechargeType;

            obj.Money = this.Money;

            obj.MoneyType = this.MoneyType;

            obj.CreateDate = this.CreateDate;

            obj.CreateUserId = this.CreateUserId;



            return obj;
        }
    }
}
