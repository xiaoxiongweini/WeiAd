
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
    public partial class AccountInfoVO: IModel
    {
        public AccountInfoVO() { }

        public AccountInfoVO(IDataReader row)
        {
          Id = ConvertHelper.GetInt(row["Id"]);
          UserName = ConvertHelper.GetString(row["UserName"]);
          NickName = ConvertHelper.GetString(row["NickName"]);
          Email = ConvertHelper.GetString(row["Email"]);
          Phone = ConvertHelper.GetString(row["Phone"]);
          UserType = ConvertHelper.GetInt(row["UserType"]);
          UserPwd = ConvertHelper.GetString(row["UserPwd"]);
          UserImg = ConvertHelper.GetString(row["UserImg"]);
          RegDate = ConvertHelper.GetDateTime(row["RegDate"]);
          RegIp = ConvertHelper.GetString(row["RegIp"]);
          IsLock = ConvertHelper.GetInt(row["IsLock"]);
          LastLoginDate = ConvertHelper.GetDateTime(row["LastLoginDate"]);
          AccountType = ConvertHelper.GetInt(row["AccountType"]);
          OpenId = ConvertHelper.GetString(row["OpenId"]);
          ConsumptionMoney = ConvertHelper.GetFloat(row["ConsumptionMoney"]);
          Money = ConvertHelper.GetFloat(row["Money"]);
          MoneyFree = ConvertHelper.GetFloat(row["MoneyFree"]);
          MoneyCount = ConvertHelper.GetFloat(row["MoneyCount"]);
          LastMoneyDate = ConvertHelper.GetDateTime(row["LastMoneyDate"]);

        }

        public AccountInfoVO(DataRow row)
        {
          Id = ConvertHelper.GetInt(row["Id"]);
          UserName = ConvertHelper.GetString(row["UserName"]);
          NickName = ConvertHelper.GetString(row["NickName"]);
          Email = ConvertHelper.GetString(row["Email"]);
          Phone = ConvertHelper.GetString(row["Phone"]);
          UserType = ConvertHelper.GetInt(row["UserType"]);
          UserPwd = ConvertHelper.GetString(row["UserPwd"]);
          UserImg = ConvertHelper.GetString(row["UserImg"]);
          RegDate = ConvertHelper.GetDateTime(row["RegDate"]);
          RegIp = ConvertHelper.GetString(row["RegIp"]);
          IsLock = ConvertHelper.GetInt(row["IsLock"]);
          LastLoginDate = ConvertHelper.GetDateTime(row["LastLoginDate"]);
          AccountType = ConvertHelper.GetInt(row["AccountType"]);
          OpenId = ConvertHelper.GetString(row["OpenId"]);
          ConsumptionMoney = ConvertHelper.GetFloat(row["ConsumptionMoney"]);
          Money = ConvertHelper.GetFloat(row["Money"]);
          MoneyFree = ConvertHelper.GetFloat(row["MoneyFree"]);
          MoneyCount = ConvertHelper.GetFloat(row["MoneyCount"]);
          LastMoneyDate = ConvertHelper.GetDateTime(row["LastMoneyDate"]);

        }

       [Column(IsPrimaryKey = true, IsAutoNumber = true)]
       public int Id { get; set; }
       public string UserName { get; set; }
       public string NickName { get; set; }
       public string Email { get; set; }
       public string Phone { get; set; }
       public int UserType { get; set; }
       public string UserPwd { get; set; }
       public string UserImg { get; set; }
       public DateTime RegDate { get; set; }
       public string RegIp { get; set; }
       public int IsLock { get; set; }
       public DateTime LastLoginDate { get; set; }
       public int AccountType { get; set; }
       public string OpenId { get; set; }
       public float ConsumptionMoney { get; set; }
       public float Money { get; set; }
       public float MoneyFree { get; set; }
       public float MoneyCount { get; set; }
       public DateTime LastMoneyDate { get; set; }


        public object Clone()
        {
            AccountInfoVO obj = new AccountInfoVO();
            
			            obj.Id = this.Id;

            obj.UserName = this.UserName;

            obj.NickName = this.NickName;

            obj.Email = this.Email;

            obj.Phone = this.Phone;

            obj.UserType = this.UserType;

            obj.UserPwd = this.UserPwd;

            obj.UserImg = this.UserImg;

            obj.RegDate = this.RegDate;

            obj.RegIp = this.RegIp;

            obj.IsLock = this.IsLock;

            obj.LastLoginDate = this.LastLoginDate;

            obj.AccountType = this.AccountType;

            obj.OpenId = this.OpenId;

            obj.ConsumptionMoney = this.ConsumptionMoney;

            obj.Money = this.Money;

            obj.MoneyFree = this.MoneyFree;

            obj.MoneyCount = this.MoneyCount;

            obj.LastMoneyDate = this.LastMoneyDate;



            return obj;
        }
    }
}
