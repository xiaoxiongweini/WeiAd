<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Web.Master" AutoEventWireup="true" CodeBehind="LogBrowseDataTransfer.aspx.cs" Inherits="WebApp.Admin.Sys.LogBrowseDataTransfer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    数据迁移
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="/Assets/Scripts/Plugs/My97DatePicker/WdatePicker.js"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="miniContent" runat="server">

    <!-- Content Header (Page header) -->
    <section class="content-header">
        <h1>系统设置
            <small>数据迁移</small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>首页</a></li>
            <li><a href="#">系统设置</a></li>
            <li class="active">数据迁移</li>
        </ol>
    </section>

    <!-- Main content -->
    <section class="content">

        <!-- SELECT2 EXAMPLE -->
        <div class="box box-default">
            <div class="box-header with-border">
                <h3 class="box-title">数据迁移</h3>
                <div class="box-tools pull-right">
                    <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    <button class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>
                </div>
            </div>
            <!-- /.box-header -->
            <div class="box-body ">
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-2">选择迁移时间</label>
                        <div class="col-xs-2">
                            <input type="text" runat="server" id="txtTimeOld" class="form-control" onfocus="WdatePicker({maxDate:'%y-%M-{%d}'})" />
                        </div>
                        <div class="col-xs-2">
                            <asp:Button runat="server" ID="btnTransfer" CssClass="btn btn-info form-control" Text="浏览数据迁移" OnClick="btnTransfer_Click" />
                        </div>
                        <div class="col-xs-2">
                            <asp:Button runat="server" ID="btnShowSummer" CssClass="btn btn-info form-control" Text="查看汇总数据" OnClick="btnShowSummer_Click" />
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="form-group">
                        <div class="col-xs-12">
                             <table class="table table-striped table-bordered table-hover">
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>AdId</th>
                            <th>UserId</th>
                            <th>PvCount</th>
                            <th>UvCount</th>
                            <th>IpCount</th>
                            <th>Price</th>
                            <th>Money</th>
                            <th>CreateDate</th>
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
                                        <%#Eval("AdId") %>
                                    </td>
                                    <td>
                                        <%#Eval("UserId")%>
                                    </td>
                                    <td>
                                        <%#Eval("PvCount") %>
                                    </td>
                                    <td>
                                        <%#Eval("UvCount") %>
                                    </td>
                                       <td>
                                        <%#Eval("IpCount") %>
                                    </td>
                                    <td>
                                        <%#Eval("Price") %>
                                    </td>
                                    <td>
                                        <%#Eval("Money") %>
                                    </td>
                                    <td>
                                        <%#Eval("CreateDate")%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
                        </div>
                    </div>

                </div>

                <br />
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2"></label>
                        <div class="col-xs-6">
                            <asp:Label runat="server" ID="lblMsg"></asp:Label>
                        </div>
                    </div>
                </div>
                <!-- /.row -->
            </div>
        </div>
        <!-- /.box -->
    </section>
    <!-- /.content -->
</asp:Content>
