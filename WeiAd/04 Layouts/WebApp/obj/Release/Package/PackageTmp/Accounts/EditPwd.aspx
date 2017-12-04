<%@ Page Title="" Language="C#" MasterPageFile="~/Accounts/Web.Master" AutoEventWireup="true" CodeBehind="EditPwd.aspx.cs" Inherits="WebApp.Accounts.EditPwd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    重置密码
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
        function oncheckpage() {
            var pwd = $("#<%=txtPwd.ClientID%>").val();
            if (pwd == "") {
                alert("【原密码】不能为空。");
                return false;
            }

            var p1 = $("#<%=txtPwd1.ClientID%>").val();
            if (p1 == "") {
                alert("【新密码】不能为空。");
                return false;
            }
            if (pl.length <= 5) {
                alert("【新密码】至少为6位以上。");
                return false;
            }
            var p2 = $("#<%=txtPwd2.ClientID%>").val();
            if (p2 == "") {
                alert("【确认密码】不能为空。");
                return false;
            }
            if (p2.length <= 5) {
                alert("【确认密码】至少为6位以上。");
                return false;
            }
            if (p1 != p2) {
                alert("两次输入的密码不一致，请重新输入。");
                return false;
            }

            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="miniContent" runat="server">
    <asp:HiddenField runat="server" ID="hidJson" />
    <asp:HiddenField runat="server" ID="hidId" />

    <!-- Content Header (Page header) -->
    <section class="content-header">
        <h1>重置密码
            <small>重置密码</small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>首页</a></li>
            <li class="active">重置密码</li>
        </ol>
    </section>

    <!-- Main content -->
    <section class="content">

        <!-- SELECT2 EXAMPLE -->
        <div class="box box-default">
            <div class="box-header with-border">
                <h3 class="box-title">重置密码</h3>
                <div class="box-tools pull-right">
                    <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    <button class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>
                </div>
            </div>
            <!-- /.box-header -->
            <div class="box-body ">
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">原密码</label>
                        <div class="col-xs-6">
                            <input type="password" runat="server" id="txtPwd" class="form-control" />
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">新密码</label>
                        <div class="col-xs-6">
                            <input type="password" runat="server" id="txtPwd1" class="form-control" />
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">确认密码</label>
                        <div class="col-xs-6">
                            <input type="password" runat="server" id="txtPwd2" class="form-control" />
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2"></label>
                        <div class="col-xs-2">
                            <asp:Button runat="server" ID="btnEdit" CssClass="btn btn-info form-control" Text="修改" OnClientClick="return oncheckpage();" OnClick="btnEdit_Click" />
                        </div>
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
