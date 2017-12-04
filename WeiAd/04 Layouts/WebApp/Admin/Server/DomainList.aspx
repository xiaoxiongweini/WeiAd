<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Web.Master" AutoEventWireup="true" CodeBehind="DomainList.aspx.cs" Inherits="WebApp.Admin.Server.DomainList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    域名池管理
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function onshowimportwin() {
            var url = "/Admin/Server/ImportDomain.aspx";
            //iframe层-父子操作
            layer.open({
                type: 2,
                title: '导入域名',
                area: ['700px', '450px'],
                fixed: true, //不固定
                shadeClose: true, //开启遮罩关闭
                maxmin: true,
                content: [url, 'no'],
                cancel: function () {
                    document.location.href = document.location.href;
                }
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="miniContent" runat="server">
    <!-- Main content -->
    <section class="content">
        <div class="row">
            <div class="col-xs-12">
                <div class="box">
                    <div class="box-header">
                        <h3 class="box-title">域名池管理</h3>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="row">
                            <div class="col-xs-2">
                                <asp:DropDownList runat="server" ID="ddlAdType" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                            <div class="col-xs-1">
                                <asp:Button runat="server" ID="btnSearch" CssClass="btn btn-info form-control" Text="搜索" OnClick="btnSearch_Click" />
                            </div>
                            <div class="col-xs-2">
                                <a href="DomainEdit.aspx" class="btn btn-info form-control">添加域名</a>
                            </div>
                            <div class="col-xs-2">
                                <button type="button" onclick="onshowimportwin();" class="btn btn-info form-control">导入域名</button>
                            </div>
                        </div>
                        <br />
                        <table id="example2" class="table table-bordered table-hover">
                            <thead>
                                <tr>
                                    <th>Id</th>
                                    <th>名称</th>
                                    <th>域名地址</th>
                                    <th>归属城市</th>
                                    <th>备案</th>
                                    <th>关闭</th>
                                    <th>解析</th>
                                    <th>解析服务器</th>
                                    <th>解析时间</th>
                                    <th>创建时间</th>
                                    <th>操作</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater runat="server" ID="rptTable">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%#Eval("Id") %></td>
                                            <td><%#Eval("Name") %></td>
                                            <td><%#Eval("Domain") %></td>
                                            <td><%#Eval("CityName") %></td>
                                            <td>
                                                <a class="btn btn-xs btn-warning" href="DomainList.aspx?id=<%#Eval("Id") %>&isauth=<%#Eval("IsAuth") %>">
                                                    <%#Eval("IsAuth").ToString()=="1"?"是":"否" %>
                                                </a>
                                            </td>
                                            <td>
                                                <a class="btn btn-xs btn-warning" href="DomainList.aspx?id=<%#Eval("Id") %>&isstate=<%#Eval("IsState") %>">
                                                    <%#Eval("IsColse").ToString()=="1"?"是":"否" %>
                                                </a>
                                            </td>
                                            <td>
                                                <%#Eval("IsResolution").ToString()=="1"?"是":"否" %>
                                            </td>
                                            <td><%#Eval("SerName") %></td>
                                            <td><%#Eval("ResolutionDate") %></td>
                                            <td><%#Eval("CreateDate") %></td>
                                            <td>
                                                <a class="btn btn-info btn-xs" target="_blank" href="DomainEdit.aspx?id=<%#Eval("Id") %>">修改</a>
                                                <a class="btn btn-danger btn-xs" onclick="return confirm('确认删除吗？');" href="DomainList.aspx?id=<%#Eval("Id") %>">删除</a>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                        <div>
                            <webdiyer:AspNetPager ID="apPager" runat="server" CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，总记录%RecordCount%条" PagingButtonLayoutType="UnorderedList" CurrentPageButtonClass="active" PagingButtonSpacing="0" CssClass="pagination" HorizontalAlign="Center" OnPageChanged="apPager_PageChanged"
                                Width="100%" AlwaysShow="true" ShowCustomInfoSection="Right" PagingButtonsClass="" PagingButtonsStyle="">
                            </webdiyer:AspNetPager>
                        </div>
                    </div>
                    <!-- /.box-body -->
                </div>
                <!-- /.box -->
            </div>
            <!-- /.col -->
        </div>
        <!-- /.row -->
    </section>
    <!-- /.content -->
</asp:Content>
