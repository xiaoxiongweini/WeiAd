<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/Accounts/Web.Master" AutoEventWireup="true" CodeBehind="AdPageEdit.aspx.cs" Inherits="WebApp.Accounts.Pages.AdPageEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    广告页面编辑
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="/Assets/Scripts/Plugs/My97DatePicker/WdatePicker.js"></script>
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
            var html = $("#<%=hidContent.ClientID%>").val();
            html = html_decode(html);

            editor.html(html);

            var usercode = $("#<%=hidUserCode.ClientID%>").val();
            $("#<%=txtUserCode.ClientID%>").val(html_decode(usercode));

            var scontent = $("#<%=hidStaticContent.ClientID%>").val();
            $("#<%=txtStaticContent.ClientID%>").val(html_decode(scontent));
        });

        function onsavepage() {
            var html = editor.html();
            var nhtml = html_encode(html);
            $("#<%=hidContent.ClientID%>").val(nhtml);
            onusercode();
        }

        function onusercode() {
            var html = $("#<%=txtUserCode.ClientID%>").val();
            var nhtml = html_encode(html);
            $("#<%=hidUserCode.ClientID%>").val(nhtml);
            $("#<%=txtUserCode.ClientID%>").val("");

            var scontent = $("#<%=txtStaticContent.ClientID%>").val();
            var nscontent = html_encode(scontent);
            $("#<%=hidStaticContent.ClientID%>").val(nscontent);
            $("#<%=txtStaticContent.ClientID%>").val("");
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
    <asp:HiddenField runat="server" ID="hidJson" />
    <asp:HiddenField runat="server" ID="hidId" />

    <asp:HiddenField runat="server" ID="hidContent" />
 
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
                        <label class=" col-xs-2">微信地址</label>
                        <div class="col-xs-6">
                            <input type="text" runat="server" id="txtWeiXinUrl" class="form-control" />
                        </div>
                        <div class="col-xs-2">
                            <asp:Button runat="server" ID="btnGather" CssClass="btn btn-info" Text="文章采集" OnClientClick="onsavepage();" OnClick="btnGather_Click" />
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class=" col-xs-2">产品分类</label>
                        <div class="col-xs-2">
                            <asp:DropDownList runat="server" ID="ddlUserAdTypeId" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <label class="col-xs-1">投放平台</label>
                        <div class="col-xs-2">
                            <asp:DropDownList runat="server" ID="ddlSiteType" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <label class="col-xs-1">平台分类</label>
                        <div class="col-xs-2">
                            <asp:DropDownList runat="server" ID="ddlPlatformType" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class=" col-xs-2">计划时间</label>
                        <div class="col-xs-2">
                            <input type="text" runat="server" id="txtAdTimeStart"  class="form-control" onfocus="WdatePicker({maxDate:'%y-%M-{%d}'})" placeholder="开始时间"/>
                        </div>
                        <div class="col-xs-2">
                            <input type="text" runat="server" id="txtAdTimeEnd"  class="form-control" onfocus="WdatePicker({maxDate:'%y-%M-{%d}'})" placeholder="结束时间"/>
                        </div>
                        <div class="col-xs-4">
                            <div class="help-block">该时间只做呈现使用，不做程序上的处理</div>
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class=" col-xs-2">备注</label>
                        <div class="col-xs-6">
                            <asp:TextBox runat="server" ID="txtDesc" CssClass="form-control" TextMode="MultiLine" Rows="2"></asp:TextBox>
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class=" col-xs-2">广告标题</label>
                        <div class="col-xs-6">
                            <asp:TextBox runat="server" ID="txtTitle" CssClass="form-control" TextMode="MultiLine" Rows="2"></asp:TextBox>
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>

                <div class="row">
                    <div class="form-group">
                        <label class=" col-xs-2">图片标题</label>
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
                        <label class=" col-xs-2">图片预览</label>
                        <div class="col-xs-4">
                            <asp:Image runat="server" ID="imgPerview" Height="100px" />
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class=" col-xs-2">文章简述</label>
                        <div class="col-xs-6">
                            <asp:TextBox runat="server" ID="txtTitleShort" CssClass="form-control" TextMode="MultiLine" Rows="3"></asp:TextBox>
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class=" col-xs-2">广告内容</label>
                        <div class="col-xs-8">
                            <textarea id="editor_id" name="content" style="width: 100%; height: 300px;"></textarea>
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class=" col-xs-2">内容图片</label>
                        <div class="col-xs-8">
                            <table id="example2" class="table table-bordered table-hover">
                                <thead>
                                    <tr>
                                        <th>图片</th>
                                        <th>图片地址</th>
                                        <th>操作</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater runat="server" ID="rptImg">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <img src="<%# ((string)Container.DataItem)%>" class="imgprive" />
                                                </td>
                                                <td><%# ((string)Container.DataItem)%></td>
                                                <td><a href="<%# ((string)Container.DataItem)%>" target="_blank">预览图片</a></td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class=" col-xs-2">动态内容</label>
                        <div class="col-xs-6">
                            <asp:TextBox runat="server" ID="txtUserCode" TextMode="MultiLine" Rows="5" CssClass="form-control"></asp:TextBox>
                            <asp:HiddenField runat="server" ID="hidUserCode" />
                        </div>
                        <div class="col-xs-3">
                            <asp:Button runat="server" ID="btnBindImg" Text="查看所有图片" CssClass="btn  btn-info" OnClientClick="onsavepage();" OnClick="btnBindImg_Click" />                            
                            <asp:Button runat="server" ID="btnRefImg" Text="刷新图片" CssClass="btn  btn-info" OnClientClick="onsavepage();" OnClick="btnRefImg_Click" />
                            <asp:TextBox runat="server" ID="txtImgLevel" Text="20" CssClass="form-control"></asp:TextBox>
                            <asp:Button runat="server" ID="btnZip" Text="图片压缩" CssClass="btn  btn-info" OnClientClick="onsavepage();" OnClick="btnZip_Click" />
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class=" col-xs-2">统计代码</label>
                        <div class="col-xs-6">
                            <asp:TextBox runat="server" ID="txtStaticContent" TextMode="MultiLine" Rows="5" CssClass="form-control"></asp:TextBox>
                            <asp:HiddenField runat="server" ID="hidStaticContent" />
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class=" col-xs-2">页面名称</label>
                        <div class="col-xs-6">
                            <input type="text" runat="server" id="txtPage" class="form-control" />
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class=" col-xs-2">模版名称</label>
                        <div class="col-xs-6">
                            <asp:DropDownList runat="server" ID="ddlTemplate" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class=" col-xs-2">二维码地址</label>
                        <div class="col-xs-6">
                            <asp:TextBox runat="server" ID="txtQcode" CssClass="form-control" TextMode="MultiLine" Rows="2"></asp:TextBox>
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class=" col-xs-2">默认二维码</label>
                        <div class="col-xs-6">
                            <asp:TextBox runat="server" ID="txtDefaultQcode" CssClass="form-control" TextMode="MultiLine" Rows="2"></asp:TextBox>
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class=" col-xs-2">如何找二维码</label>
                        <div class="col-xs-6">
                            二维码图片上点击鼠标“右键”,“复制图片地址”或“复制”，去掉前面的域名即可。
                        </div>
                    </div>
                </div>
                 <div class="row">
                    <div class="form-group">
                        <label class=" col-xs-2">二维码地址2</label>
                        <div class="col-xs-6">
                            <asp:TextBox runat="server" ID="txtWeiXinName" CssClass="form-control" TextMode="MultiLine" Rows="2"></asp:TextBox>
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class=" col-xs-2">默认二维码2</label>
                        <div class="col-xs-6">
                            <asp:TextBox runat="server" ID="txtDefaultWeiXinName" CssClass="form-control" TextMode="MultiLine" Rows="2"></asp:TextBox>
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class=" col-xs-2">相关域名</label>
                        <div class="col-xs-6">
                            <asp:TextBox runat="server" ID="txtDomainList"  CssClass="form-control" TextMode="MultiLine" Rows="4"></asp:TextBox>
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class=" col-xs-2"></label>
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
