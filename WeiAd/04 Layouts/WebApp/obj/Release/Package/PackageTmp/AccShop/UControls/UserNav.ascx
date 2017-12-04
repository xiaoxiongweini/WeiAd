<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserNav.ascx.cs" Inherits="WebApp.AccShop.UControls.UserNav" %>
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
        <li class="treeview  ">
            <a href="#">
                <i class="fa fa-edit"></i><span>订单管理</span>
                <i class="fa fa-angle-left pull-right"></i>
            </a>
            <ul class="treeview-menu">
                <li><a href="/AccShop/Order/OrderList.aspx"><i class="fa fa-circle-o"></i>订单管理</a></li>
                
            </ul>
        </li>
    </ul>
</section>
<!-- /.sidebar -->
