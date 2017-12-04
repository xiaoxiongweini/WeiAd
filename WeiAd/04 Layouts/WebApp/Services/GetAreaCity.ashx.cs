using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DN.WeiAd.Models;
using DN.WeiAd.Business;

namespace WebApp.Services
{
    /// <summary>
    /// 获取城市信息
    /// </summary>
    public class GetAreaCity : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";

            int pid = int.Parse(context.Request.Params["pid"] ?? "1");

            List<SysAreaCityVO> list = new List<SysAreaCityVO>();
            try
            {
                list = SysAreaCityBLL.Instance.GetCitysById(pid);
            }
            catch (Exception ex)
            {
                DN.Framework.Utility.LogHelper.Write(ex.Message, "addcus");
            }

            string json = DN.Framework.Utility.Serializer.SerializeObject(list);
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