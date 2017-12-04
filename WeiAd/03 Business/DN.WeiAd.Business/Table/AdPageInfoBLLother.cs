using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DN.WeiAd.Models;
using System.IO;
using System.Web;
using System.Text.RegularExpressions;
using System.Net;
using System.Drawing;
using System.Collections.Concurrent;
using System.Drawing.Imaging;
using Aliyun.OSS;
using DN.Framework.Utility;

namespace DN.WeiAd.Business
{
    public partial class AdPageInfoBLL
    {
        static object m_lock = new object();
        const string m_cachekey = "AdPageInfoBLL";

        ConcurrentBag<AdPageInfoVO> m_list = new ConcurrentBag<AdPageInfoVO>();

        public List<AdPageInfoVO> GetCache()
        {
            List<AdPageInfoVO> cache = new List<AdPageInfoVO>();
            cache = m_list.ToList<AdPageInfoVO>();
            return cache;
        }
        
        /// <summary>
        /// 刷新缓存
        /// </summary>
        public void Refresh()
        {
            var list = GetModels(new AdPageInfoPara());
            lock (m_lock)
            {
                m_list = new ConcurrentBag<AdPageInfoVO>();

                //以文件缓存的方式做缓存，判断文件修改方式
                var mlist = RefreshReaderDbFile();
                foreach (var item in mlist)
                {
                    m_list.Add(item);
                }

                //如果数据为空，则查一次数据库
                if (m_list.Count == 0)
                {
                    var tlist = GetModels(new AdPageInfoPara());
                    foreach (var item in tlist)
                    {
                        m_list.Add(item);
                    }
                }

                //m_list = new ConcurrentBag<AdPageInfoVO>();
                //foreach (var item in list)
                //{
                //    m_list.Add(item);
                //}
            }
        }

        /// <summary>
        /// 文件地址
        /// </summary>
        const string DBFILE_URL_NAME = "/Resources/Cache/AdPage.json";
        DateTime frtime = DateTime.Now;

        /// <summary>
        /// 刷新缓存文件
        /// </summary>
        public void RefreshSaveDbFile()
        {
            var list = GetModels(new AdPageInfoPara());
            string json = DN.Framework.Utility.Serializer.SerializeObject(list);
            string path = HttpContext.Current.Server.MapPath(DBFILE_URL_NAME);
            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }

                using (StreamWriter write = new StreamWriter(path))
                {
                    write.Write(json);
                    write.Flush();
                    write.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 读取缓存文件
        /// </summary>
        public List<AdPageInfoVO> RefreshReaderDbFile()
        {
            List<AdPageInfoVO> list = new List<AdPageInfoVO>();
            string path = HttpContext.Current.Server.MapPath(DBFILE_URL_NAME);
            try
            {
                if (File.Exists(path))
                {
                    DateTime time = File.GetLastWriteTime(path);
                    if (time != frtime)
                    {
                        string json = string.Empty;
                        using (StreamReader reader = new StreamReader(path))
                        {
                            json = reader.ReadToEnd();
                        }

                        if (!string.IsNullOrEmpty(json))
                        {
                            list = DN.Framework.Utility.Serializer.DeserializeObject<List<AdPageInfoVO>>(json);
                            frtime = time;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                DN.Framework.Utility.LogHelper.Write(ex.Message, "error-adpagecache");
            }

            return list;
        }

        private void Init()
        {
            if (m_list.Count == 0)
            {
                Refresh();
            }
        }

        public string GetTitleById(object id)
        {
            if (id == null) return "";
            var info = GetModelById(int.Parse(id.ToString()));
            if (info != null)
            {
                return info.Title;
            }

            return id.ToString();
        }
        public object GetTitleByMoney(object id)
        {
            if (id == null) return "0.00";

            var info = GetModelById(int.Parse(id.ToString()));
            if (info != null)
            {
                return info.Money.ToString("0.00");
            }

            return "0.00";
        }
        public object GetTitleByMoney(object id, object ipcount)
        {
            if (id == null) return "0";

            var info = GetModelById(int.Parse(id.ToString()));
            if (info != null)
            {
                return (info.Money * int.Parse(ipcount.ToString())).ToString("0.00");
            }

            return "0";
        }


        public AdPageInfoVO GetModelById(int adid)
        {
            Refresh();
            var info = m_list.Where(p => p.Id == adid).FirstOrDefault();
            if (info == null)
            {
                info = GetSingle(new AdPageInfoPara() { Id = adid });
            }

            return info;
        }

        public AdPageInfoVO GetModelByViewPage(string viewpage)
        {
            Refresh();
            var info = m_list.Where(p => p.ViewPage == viewpage).FirstOrDefault();
            if (info == null)
            {
                info = GetSingle(new AdPageInfoPara() { ViewPage = viewpage });
            }

            return info;
        }

        /// <summary>
        /// 获取状态信息
        /// </summary>
        /// <returns></returns>
        public List<DN.Framework.Utility.TypeItem> GetStates()
        {
            List<TypeItem> list = new List<TypeItem>();

            list.Add(new TypeItem() { Id = 0, Name = "有效" });
            list.Add(new TypeItem() { Id = 1, Name = "无效" });
            list.Add(new TypeItem() { Id = 2, Name = "待启用" });

            return list;
        }

        /// <summary>
        /// 获取状态名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetStateNameById(object id)
        {
            if (id == null) return "任务状态未识别";

            var info = GetStates().SingleOrDefault(p => p.Id == int.Parse(id.ToString()));

            if (info != null)
            {
                return info.Name;
            }

            return id.ToString();
        }


        /// <summary>
        /// 采集微信文章
        /// </summary>
        /// <param name="wxurl"></param>
        public AdPageInfoVO GetWeiXin(string wxurl)
        {
            AdPageInfoVO info = new AdPageInfoVO();
            info.CreateDate = DateTime.Now;
            info.WeiXinUrl = wxurl;
            string html = DN.Framework.Utility.WebClientHelper.GetSend(wxurl, "utf-8", "utf-8");
            if (!string.IsNullOrEmpty(html))
            {
                html = html.Replace("section", "div");
            }

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);

            var node = doc.DocumentNode.SelectNodes("//*[@id='activity-name']");
            if (node != null && node.Count == 1)
            {
                Console.WriteLine(node[0].InnerText);
                info.Title = node[0].InnerText;
            }
            string chtml = "";
            var content = doc.DocumentNode.SelectNodes("//*[@id='js_content']");
            if (content != null && content.Count == 1)
            {
                chtml = content[0].InnerHtml;
                Console.WriteLine(content[0].InnerHtml);
            }

            info.Content = DownloadHtml(chtml);
            info.LastDate = DateTime.Now;
            info.QcodeImg = "";
            info.TitleImg = "";
            return info;
        }


        /// <summary>
        /// 创建广告页，每次都重新创建
        /// </summary>
        /// <param name="pageName"></param>
        /// <param name="templatename"></param>
        /// <param name="adid"></param>
        /// <returns></returns>
        public bool CreateAdPage(string pageName, string templatename, int adid = 0)
        {
            if (string.IsNullOrEmpty(pageName)) return false;

            AdPageInfoVO adinfo = null;
            if (adid != 0)
            {
                adinfo = AdPageInfoBLL.Instance.GetSingle(new AdPageInfoPara() { Id = adid });
            }
            else
            {
                adinfo = AdPageInfoBLL.Instance.GetSingle(new AdPageInfoPara() { ViewPage = pageName });
                if (adinfo == null)
                {
                    var userpaget = AdUserPageBLL.Instance.GetSingle(new AdUserPagePara() { PageName = pageName });
                    if (userpaget != null)
                    {
                        adinfo = AdPageInfoBLL.Instance.GetSingle(new AdPageInfoPara() { Id = userpaget.AdPageId });
                    }
                }
            }

            if (adinfo != null)
            {
                templatename = adinfo.TemplateName;
            }

            //默认模版
            if (string.IsNullOrEmpty(templatename))
            {
                templatename = Config.AppConfig.TemplateName;
            }

            string html = GetTemplateFile(templatename);

            string turl = string.Format("/Article/{0}", pageName);
            string filePath = HttpContext.Current.Server.MapPath(turl);

            using (StreamWriter write = new StreamWriter(filePath))
            {
                html = ReplaceAllStr(html, adinfo);
                write.WriteLine(html);
                write.Flush();
                write.Close();
            }
            return true;
        }

        /// <summary>
        /// 获可选取模
        /// </summary>
        /// <returns></returns>
        public List<string> GetTemplateSett()
        {
            string path = HttpContext.Current.Server.MapPath("/Resources/Template");
            List<string> list = new List<string>();

            var flist = Directory.GetFiles(path);
            foreach (var item in flist)
            {
                var file = Path.GetFileName(item);
                list.Add(file);
            }

            return list;
        }

        private string GetTemplateFile(string templname)
        {
            if (string.IsNullOrEmpty(templname))
            {
                templname = Config.AppConfig.TemplateName;
            }

            string url = string.Format("/Resources/Template/{0}", templname);
            string path = HttpContext.Current.Server.MapPath(url);

            //如果模版不对，则进行下一组匹配，并且改变当前模版属性
            if (!File.Exists(path))
            {
                url = string.Format("/Resources/Template/{0}", templname);
                path = HttpContext.Current.Server.MapPath(url);
            }

            string html = string.Empty;
            using (StreamReader reader = new StreamReader(path))
            {
                html = reader.ReadToEnd();
            }

            return html;
        }

        /// <summary>
        /// 重新生成页面
        /// </summary>
        /// <param name="pageName"></param>
        /// <param name="templname"></param>
        /// <returns></returns>
        public bool ChangeAdPage(string pageName, string templname)
        {
            if (string.IsNullOrEmpty(pageName)) return false;

            AdPageInfoVO adinfo = AdPageInfoBLL.Instance.GetSingle(new AdPageInfoPara() { ViewPage = pageName });
            if (adinfo == null)
            {
                var userpaget = AdUserPageBLL.Instance.GetSingle(new AdUserPagePara() { PageName = pageName });
                if (userpaget != null)
                {
                    adinfo = AdPageInfoBLL.Instance.GetSingle(new AdPageInfoPara() { Id = userpaget.AdPageId });
                }
            }

            string html = GetTemplateFile(templname);

            string turl = string.Format("/Article/{0}", pageName);
            string filePath = HttpContext.Current.Server.MapPath(turl);

            using (StreamWriter write = new StreamWriter(filePath))
            {
                html = ReplaceAllStr(html, adinfo);
                write.WriteLine(html);
                write.Flush();
                write.Close();
            }
            return true;
        }

        /// <summary>
        /// 全局变量替换
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        private string ReplaceAllStr(string html, AdPageInfoVO adinfo)
        {
            if (string.IsNullOrEmpty(html)) return "";

            //设置微信分享信息
            string wxtitle = string.Empty;                    //标题
            string wxtitleimg = string.Empty;                 //标题图片
            string wxtitlesort = string.Empty;                //短标题
            string wxname = string.Empty;                     //微信名称
            string staticContent = string.Empty;            //静态内容
            string userCode = string.Empty;                 //统计代码
            string id = "0";

            if (adinfo != null)
            {
                wxtitle = adinfo.Title;
                wxtitleimg = adinfo.TitleImg;
                wxtitlesort = adinfo.TitleShort;
                id = adinfo.Id.ToString();
                wxname = adinfo.QcodeImg;
                staticContent = DN.Framework.Utility.HtmlHelper.DecodeHtml(adinfo.StaticContent);
            }
            /*
    <meta name="sharecontent" data-msg-img="你的缩略图地址" data-msg-title="你的标题" data-msg-content="你的简介" data-msg-callBack="" data-line-img="你的缩略图地址" data-line-title="你的标题" data-line-callBack=""/>
    <meta name="sharecontent" data-msg-img="wxtitleimg" data-msg-title="wxtitle" data-msg-content="wxtitleshort" data-msg-callBack="" data-line-img="wxtitleimgshort" data-line-title="wxtitle" data-line-callBack=""/>
             */

            var articleinfo = ArticleInfoBLL.Instance.GetRandModel();
            string articlecontent = "";
            if (articleinfo != null)
            {
                articlecontent = DN.Framework.Utility.HtmlHelper.DecodeHtml(articleinfo.Content);
            }

            string nhtml = html
                .Replace("$Title$", wxtitle)
                .Replace("$PageTitle$", "")
                .Replace("$WxTitleImg$", wxtitleimg)
                .Replace("$WxTitleShort$", wxtitlesort)
                .Replace("$WxTitle$", wxtitle)
                .Replace("$Title$", wxtitle)
                .Replace("$AdInfoId$", id)
                .Replace("version", DateTime.Now.ToString("HHmmss"))
                .Replace("wxtitleimgshort", wxtitleimg)
                .Replace("wxtitleshort", wxtitlesort)
                .Replace("wxtitleimg", wxtitleimg)
                .Replace("$QcodeUrl$", wxname)
                .Replace("$StaticContent$", staticContent)
                .Replace("$AdDomain$", Config.AppConfig.AdDomain)
                .Replace("$ArticleDetail$", articlecontent);

            return nhtml;
        }


        /// <summary>
        /// 广告页
        /// </summary>
        public string GetAdViewUrl(object pageName)
        {
            string domain = DN.WeiAd.Business.Config.AppConfig.AdDomain;

            if (pageName == null) return "";
            if (string.IsNullOrEmpty(pageName.ToString())) return "";
            if (pageName.ToString().IndexOf(".") == -1)
            {
                pageName = string.Format("{0}{1}", pageName, Config.AppConfig.TemplateName.Substring(Config.AppConfig.TemplateName.IndexOf(".")));
            }

            return string.Format("{1}/Article/{0}", pageName, domain);
        }

        /// <summary>
        /// 生成页面
        /// </summary>
        /// <returns></returns>
        public string GetPageName(string template = "")
        {
            //string gid = Guid.NewGuid().ToString().Replace("-", ""); 
            if (string.IsNullOrEmpty(template))
            {
                template = Config.AppConfig.TemplateName;
            }
            string filetype = template.Substring(template.IndexOf(".") + 1);
            string gid = Guid.NewGuid().ToString();
            gid = gid.Substring(0, gid.IndexOf("-"));
            return string.Format("{0}.{1}", gid, filetype);
        }


        #region private method


        /// <summary>
        /// 将图片转换成本地的图片
        /// </summary>
        /// <param name="text">未解码的HTML</param>
        /// <returns></returns>
        public string DownloadHtml(string text)
        {
            string temp = DN.Framework.Utility.HtmlHelper.DecodeHtml(text);
            var list = GetPadImg(temp);
            var list1 = GetPadSrcImg(temp);
            list.AddRange(list1);

            List<string> tlist = list.Distinct<string>().ToList<string>();

            var ilist = DownloadImages(tlist);

            foreach (var item in ilist)
            {
                temp = temp.Replace(item.Key, item.Value);
            }
            temp = temp.Replace("data-src", "src");

            text = DN.Framework.Utility.HtmlHelper.EncodeHtml(temp);

            return text;
        }

        /// <summary>
        /// 获取Img标签
        /// </summary>
        /// <param name="htmlText">截获到的html代码</param>
        /// <returns></returns>
        public List<string> GetPadImg(string htmlText)
        {
            List<string> list = new List<string>();
            Regex regImg = new Regex(@"<img\b[^<>]*?\bdata-src[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<imgUrl>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>", RegexOptions.IgnoreCase);
            MatchCollection mc = regImg.Matches(htmlText);
            foreach (Match m in mc)
            {
                list.Add(m.Groups["imgUrl"].Value); //获取Img标签
            }
            var tlist = list.Distinct<string>().ToList<string>();
            return tlist;
        }

        public List<string> GetPadSrcImg(string htmlText)
        {
            List<string> list = new List<string>();
            Regex regImg = new Regex(@"<img\b[^<>]*?\bsrc[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<imgUrl>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>", RegexOptions.IgnoreCase);
            MatchCollection mc = regImg.Matches(htmlText);
            foreach (Match m in mc)
            {
                list.Add(m.Groups["imgUrl"].Value); //获取Img标签
            }
            return list;
        }

        /// <summary>
        /// 通过URL分析图片后缀
        /// </summary>
        /// <returns></returns>
        private string GetFileExtype(string weixinimgurl)
        {
            string fileext = "";
            if (weixinimgurl.IndexOf("png") != -1)
            {
                fileext = "png";
            }
            else if (weixinimgurl.IndexOf("jpeg") != -1)
            {
                fileext = "jpeg";
            }
            else if (weixinimgurl.IndexOf("gif") != -1)
            {
                fileext = "gif";
            }
            else if (weixinimgurl.IndexOf("jpg") != -1)
            {
                fileext = "jpg";
            }
            return fileext;
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        Dictionary<string, string> DownloadImages(List<string> list)
        {
            Dictionary<string, string> ilist = new Dictionary<string, string>();
            Dictionary<string, string> alilist = new Dictionary<string, string>();
            bool islocl = false;
            foreach (var item in list)
            {
                //本地文件
                if (item.StartsWith("/"))
                {
                    //本地文件
                    islocl = true;
                }

                string url = "/Resources/Upload/weixin/";
                string fileext = Path.GetExtension(item);
                fileext = item.Substring(item.LastIndexOf("=") + 1);


                if (fileext.Length >= 10)
                {
                    fileext = GetFileExtype(item);
                }

                if (fileext == "other")
                {
                    fileext = GetFileExtype(item);
                }

                if (string.IsNullOrWhiteSpace(fileext))
                {
                    fileext = ".xyz";
                }

                string fguid = Guid.NewGuid().ToString();
                string filename = string.Format("{0}.{1}", fguid, fileext);
                if (string.IsNullOrWhiteSpace(fileext))
                {
                    filename = string.Format("{0}", fguid);
                }

                string save = HttpContext.Current.Server.MapPath(url);

                if (!Directory.Exists(save))
                {
                    Directory.CreateDirectory(save);
                }

                string filePath = Path.Combine(save, filename);
                if (islocl)
                {
                    filePath = HttpContext.Current.Server.MapPath(item);
                    filename = Path.GetFileName(item);
                }
                else
                {
                    DoGetImage(item, filePath);
                    if (!ilist.ContainsKey(item))
                    {
                        ilist.Add(item, url + filename);
                    }
                }

                //if (Config.AppConfig.AliYunIsSave)
                //{
                //    //同步到阿里云
                //    string fileToUpload = filePath;
                //    string alifile = Utilty.AliYunOssClientHelper.PutObject(filename, fileToUpload);
                //    if (!alilist.ContainsKey(item))
                //    {
                //        alilist.Add(item, alifile);
                //    }
                //}
            }

            return ilist;

            //if (Config.AppConfig.AliYunIsSave)
            //{
            //    return alilist;
            //}
            //else
            //{
            //    return ilist;
            //}
        }

        void DoGetGif(string url, string path)
        {
            WebClient client = new WebClient();
            client.DownloadFile(url, path);
        }

        /// <summary>
        /// 自动同步到阿里云服务器
        /// </summary>
        /// <param name="html">未解码的HTML内容，图片地址必须为当前域名下的图片地址</param>
        /// <returns></returns>
        public Dictionary<string, string> PutAliyun(string html)
        {
            //原图片地址，新图片地址
            Dictionary<string, string> alilist = new Dictionary<string, string>();

            string temp = DN.Framework.Utility.HtmlHelper.DecodeHtml(html);
            var list = GetPadImg(temp);
            var list1 = GetPadSrcImg(temp);
            list.AddRange(list1);

            List<string> tlist = list.Distinct<string>().ToList<string>();

            foreach (var item in tlist)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    if (item.StartsWith("/"))
                    {
                        string filePath = HttpContext.Current.Server.MapPath(item);
                        if (File.Exists(filePath))
                        {
                            string fileName = Path.GetFileName(filePath);
                            //同步到阿里云
                            string fileToUpload = filePath;
                            string alifile = Utilty.AliYunOssClientHelper.PutObject(fileName, fileToUpload);
                            if (!alilist.ContainsKey(item))
                            {
                                alilist.Add(item, alifile);
                            }
                        }
                    }
                }
            }

            return alilist;
        }


        void DoGetImage(string url, string path)
        {
            //不重复下载文件
            if (File.Exists(path))
            {
                return;
            }

            bool isgif = false;

            if (path.EndsWith(".gif", StringComparison.OrdinalIgnoreCase))
            {
                isgif = true;
            }
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);

            req.ServicePoint.Expect100Continue = false;
            req.Method = "GET";
            req.KeepAlive = true;
            if (isgif)
            {
                req.ContentType = "image/GIF";
            }
            else
            {
                req.ContentType = "image/png";
            }
            HttpWebResponse rsp = (HttpWebResponse)req.GetResponse();

            System.IO.Stream stream = null;

            try
            {
                if (isgif)
                {
                    DoGetGif(url, path);
                }
                else
                {
                    // 以字符流的方式读取HTTP响应
                    stream = rsp.GetResponseStream();
                    System.Drawing.Image img = System.Drawing.Image.FromStream(stream);
                    img.Save(path);
                }
            }
            finally
            {
                // 释放资源
                if (stream != null) stream.Close();
                if (rsp != null) rsp.Close();
            }
        }
        #endregion
    }
}
