using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdApp.Services
{
    /// <summary>
    /// GetDetail 的摘要说明
    /// </summary>
    public class GetDetail : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string id = context.Request.Params["id"] ?? "5";
            string html = "";

            try
            {
                int aid = int.Parse(id);
                var info = DN.WeiAd.Business.AdPageInfoBLL.Instance.GetSingle(new DN.WeiAd.Models.AdPageInfoPara() { Id = aid });

                if (info != null)
                {
                    html = DN.Framework.Utility.HtmlHelper.DecodeHtml(info.Content);
                }
            }
            catch (Exception ex)
            {

            }

            context.Response.ClearContent();
            context.Response.Write(html);
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