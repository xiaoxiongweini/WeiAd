<%@ Page Title="" Language="C#" MasterPageFile="~/Accounts/Web.Master" AutoEventWireup="true" CodeBehind="ProductEdit.aspx.cs" Inherits="WebApp.Accounts.Order.ProductEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    新增产品信息
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
    <asp:HiddenField runat="server" ID="hidId" />

    <!-- Content Header (Page header) -->
    <section class="content-header">
        <h1>编辑产品信息
            <small>产品信息</small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>首页</a></li>
            <li><a href="#">服务配置</a></li>
            <li class="active">编辑产品信息</li>
        </ol>
    </section>

    <!-- Main content -->
    <section class="content">

        <!-- SELECT2 EXAMPLE -->
        <div class="box box-default">
            <div class="box-header with-border">
                <h3 class="box-title">产品信息</h3>
                <div class="box-tools pull-right">
                    <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    <button class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>
                </div>
            </div>
            <!-- /.box-header -->
            <div class="box-body ">
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">广告ID</label>
                        <div class="col-xs-6">
                            <asp:DropDownList runat="server" ID="ddlAd" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">产品名称</label>
                        <div class="col-xs-6">
                            <asp:TextBox runat="server" ID="txtName" CssClass="form-control"></asp:TextBox>
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">产品描述</label>
                        <div class="col-xs-6">
                            <asp:TextBox runat="server" ID="txtDesc" TextMode="MultiLine" Rows="4" CssClass="form-control"></asp:TextBox>
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">产品属性</label>
                        <div class="col-xs-6">
                            <asp:TextBox runat="server" ID="txtAttr" TextMode="MultiLine" Rows="8" CssClass="form-control"></asp:TextBox>
                            
                            <p>示例：
                                <br />
                                产品颜色=红色，绿色，蓝色<br />
                                产品尺寸=29码，30码
                            </p>
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">价格(元)</label>
                        <div class="col-xs-6">
                            <asp:TextBox runat="server" ID="txtPrice" Text="0" CssClass="form-control"></asp:TextBox>
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
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2"></label>
                        <div class="col-xs-2">
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
