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
    /// SerAdd 的摘要说明，服务器上报数据
    /// </summary>
    public class SerAdd : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";

            string sname = context.Request.Params["sname"] ?? "";
            
            ApiResult result = new ApiResult();

            try
            {
                if (!string.IsNullOrEmpty(sname))
                {

                    ServerInfoPara sip = new ServerInfoPara();
                    sip.Name = sname;

                    var list = ServerInfoBLL.Instance.GetModels(sip);
                    if (list.Count == 0)
                    {
                        ServerInfoVO info = new ServerInfoVO();

                        info.CreateDate = DateTime.Now;
                        info.Desc = "";
                        info.Ip = DN.Framework.Utility.ClientHelper.ClientIP();
                        info.IsState = 0;
                        info.Name = sname;
                        info.ServerId = Guid.NewGuid().ToString();
                        info.UpdateDate = DateTime.Now;                        
                        ServerInfoBLL.Instance.Add(info);

                        result.code = 1;
                        result.msg = "服务器信息上报成功。";
                    }
                    else
                    {
                        result.code = 0;
                        result.msg = "己存在相同服务器信息。";
                    }
                }
            }
            catch (Exception ex)
            {
                result.code = 2;
                result.msg = ex.Message; 
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