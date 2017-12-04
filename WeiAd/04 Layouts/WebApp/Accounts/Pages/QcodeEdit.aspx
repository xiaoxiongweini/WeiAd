<%@ Page Title="" Language="C#" MasterPageFile="~/Accounts/Web.Master" AutoEventWireup="true" CodeBehind="QcodeEdit.aspx.cs" Inherits="WebApp.Accounts.Pages.QcodeEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    广告页面编辑
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function onsavepage() {

            var name = $("#<%=txtName.ClientID%>").val();
            if (name == "") {
                alert("【名称】不能为空。");
                return false;
            }
            return true;
        }
    </script>
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
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="miniContent" runat="server">
    <asp:HiddenField runat="server" ID="hidAdId" />
    <asp:HiddenField runat="server" ID="hidId" />

    <div class="hidden" id="divWeiXinHtml">
        <asp:Literal runat="server" ID="ltContent"></asp:Literal>
    </div>
    <!-- Content Header (Page header) -->
    <section class="content-header">
        <h1>编辑广告二维码
            <small>广告二维码</small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>首页</a></li>
            <li><a href="#">广告管理</a></li>
            <li class="active">广告二维码</li>
        </ol>
    </section>

    <!-- Main content -->
    <section class="content">

        <!-- SELECT2 EXAMPLE -->
        <div class="box box-default">
            <div class="box-header with-border">
                <h3 class="box-title">广告二维码</h3>
                <div class="box-tools pull-right">
                    <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    <button class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>
                </div>
            </div>
            <!-- /.box-header -->
            <div class="box-body ">
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">标题</label>
                        <div class="col-xs-6">
                            <input type="text" runat="server" id="txtName" class="form-control" />
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">二维码</label>
                        <div class="col-xs-2">
                            <asp:FileUpload runat="server" ID="flImg" />
                        </div>
                        <div class="col-xs-2">
                            <asp:Button runat="server" ID="btnUpload" CssClass="btn btn-info" Text="上传二维码" OnClick="btnUpload_Click" />
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">(优先级高)替换文字</label>
                        <div class="col-xs-6">
                            <asp:TextBox runat="server" ID="txtQcodeUrl"></asp:TextBox>
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">(优先级低)预览二维码</label>
                        <div class="col-xs-6">
                            <asp:Image runat="server" ID="imgPreview" CssClass="imgprive" />
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">替换文字2</label>
                        <div class="col-xs-6">
                            <asp:TextBox runat="server" ID="txtWeiXinName"></asp:TextBox>
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2"></label>
                        <div class="col-xs-2">
                            <asp:Button runat="server" ID="btnSave" Visible="false" CssClass="btn btn-info form-control" Text="保存" OnClientClick="onsavepage();" OnClick="btnSave_Click" />

                            <asp:Button runat="server" ID="btnEdit" Visible="false" CssClass="btn btn-info form-control" Text="修改" OnClientClick="onsavepage();" OnClick="btnEdit_Click" />
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
