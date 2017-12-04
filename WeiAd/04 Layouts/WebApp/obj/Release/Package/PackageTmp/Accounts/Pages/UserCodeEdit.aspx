<%@ Page Title="" Language="C#" MasterPageFile="~/Accounts/Web.Master" AutoEventWireup="true" CodeBehind="UserCodeEdit.aspx.cs" Inherits="WebApp.Accounts.Pages.UserCodeEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    广告页面编辑
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
        function onsavepage() {
            var html = $("#<%=txtUserCode.ClientID%>").val();
            var nhtml = html_encode(html);
            $("#<%=hidContent.ClientID%>").val(nhtml);
            $("#<%=txtUserCode.ClientID%>").val("");
        }
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="miniContent" runat="server">
    <asp:HiddenField runat="server" ID="hidJson" />
    <asp:HiddenField runat="server" ID="hidId" />

    <!-- Content Header (Page header) -->
    <section class="content-header">
        <h1>编辑广告信息
            <small>广告页面编辑</small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>首页</a></li>
            <li><a href="#">广告</a></li>
            <li class="active">广告页面编辑</li>
        </ol>
    </section>

    <!-- Main content -->
    <section class="content">

        <!-- SELECT2 EXAMPLE -->
        <div class="box box-default">
            <div class="box-header with-border">
                <h3 class="box-title">广告信息</h3>
                <div class="box-tools pull-right">
                    <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    <button class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>
                </div>
            </div>
            <!-- /.box-header -->
            <div class="box-body ">
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">代码类型</label>
                        <div class="col-xs-6">
                            <asp:DropDownList runat="server" ID="ddlType" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">代码名称</label>
                        <asp:HiddenField runat="server" ID="HiddenField1" />
                        <div class="col-xs-6">
                            <asp:TextBox runat="server" ID="txtName" CssClass="form-control"></asp:TextBox>
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">统计代码</label>
                        <asp:HiddenField runat="server" ID="hidContent" />
                        <div class="col-xs-6">
                            <asp:TextBox runat="server" ID="txtUserCode" CssClass="form-control" TextMode="MultiLine" Rows="6"></asp:TextBox>
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
