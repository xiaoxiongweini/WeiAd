<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/WebEmp.Master" AutoEventWireup="true" CodeBehind="ImportDomain.aspx.cs" Inherits="WebApp.Admin.Server.ImportDomain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    批量导入域名
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="miniContent" runat="server">
    <!-- Main content -->
    <section class="content">
        <!-- SELECT2 EXAMPLE -->
        <div class="box box-default">
            <!-- /.box-header -->
            <div class="box-body ">
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-2">域名名称</label>
                        <div class="col-xs-10">
                            <input type="text" runat="server" id="txtName" class="form-control" />
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="form-group">
                        <label class=" col-xs-2">域名列表</label>
                        <div class="col-xs-10">
                            <asp:TextBox runat="server" ID="txtDomain" CssClass="form-control" TextMode="MultiLine" Rows="6"></asp:TextBox>
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-2">域名归属地</label>
                        <div class="col-xs-2">
                            <asp:DropDownList runat="server" ID="ddlCity" CssClass="form-control"></asp:DropDownList>
                        </div>    
                        <label class="col-xs-1">备案</label>
                        <div class="col-xs-2">
                            <asp:CheckBox runat="server" ID="chkIsAuth" />
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-2">IP地址</label>
                        <div class="col-xs-10">
                            <input type="text" runat="server" id="txtIp" class="form-control" />
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-2"></label>
                        <div class="col-xs-2">
                            <asp:Button runat="server" ID="btnSave" CssClass="btn btn-info form-control" Text="保存" OnClick="btnSave_Click" />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-2"></label>
                        <div class="col-xs-10">
                            <asp:Label runat="server" ID="lblMsg"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
