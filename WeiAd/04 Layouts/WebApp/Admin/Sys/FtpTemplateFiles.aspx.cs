using DN.WeiAd.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.Admin.Sys
{
    public partial class FtpTemplateFiles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindPage();
            }
        }
        private void BindPage()
        {
            var list = AdPageInfoBLL.Instance.GetTemplateDetail();
            rptTables.DataSource = list;
            rptTables.DataBind();
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FUFile.PostedFile != null)
            {
                string tempVar = "~/Resources/Template/" + FUFile.Value.ToString();
                FUFile.PostedFile.SaveAs(Server.MapPath(tempVar));
            }
            BindPage();
            message.Text = "上传成功";
        }
    }
}