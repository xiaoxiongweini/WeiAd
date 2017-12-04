<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Web.Master" AutoEventWireup="true" CodeBehind="TemplateEdit.aspx.cs" Inherits="WebApp.Admin.Sys.TemplateEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    全站操作
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="miniContent" runat="server">

    <!-- Content Header (Page header) -->
    <section class="content-header">
        <h1>系统设置
            <small>全站操作</small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>首页</a></li>
            <li><a href="#">全站操作</a></li>
            <li class="active">全站操作</li>
        </ol>
    </section>

    <!-- Main content -->
    <section class="content">

        <!-- SELECT2 EXAMPLE -->
        <div class="box box-default">
            <div class="box-header with-border">
                <h3 class="box-title">全站操作</h3>
                <div class="box-tools pull-right">
                    <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    <button class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>
                </div>
            </div>
            <!-- /.box-header -->
            <div class="box-body ">
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">模版名称</label>
                        <div class="col-xs-6">
                            <asp:DropDownList runat="server" ID="ddlTemplate" CssClass="form-control"></asp:DropDownList>
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2"></label>
                        <div class="col-xs-2">
                            <asp:Button runat="server" ID="btnBuilder" CssClass="btn btn-info form-control" Text="生成页面" OnClick="btnBuilder_Click" />
                        </div>
                         <div class="col-xs-2">
                            <asp:Button runat="server" ID="btnTemplate" CssClass="btn btn-info form-control" Text="按自有模版生成" OnClick="btnTemplate_Click" />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2"></label>
                        <div class="col-xs-6">
                            <asp:Label runat="server" ID="lblMsg"></asp:Label>
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">中间页操作</label>
                        <div class="col-xs-2">
                            <asp:Button runat="server" ID="btnMiddlePage" CssClass="btn btn-info form-control" Text="中间页全部生成" OnClick="btnMiddlePage_Click" />
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">更新默认二维码</label>
                        <div class="col-xs-2">
                            <asp:Button runat="server" ID="btnQcode" CssClass="btn btn-info form-control" Text="更新默认二维码" OnClick="btnQcode_Click" />
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">更新页面统计</label>
                        <div class="col-xs-2">
                            <asp:Button runat="server" ID="btnAdPagetCount" CssClass="btn btn-info form-control" Text="更新页面统计" OnClick="btnAdPagetCount_Click" />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2"></label>
                        <div class="col-xs-6">
                            <asp:Label runat="server" ID="ltMiddle"></asp:Label>
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
