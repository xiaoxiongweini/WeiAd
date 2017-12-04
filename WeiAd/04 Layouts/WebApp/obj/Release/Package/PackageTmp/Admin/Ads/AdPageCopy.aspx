<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/WebEmp.Master" AutoEventWireup="true" CodeBehind="AdPageCopy.aspx.cs" Inherits="WebApp.Admin.Ads.AdPageCopy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    一键修改模版
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="miniContent" runat="server">
    <asp:HiddenField runat="server" ID="hidAdId" />
    <!-- Main content -->
    <section class="content">
        <!-- SELECT2 EXAMPLE -->
        <div class="box box-default">
            <div class="box-header with-border">
                <h3 class="box-title">修改模版</h3>
                <div class="box-tools pull-right">
                    <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    <button class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>
                </div>
            </div>
            <!-- /.box-header -->
            <div class="box-body ">
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">广告名称</label>
                        <div class="col-xs-8">
                            <asp:Literal runat="server" ID="ltTitle"></asp:Literal>
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">页面地址</label>
                        <div class="col-xs-8">
                            <asp:Literal runat="server" ID="ltAdUrl"></asp:Literal>
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">复制数量</label>
                        <div class="col-xs-8">
                            <asp:TextBox runat="server" ID="txtNum" Text="1"></asp:TextBox>
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">模版名称</label>
                        <div class="col-xs-6">
                            <asp:DropDownList runat="server" ID="ddlTemplate" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2"></label>
                        <div class="col-xs-2">
                            <asp:Button runat="server" ID="btnSave" CssClass="btn btn-info form-control" Text="保存" OnClick="btnSave_Click" />
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
                <!-- /.row -->
            </div>
        </div>
        <!-- /.box -->
    </section>
    <!-- /.content -->
</asp:Content>
