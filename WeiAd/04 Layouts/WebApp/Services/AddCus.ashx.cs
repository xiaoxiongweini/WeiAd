using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DN.WeiAd.Models;
using DN.WeiAd.Business;
using DN.WeiAd.Business.Entity;

namespace WebApp.Services
{
    /// <summary>
    /// AddCus 的摘要说明
    /// </summary>
    public class AddCus : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";
            
            string realname = context.Request.Params["rname"] ?? "";
            string phone = context.Request.Params["phone"] ?? "";
            string wxname = context.Request.Params["wxname"] ?? "";
            string address = context.Request.Params["address"] ?? "";
            string url = context.Request.Params["__url"] ?? "";
            string remark = context.Request.Params["remark"] ?? "";
            string province = context.Request.Params["province"] ?? "";
            string city = context.Request.Params["city"] ?? "";
            string area = context.Request.Params["area"] ?? "";
            string size = context.Request.Params["size"] ?? "";
            string color = context.Request.Params["color"] ?? "";
            string productname = context.Request.Params["productname"] ?? "";
            string num = context.Request.Params["num"] ?? "";
            string price = context.Request.Params["price"] ?? "";
            int adid = int.Parse(context.Request.Params["adid"] ?? "0");
            int aduserid = int.Parse(context.Request.Params["aduserid"] ?? "0");
            ApiResult result = new ApiResult();
            CustomerInfoVO info = new CustomerInfoVO();

            try
            {
                info.Size = size;
                info.Color = color;
                info.ProducteName = productname;
                info.Num = int.Parse(num);
                info.Price = decimal.Parse(price);

                info.Address = address;
                info.AdId = adid;
                info.AdUserId = aduserid;
                info.AdUrl = url;
                info.BrowseName = DN.Framework.Utility.ClientHelper.GetBrowseName();
                info.BrowseVersion = DN.Framework.Utility.ClientHelper.GetBrowseVersion();
                info.ClientId = GetClentId(context.Request, context.Response);
                info.ClientIp = DN.Framework.Utility.ClientHelper.ClientIP();
                info.ExportDate = DateTime.Now;

                //IP相关信息
                info.Country = "";
                info.County = "";
                info.IpSource = "";
                info.Isp = "";
                info.Region = "";
                info.Area = "";

                info.CreateDate = DateTime.Now;
                info.IsMobile = DN.Framework.Utility.ClientHelper.GetIsMobileDevice() ? 1 : 0;             
                info.OsName = DN.Framework.Utility.ClientHelper.GetOsName();
                info.Phone = phone;
                info.RealName = realname;
                info.ReferrerUrl = DN.Framework.Utility.ClientHelper.GetReferer();
                info.Remark = remark;
                info.UserCity = city;
                info.UserCountry = area;
                info.UserRegion = province;
                info.WeiXinNum = wxname;

                CustomerInfoPara cip = new CustomerInfoPara();
                cip.RealName = info.RealName;
                cip.Phone = info.Phone;
                cip.AdUrl = info.AdUrl;
                cip.Address = info.Address;

                var count = CustomerInfoBLL.Instance.GetRecords(cip);

                if (count == 0)
                {
                    CustomerInfoBLL.Instance.Add(info);
                    result.code = 1;
                    result.msg = "您的信息己提交成功，稍后销售客服马上联系您。";
                }
                else
                {
                    result.code = 0;
                    result.msg = "您的信息己提交成功，销售顾问将会与您联系。";
                }
            }
            catch (Exception ex)
            {
                result.msg = "客户提交异常。管理员正在处理中。";
                result.code = 0;
                DN.Framework.Utility.LogHelper.Write(ex.Message, "addcus");
            }

            string json = DN.Framework.Utility.Serializer.SerializeObject(result);
            context.Response.ClearContent();
            context.Response.Write(json);
            context.Response.End();
        }

        private string GetClentId(HttpRequest Request, HttpResponse Response)
        {
            string client = string.Empty;
            HttpCookie cookie = Request.Cookies.Get("_adclientid");
            if (cookie == null)
            {
                client = Guid.NewGuid().ToString();
                cookie = new HttpCookie("_adclientid");
                cookie.Value = Guid.NewGuid().ToString();
                cookie.Expires = DateTime.MaxValue;
                Response.Cookies.Add(cookie);
            }
            else
            {
                client = cookie.Value;
            }

            return client;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}