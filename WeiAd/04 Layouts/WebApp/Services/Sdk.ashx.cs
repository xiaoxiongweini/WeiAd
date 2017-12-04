using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DN.WeiAd.Business.Sdk;

namespace WebApp.Services
{
    /// <summary>
    /// Sdk 的摘要说明
    /// </summary>
    public class Sdk : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";
            ApiResult result = new ApiResult();

            try
            {

            }
            catch (Exception ex)
            {

            }

            context.Response.ClearContent();
            context.Response.Write(DN.Framework.Utility.Serializer.SerializeObject(result));
            context.Response.End();
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