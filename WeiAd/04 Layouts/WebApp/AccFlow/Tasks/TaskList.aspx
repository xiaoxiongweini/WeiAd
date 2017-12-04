<%@ Page Title="" Language="C#" MasterPageFile="~/AccFlow/Web.Master" AutoEventWireup="true" CodeBehind="TaskList.aspx.cs" Inherits="WebApp.AccFlow.Tasks.TaskList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    广告管理
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function onshowpage(id) {
            layer.open({
                type: 2,
                title: '领取任务页面',
                shadeClose: true,
                shade: 0.8,
                area: ['680px', '480px'],
                content: '/AccFlow/Tasks/AddTask.aspx?adid=' + id //iframe的url
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
                        <h3 class="box-title">广告管理</h3>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="row">
                            <div class="col-xs-1">
                                <asp:Button runat="server" ID="btnSearch" CssClass="btn btn-info form-control" Text="刷新" OnClick="btnSearch_Click" />
                            </div>
                        </div>
                        <br />
                        <table id="example2" class="table table-bordered table-hover">
                            <thead>
                                <tr>
                                    <th>广告ID</th>
                                    <th>广告标题</th>
                                    <th>广告单价(元)</th>
                                    <th>创建时间</th>
                                    <th>操作</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater runat="server" ID="rptTable">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%#Eval("Id") %></td>
                                            <td><%#Eval("Title") %></td>
                                            <td><%#decimal.Parse( Eval("Money").ToString()).ToString("0.00") %></td>
                                            <td><%#Eval("CreateDate") %></td>
                                            <td>
                                                <input type="button" class="btn btn-info btn-xs" onclick='onshowpage(<%#Eval("Id") %>);'  value="领取任务"></input>                                                
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
