<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Web.Master" AutoEventWireup="true" CodeBehind="DomainServerApp.aspx.cs" Inherits="WebApp.Admin.Server.DomainServerApp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    域名同步服务
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
        <h1>域名同步服务
            <small>域名同步</small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>首页</a></li>
            <li><a href="#">服务器配置</a></li>
            <li class="active">域名同步服务</li>
        </ol>
    </section>

    <!-- Main content -->
    <section class="content">

        <!-- SELECT2 EXAMPLE -->
        <div class="box box-default">
            <div class="box-header with-border">
                <h3 class="box-title">域名同步服务</h3>
                <div class="box-tools pull-right">
                    <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    <button class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>
                </div>
            </div>
            <!-- /.box-header -->
            <div class="box-body ">
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">选择服务器</label>
                        <div class="col-xs-6">
                            <asp:DropDownList runat="server" ID="ddlServer" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>   
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">主域名网站地址</label>
                        <div class="col-xs-6">
                            <asp:TextBox runat="server" ID="txtWebPath" CssClass="form-control"></asp:TextBox>
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">主域名</label>
                        <div class="col-xs-6">
                            <asp:TextBox runat="server" ID="txtMainDomain" CssClass="form-control"></asp:TextBox>
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">域名</label>
                        <div class="col-xs-6">
                            <asp:TextBox runat="server" ID="txtDomains" CssClass="form-control" TextMode="MultiLine" Rows="6"></asp:TextBox>
                            <p class="label label-danger">多个域名使用换行方式</p>
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2"></label>
                        <div class="col-xs-2">
                            <asp:Button runat="server" ID="btnAdd" CssClass="btn btn-info form-control" Text="同步到服务器" OnClick="btnAdd_Click" />
                        </div>
                        <div class="col-xs-2">
                            <asp:Button runat="server" ID="btnDel" CssClass="btn btn-warning form-control" Text="从服务器删除" OnClick="btnDel_Click" />
                        </div>   
                        <div class="col-xs-2">
                            <asp:Button runat="server" ID="btnDelDomain" CssClass="btn btn-warning form-control" Text="删除主域名" OnClick="btnDelDomain_Click" />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2"></label>
                        <div class="col-xs-8">
                            <asp:Label runat="server" ID="lblMsg" CssClass="label label-warning"></asp:Label>
                        </div>
                    </div>
                </div>
                <!-- /.row -->
            </div>
            <!-- /.box -->
    </section>
    <!-- /.content -->
</asp:Content>
