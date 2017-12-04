using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdApp.Controllers
{
    public class ttController: BaseVewController
    {
        /// <summary>
        /// 页面
        /// </summary>
        /// <param name="d"></param>
        /// <param name="nd"></param>
        /// <returns></returns>
        public ActionResult qb(string d, string nd)
        {
            CommonViewAreasByTemplateName(d, nd, "qb.txt", true);
            return View();
        }

        /// <summary>
        /// 祛斑页面
        /// </summary>
        /// <param name="d"></param>
        /// <param name="nd"></param>
        /// <returns></returns>
        public ActionResult qb1(string d, string nd)
        {
            CommonViewAreasByTemplateName(d, nd, "qb1.txt", true);
            return View();
        }

        /// <summary>
        /// 鼻炎专用
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nd"></param>
        /// <returns></returns>
        public ActionResult by(string id, string nd)
        {
            CommonViewAreasByTemplateName(id, nd, "by.txt", true);
            return View();
        }
    }
}