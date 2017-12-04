<%@ Page Title="" Language="C#" MasterPageFile="~/AccFlow/Web.Master" AutoEventWireup="true" CodeBehind="UserTaskList.aspx.cs" Inherits="WebApp.AccFlow.Tasks.UserTaskList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    我的任务
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
                content: '/AccFlow/Tasks/UserTaskState.aspx?pagename=' + id //iframe的url
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="miniContent" runat="server">
    <asp:HiddenField runat="server" ID="hidState" />
    <!-- Main content -->
    <section class="content">
        <div class="row">
            <div class="col-xs-12">
                <div class="box">
                    <div class="box-header">
                        <h3 class="box-title">我的任务</h3>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="row hidden">
                            <div class="col-xs-2">
                                <asp:DropDownList runat="server" ID="ddlAdType" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                            <div class="col-xs-1">
                                <asp:Button runat="server" ID="btnSearch" CssClass="btn btn-info form-control" Text="搜索" OnClick="btnSearch_Click" />
                            </div>
                        </div>
                        <table id="example2" class="table table-bordered table-hover">
                            <thead>
                                <tr>
                                    <th>广告ID</th>
                                    <th>广告标题</th>
                                    <th>链接地址</th>
                                    <th>浏览次数（PV）</th>
                                    <th>独立访客（UV）</th>
                                    <th>IP</th>
                                    <th>操作</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater runat="server" ID="rptTable">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%#Eval("AdPageId") %>
                                                <asp:HiddenField runat="server" ID="hidAdId" Value='<%#Eval("AdPageId") %>' />
                                            </td>
                                            <td><%#DN.WeiAd.Business.AdPageInfoBLL.Instance.GetTitleById( Eval("AdPageId")) %></td>
                                            <td>
                                                <a target="_blank" href="<%#DN.WeiAd.Business.AdPageInfoBLL.Instance.GetAdViewUrl( Eval("PageName")) %>"><%#DN.WeiAd.Business.AdPageInfoBLL.Instance.GetAdViewUrl( Eval("PageName")) %></a>
                                            </td>
                                            <td>
                                                <asp:Literal runat="server" ID="ltPvCount" Text="0"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:Literal runat="server" ID="ltUvCount" Text="0"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:Literal runat="server" ID="ltIpCount" Text="0"></asp:Literal>
                                            </td>
                                            <td>
                                                <a class="btn btn-info btn-xs" href="<%#DN.WeiAd.Business.AdPageInfoBLL.Instance.GetAdViewUrl( Eval("PageName")) %>" target="_blank">预览广告</a>
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
