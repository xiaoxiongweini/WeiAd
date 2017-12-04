<%@ Page Title="" Language="C#" MasterPageFile="~/Wap/Web.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebApp.Wap.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(function () {
            onactionurl();
        })

        function onactionurl()
        {
            var url = document.location.pathname + document.location.search;
            alert(url);

            $("#divnavbox a").each(function () {
                var href = $(this).attr("href");
                if (href == url) {
                    $(this).addClass("active");
                }
            })
        }
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="miniContent" runat="server">
    <asp:HiddenField runat="server" ID="hidChannelId" />

    <!-- page集合的容器，里面放多个平行的.page，其他.page作为内联页面由路由控制展示 -->
    <div class="page-group">
        <!-- 单个page ,第一个.page默认被展示-->
        <div class="page">
            <!-- 标题栏 -->
            <header class="bar bar-nav">
                <h1 class="title">微糖赚</h1>
            </header>

            <!-- 工具栏 -->
            <nav class="bar bar-tab">
                <a class="tab-item external active" href="#">
                    <span class="icon icon-home"></span>
                    <span class="tab-label">个人中心</span>
                </a>
                <a class="tab-item external" href="Index.aspx">
                    <span class="icon icon-star"></span>
                    <span class="tab-label">开始赚钱</span>
                </a>
                <a class="tab-item external" href="#">
                    <span class="icon icon-settings"></span>
                    <span class="tab-label">开始收徒</span>
                </a>
            </nav>

            <!-- 这里是页面内容区 -->
            <div class="content">
                <div class="buttons-tab" id="divnavbox">
                    <a href="/Wap/Index.aspx" class="button">最新</a>
                    <asp:Repeater runat="server" ID="rptChannel">
                        <ItemTemplate>
                            <a href="/Wap/Index.aspx?cid=<%#Eval("Id") %>" class="button"><%#Eval("Name") %></a>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div class="list-block media-list">
                    <ul>
                        <asp:Repeater runat="server" ID="rptTable">
                            <ItemTemplate>
                                <li>
                                    <a href="Detail.aspx?id=<%#Eval("Id") %>" class="item-link item-content">
                                        <div class="item-media">
                                            <img src="<%#Eval("TitleImg") %>" width="44"></div>
                                        <div class="item-inner">
                                            <div class="item-title-row">
                                                <div class="item-title"><%#Eval("Title") %></div>
                                            </div>
                                            <div class="item-subtitle"><%#Eval("TitleShort") %></div>
                                        </div>
                                    </a>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>

                    </ul>
                </div>
            </div>
        </div>
        <!-- 其他的单个page内联页（如果有） -->
        <div class="page">...</div>
    </div>
    <!-- 默认必须要执行$.init(),实际业务里一般不会在HTML文档里执行，通常是在业务页面代码的最后执行 -->
   <%--<script>$.init()</script>--%>
</asp:Content>
