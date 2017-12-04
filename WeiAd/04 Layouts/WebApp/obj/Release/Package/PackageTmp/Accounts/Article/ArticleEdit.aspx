<%@ Page Title="" Language="C#" MasterPageFile="~/Accounts/Web.Master" AutoEventWireup="true" CodeBehind="ArticleEdit.aspx.cs" Inherits="WebApp.Accounts.Article.ArticleEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    新闻页面编辑
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="/Assets/Scripts/Plugs/kindeditor/kindeditor-min.js"></script>
    <script type="text/javascript" src="/Assets/Scripts/Plugs/kindeditor/lang/zh_CN.js"></script>
    <script type="text/javascript">
        var edit = null;
        KindEditor.ready(function (K) {
            editor = K.create('#editor_id', {
                uploadJson: '/Assets/Scripts/Plugs/kindeditor/asp.net/upload_json.ashx',
                //文件管理
                fileManagerJson: '/Assets/Scripts/Plugs/kindeditor/asp.net/file_manager_json.ashx',
                allowFileManager: true
            });
            var html = $("#divWeiXinHtml").html();
            editor.html(html);
        });

        function onsavepage() {
            var html = editor.html();
            var nhtml = html_encode(html);
            $("#<%=hidContent.ClientID%>").val(nhtml);
            onusercode();
        }

        function onusercode() {
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
    <script type="text/javascript">
        $(function () {
        });
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="miniContent" runat="server">
    <asp:HiddenField runat="server" ID="hidJson" />
    <asp:HiddenField runat="server" ID="hidId" />

    <asp:HiddenField runat="server" ID="hidContent" />
    <div class="hidden" id="divWeiXinHtml">
        <asp:Literal runat="server" ID="ltContent"></asp:Literal>
    </div>
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
                        <label class="col-xs-offset-1 col-xs-2">微信地址</label>
                        <div class="col-xs-6">
                            <input type="text" runat="server" id="txtWeiXinUrl" class="form-control" />
                        </div>
                        <div class="col-xs-2">
                            <asp:Button runat="server" ID="btnGather" CssClass="btn btn-info" Text="文章采集" OnClick="btnGather_Click" />
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div> <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">频道</label>
                        <div class="col-xs-6">
                            <asp:DropDownList runat="server" ID="ddlChannel" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">广告标题</label>
                        <div class="col-xs-6">
                            <input type="text" runat="server" id="txtTitle" class="form-control" />
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">图片标题</label>
                        <div class="col-xs-4">
                            <asp:FileUpload runat="server" ID="flTitleImg" />
                        </div>
                        <div class="col-xs-2">
                            <asp:Button runat="server" ID="btnUpload" Text="上传图片" CssClass="btn btn-info" OnClientClick="onsavepage();" OnClick="btnUpload_Click" />
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">图片预览</label>
                        <div class="col-xs-4">
                            <asp:Image runat="server" ID="imgPerview" Height="100px" />
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">文章简述</label>
                        <div class="col-xs-6">
                            <asp:TextBox runat="server" ID="txtTitleShort" CssClass="form-control" TextMode="MultiLine" Rows="3"></asp:TextBox>
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">新闻内容</label>
                        <div class="col-xs-8">
                            <textarea id="editor_id" name="content" style="width: 100%; height: 300px;"></textarea>
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>              
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">页面地址</label>
                        <div class="col-xs-6">
                            <input type="text" runat="server" id="txtPage" class="form-control" />
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">状态</label>
                        <div class="col-xs-6">
                            <asp:RadioButtonList runat="server" ID="rdlstState" RepeatLayout="Flow" RepeatDirection="Horizontal"></asp:RadioButtonList>
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
