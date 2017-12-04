using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DN.WeiAd.Models;
using DN.WeiAd.Business;
using DN.WeiAd.Business.AdData;

namespace WebApp.Services
{
    /// <summary>
    /// GetAdData 的摘要说明
    /// </summary>
    public class GetAdData : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string html = "0";

            int userid = int.Parse(context.Request.Params["uid"] ?? "0");
            int adid = int.Parse(context.Request.Params["adid"] ?? "0");

            try
            {
                context.Response.ContentType = "text/plain";
                DN.Framework.Utility.LogHelper.Write(string.Format("用户信息：{0}-{1}", userid, adid), "addata");

                var info = AdDataBLL.Instance.GetALL().SingleOrDefault(p => p.AdId == adid && p.UserId == userid);
                if (info != null)
                {
                    if (info.App == 0)
                    {
                        string shtml = DN.Framework.Utility.WebClientHelper.GetSend(info.ClientUrl, info.Encoding, info.Encoding);

                        HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                        doc.LoadHtml(shtml);
                        string xpath = "//tr[2]/td[2]";
                        if (!string.IsNullOrEmpty(info.XPath))
                        {
                            xpath = info.XPath;
                        }
                        var node = doc.DocumentNode.SelectSingleNode(xpath);
                        if (node != null)
                        {
                            html = node.InnerText;
                        }
                    }
                    else if (info.App == 1)
                    {
                        //需要登录，再获取相关数据
                        html = WebSite.k4884BLL.GetCount();
                    }
                    else if (info.App == 2)
                    {
                        html = WebSite.kuaizhuanBLL.GetCount(info.ClientUrl).ToString();
                    }
                    else if (info.App == 3)
                    {
                        html = WebSite.beijingfengchuankejiBLL.Start(info);
                    }
                    else if (info.App == 4)
                    {
                        html = WebSite.douzhuanBLL.GetCount(info.XPath);
                    }
                    else if (info.App == 5)
                    {
                        string shtml = DN.Framework.Utility.WebClientHelper.GetSend(info.ClientUrl, info.Encoding, info.Encoding);

                        HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                        doc.LoadHtml(shtml);

                        var tdlist = doc.DocumentNode.SelectNodes("//td");

                        int tcount = 0;
                        int tmcount = 0;
                        foreach (var td in tdlist)
                        {
                            if (td.InnerText.IndexOf("-") == -1)
                            {
                                int.TryParse(td.InnerText, out tcount);
                                tmcount = tcount + tmcount;
                            }
                        }

                        html = tmcount.ToString();
                    }
                    else if (info.App == 6)
                    {
                        html = WebSite.seegifBLL.Start(info);
                    }
                    else if (info.App == 7)
                    {
                        html = WebSite.MultilineRowBLL.Start(info);
                    }
                    else if (info.App == 8)
                    {
                        html = WebSite.dadaBLL.Start(info);
                    }
                    else if (info.App == 9)
                    {
                        html = WebSite.jiushuzhijiaBLL.GetCount();
                    }else if(info.App ==10)
                    {
                        html = WebSite.WeiYouZhiJiaBLL.Start(info).ToString();
                    }
                    else if (info.App == 11)
                    {
                        html = WebSite.douzhuanDfBLL.GetCount(info);
                    }
                }
                else
                {
                    DN.Framework.Utility.LogHelper.Write(string.Format("用户信息：{0}-{1}，数据为空。", userid, adid), "addata");
                }


                int vcount = int.Parse(html);
                vcount = vcount + info.VirCount;
                html = vcount.ToString();
            }
            catch (Exception ex)
            {
                DN.Framework.Utility.LogHelper.Write(ex.Message, "addata");
                Console.WriteLine(ex.Message);
            }

            try
            {
                int vcount = int.Parse(html);
                var vlist = VirAdBrowseBLL.Instance.GetModels(new VirAdBrowsePara() { AdId = adid, IsDelete = 0 });
                foreach (var item in vlist)
                {
                    vcount += item.IpCount;
                }

                html = vcount.ToString();
            }
            catch (Exception ex)
            {
                DN.Framework.Utility.LogHelper.Write(ex.Message, "addata");
                Console.WriteLine(ex.Message);
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