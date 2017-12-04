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
    /// 获取省份信息
    /// </summary>
    public class GetAreaRegion : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";

            List<SysAreaProvincesVO> list = new List<SysAreaProvincesVO>();

            try
            {
                list = SysAreaProvincesBLL.Instance.GetRegions();
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