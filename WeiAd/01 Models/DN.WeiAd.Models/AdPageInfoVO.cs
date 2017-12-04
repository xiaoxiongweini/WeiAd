
/*

skey edit by 2017/5/17 7:00:19

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
    public partial class AdPageInfoVO: IModel
    {
        public AdPageInfoVO() { }

        public AdPageInfoVO(IDataReader row)
        {
          Id = ConvertHelper.GetInt(row["Id"]);
          WeiXinUrl = ConvertHelper.GetString(row["WeiXinUrl"]);
          Title = ConvertHelper.GetString(row["Title"]);
          TitleImg = ConvertHelper.GetString(row["TitleImg"]);
          QcodeImg = ConvertHelper.GetString(row["QcodeImg"]);
          Content = ConvertHelper.GetString(row["Content"]);
          AdType = ConvertHelper.GetInt(row["AdType"]);
          CreateDate = ConvertHelper.GetDateTime(row["CreateDate"]);
          LastDate = ConvertHelper.GetDateTime(row["LastDate"]);
          UserId = ConvertHelper.GetInt(row["UserId"]);
          ViewPage = ConvertHelper.GetString(row["ViewPage"]);
          UserCodeId = ConvertHelper.GetInt(row["UserCodeId"]);
          UserCodeIds = ConvertHelper.GetString(row["UserCodeIds"]);
          IsState = ConvertHelper.GetInt(row["IsState"]);
          Money = ConvertHelper.GetDecimal(row["Money"]);
          SaleType = ConvertHelper.GetInt(row["SaleType"]);
          PlanIp = ConvertHelper.GetInt(row["PlanIp"]);
          StartTime = ConvertHelper.GetDateTime(row["StartTime"]);
          PlanTerminal = ConvertHelper.GetInt(row["PlanTerminal"]);
          MoneyCount = ConvertHelper.GetDecimal(row["MoneyCount"]);
          BuyMoney = ConvertHelper.GetDecimal(row["BuyMoney"]);
          OrderIndex = ConvertHelper.GetInt(row["OrderIndex"]);
          UserCode = ConvertHelper.GetString(row["UserCode"]);
          TitleShort = ConvertHelper.GetString(row["TitleShort"]);
          BuyIp = ConvertHelper.GetInt(row["BuyIp"]);
          TemplateName = ConvertHelper.GetString(row["TemplateName"]);
          IsDel = ConvertHelper.GetInt(row["IsDel"]);
          IsAuth = ConvertHelper.GetInt(row["IsAuth"]);
          StaticContent = ConvertHelper.GetString(row["StaticContent"]);
          CreateUserId = ConvertHelper.GetInt(row["CreateUserId"]);
          MiddlePage = ConvertHelper.GetString(row["MiddlePage"]);
          AdTimeStart = ConvertHelper.GetString(row["AdTimeStart"]);
          AdTimeEnd = ConvertHelper.GetString(row["AdTimeEnd"]);
          UserAdTypeId = ConvertHelper.GetInt(row["UserAdTypeId"]);
          Desc = ConvertHelper.GetString(row["Desc"]);
          SiteTypeId = ConvertHelper.GetInt(row["SiteTypeId"]);
          PlatformType = ConvertHelper.GetString(row["PlatformType"]);
          DeleteDate = ConvertHelper.GetDateTime(row["DeleteDate"]);
          DefaultQcode = ConvertHelper.GetString(row["DefaultQcode"]);
          QcodeCount = ConvertHelper.GetInt(row["QcodeCount"]);
          PageCount = ConvertHelper.GetInt(row["PageCount"]);
          QcodeImg2 = ConvertHelper.GetString(row["QcodeImg2"]);
          DefaultQcode2 = ConvertHelper.GetString(row["DefaultQcode2"]);
          DomainList = ConvertHelper.GetString(row["DomainList"]);

        }

        public AdPageInfoVO(DataRow row)
        {
          Id = ConvertHelper.GetInt(row["Id"]);
          WeiXinUrl = ConvertHelper.GetString(row["WeiXinUrl"]);
          Title = ConvertHelper.GetString(row["Title"]);
          TitleImg = ConvertHelper.GetString(row["TitleImg"]);
          QcodeImg = ConvertHelper.GetString(row["QcodeImg"]);
          Content = ConvertHelper.GetString(row["Content"]);
          AdType = ConvertHelper.GetInt(row["AdType"]);
          CreateDate = ConvertHelper.GetDateTime(row["CreateDate"]);
          LastDate = ConvertHelper.GetDateTime(row["LastDate"]);
          UserId = ConvertHelper.GetInt(row["UserId"]);
          ViewPage = ConvertHelper.GetString(row["ViewPage"]);
          UserCodeId = ConvertHelper.GetInt(row["UserCodeId"]);
          UserCodeIds = ConvertHelper.GetString(row["UserCodeIds"]);
          IsState = ConvertHelper.GetInt(row["IsState"]);
          Money = ConvertHelper.GetDecimal(row["Money"]);
          SaleType = ConvertHelper.GetInt(row["SaleType"]);
          PlanIp = ConvertHelper.GetInt(row["PlanIp"]);
          StartTime = ConvertHelper.GetDateTime(row["StartTime"]);
          PlanTerminal = ConvertHelper.GetInt(row["PlanTerminal"]);
          MoneyCount = ConvertHelper.GetDecimal(row["MoneyCount"]);
          BuyMoney = ConvertHelper.GetDecimal(row["BuyMoney"]);
          OrderIndex = ConvertHelper.GetInt(row["OrderIndex"]);
          UserCode = ConvertHelper.GetString(row["UserCode"]);
          TitleShort = ConvertHelper.GetString(row["TitleShort"]);
          BuyIp = ConvertHelper.GetInt(row["BuyIp"]);
          TemplateName = ConvertHelper.GetString(row["TemplateName"]);
          IsDel = ConvertHelper.GetInt(row["IsDel"]);
          IsAuth = ConvertHelper.GetInt(row["IsAuth"]);
          StaticContent = ConvertHelper.GetString(row["StaticContent"]);
          CreateUserId = ConvertHelper.GetInt(row["CreateUserId"]);
          MiddlePage = ConvertHelper.GetString(row["MiddlePage"]);
          AdTimeStart = ConvertHelper.GetString(row["AdTimeStart"]);
          AdTimeEnd = ConvertHelper.GetString(row["AdTimeEnd"]);
          UserAdTypeId = ConvertHelper.GetInt(row["UserAdTypeId"]);
          Desc = ConvertHelper.GetString(row["Desc"]);
          SiteTypeId = ConvertHelper.GetInt(row["SiteTypeId"]);
          PlatformType = ConvertHelper.GetString(row["PlatformType"]);
          DeleteDate = ConvertHelper.GetDateTime(row["DeleteDate"]);
          DefaultQcode = ConvertHelper.GetString(row["DefaultQcode"]);
          QcodeCount = ConvertHelper.GetInt(row["QcodeCount"]);
          PageCount = ConvertHelper.GetInt(row["PageCount"]);
          QcodeImg2 = ConvertHelper.GetString(row["QcodeImg2"]);
          DefaultQcode2 = ConvertHelper.GetString(row["DefaultQcode2"]);
          DomainList = ConvertHelper.GetString(row["DomainList"]);

        }

       [Column(IsPrimaryKey = true, IsAutoNumber = true)]
       public int Id { get; set; }
       public string WeiXinUrl { get; set; }
       public string Title { get; set; }
       public string TitleImg { get; set; }
       public string QcodeImg { get; set; }
       public string Content { get; set; }
       public int AdType { get; set; }
       public DateTime CreateDate { get; set; }
       public DateTime LastDate { get; set; }
       public int UserId { get; set; }
       public string ViewPage { get; set; }
       public int UserCodeId { get; set; }
       public string UserCodeIds { get; set; }
       public int IsState { get; set; }
       public decimal Money { get; set; }
       public int SaleType { get; set; }
       public int PlanIp { get; set; }
       public DateTime StartTime { get; set; }
       public int PlanTerminal { get; set; }
       public decimal MoneyCount { get; set; }
       public decimal BuyMoney { get; set; }
       public int OrderIndex { get; set; }
       public string UserCode { get; set; }
       public string TitleShort { get; set; }
       public int BuyIp { get; set; }
       public string TemplateName { get; set; }
       public int IsDel { get; set; }
       public int IsAuth { get; set; }
       public string StaticContent { get; set; }
       public int CreateUserId { get; set; }
       public string MiddlePage { get; set; }
       public string AdTimeStart { get; set; }
       public string AdTimeEnd { get; set; }
       public int UserAdTypeId { get; set; }
       public string Desc { get; set; }
       public int SiteTypeId { get; set; }
       public string PlatformType { get; set; }
       public DateTime DeleteDate { get; set; }
       public string DefaultQcode { get; set; }
       public int QcodeCount { get; set; }
       public int PageCount { get; set; }
       public string QcodeImg2 { get; set; }
       public string DefaultQcode2 { get; set; }
       public string DomainList { get; set; }


        public object Clone()
        {
            AdPageInfoVO obj = new AdPageInfoVO();
            
			            obj.Id = this.Id;

            obj.WeiXinUrl = this.WeiXinUrl;

            obj.Title = this.Title;

            obj.TitleImg = this.TitleImg;

            obj.QcodeImg = this.QcodeImg;

            obj.Content = this.Content;

            obj.AdType = this.AdType;

            obj.CreateDate = this.CreateDate;

            obj.LastDate = this.LastDate;

            obj.UserId = this.UserId;

            obj.ViewPage = this.ViewPage;

            obj.UserCodeId = this.UserCodeId;

            obj.UserCodeIds = this.UserCodeIds;

            obj.IsState = this.IsState;

            obj.Money = this.Money;

            obj.SaleType = this.SaleType;

            obj.PlanIp = this.PlanIp;

            obj.StartTime = this.StartTime;

            obj.PlanTerminal = this.PlanTerminal;

            obj.MoneyCount = this.MoneyCount;

            obj.BuyMoney = this.BuyMoney;

            obj.OrderIndex = this.OrderIndex;

            obj.UserCode = this.UserCode;

            obj.TitleShort = this.TitleShort;

            obj.BuyIp = this.BuyIp;

            obj.TemplateName = this.TemplateName;

            obj.IsDel = this.IsDel;

            obj.IsAuth = this.IsAuth;

            obj.StaticContent = this.StaticContent;

            obj.CreateUserId = this.CreateUserId;

            obj.MiddlePage = this.MiddlePage;

            obj.AdTimeStart = this.AdTimeStart;

            obj.AdTimeEnd = this.AdTimeEnd;

            obj.UserAdTypeId = this.UserAdTypeId;

            obj.Desc = this.Desc;

            obj.SiteTypeId = this.SiteTypeId;

            obj.PlatformType = this.PlatformType;

            obj.DeleteDate = this.DeleteDate;

            obj.DefaultQcode = this.DefaultQcode;

            obj.QcodeCount = this.QcodeCount;

            obj.PageCount = this.PageCount;

            obj.QcodeImg2 = this.QcodeImg2;

            obj.DefaultQcode2 = this.DefaultQcode2;

            obj.DomainList = this.DomainList;



            return obj;
        }
    }
}
