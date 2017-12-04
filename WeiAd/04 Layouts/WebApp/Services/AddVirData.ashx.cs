using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DN.WeiAd.Models;
using DN.WeiAd.Business;

namespace WebApp.Services
{
    /// <summary>
    /// AddVirData 的摘要说明
    /// </summary>
    public class AddVirData : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string html = "";
            string ads = context.Request.Params["adids"] ?? "";

            try
            {
                Random rd = new Random();

                if(!string.IsNullOrEmpty(ads))
                {
                    var list = ads.Split(',');
                    for (int i = 0; i < list.Length; i++)
                    {
                        if(!string.IsNullOrEmpty(list[i]))
                        {
                            VirAdBrowseVO info = new VirAdBrowseVO();

                            info.AdId = int.Parse(list[i]);
                            info.CreateDate = DateTime.Now;
                            info.CreateUserId = 0;
                            info.IpCount = rd.Next(1, 5);
                            info.PvCount = rd.Next(1, 10);
                            info.TimeId = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
                            info.UvCount = rd.Next(1, 10);

                            VirAdBrowseBLL.Instance.Add(info);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }

            context.Response.Clear();
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