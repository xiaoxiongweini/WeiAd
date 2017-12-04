<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserNav.ascx.cs" Inherits="WebApp.Admin.UControls.UserNav" %>
<!-- sidebar: style can be found in sidebar.less -->
<script type="text/javascript" src="/Assets/Scripts/app.js"></script>
<script type="text/javascript">
    $(function () {
        var isactive = true;
        var url = document.location.pathname;
        $(".treeview").each(function () {
            var html = $(this).html();
            if (html.indexOf(url) != -1) {
                $(this).addClass("active");
                isactive = false;
                $.cookie("leftnav", url);
            }
        });
        if (isactive) {
            var url = $.cookie("leftnav");
            $(".treeview").each(function () {
                var html = $(this).html();
                if (html.indexOf(url) != -1) {
                    $(this).addClass("active");
                    isactive = false;
                }
            });
        }
    })
</script>
<section class="sidebar">
    <!-- Sidebar user panel -->
    <div class="user-panel">
        <div class="pull-left image">
            <img src="/Assets/Manager/images/defaultuser.png" class="img-circle" alt="User Image">
        </div>
        <div class="pull-left info">
            <p>
                <asp:Literal runat="server" ID="ltRealName"></asp:Literal>
            </p>
            <a href="#"><i class="fa fa-circle text-success"></i>Online</a>
        </div>
    </div>
    <!-- sidebar menu: : style can be found in sidebar.less -->
    <ul class="sidebar-menu">
        <li class="treeview ">
            <a href="#">
                <i class="fa fa-edit"></i><span>用户管理</span>
                <i class="fa fa-angle-left pull-right"></i>
            </a>
            <ul class="treeview-menu">
                <li><a href="/Admin/Users/UserList.aspx"><i class="fa fa-circle-o"></i>帐户管理</a></li>  
                <li><a href="/Admin/Cus/CpsUserList.aspx"><i class="fa fa-circle-o"></i>CPS广告用户配置</a></li>
            </ul>
        </li>
        <li class="treeview ">
            <a href="#">
                <i class="fa fa-edit"></i><span>内容管理</span>
                <i class="fa fa-angle-left pull-right"></i>
            </a>
            <ul class="treeview-menu">
                <li><a href="/Admin/Article/ChannelList.aspx"><i class="fa fa-circle-o"></i>新闻频道管理</a></li>
                <li><a href="/Admin/Article/ArticleList.aspx"><i class="fa fa-circle-o"></i>新闻管理</a></li>
                <li><a href="/Admin/Ads/AdPageList.aspx"><i class="fa fa-circle-o"></i>广告管理</a></li>
                <li><a href="/Admin/Shop/ProducteList.aspx"><i class="fa fa-circle-o"></i>商品信息管理</a></li>
                <li><a href="/Admin/Ads/AdPageListDel.aspx"><i class="fa fa-circle-o"></i>广告回收站</a></li>
                <li><a href="/Admin/Ads/AdDomainEdit.aspx"><i class="fa fa-circle-o"></i>广告域名批量生成</a></li>
            </ul>
        </li>
        <li class="treeview hidden">
            <a href="#">
                <i class="fa fa-edit"></i><span>全站统计</span>
                <i class="fa fa-angle-left pull-right"></i>
            </a>
            <ul class="treeview-menu">
                <li><a href="/Admin/Analysis/HourAnalysis.aspx"><i class="fa fa-circle-o"></i>分时段统计</a></li>
                <li><a href="/Admin/Analysis/AdUserAnalysis.aspx"><i class="fa fa-circle-o"></i>分广告商统计</a></li>
                <li><a href="/Admin/Analysis/FlowUserAnalysis.aspx"><i class="fa fa-circle-o"></i>分流量统计</a></li>
                <li><a href="/Admin/Analysis/BrowseList.aspx"><i class="fa fa-circle-o"></i>当日浏览详情</a></li>
            </ul>
        </li>
        <li class="treeview">
            <a href="#">
                <i class="fa fa-edit"></i><span>全站统计（新版）</span>
                <i class="fa fa-angle-left pull-right"></i>
            </a>
            <ul class="treeview-menu">
                <li><a href="/Admin/LogBrowse/HourAnalysis.aspx"><i class="fa fa-circle-o"></i>分时段统计</a></li>
                <li><a href="/Admin/LogBrowse/DayAnalysis.aspx"><i class="fa fa-circle-o"></i>天粒度汇总统计</a></li>
                <li><a href="/Admin/LogBrowse/AdDayAnalaysis.aspx"><i class="fa fa-circle-o"></i>分广告商汇总统计</a></li>
                <li><a href="/Admin/LogBrowse/AdAnalysis.aspx"><i class="fa fa-circle-o"></i>按广告每日统计</a></li>
                <li><a href="/Admin/LogBrowse/AdSummaryList.aspx"><i class="fa fa-circle-o"></i>广告总量统计</a></li>
                <li><a href="/Admin/LogBrowse/BrowseList.aspx"><i class="fa fa-circle-o"></i>浏览详情</a></li>
            </ul>
        </li>
        <li class="treeview hidden">
            <a href="#">
                <i class="fa fa-edit"></i><span>二维码访问统计</span>
                <i class="fa fa-angle-left pull-right"></i>
            </a>
            <ul class="treeview-menu">
                <li><a href="/Admin/Analysis/DayHisQcodeAnalysis.aspx"><i class="fa fa-circle-o"></i>历史总览</a></li>
                <li><a href="/Admin/Analysis/LogQcodeList.aspx"><i class="fa fa-circle-o"></i>当日浏览详情</a></li>
            </ul>
        </li>
        <li class="treeview hidden">
            <a href="#">
                <i class="fa fa-edit"></i><span>二维码统计（新版）</span>
                <i class="fa fa-angle-left pull-right"></i>
            </a>
            <ul class="treeview-menu">
                <li><a href="/Admin/Qcode/HourAnalysis.aspx"><i class="fa fa-circle-o"></i>分时段统计</a></li>
                <li><a href="/Admin/Qcode/DayAnalysis.aspx"><i class="fa fa-circle-o"></i>天粒度汇总统计</a></li>
                <li><a href="/Admin/Qcode/AdUserAnalysis.aspx"><i class="fa fa-circle-o"></i>分广告商汇总统计</a></li>
                <li><a href="/Admin/Qcode/AdAnalysis.aspx"><i class="fa fa-circle-o"></i>按广告统计</a></li>
                <li><a href="/Admin/Qcode/QcodeList.aspx"><i class="fa fa-circle-o"></i>浏览详情</a></li>
            </ul>
        </li>
        <li class="treeview hidden">
            <a href="#">
                <i class="fa fa-edit"></i><span>财务管理</span>
                <i class="fa fa-angle-left pull-right"></i>
            </a>
            <ul class="treeview-menu">
                <li><a href="/Admin/Finances/BrowseDayList.aspx"><i class="fa fa-circle-o"></i>今日点击统计</a></li>
                <li><a href="/Admin/Finances/BrowseHistoryList.aspx"><i class="fa fa-circle-o"></i>历史点击统计</a></li>
            </ul>
        </li>
        <li class="treeview  ">
            <a href="#">
                <i class="fa fa-edit"></i><span>系统设置</span>
                <i class="fa fa-angle-left pull-right"></i>
            </a>
            <ul class="treeview-menu">
                <li><a href="/Admin/Pages/DomainList.aspx"><i class="fa fa-circle-o"></i>域名池管理</a></li>
                <li><a href="/Admin/Pages/FtpList.aspx"><i class="fa fa-circle-o"></i>FTP管理</a></li>
                <li><a href="/Admin/Sys/CacheList.aspx"><i class="fa fa-circle-o"></i>缓存管理</a></li>
                <li><a href="/Admin/Sys/TemplateEdit.aspx"><i class="fa fa-circle-o"></i>模版文件全局管理</a></li>
                <li><a href="/Admin/Sys/IisList.aspx"><i class="fa fa-circle-o"></i>IIS操作</a></li>
                <li><a href="/Admin/Sys/LogBrowseDataTransfer.aspx"><i class="fa fa-circle-o"></i>数据迁移</a></li>
                <li><a href="/Admin/Vir/VirAdBrowseList.aspx"><i class="fa fa-circle-o"></i>虚拟数据管理</a></li>
            </ul>
        </li>
         <li class="treeview ">
            <a href="#">
                <i class="fa fa-edit"></i><span>服务器配置</span>
                <i class="fa fa-angle-left pull-right"></i>
            </a>
            <ul class="treeview-menu">
                <li><a href="/Admin/Server/DomainList.aspx"><i class="fa fa-circle-o"></i>域名池管理</a></li>
                <li><a href="/Admin/Server/SerList.aspx"><i class="fa fa-circle-o"></i>服务器信息</a></li>
                <li><a href="/Admin/Server/DomainServerApp.aspx"><i class="fa fa-circle-o"></i>域名部署操作</a></li>
            </ul>
        </li>
         <li class="treeview  ">
            <a href="#">
                <i class="fa fa-edit"></i><span>CPS客户管理</span>
                <i class="fa fa-angle-left pull-right"></i>
            </a>
            <ul class="treeview-menu">
                <li><a href="/Admin/Cus/CusList.aspx"><i class="fa fa-circle-o"></i>客户管理 </a></li>    
                <li><a href="/Admin/Cus/CpsUserList.aspx"><i class="fa fa-circle-o"></i>CPS客户配置 </a></li>
                <li><a href="/Admin/Cps/CpsAnalysis.aspx"><i class="fa fa-circle-o"></i>CPS分析 </a></li>
            </ul>
        </li>
    </ul>
</section>
<!-- /.sidebar -->
