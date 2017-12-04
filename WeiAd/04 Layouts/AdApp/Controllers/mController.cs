using DN.WeiAd.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdApp.Controllers
{
    public class mController : BaseVewController
    {
        /// <summary>
        /// 痔疮
        /// </summary>
        /// <param name="d"></param>
        /// <param name="nd"></param>
        /// <returns></returns>
        public ActionResult zc(string d, string nd)
        {
            CommonView(d, nd);

            return View();
        }


        /// <summary>
        /// 增高
        /// </summary>
        /// <param name="d"></param>
        /// <param name="nd"></param>
        /// <returns></returns>
        public ActionResult zg(string d, string nd)
        {
            //CommonView(d, nd);

            //skey edit 2017-11-20
            string html = TemplateBLL.GetTemplate(DN.WeiAd.Business.Config.AppConfig.TemplatePathDynamic);

            if(!string.IsNullOrEmpty(d))
            {
                var adinfo = AdPageInfoBLL.Instance.GetModelById(int.Parse(d));
                if(adinfo!= null)
                {
                    html = html.Replace("@ViewBag.QcodeImg2", adinfo.QcodeImg2);
                }
            }

            ViewBag.TemplateConntent = html;

            return View();
        }  

        /// <summary>
        /// 增高
        /// </summary>
        /// <param name="d"></param>
        /// <param name="nd"></param>
        /// <returns></returns>
        public ActionResult zg1(string d, string nd)
        {
            CommonView(d, nd);

            return View();
        }


        /// <summary>
        /// 鼻炎
        /// </summary>
        /// <param name="d"></param>
        /// <param name="nd"></param>
        /// <returns></returns>
        public ActionResult by(string d, string nd)
        {

            CommonViewAreasByTemplateName(d, nd, "bywap.txt", true);
            //CommonView(d, nd);

            return View();
        }

        /// <summary>
        /// 祛斑
        /// </summary>
        /// <param name="d"></param>
        /// <param name="nd"></param>
        /// <returns></returns>
        public ActionResult qb(string d, string nd)
        {
            CommonView(d, nd);

            return View();
        }
    }
}