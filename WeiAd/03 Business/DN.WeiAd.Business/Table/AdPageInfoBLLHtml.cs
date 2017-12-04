using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DN.WeiAd.Models;
using DN.WeiAd.Business;
using System.Web;
using System.IO;

namespace DN.WeiAd.Business
{
    public partial class AdPageInfoBLL
    {
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="info"></param>
        /// <returns>adurl</returns>
        public string CreateJSFile(AdPageInfoVO info)
        {
            string jshtml = GetJsTemplate();
            StringBuilder sbJsCon = new StringBuilder();
            sbJsCon.Append(DN.Framework.Utility.HtmlHelper.DecodeHtml(info.Content));
            sbJsCon.AppendFormat("<div style='display:none'>{0}</div>", DN.Framework.Utility.HtmlHelper.DecodeHtml(info.UserCode));
            string jscon = sbJsCon.ToString();

            var qlist = AdQcodeInfoBLL.Instance.GetModels(new AdQcodeInfoPara() { AdId = info.Id });
            StringBuilder sbQlist = new StringBuilder();
            foreach (var item in qlist)
            {
                sbQlist.AppendFormat("'{0}',", item.QcodeUrl);
            }
            if (sbQlist.Length >= 2)
            {
                sbQlist = sbQlist.Remove(sbQlist.Length - 1, 1);
            }

            jscon = Microsoft.JScript.GlobalObject.escape(jscon);
            
            jshtml = jshtml
                .Replace("$Content$", jscon)
                .Replace("$weixinlist$", sbQlist.ToString())
                .Replace("$QcodeImg$", info.QcodeImg)
                .Replace("$DefaultQcodeImg$", info.DefaultQcode);
            //写入JS文件
            string jspath = Path.Combine(HttpContext.Current.Server.MapPath("~"), "Files", "cm_" + info.Id.ToString() + ".js");
            using (StreamWriter writer = new StreamWriter(jspath))
            {
                writer.Write(jshtml);
                writer.Flush();
                writer.Close();
            }
            
            string html = GetHtmlTemplate();
            string adpagename = "detail_" + info.Id.ToString() + ".html";
            string path = Path.Combine(HttpContext.Current.Server.MapPath("~"), "Files", adpagename);
            string adurl = string.Format("/Files/{0}", adpagename);
            var articleinfo = ArticleInfoBLL.Instance.GetRandModel();
            string articlecontent = "";
            if(articleinfo!= null)
            {
                articlecontent = DN.Framework.Utility.HtmlHelper.DecodeHtml(articleinfo.Content);
            }
            html = html.Replace("$UserCode$", DN.Framework.Utility.HtmlHelper.DecodeHtml(info.StaticContent))
                .Replace("$JsFile$", "")
                .Replace("$Title$", info.Title)
                .Replace("$AdPagetId$", info.Id.ToString())
                .Replace("$version$", DateTime.Now.ToString("hhmmss"))
                .Replace("$viewpage$", "cm_" + info.Id.ToString())
                .Replace("$ArticleDetail$", articlecontent);
            
            //写入HTML
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.Write(html);
                writer.Flush();
                writer.Close();
            }


            //读取图片，转换成base64位
            //var list = GetPadSrcImg(jscon);
            //foreach (var item in list)
            //{
            //    string imgurl = item;
            //    if (imgurl.StartsWith("/"))
            //    {
            //        string imgpath = HttpContext.Current.Server.MapPath(imgurl);
            //        //string bimg = DN.WeiAd.Framework.ImageHelper.ImgToBase64String(imgpath, true);
            //        string bimg = DN.WeiAd.Framework.ImageHelper.encodingforfile(imgpath);
            //        jscon = jscon.Replace(item, bimg);
            //    }
            //}

            return adurl;
        }

        private string GetHtmlTemplate()
        {
            string html = "";

            string url = "/Resources/JsTemplate/Default.html";
            string path = HttpContext.Current.Server.MapPath(url);
            using (StreamReader reader = new StreamReader(path))
            {
                html = reader.ReadToEnd();
            }
            return html;
        }

        public string GetJsTemplate()
        {
            string html = "";
            string url = "/Resources/JsTemplate/JsTemplate.js";
            string path = HttpContext.Current.Server.MapPath(url);
            using (StreamReader reader = new StreamReader(path))
            {
                html = reader.ReadToEnd();
            }
            return html;
        }
    }
}
