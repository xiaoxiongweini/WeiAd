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
    /// SerGetDomain 的摘要说明，获取相关配置
    /// </summary>
    public class SerGetDomain : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";

            string sname = context.Request.Params["sname"];

            //获取当前IP
            string clientIp = DN.Framework.Utility.ClientHelper.ClientIP();

            ApiResult result = new ApiResult();

            try
            {
                //检查IP是否认证的IP
                ServerInfoPara sip = new ServerInfoPara();
                var serv = ServerInfoBLL.Instance.GetSingle(new ServerInfoPara() { Name = sname });
                if (serv == null || serv.IsState == 0)
                {
                    result.code = 0;
                    result.msg = "您的服务器没有经过认证，请联系管理员处理。";
                }
                else
                {
                    DomainSynchroHistoryPara dsp = new DomainSynchroHistoryPara();
                    dsp.Name = sname;
                    dsp.IsSynchro = 0;

                    var list = DomainSynchroHistoryBLL.Instance.GetModels(dsp);
                    if(list.Count ==0)
                    {
                        result.code = 0;
                        result.msg = "当前无同步数据。";
                    }
                    else
                    {
                        result.code = 1;
                        result.datajson = DN.Framework.Utility.Serializer.SerializeObject(list);

                        var domains = DomainInfoBLL.Instance.GetModels(new DomainInfoPara());
                        

                        foreach (var item in list)
                        {
                            item.SynchroDate = DateTime.Now;
                            item.IsSynchro = 1;
                            DomainSynchroHistoryBLL.Instance.Edit(item);

                            //自动更新域名池信息
                            if(!string.IsNullOrEmpty(item.Domains))
                            {
                                
                                var tdlist = item.Domains.Split(new char[] { '\r', '\t', '\n', ',' });
                                foreach (var tdomain in tdlist)
                                {
                                    if(!string.IsNullOrEmpty(tdomain))
                                    {
                                        var tdinfo = domains.SingleOrDefault(p => p.Domain == tdomain);
                                        if(tdinfo!= null)
                                        {
                                            if (item.OperType == 0)
                                            {
                                                tdinfo.IsResolution = 1;
                                                tdinfo.ResolutionDate = DateTime.Now;
                                                tdinfo.SerName = dsp.Name;

                                                tdinfo.IsColse = 0;

                                                DomainInfoBLL.Instance.Edit(tdinfo);
                                            }else if(item.OperType ==1)
                                            {
                                                tdinfo.IsResolution = 0;

                                                //删除
                                                tdinfo.IsColse = 1;
                                                tdinfo.ColseDate = DateTime.Now;
                                                tdinfo.CloseUserId = 0;
                                                DomainInfoBLL.Instance.Edit(tdinfo);
                                            }
                                        }
                                    }
                                }
                            }
                        }
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