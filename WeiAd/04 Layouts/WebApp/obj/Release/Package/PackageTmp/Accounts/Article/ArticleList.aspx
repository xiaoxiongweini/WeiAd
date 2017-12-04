<%@ Page Title="" Language="C#" MasterPageFile="~/Accounts/Web.Master" AutoEventWireup="true" CodeBehind="ArticleList.aspx.cs" Inherits="WebApp.Accounts.Article.ArticleList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    文章管理
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .pagination input {
            float: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="miniContent" runat="server">
    <asp:HiddenField runat="server" ID="hidTypeId" />
    <div class="panel panel-default">
        <div class="panel-heading">
            文章管理&nbsp;
        </div>
        <div class="panel-body">
            <div class="form-horizontal">
                <div class="form-group">
                    <div class="row">
                        <label class="col-sm-1 control-label">栏目</label>
                        <div class="col-sm-2">
                            <asp:DropDownList runat="server" ID="ddlChannel" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <label class="col-sm-1 control-label">文章分类</label>
                        <div class="col-sm-2 ">
                            <asp:DropDownList runat="server" ID="ddlArticleType" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <label class="col-sm-1 control-label">审核</label>
                        <div class="col-sm-2">
                            <asp:DropDownList runat="server" ID="ddlState" CssClass="form-control">
                                <asp:ListItem Text="不限" Value=""></asp:ListItem>
                                <asp:ListItem Text="通过" Value="0"></asp:ListItem>
                                <asp:ListItem Text="未审核" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <label class="col-sm-1 control-label">顶/热</label>
                        <div class="col-sm-1">
                            <asp:DropDownList runat="server" ID="ddlTop" CssClass="form-control">
                                <asp:ListItem Text="不限" Value=""></asp:ListItem>
                                <asp:ListItem Text="否" Value="0"></asp:ListItem>
                                <asp:ListItem Text="是" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-sm-1">
                            <asp:DropDownList runat="server" ID="ddlHot" CssClass="form-control">
                                <asp:ListItem Text="不限" Value=""></asp:ListItem>
                                <asp:ListItem Text="否" Value="0"></asp:ListItem>
                                <asp:ListItem Text="是" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <label class="col-sm-1 control-label">关键字</label>
                        <div class="col-sm-2">
                            <asp:TextBox runat="server" ID="txtSerchTitle" ClientIDMode="Static" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-sm-1">
                            <asp:Button runat="server" ID="btnSearch" CssClass="btn btn-info" Text=" 搜 索 " OnClick="btnSearch_Click" />
                        </div>  <div class="col-sm-1">
                            <asp:Button runat="server" ID="btnRefCache" CssClass="btn btn-info" Text=" 刷新 " OnClick="btnRefCache_Click" />
                        </div>
                        <div class="col-sm-1">
                            <a href="ArticleEdit.aspx" class="btn btn-info">添加内容
                            </a>
                        </div>
                    </div>
                </div>
            </div>
            <div>
                <table class="table table-striped table-bordered table-hover">
                    <thead>
                        <tr>
                            <th>序号</th>
                            <th style="width: 350px;">标题</th>
                            <th>创建时间</th>
                            <th>访问</th>
                            <th>排序</th>
                            <th>审核</th>
                            <th>置顶</th>
                            <th>热门</th>
                            <th>操作</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater runat="server" ID="rptTables">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <%#Eval("Id") %>
                                    </td>
                                    <td>
                                        <%#Eval("Title") %>
                                    </td>
                                    <td>
                                        <%#Eval("CreateDate")%>
                                    </td>
                                    <td>
                                        <%#Eval("OpenCount") %>
                                    </td>
                                    <td>
                                        <%#Eval("OrderIndex") %>
                                    </td>
                                    <td>
                                        <%#Eval("IsState").ToString()=="0"?"通过":"未审核" %>
                                    </td>
                                    <td>
                                        <a class="btn btn-info btn-xs" href="ArticleList.aspx?id=<%#Eval("Id")%>&tid=<%#Eval("ChannelId")%>&top=1">
                                        <%#Eval("IsTop").ToString() == "0"?"否":"是" %>
                                            </a>
                                    </td>
                                    <td>
                                        <a class="btn btn-info btn-xs" href="ArticleList.aspx?id=<%#Eval("Id")%>&tid=<%#Eval("ChannelId")%>&hot=1">
                                        <%#Eval("IsHot").ToString() == "0"?"否":"是" %></a>
                                    </td>
                                    <td>
                                        <a href="ArticleEdit.aspx?id=<%#Eval("Id")%>" class="btn btn-info btn-xs">编 辑</a>
                                        <a class="btn btn-info btn-xs" href="ArticleList.aspx?id=<%#Eval("Id")%>&tid=<%#Eval("ChannelId")%>&del=1" onclick="return confirm('确认删除吗？');">删除</a>
                                        
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
                <div>
                    <webdiyer:AspNetPager ID="apPager" runat="server" CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，总记录%RecordCount%条" PagingButtonLayoutType="UnorderedList" CurrentPageButtonClass="active" PagingButtonSpacing="0" CssClass="pagination" HorizontalAlign="Center" OnPageChanged="apPager_PageChanged"
                        Width="100%" AlwaysShow="true" ShowCustomInfoSection="Right" PagingButtonsClass="" PagingButtonsStyle="" ShowBoxThreshold="2" CustomInfoSectionWidth="30%" TextAfterPageIndexBox="&lt;/li&gt;" TextBeforePageIndexBox="&lt;li&gt;" NumericButtonCount="5">
                    </webdiyer:AspNetPager>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
