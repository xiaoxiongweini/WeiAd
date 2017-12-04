<%@ Page Title="" Language="C#" MasterPageFile="~/Accounts/Web.Master" AutoEventWireup="true" CodeBehind="SiteEdit.aspx.cs" Inherits="WebApp.Accounts.Sys.SiteEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    投放平台编辑
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
    <asp:HiddenField runat="server" ID="hidId" />

    <div class="hidden" id="divWeiXinHtml">
        <asp:Literal runat="server" ID="ltContent"></asp:Literal>
    </div>
    <!-- Content Header (Page header) -->
    <section class="content-header">
        <h1>编辑投放平台
            <small>投放平台</small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>首页</a></li>
            <li><a href="#">内容管理</a></li>
            <li class="active">投放平台</li>
        </ol>
    </section>

    <!-- Main content -->
    <section class="content">

        <!-- SELECT2 EXAMPLE -->
        <div class="box box-default">
            <div class="box-header with-border">
                <h3 class="box-title">投放平台</h3>
                <div class="box-tools pull-right">
                    <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    <button class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>
                </div>
            </div>
            <!-- /.box-header -->
            <div class="box-body ">
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">投放平台</label>
                        <div class="col-xs-6">
                            <input type="text" runat="server" id="txtName" class="form-control" />
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                 <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">描述</label>
                        <div class="col-xs-6">
                            <asp:TextBox runat="server" ID="txtDesc" TextMode="MultiLine" Rows="4" CssClass="form-control"></asp:TextBox>
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                 <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">网址</label>
                        <div class="col-xs-6">
                            <asp:TextBox runat="server" ID="txtWebSite" TextMode="MultiLine" Rows="4" CssClass="form-control"></asp:TextBox>
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
