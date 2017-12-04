using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DN.WeiAd.Models;
using DN.WeiAd.Business;

namespace WebApp
{
    /// <summary>
    /// GetDomain 的摘要说明
    /// </summary>
    public class GetDomain : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {   
            context.Response.ContentType = "text/plain";

            string adid = context.Request.Params["newid"] ?? "0";
            string dlist = "";
            var info = AdPageInfoBLL.Instance.GetModelById(int.Parse(adid));
            if(info== null)
            {
                info = AdPageInfoBLL.Instance.GetSingle(new AdPageInfoPara() { Id = int.Parse(adid) });
                dlist = info.DomainList;
            }
            else
            {
                dlist = info.DomainList;
            }
            
            context.Response.ClearContent();
            context.Response.Write(dlist);
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