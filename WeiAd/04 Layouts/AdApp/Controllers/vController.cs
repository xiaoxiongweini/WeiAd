using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DN.WeiAd.Models;
using DN.WeiAd.Business;

namespace AdApp.Controllers
{
    public class vController : BaseVewController
    {
        /// <summary>
        /// 页面
        /// </summary>
        /// <param name="d"></param>
        /// <param name="nd"></param>
        /// <returns></returns>
        public ActionResult w(string d, string nd)
        {
            CommonViewEncode(d, nd);

            return View();
        }

        /// <summary>
        /// 无中间页刚跳转
        /// </summary>
        /// <param name="d"></param>
        /// <param name="nd"></param>
        /// <returns></returns>
        public ActionResult v(string d, string nd)
        {
            CommonView(d, nd);

            return View();
        }

        /// <summary>
        /// AJAX加载
        /// </summary>
        /// <param name="d"></param>
        /// <param name="nd"></param>
        /// <returns></returns>
        public ActionResult d(string d, string nd)
        {
            CommonView(d, nd);
            ViewBag.Nid = d;
            return View();
        }

        /// <summary>
        /// weixin客户端
        /// </summary>
        /// <param name="kd">广告ID</param>
        /// <param name="td">新闻ID</param>
        /// <returns></returns>
        public ActionResult detail(string kd, string td)
        {
            CommonViewArea(kd, td);
            return View();
        }

        /// <summary>
        /// 纯图片使用CSS的方式防封
        /// </summary>
        /// <param name="kd"></param>
        /// <param name="td"></param>
        /// <returns></returns>
        public ActionResult cs(string kd, string td)
        {
            CommomViewCss(kd, td);
            return View();
        }

        /// <summary>
        /// weixin客户端
        /// </summary>
        /// <param name="ad">广告ID</param>
        /// <param name="cd">新闻ID</param>
        /// <returns></returns>
        public ActionResult dw(string ad, string cd)
        {
            CommonView(ad, cd);
            return View();
        }

        /// <summary>
        /// 客户端，屏蔽上海IP
        /// </summary>
        /// <param name="wid">广告ID</param>
        /// <param name="wnd">新闻ID</param>
        /// <returns></returns>
        public ActionResult gp(string wid, string wnd)
        {
            CommonViewArea(wid, wnd);
            return View();
        }

        /// <summary>
        /// 客户端，屏蔽上海IP
        /// </summary>
        /// <param name="d">广告ID</param>
        /// <param name="n">新闻ID</param>
        /// <returns></returns>
        public ActionResult gp1(string d, string n)
        {
            CommonView(d, n);
            return View();
        }
    }
}