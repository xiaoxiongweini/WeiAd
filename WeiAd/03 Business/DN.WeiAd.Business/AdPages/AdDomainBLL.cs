using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DN.WeiAd.Models;
using DN.WeiAd.Business;
using DN.WeiAd.Business.Entity;
using System.IO;
using System.Web;

namespace DN.WeiAd.Business.AdPages
{
    /// <summary>
    /// 广告域名随机业务
    /// </summary>
    public class AdDomainBLL
    {
        /// <summary>
        /// 生成的文件夹地址
        /// </summary>
        const string m_diction = "/Resources/AdDomain/";

        const string m_template = "/Resources/AdDomainTemplate/";

        const string m_html_index = "index.html";
        const string m_html_style = "style.css";
        //中间页
        const string m_html_default = "default.html";

        Random m_random = new Random();

        //生成中间页
        private void CreateMiddPage(List<string> list, ArticleInfoVO ainfo,AdPageInfoVO adinfo)
        {
            string html = "";

            string indexpath = HttpContext.Current.Server.MapPath(string.Format("{0}{1}", m_template, m_html_default));         
            using (StreamReader reader = new StreamReader(indexpath))
            {
                html = reader.ReadToEnd();
            }

            string jsscript = "var domains = ['$domains$']; var rdmain = \"\"; if (domains.length == 1){ rdmain = domains[0];  }  else  { rdmain = domains[Math.floor(Math.random() * domains.length)]; }document.location.href = \"http://\" + rdmain;";
            jsscript = jsscript.Replace("$domains$", string.Join("','", list.ToArray()));
            Yahoo.Yui.Compressor.JavaScriptCompressor js = new Yahoo.Yui.Compressor.JavaScriptCompressor();

            string jstext = js.Compress(jsscript);
            html = html.Replace("$script$", jstext)
                .Replace("$adid$",adinfo.Id.ToString())
                .Replace("$ArticleDetail$", DN.Framework.Utility.HtmlHelper.DecodeHtml(ainfo.Content));

            string dir = HttpContext.Current.Server.MapPath(m_diction);
            string nhtmlpath = Path.Combine(dir, "index.html");

            using (StreamWriter write = new StreamWriter(nhtmlpath))
            {
                write.Write(html);
                write.Flush();
                write.Close();
            }
        }

        /// <summary>
        /// 生成广告域名文件夹
        /// </summary>
        /// <param name="addomain"></param>
        public void CreatedAdDomain(AdDomainInfo addomain)
        {
            var info = AdPageInfoBLL.Instance.GetSingle(new AdPageInfoPara() { Id = addomain.AdId });
            var articleList = ArticleInfoBLL.Instance.GetModels(new ArticleInfoPara());

            StringBuilder sbdomain = new StringBuilder();
            List<string> domains = new List<string>();

            if (info != null)
            {
                //分别获取HTML和CSS文件内容
                string indexpath = HttpContext.Current.Server.MapPath(string.Format("{0}{1}", m_template, m_html_index));
                string stylepath = HttpContext.Current.Server.MapPath(string.Format("{0}{1}", m_template, m_html_style));
                string html = "";
                string style = "";
                using (StreamReader reader = new StreamReader(indexpath))
                {
                    html = reader.ReadToEnd();
                }
                using (StreamReader reader = new StreamReader(stylepath))
                {
                    style = reader.ReadToEnd();
                }

                foreach (var item in addomain.Domains)
                {
                    if (string.IsNullOrEmpty(item))
                    {
                        continue;
                    }

                    string domain = CreateRoundDomain(item,addomain);
                    sbdomain.AppendLine(domain + ",");
                    domains.Add(domain);
                    string dir = string.Format("{0}{1}", m_diction, domain);
                    dir = HttpContext.Current.Server.MapPath(dir);
                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }

                    ArticleInfoVO ainfo = articleList[m_random.Next(articleList.Count - 1)];


                    //写入域名相关的文件夹
                    string nhtmlpath = Path.Combine(dir, "index.html");
                    string nstylename = Guid.NewGuid().ToString();
                    nstylename = nstylename.Substring(0, 4);
                    string nstylepath = Path.Combine(dir, string.Format("{0}.css", nstylename));

                    var result = ReplaceHtml(html, style, info, ainfo, nstylename);

                    using (StreamWriter write = new StreamWriter(nhtmlpath))
                    {
                        write.Write(result.Item1);
                        write.Flush();
                        write.Close();
                    }
                    using (StreamWriter write = new StreamWriter(nstylepath))
                    {
                        write.Write(result.Item2);
                        write.Flush();
                        write.Close();
                    }
                }
            }

            info.DomainList = sbdomain.ToString();
            AdPageInfoBLL.Instance.Edit(info);
            var arinfo = articleList[m_random.Next(articleList.Count - 1)];
            CreateMiddPage(domains, arinfo, info);
        }

        /// <summary>
        /// 更新静态文件内容
        /// </summary>
        /// <param name="html"></param>
        /// <param name="adpage"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        private Tuple<string,string> ReplaceHtml(string html,string style, AdPageInfoVO adpage, ArticleInfoVO info,string stylefilename)
        {
            string nhtml = html;
            StringBuilder sb = new StringBuilder();
            sb.Append(style);

            //随机插入部分样式
            string rcss = Guid.NewGuid().ToString();
            sb.AppendLine(string.Format(".{0}", rcss));
            sb.Append("{color:red;padding:0px;}");
            string nstyle = sb.ToString();

            //替换CSS名称
            var csslist = GetCssList();
            foreach (var item in csslist)
            {
                nhtml.Replace(item.Key, item.Value);
                nstyle.Replace(item.Key, item.Value);
            }

            Yahoo.Yui.Compressor.CssCompressor css = new Yahoo.Yui.Compressor.CssCompressor();
            string nstylemin = css.Compress(nstyle);

            nhtml = nhtml.Replace("$AdPagetId$", adpage.Id.ToString())
                .Replace("$ArticleDetail$", DN.Framework.Utility.HtmlHelper.DecodeHtml(info.Content))
                .Replace("$UserCode$", DN.Framework.Utility.HtmlHelper.DecodeHtml( adpage.StaticContent))
                .Replace("$Title$", info.Title)
                .Replace("$version$", DateTime.Now.ToString("yyyyMMddhhmmss"))
                .Replace("href=\"style.css\"", string.Format("href=\"{0}\"", stylefilename));

            return new Tuple<string, string>(nhtml, nstylemin);
        }

        private Dictionary<string,string> GetCssList()
        {
            Dictionary<string, string> list = new Dictionary<string, string>();

            list.Add("rich_media_inner", Guid.NewGuid().ToString());
            list.Add("rich_media_area_primary", Guid.NewGuid().ToString());
            list.Add("rich_media_title", Guid.NewGuid().ToString());
            list.Add("rich_media_content", Guid.NewGuid().ToString());
            list.Add("rich_media", Guid.NewGuid().ToString());
            list.Add("top_banner", Guid.NewGuid().ToString());

            return list;
        }

        /// <summary>
        /// 生成随机域名
        /// </summary>
        /// <param name="domain"></param>
        /// <returns></returns>
        private string CreateRoundDomain(string domain, AdDomainInfo addomain)
        {
            string gid = Guid.NewGuid().ToString();
            if(!string.IsNullOrEmpty(addomain.TwoDomain))
            {
                gid = addomain.TwoDomain;
            }
            else
            {
                gid = gid.Substring(0, gid.IndexOf("-"));
            }
            return string.Format("{0}.{1}", gid, domain);
        }

    }
}
