<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserNav.ascx.cs" Inherits="WebApp.Accounts.UControls.UserNav" %>
<!-- sidebar: style can be found in sidebar.less -->

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
        <li class="treeview hidden ">
            <a href="#">
                <i class="fa fa-edit"></i><span>任务中心</span>
                <i class="fa fa-angle-left pull-right"></i>
            </a>
            <ul class="treeview-menu">
                <li><a href="/Accounts/Pages/UserPageList.aspx"><i class="fa fa-circle-o"></i>运行中</a></li>
                <li><a href="/Accounts/Pages/UserCodeList.aspx"><i class="fa fa-circle-o"></i>己关闭</a></li>
            </ul>
        </li>
        <li class="treeview  ">
            <a href="/Accounts/Charts/AdVlist.aspx">
                <i class="fa fa-edit"></i><span>今日广告概况</span>
                <i class="fa fa-angle-left pull-right"></i>
            </a>
        </li>
        <li class="treeview  ">
            <a href="/Accounts/Charts/DayHisAnalaysis.aspx">
                <i class="fa fa-edit"></i><span>广告历史查询</span>
                <i class="fa fa-angle-left pull-right"></i>
            </a>
        </li>
        <li class="treeview  ">
            <a href="/Accounts/Pages/AdPageList.aspx">
                <i class="fa fa-edit"></i><span>广告链接列表</span>
                <i class="fa fa-angle-left pull-right"></i>
            </a>
        </li>
        <li class="treeview hidden ">
            <a href="#">
                <i class="fa fa-edit"></i><span>广告统计</span>
                <i class="fa fa-angle-left pull-right"></i>
            </a>
            <ul class="treeview-menu">
                <%--<li><a href="/Accounts/Ads/AdList.aspx"><i class="fa fa-circle-o"></i>广告管理</a></li>--%>
                <li><a href="/Accounts/Ads/LogListDay.aspx"><i class="fa fa-circle-o"></i>今日点击详情</a></li>
                <li><a href="/Accounts/Ads/LogList.aspx"><i class="fa fa-circle-o"></i>历史点击详情</a></li>
                <li><a href="/Accounts/Ads/AdDayChart.aspx"><i class="fa fa-circle-o"></i>今日点击趋势</a></li>
                <li><a href="/Accounts/Ads/DayChart.aspx"><i class="fa fa-circle-o"></i>历史点击趋势</a></li>
            </ul>
        </li>
        <li class="treeview hidden">
            <a href="#">
                <i class="fa fa-edit"></i><span>广告页管理</span>
                <i class="fa fa-angle-left pull-right"></i>
            </a>
            <ul class="treeview-menu">
                <li><a href="/Accounts/Pages/AdPageList.aspx"><i class="fa fa-circle-o"></i>广告内容管理</a></li>
                <li class="hidden"><a href="/Accounts/Pages/UserPageList.aspx"><i class="fa fa-circle-o"></i>页面管理</a></li>
                <li class="hidden"><a href="/Accounts/Pages/UserCodeList.aspx"><i class="fa fa-circle-o"></i>统计代码管理</a></li>
            </ul>
        </li>
        <li class="treeview  hidden">
            <a href="#">
                <i class="fa fa-edit"></i><span>今日数据分析</span>
                <i class="fa fa-angle-left pull-right"></i>
            </a>
            <ul class="treeview-menu">
                <li><a href="/Accounts/Charts/HourAnalysis.aspx"><i class="fa fa-circle-o"></i>小时时段分析</a></li>
                <li><a href="/Accounts/Charts/AdFlowDetail.aspx"><i class="fa fa-circle-o"></i>按工作室分析</a></li>
                <li><a href="/Accounts/Charts/AllAdAnalysis.aspx"><i class="fa fa-circle-o"></i>按广告分析</a></li>
                <li><a href="/Accounts/Charts/PageAnalysis.aspx"><i class="fa fa-circle-o"></i>受访页面</a></li>
                <li><a href="/Accounts/Charts/HourDetails.aspx"><i class="fa fa-circle-o"></i>访问详情</a></li>
            </ul>
        </li>
        <li class="treeview hidden">
            <a href="#">
                <i class="fa fa-edit"></i><span>历史数据分析</span>
                <i class="fa fa-angle-left pull-right"></i>
            </a>
            <ul class="treeview-menu">
                <li><a href="/Accounts/Charts/His/HourAnalysis.aspx"><i class="fa fa-circle-o"></i>小时时段分析</a></li>
                <li><a href="/Accounts/Charts/His/AdFlowDetail.aspx"><i class="fa fa-circle-o"></i>按工作室分析</a></li>
                <li><a href="/Accounts/Charts/His/AllAdAnalysis.aspx"><i class="fa fa-circle-o"></i>按广告分析</a></li>
                <li><a href="/Accounts/Charts/His/PageAnalysis.aspx"><i class="fa fa-circle-o"></i>受访页面</a></li>
                <li><a href="/Accounts/Charts/His/HourDetails.aspx"><i class="fa fa-circle-o"></i>访问详情</a></li>
            </ul>
        </li>
        <li class="treeview hidden">
            <a href="#">
                <i class="fa fa-edit"></i><span>财务管理</span>
                <i class="fa fa-angle-left pull-right"></i>
            </a>
            <ul class="treeview-menu">
                <li><a href="/Accounts/Finances/UserFinanceEdit.aspx"><i class="fa fa-circle-o"></i>我的余额</a></li>
                <li><a href="/Accounts/Finances/UserFinanceList.aspx"><i class="fa fa-circle-o"></i>充值历史</a></li>
                <li><a href="/Accounts/Finances/AdFinanceHistoryList.aspx"><i class="fa fa-circle-o"></i>消费历史</a></li>
            </ul>
        </li>
        <li class="treeview hidden ">
            <a href="#">
                <i class="fa fa-edit"></i><span>用户管理</span>
                <i class="fa fa-angle-left pull-right"></i>
            </a>
            <ul class="treeview-menu">
                <li><a href="/Accounts/EditPwd.aspx"><i class="fa fa-circle-o"></i>修改密码</a></li>
                <li class="hidden"><a href="#"><i class="fa fa-circle-o"></i>帐户管理</a></li>
                <li class="hidden"><a href="#"><i class="fa fa-circle-o"></i>登录日志</a></li>
            </ul>
        </li>
    </ul>
</section>
<!-- /.sidebar -->

