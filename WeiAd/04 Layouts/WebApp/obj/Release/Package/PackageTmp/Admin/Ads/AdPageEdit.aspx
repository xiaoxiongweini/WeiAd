<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/Admin/Web.Master" AutoEventWireup="true" CodeBehind="AdPageEdit.aspx.cs" Inherits="WebApp.Admin.Ads.AdPageEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    广告页面编辑
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

        .imgprivesmall {
            width: 50px;
            height: 50px;
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
                        <label class="col-xs-offset-1 col-xs-2">微信地址</label>
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
                        <label class="col-xs-offset-1 col-xs-2">文案文件</label>
                        <div class="col-xs-4">
                            <asp:FileUpload runat="server" ID="flFile" />
                        </div>
                        <div class="col-xs-2">
                            <asp:HyperLink runat="server" ID="hyplnkFile"></asp:HyperLink>
                        </div>
                        <div class="col-xs-2">
                            <asp:Button runat="server" ID="btnUploadFile" CssClass="btn btn-info" Text="上传文案" OnClientClick="onsavepage();" OnClick="btnUploadFile_Click" />
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">注意：</label>
                        <div class="col-xs-8">
                            <p class="help-block">方案压缩文件必须页面名称为index.html，压缩方式为在index.html文件目录右键压缩</p>
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">广告主</label>
                        <div class="col-xs-6">
                            <asp:DropDownList runat="server" ID="ddlAdUserName" CssClass="form-control"></asp:DropDownList>
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
                        <label class="col-xs-offset-1 col-xs-2">广告内容</label>
                        <div class="col-xs-8">
                            <textarea id="editor_id" name="content" style="width: 100%; height: 300px;"></textarea>
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">统计代码</label>
                        <div class="col-xs-6">
                            <asp:TextBox runat="server" ID="txtUserCode" CssClass="form-control" TextMode="MultiLine" Rows="5"></asp:TextBox>
                            <asp:HiddenField runat="server" ID="hidUserCode" />
                        </div>
                        <div class="col-xs-3">
                            <asp:Button runat="server" ID="btnDownloadImg" CssClass="btn btn-info" Text="本地图片服务器" OnClientClick="onsavepage();" OnClick="btnDownloadImg_Click" />
                            <br />
                            <asp:Button runat="server" ID="btnImportAliyun" CssClass="btn btn-info" Text="远程图片服务器" OnClientClick="onsavepage();" OnClick="btnImportAliyun_Click" />
                            <br />
                            <asp:Button runat="server" ID="btnBindImg" CssClass="btn btn-info" Text="加载HTML图片" OnClientClick="onsavepage();" OnClick="btnBindImg_Click" />
                            <asp:TextBox runat="server" ID="txtImgLevel" Text="20" CssClass="form-control"></asp:TextBox>
                            <br />
                            <asp:Button runat="server" ID="btnZip" Text="图片压缩" CssClass="btn  btn-info" OnClientClick="onsavepage();" OnClick="btnZip_Click" />
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">静态内容</label>
                        <div class="col-xs-6">
                            <asp:TextBox runat="server" ID="txtStaticContent" TextMode="MultiLine" Rows="5" CssClass="form-control"></asp:TextBox>
                            <asp:HiddenField runat="server" ID="hidStaticContent" />
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">内容图片</label>
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
                                                    <img src="<%# ((string)Container.DataItem)%>" class="imgprivesmall" />
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
                        <label class="col-xs-offset-1 col-xs-2">二维码</label>
                        <div class="col-xs-8">
                            <asp:TextBox runat="server" ID="txtQcodeImg" CssClass="form-control" TextMode="MultiLine" Rows="3"></asp:TextBox>
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">默认二维码</label>
                        <div class="col-xs-8">
                            <asp:TextBox runat="server" ID="txtDefaultQcode" CssClass="form-control" TextMode="MultiLine" Rows="2"></asp:TextBox>
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">二维码2</label>
                        <div class="col-xs-8">
                            <asp:TextBox runat="server" ID="txtQcodeImg2" CssClass="form-control" TextMode="MultiLine" Rows="3"></asp:TextBox>
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">默认二维码2</label>
                        <div class="col-xs-8">
                            <asp:TextBox runat="server" ID="txtDefaultQcode2" CssClass="form-control" TextMode="MultiLine" Rows="2"></asp:TextBox>
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                  <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">域名列表</label>
                        <div class="col-xs-8">
                            <asp:TextBox runat="server" ID="txtDomainList" CssClass="form-control" TextMode="MultiLine" Rows="4"></asp:TextBox>
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">广告单价(元)</label>
                        <div class="col-xs-2">
                            <input type="text" runat="server" id="txtMoney" value="0.4" class="form-control" />
                        </div>
                        <label class=" col-xs-2">充值金额(元)</label>
                        <div class="col-xs-2">
                            <input type="text" runat="server" id="txtMoneyCount" value="0" class="form-control" />
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">计划IP</label>
                        <div class="col-xs-2">
                            <input type="text" runat="server" id="txtPlanIp" class="form-control" />
                        </div>
                        <label class=" col-xs-2">实际IP</label>
                        <div class="col-xs-2">
                            <input type="text" runat="server" id="txtBuyIp" class="form-control" />
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">广告页面</label>
                        <div class="col-xs-6">
                            <input type="text" runat="server" id="txtPage" class="form-control" />
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-offset-1 col-xs-2">模版名称</label>
                        <div class="col-xs-6">
                            <asp:DropDownList runat="server" ID="ddlTemplate" CssClass="form-control"></asp:DropDownList>
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
