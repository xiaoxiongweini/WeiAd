using DN.WeiAd.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdApp.Controllers
{
    public class sController : BaseVewController
    {
        /// <summary>
        /// 增高页面
        /// </summary>
        /// <param name="d"></param>
        /// <param name="nd"></param>
        /// <returns></returns>
        public ActionResult zg(string d, string nd)
        {
            //CommonViewAreasByTemplateName(d, nd, "zg.txt", true);
            //CommonViewAreasByTemplateName(d, nd, "zg1.txt", false);
            //CommonView(d, nd);
            ViewBag.TemplateConntent = TemplateBLL.GetTemplate(DN.WeiAd.Business.Config.AppConfig.TemplatePath);
            return View();
        }

        /// <summary>
        /// 鼻炎页面
        /// </summary>
        /// <param name="d"></param>
        /// <param name="nd"></param>
        /// <returns></returns>
        public ActionResult by(string d, string nd)
        {
            //CommonView(d, nd);

            CommonViewAreasByTemplateName(d, nd, "bywap.txt", true);

            return View();
        }

        /// <summary>
        /// 鼻炎备份页
        /// </summary>
        /// <param name="d"></param>
        /// <param name="nd"></param>
        /// <returns></returns>
        public ActionResult bybak(string d, string nd)
        {
            CommonView(d, nd);

            return View();
        }
    }
}