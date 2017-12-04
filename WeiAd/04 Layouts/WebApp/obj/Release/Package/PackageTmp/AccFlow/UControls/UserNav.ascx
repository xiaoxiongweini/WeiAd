<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserNav.ascx.cs" Inherits="WebApp.AccFlow.UControls.UserNav" %>
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
                <i class="fa fa-edit"></i><span>任务中心</span>
                <i class="fa fa-angle-left pull-right"></i>
            </a>
            <ul class="treeview-menu">
                <li><a href="/AccFlow/Tasks/TaskList.aspx"><i class="fa fa-circle-o"></i>领取任务</a></li>
                <li><a href="/AccFlow/Tasks/UserTaskList.aspx?state=0"><i class="fa fa-circle-o"></i>运行中</a></li>
                <li><a href="/AccFlow/Tasks/UserTaskList.aspx?state=1"><i class="fa fa-circle-o"></i>己关闭</a></li>
            </ul>
        </li>
        <li class="treeview  ">
            <a href="#">
                <i class="fa fa-edit"></i><span>广告分析</span>
                <i class="fa fa-angle-left pull-right"></i>
            </a>
            <ul class="treeview-menu">
                <li><a href="/AccFlow/Analysis/HourAnalysis.aspx"><i class="fa fa-circle-o"></i>今日分析</a></li>
                <li><a href="/AccFlow/Analysis/HourDetails.aspx"><i class="fa fa-circle-o"></i>今日访问详情</a></li>
                <li><a href="/AccFlow/Analysis/DayHisAnalaysis.aspx"><i class="fa fa-circle-o"></i>广告历史查询</a></li>
            </ul>
        </li>
        <li class="treeview hidden ">
            <a href="#">
                <i class="fa fa-edit"></i><span>用户管理</span>
                <i class="fa fa-angle-left pull-right"></i>
            </a>
            <ul class="treeview-menu">
                <li><a href="#"><i class="fa fa-circle-o"></i>修改密码</a></li>
            </ul>
        </li>
    </ul>
</section>
<!-- /.sidebar -->
