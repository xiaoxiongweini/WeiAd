<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Web.Master" AutoEventWireup="true" CodeBehind="UserEdit.aspx.cs" Inherits="WebApp.Admin.Users.UserEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    编辑用户信息
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
            var txtUserName = $("#<%=txtUserName.ClientID%>").val();
            if (txtUserName == "") {
                alert("【登录名称】不能为空。");
                return false;
            }
            var txtPwd = $("#<%=txtPwd.ClientID%>").val();
            if (txtPwd == "") {
                alert("【用户密码】不能为空。");
                return false;
            }

            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="miniContent" runat="server">
    <asp:HiddenField runat="server" ID="hidId" />

    <!-- Content Header (Page header) -->
    <section class="content-header">
        <h1>管理帐户
            <small>编辑用户信息</small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>首页</a></li>
            <li><a href="#">管理帐户</a></li>
            <li class="active">编辑用户信息</li>
        </ol>
    </section>

    <!-- Main content -->
    <section class="content">

        <!-- SELECT2 EXAMPLE -->
        <div class="box box-default">
            <div class="box-header with-border">
                <h3 class="box-title">用户信息</h3>
                <div class="box-tools pull-right">
                    <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    <button class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>
                </div>
            </div>
            <!-- /.box-header -->
            <div class="box-body ">
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">用户类型</label>
                        <div class="col-xs-6">
                            <asp:DropDownList runat="server" ID="ddlUserType" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">登录名称<span class="cred">*</span></label>
                        <div class="col-xs-6">
                            <input type="text" runat="server" id="txtUserName" class="form-control" />
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">用户密码<span class="cred">*</span></label>
                        <div class="col-xs-6">
                            <input type="password" runat="server" id="txtPwd" class="form-control" />
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">手机号码</label>
                        <div class="col-xs-6">
                            <input type="text" runat="server" id="txtPhone" class="form-control" />
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">Email</label>
                        <div class="col-xs-6">
                            <input type="text" runat="server" id="txtEmail" class="form-control" />
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <div class="form-group ">
                    <div class="row">
                        <label class="col-xs-offset-1 col-xs-2">用户锁定</label>
                        <div class="col-xs-2">
                            <asp:CheckBox runat="server" ID="chkIsLock" />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2"></label>
                        <div class="col-xs-2">
                            <asp:Button runat="server" ID="btnSave" Visible="false" CssClass="btn btn-info form-control" Text="保存" OnClick="btnSave_Click" />

                            <asp:Button runat="server" ID="btnEdit" Visible="false" CssClass="btn btn-info form-control" Text="修改" OnClick="btnEdit_Click" />
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
