using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdApp.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class xcController : BaseVewController
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
        /// 鼻炎
        /// </summary>
        /// <param name="d"></param>
        /// <param name="nd"></param>
        /// <returns></returns>
        public ActionResult by1(string d, string nd)
        {
            CommonViewAreasByTemplateName(d, nd, "bywap.txt", true);
            //CommonView(d, nd);

            return View();
        }

        /// <summary>
        /// 鼻炎
        /// </summary>
        /// <param name="d"></param>
        /// <param name="nd"></param>
        /// <returns></returns>
        public ActionResult by2(string d, string nd)
        {
            CommonView(d, nd);
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