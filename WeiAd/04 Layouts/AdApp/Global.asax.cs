﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AdApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {    
            //移除所有视图引擎
            ViewEngines.Engines.Clear();

            //添加Razor视图引擎
            ViewEngines.Engines.Add(new RazorViewEngine());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
          
        }
    }
}
