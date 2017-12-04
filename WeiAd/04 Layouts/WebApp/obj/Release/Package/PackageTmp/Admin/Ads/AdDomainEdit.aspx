<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Web.Master" AutoEventWireup="true" CodeBehind="AdDomainEdit.aspx.cs" Inherits="WebApp.Admin.Ads.AdDomainEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    广告域名批量生成
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="miniContent" runat="server">
    <!-- Main content -->
    <section class="content">
        <!-- SELECT2 EXAMPLE -->
        <div class="box box-default">
            <div class="box-header with-border">
                <h3 class="box-title">广告域名批量生成</h3>
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
                        <div class="col-xs-8">
                            <asp:TextBox runat="server" ID="txtAds" CssClass="form-control"></asp:TextBox>
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">域名列表</label>
                        <div class="col-xs-6">
                            <asp:TextBox runat="server" ID="txtDomain" CssClass="form-control" TextMode="MultiLine" Rows="6"></asp:TextBox>
                        </div>
                        <div class="col-xs-2">
                            <asp:TextBox runat="server" ID="txtTwoDomain" CssClass="form-control"></asp:TextBox>
                            <br />
                            二级域名的名称，不指定时自动随机生成
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">广告复制数量</label>
                        <div class="col-xs-2">
                            <asp:TextBox runat="server" ID="txtNum" CssClass="form-control" Text="1"></asp:TextBox>
                        </div>
                        <div class="col-xs-6">
                            复制时，会刷新广告图片的的压缩比
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
