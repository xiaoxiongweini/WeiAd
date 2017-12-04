<%@ Page Title="" Language="C#" MasterPageFile="~/Accounts/Web.Master" AutoEventWireup="true" CodeBehind="AdList.aspx.cs" Inherits="WebApp.Accounts.Ads.AdList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    广告管理
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="miniContent" runat="server">
    <!-- Main content -->
    <section class="content">
        <div class="row">
            <div class="col-xs-12">
                <div class="box">
                    <div class="box-header">
                        <h3 class="box-title">广告管理</h3>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="row">
                            <div class="col-xs-2">
                                <asp:DropDownList runat="server" ID="ddlAdType" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                            <div class="col-xs-1">
                                <asp:Button runat="server" ID="btnSearch" CssClass="btn btn-info form-control" Text="搜索" OnClick="btnSearch_Click" />
                            </div>
                            <div class="col-xs-2">
                                <a href="AdEdit.aspx" class="btn btn-info form-control">添加广告</a>
                            </div>
                            <div class="col-xs-2">
                                <a href="/AdView.aspx?uuid=<%=Account.UserId %>" target="_blank" class="btn btn-info form-control">浏览广告</a>
                            </div>
                        </div>
                        <br />
                        <table id="example2" class="table table-bordered table-hover">
                            <thead>
                                <tr>
                                    <th>Id</th>
                                    <th>广告标题</th>
                                    <th>链接地址</th>
                                    <th>广告单价(元)</th>
                                    <th>是否显示</th>
                                    <th>创建时间</th>
                                    <th>操作</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater runat="server" ID="rptTable">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%#Eval("Id") %></td>
                                            <td><%#Eval("Title") %></td>
                                            <td><%#Eval("LinkUrl") %></td>
                                            <td><%#Eval("ClickMoney") %></td>
                                            <td><%#Eval("IsShow").ToString()=="1"?"是":"否" %></td>
                                            <td><%#Eval("DateStart") %></td>
                                            <td>
                                                <a class="btn btn-info btn-xs" href="AdEdit.aspx?id=<%#Eval("Id") %>">修改</a>
                                                <a class="btn btn-danger btn-xs" onclick="return confirm('确认删除吗？');" href="AdList.aspx?id=<%#Eval("Id") %>">删除</a>
                                                <a class="btn btn-info btn-xs" target="_blank" href="AdFullChart.aspx?adid=<%#Eval("Id") %>">广告统计</a>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                        <div>
                            <webdiyer:AspNetPager ID="apPager" runat="server" CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，总记录%RecordCount%条" PagingButtonLayoutType="UnorderedList" CurrentPageButtonClass="active" PagingButtonSpacing="0" CssClass="pagination" HorizontalAlign="Center" OnPageChanged="apPager_PageChanged"
                                Width="100%" AlwaysShow="true" ShowCustomInfoSection="Right" PagingButtonsClass="" PagingButtonsStyle="">
                            </webdiyer:AspNetPager>
                        </div>
                    </div>
                    <!-- /.box-body -->
                </div>
                <!-- /.box -->
            </div>
            <!-- /.col -->
        </div>
        <!-- /.row -->
    </section>
    <!-- /.content -->
</asp:Content>
