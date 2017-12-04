<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Web.Master" AutoEventWireup="true" CodeBehind="CacheList.aspx.cs" Inherits="WebApp.Admin.Sys.CacheList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    缓存管理
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="miniContent" runat="server">

    <!-- Content Header (Page header) -->
    <section class="content-header">
        <h1>系统设置
            <small>缓存管理</small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>首页</a></li>
            <li><a href="#">系统设置</a></li>
            <li class="active">缓存管理</li>
        </ol>
    </section>

    <!-- Main content -->
    <section class="content">

        <!-- SELECT2 EXAMPLE -->
        <div class="box box-default">
            <div class="box-header with-border">
                <h3 class="box-title">缓存管理</h3>
                <div class="box-tools pull-right">
                    <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    <button class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>
                </div>
            </div>
            <!-- /.box-header -->
            <div class="box-body ">
                <div class="row">
                    <div class="form-group">
                        <div class="col-xs-2">
                            <asp:Button runat="server" ID="btnQueryCache" CssClass="btn btn-info form-control" Text="查看缓存" OnClick="btnQueryCache_Click" />
                        </div>
                        <div class="col-xs-2">
                            <asp:Button runat="server" ID="btnReface" CssClass="btn btn-info form-control" Text="刷新缓存" OnClick="btnReface_Click" />
                        </div>
                        <div class="col-xs-2">
                            <asp:Button runat="server" ID="btnSaveDbFile" CssClass="btn btn-info form-control" Text="生成缓存文件" OnClick="btnSaveDbFile_Click" />
                        </div>   <div class="col-xs-2">
                            <asp:Button runat="server" ID="btnReaderDbFile" CssClass="btn btn-info form-control" Text="读取缓存文件" OnClick="btnReaderDbFile_Click" />
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
                <br />
                <table id="example2" class="table table-bordered table-hover">
                    <thead>
                        <tr>
                            <th>缓存名称</th>
                            <th>缓存项</th>
                            <th>缓存数据量</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater runat="server" ID="rptTable">
                            <ItemTemplate>
                                <tr>
                                    <td><%#Eval("NameCn") %></td>
                                    <td><%#Eval("NameEn") %></td>
                                    <td><%#Eval("CacheCount") %></td>
                                    <td><%#Eval("DbCount") %></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
                <!-- /.row -->
            </div>
        </div>
        <!-- /.box -->
    </section>
    <!-- /.content -->
</asp:Content>
