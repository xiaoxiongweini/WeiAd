using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DN.WeiAd.Models;
using DN.WeiAd.Business;

namespace WebApp.Services
{
    /// <summary>
    /// 获取区县数据
    /// </summary>
    public class GetAreaCounty : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";

            int pid = int.Parse(context.Request.Params["pid"] ?? "1");

            List<SysAreaDistrictsVO> list = new List<SysAreaDistrictsVO>();
            try
            {
                list = SysAreaDistrictsBLL.Instance.GetCountyByCityId(pid);
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