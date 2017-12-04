<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Web.Master" AutoEventWireup="true" CodeBehind="ChannelList.aspx.cs" Inherits="WebApp.Admin.Article.ChannelList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    频道管理
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
            频道管理&nbsp;
        </div>
        <div class="panel-body">
            <div class="form-horizontal">
                <div class="form-group">
                    <div class="row">
                        <label class="col-sm-1 control-label">关键字</label>
                        <div class="col-sm-2">
                            <asp:TextBox runat="server" ID="txtSerchTitle" ClientIDMode="Static" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-sm-1">
                            <asp:Button runat="server" ID="btnSearch" CssClass="btn btn-info" Text=" 搜 索 " OnClick="btnSearch_Click" />
                        </div>
                        <div class="col-sm-1">
                            <a href="ChannelEdit.aspx" class="btn btn-info">添加频道
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
                            <th>频道名称</th>
                            <th>链接地址</th>
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
                                        <%#Eval("Name") %>
                                    </td>
                                    <td>
                                        <%#Eval("LinkUrl")%>
                                    </td>
                                    <td>
                                        <%#Eval("IsTop").ToString() == "0"?"否":"是" %>
                                    </td>
                                    <td>
                                        <%#Eval("IsHot").ToString() == "0"?"否":"是" %>
                                    </td>
                                    <td>
                                        <a href="ArticleEdit.aspx?id=<%#Eval("Id")%>" class="btn btn-info btn-xs">编 辑</a>
                                        <a class="btn btn-info btn-xs" href="ArticleList.aspx?id=<%#Eval("Id")%>&del=1" onclick="return confirm('确认删除吗？');">删除</a>

                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
                <div>
                    <webdiyer:AspNetPager ID="apPager" runat="server" CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，总记录%RecordCount%条" PagingButtonLayoutType="UnorderedList" CurrentPageButtonClass="active" PagingButtonSpacing="0" CssClass="pagination" HorizontalAlign="Center" UrlPaging="true"
                        Width="100%" AlwaysShow="true" ShowCustomInfoSection="Right" PagingButtonsClass="" PagingButtonsStyle="" ShowBoxThreshold="2" CustomInfoSectionWidth="30%" TextAfterPageIndexBox="&lt;/li&gt;" TextBeforePageIndexBox="&lt;li&gt;" NumericButtonCount="5">
                    </webdiyer:AspNetPager>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
