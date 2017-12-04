<%@ Page Title="" Language="C#" MasterPageFile="~/AccFlow/WebEmp.Master" AutoEventWireup="true" CodeBehind="UserTaskState.aspx.cs" Inherits="WebApp.AccFlow.Tasks.UserTaskState" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    改变状态
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="miniContent" runat="server">
    <asp:HiddenField runat="server" ID="hidUserPageName" />
    <!-- Main content -->
    <section class="content">
        <!-- SELECT2 EXAMPLE -->
        <div class="box box-default" style="min-height: 200px;">
            <div class="box-header with-border">
                <h3 class="box-title">处理任务</h3>
                <div class="box-tools pull-right">
                    <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    <button class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>
                </div>
            </div>
            <!-- /.box-header -->
            <div class="box-body ">
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-3">广告专属页面</label>
                        <div class="col-xs-6">
                            <input type="text" runat="server" id="txtPageName" class="form-control disabled" disabled="disabled" />
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">广告预览</label>
                        <div class="col-xs-6">
                            <asp:HyperLink runat="server" ID="lnkPrview" Text="预览页面" CssClass="btn btn-danger" Target="_blank"></asp:HyperLink>
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-3">状态</label>
                        <div class="col-xs-6">
                            <asp:CheckBox runat="server" ID="chkState" />
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2"></label>
                        <div class="col-xs-2">
                            <asp:Button runat="server" ID="btnSave" CssClass="btn btn-info form-control" Text="保存" OnClientClick="onsavepage();" OnClick="btnSave_Click" />
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
