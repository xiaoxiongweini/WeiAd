using DN.WeiAd.Business.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DN.WeiAd.Models;
using DN.WeiAd.Business;

namespace WebApp.Admin.Server
{
    public partial class DomainServerApp : BasePageAdmin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindPage();
            }
        }

        private void BindPage()
        {
            ServerInfoPara sip = new ServerInfoPara();
            sip.OrderBy = " id desc ";
            sip.IsState = 1;

            var list = ServerInfoBLL.Instance.GetModels(sip);
            ddlServer.Items.Clear();
            
            foreach (var item in list)
            {
                ListItem lt = new ListItem();
                lt.Text = string.Format("{0}-{1}-{2}", item.Id, item.Name, item.Ip);
                lt.Value = item.Name;
                ddlServer.Items.Add(lt);
            }

            ddlServer.Items.Insert(0, new ListItem() { Text = "请选择同步服务器", Value = "" });
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            DomainSynchroHistoryVO info = new DomainSynchroHistoryVO();
            info.ClientIp = "";
            info.CreateDate = DateTime.Now;
            info.CreateUserId = Account.UserId;
            info.DomainPath = txtWebPath.Text;
            info.Domains = txtDomains.Text;
            info.MainDomain = txtMainDomain.Text;
            info.Name = ddlServer.SelectedValue;
            info.OperType = 0;
            info.ServerId = 0;
            info.SynchroDate = DateTime.Now;
            info.UserId = Account.UserId;

            DomainSynchroHistoryBLL.Instance.Add(info);
            lblMsg.Text = "域名同步数据提交，服务器正在同步处理。";            
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            DomainSynchroHistoryVO info = new DomainSynchroHistoryVO();
            info.ClientIp = "";
            info.CreateDate = DateTime.Now;
            info.CreateUserId = Account.UserId;
            info.DomainPath = txtWebPath.Text;
            info.Domains = txtDomains.Text;
            info.MainDomain = txtMainDomain.Text;
            info.Name = ddlServer.SelectedValue;
            info.OperType = 1;
            info.ServerId = 0;
            info.SynchroDate = DateTime.Now;
            info.UserId = Account.UserId;

            DomainSynchroHistoryBLL.Instance.Add(info);
            lblMsg.Text = "域名同步数据提交，服务器正在同步处理。";
        }

        protected void btnDelDomain_Click(object sender, EventArgs e)
        {
            DomainSynchroHistoryVO info = new DomainSynchroHistoryVO();
            info.ClientIp = "";
            info.CreateDate = DateTime.Now;
            info.CreateUserId = Account.UserId;
            info.DomainPath = txtWebPath.Text;
            info.Domains = txtDomains.Text;
            info.MainDomain = txtMainDomain.Text;
            info.Name = ddlServer.SelectedValue;
            info.OperType = 2;
            info.ServerId = 0;
            info.SynchroDate = DateTime.Now;
            info.UserId = Account.UserId;

            DomainSynchroHistoryBLL.Instance.Add(info);
            lblMsg.Text = "域名同步数据提交，服务器正在同步处理。";
        }
    }
}