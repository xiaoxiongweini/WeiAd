<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserNav.ascx.cs" Inherits="WebApp.AccVir.UControls.UserNav" %>

<aside id="menu">
    <div id="navigation">
        <div class="profile-picture">
            <a href="/AccVir/Index.aspx">
                <img src="<%=Account.UserImg %>" class="img-circle m-b" alt="logo">
            </a>

            <div class="stats-label text-color">
                <span class="font-extra-bold font-uppercase"><%=Account.NickName %></span>

                <div id="sparkline1" class="small-chart m-t-sm"></div>
            </div>
        </div>
        <ul class="nav" id="side-menu">
            <li>
                <a href="/AccVir/Index.aspx"> <span class="nav-label">今日广告统计</span> </a>
            </li>
            <li>
                <a href="/AccVir/HistroyList.aspx"> <span class="nav-label">历史广告查询</span></a>
            </li>
            <li>
                <a href="/AccVir/AdList.aspx"> <span class="nav-label">广告链接列表</span></a>
            </li>
        </ul>
    </div>
</aside>
<script type="text/javascript">
    $(function () {
        var url = document.location.pathname;
        $("#side-menu li").each(function () {
            if ($(this).html().indexOf(url) != -1) {
                $(this).addClass("active");
            }
        });
    })
</script>