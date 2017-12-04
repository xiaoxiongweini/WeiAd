using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DN.WeiAd.Models;
using System.Web;
using System.IO;

namespace DN.WeiAd.Business
{
    public partial class AdPageInfoBLL
    {
        private string GetServerUrl(string url)
        {
            if (string.IsNullOrEmpty(url)) return "";

            if (url.IndexOf("/Article/") != -1)
            {
                return url.Substring(url.IndexOf("/Article/"));
            }
            else if (url.IndexOf("/Mp/") != -1)
            {
                return url.Substring(url.IndexOf("/Mp/"));
            }
            return url;
        }


        /// <summary>
        /// 删除相关广告
        /// </summary>
        /// <param name="adinfo"></param>
        public void DeleteAd(AdPageInfoVO adinfo)
        {
            try
            {
                var ulist = AdUserPageBLL.Instance.GetModels(new AdUserPagePara() { AdPageId = adinfo.Id });
                string url = string.Empty;
                string path = string.Empty;
                foreach (var item in ulist)
                {
                    //删除文件
                    url = AdPageInfoBLL.Instance.GetAdViewUrl(item.PageName);

                    path = HttpContext.Current.Server.MapPath(GetServerUrl(url));
                    if (!string.IsNullOrEmpty(path))
                    {
                        if (File.Exists(path))
                        {
                            File.Delete(path);
                        }
                    }

                    //删除数据，暂时不删除，等版本更新
                }
                //删除中间页
                url = adinfo.MiddlePage;
                path = HttpContext.Current.Server.MapPath(GetServerUrl(url));
                if (!string.IsNullOrEmpty(path))
                {
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                }
                //删除广告页
                url = AdPageInfoBLL.Instance.GetAdViewUrl(adinfo.ViewPage);
                path = HttpContext.Current.Server.MapPath(GetServerUrl(url));
                if (!string.IsNullOrEmpty(path))
                {
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            adinfo.IsDel = 1;
            adinfo.DeleteDate = DateTime.Now;
            AdPageInfoBLL.Instance.Edit(adinfo);

            //删除数据，暂时不删除，等版本更新
        }
    }
}
