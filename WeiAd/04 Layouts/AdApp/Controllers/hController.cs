using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdApp.Controllers
{
    public class hController : BaseVewController
    {
        /// <summary>
        /// 男科广告
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nd"></param>
        /// <returns></returns>
        public ActionResult bbs(string id, string nd)
        {
            CommonView(id, nd);
            return View();
        }
    }
}