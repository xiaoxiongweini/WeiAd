﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DN.WeiAd.Models;
using DN.WeiAd.Business;
using DN.WeiAd.Business.Pages;

namespace WebApp.Admin
{
    public partial class Index : BasePageAdmin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string lt = Account.NickName;
        }
    }
}