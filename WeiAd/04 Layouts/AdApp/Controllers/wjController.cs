using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdApp.Controllers
{
    public class wjController: BaseVewController
    {
        /// <summary>
        /// 鼻炎
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nd"></param>
        /// <returns></returns>
        public ActionResult by(string id, string nd)
        {
            CommonView(id, nd);
            return View();
        }

        /// <summary>
        /// 鼻炎功能的界面,WAP使用微信号
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nd"></param>
        /// <returns></returns>
        public ActionResult byw1(string id, string nd)
        {
            CommonViewAreasByTemplateName(id, nd, "bywap.txt", true);
            return View();
        }

        /// <summary>
        /// 鼻炎
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nd"></param>
        /// <returns></returns>
        public ActionResult zg(string id, string nd)
        {
            CommonViewAreasByTemplateName(id, nd, "zg.txt", true);
            return View();
        }

        /// <summary>
        /// 增高页面
        /// </summary>
        /// <param name="d"></param>
        /// <param name="nd"></param>
        /// <returns></returns>
        public ActionResult zg1(string d, string nd)
        {
            CommonViewAreasByTemplateName(d, nd, "zg1.txt", true);
            //CommonView(d, nd);
            return View();
        }
    }
}