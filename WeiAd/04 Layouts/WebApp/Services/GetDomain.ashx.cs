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
    /// GetDomain 的摘要说明
    /// </summary>
    public class GetDomain : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";

            string sname = context.Request.Params["sname"] ?? "";
            ApiResult result = new ApiResult();

            try
            {
                DomainInfoPara dip = new DomainInfoPara();
                dip.SerName = sname;

                var list = DomainInfoBLL.Instance.GetModels(dip);
                result.datajson = DN.Framework.Utility.Serializer.SerializeObject(list);
                result.code = 1;
                result.msg = "获取成功。";
            }
            catch (Exception ex)
            {
                result.msg = ex.Message;
                result.code = 2;
            }

            string json = DN.Framework.Utility.Serializer.SerializeObject(result);
            context.Response.ClearContent();
            context.Response.Write(json);
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