<%@ Page Title="" Language="C#" MasterPageFile="~/Accounts/Web.Master" AutoEventWireup="true" CodeBehind="AdDataList.aspx.cs" Inherits="WebApp.Accounts.Vir.AdDataList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    配置数据工具
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .hiddenpreview{display:none;}
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="miniContent" runat="server">
    <!-- Main content -->
    <section class="content">
        <div class="row">
            <div class="col-xs-12">
                <div class="box">
                    <div class="box-header">
                        <h3 class="box-title">配置数据工具</h3>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="row">
                            <div class="col-xs-2">
                                <a class="btn btn-info" href="AdDataEdit.aspx">添加配置数据工具</a>
                            </div>
                        </div>
                        <br />
                        <table id="example2" class="table table-bordered table-hover">
                            <thead>
                                <tr>
                                    <th>用户名称</th>
                                    <th>广告ID</th>
                                    <th>客户端地址</th>
                                    <th>编码</th>
                                    <th>类型</th>
                                    <th>XPath</th>
                                    <th>Purl</th>
                                    <th class="opclass">操作</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater runat="server" ID="rptTable">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%#Eval("Id") %></td>
                                            <td><%#Eval("Name") %></td>
                                            <td><%#Eval("Desc") %></td>
                                            <td><%#Eval("Id") %></td>
                                            <td><%#Eval("Name") %></td>
                                            <td><%#Eval("Desc") %></td>
                                            <td><%#Eval("Id") %></td>
                                            <td><%#Eval("Name") %></td>
                                            <td><%#Eval("Desc") %></td>
                                            <td class="opclass">
                                                <a class="btn btn-info btn-xs" href="AdTypeEdit.aspx?id=<%#Eval("Id") %>">修改</a>
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
