﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Web.Master" AutoEventWireup="true" CodeBehind="SerEdit.aspx.cs" Inherits="WebApp.Admin.Server.SerEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    编辑服务器信息
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .row {
            padding-top: 20px;
        }

            .row label {
                padding-top: 5px;
                text-align: right;
            }

        .imgprive {
            width: 100px;
            height: 100px;
        }
    </style>
    <script type="text/javascript">
        $(function () {
        });
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="miniContent" runat="server">
    <asp:HiddenField runat="server" ID="hidJson" />
    <asp:HiddenField runat="server" ID="hidId" />

    <!-- Content Header (Page header) -->
    <section class="content-header">
        <h1>编辑服务器信息
            <small>服务器信息</small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>首页</a></li>
            <li><a href="#">服务配置</a></li>
            <li class="active">编辑服务器信息</li>
        </ol>
    </section>

    <!-- Main content -->
    <section class="content">

        <!-- SELECT2 EXAMPLE -->
        <div class="box box-default">
            <div class="box-header with-border">
                <h3 class="box-title">服务器信息</h3>
                <div class="box-tools pull-right">
                    <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    <button class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>
                </div>
            </div>
            <!-- /.box-header -->
            <div class="box-body ">
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">随机Key</label>
                        <div class="col-xs-6">
                            <input type="text" runat="server" id="txtServerId" readonly="true" class="form-control" />
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">服务器名称</label>
                        <div class="col-xs-6">
                            <input type="text" runat="server" id="txtName" readonly="true" class="form-control" />
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">描述</label>
                        <div class="col-xs-6">
                            <input type="text" runat="server" id="txtDesc" readonly="true" class="form-control" />
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">IP地址</label>
                        <div class="col-xs-6">
                            <input type="text" runat="server" id="txtIp" readonly="true" class="form-control" />
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">是否有效</label>
                        <div class="col-xs-6">
                            <asp:CheckBox runat="server" ID="chkIsState" />
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2"></label>
                        <div class="col-xs-2">
                            <asp:Button runat="server" ID="btnSave" Visible="false" CssClass="btn btn-info form-control" Text="保存" OnClick="btnSave_Click" />

                            <asp:Button runat="server" ID="btnEdit" Visible="false" CssClass="btn btn-info form-control" Text="修改" OnClick="btnEdit_Click" />
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
