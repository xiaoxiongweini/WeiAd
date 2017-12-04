using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdApp.Controllers
{
    public class ffController : BaseVewController
    {
        /// <summary>
        /// 页面
        /// </summary>
        /// <param name="d"></param>
        /// <param name="nd"></param>
        /// <returns></returns>
        public ActionResult p(string d, string nd)
        {
            ViewBag.Pid = d;
            ViewBag.Nid = nd;
            CommonViewNoLog(d, nd);
            return View();
        }

        /// <summary>
        /// 页面
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nd"></param>
        /// <returns></returns>
        public ActionResult pd(string id, string nd)
        {
            CommonView(id, nd);

            return View();
        }

        /// <summary>
        /// 页面
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nd"></param>
        /// <returns></returns>
        public ActionResult pr(string id, string nd)
        {
            CommonViewWeb(id, nd);

            return View();
        }

        /// <summary>
        /// 页面
        /// </summary>
        /// <param name="d"></param>
        /// <param name="nd"></param>
        /// <returns></returns>
        public ActionResult zg(string d, string nd)
        {
            ViewBag.Pid = d;
            ViewBag.Nid = nd;
            CommonViewNoLog(d, nd);
            return View();
        }

        /// <summary>
        /// 痔疮
        /// </summary>
        /// <param name="d"></param>
        /// <param name="nd"></param>
        /// <returns></returns>
        public ActionResult zc(string d, string nd)
        {
            ViewBag.Pid = d;
            ViewBag.Nid = nd;
            CommonViewNoLog(d, nd);
            return View();
        }

        /// <summary>
        /// 丰胸
        /// </summary>
        /// <param name="d"></param>
        /// <param name="nd"></param>
        /// <returns></returns>
        public ActionResult fx(string d, string nd)
        {
            ViewBag.Pid = d;
            ViewBag.Nid = nd;
            CommonViewNoLog(d, nd);
            return View();
        }
    }
}