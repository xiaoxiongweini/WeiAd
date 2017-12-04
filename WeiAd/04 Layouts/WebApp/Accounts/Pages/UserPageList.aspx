<%@ Page Title="" Language="C#" MasterPageFile="~/Accounts/Web.Master" AutoEventWireup="true" CodeBehind="UserPageList.aspx.cs" Inherits="WebApp.Accounts.Pages.UserPageList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    广告页面管理
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function onshowpage() {
            var id = "<%=hidAdId.Value%>";
            layer.open({
                type: 2,
                title: '创建广告页面',
                shadeClose: true,
                shade: 0.8,
                area: ['680px', '480px'],
                content: '/Accounts/Pages/UserPageEdit.aspx?adid=' + id, //iframe的url
                end: function () {
                    location.reload();
                }
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="miniContent" runat="server">
    <asp:HiddenField runat="server" ID="hidAdId" />
    <!-- Main content -->
    <section class="content">
        <div class="row">
            <div class="col-xs-12">
                <div class="box">
                    <div class="box-header">
                        <h3 class="box-title">广告页面管理</h3>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="row">
                            <div class="col-xs-4">
                                <asp:DropDownList runat="server" ID="ddlAdInfo" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                            <div class="col-xs-1">
                                <asp:Button runat="server" ID="btnSearch" CssClass="btn btn-info form-control" Text="搜索" OnClick="btnSearch_Click" />
                            </div>
                            <div class="col-xs-2">
                                <input type="button" class="btn btn-info form-control" value="新建页面" onclick="onshowpage();" />
                            </div>
                        </div>
                        <br />
                        <table id="example2" class="table table-bordered table-hover">
                            <thead>
                                <tr>
                                    <th>Id</th>
                                    <th class="hidden">工作室名称</th>
                                    <th>广告名称</th>
                                    <th>页面名称</th>
                                    <th class="hidden">是否开放</th>
                                    <th class="hidden">是否有人认领</th>
                                    <th>创建时间</th>
                                    <th>操作</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater runat="server" ID="rptTable">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%#Eval("Id") %></td>
                                            <td class="hidden"><%#GetUserName(Eval("FlowUserId")) %></td>
                                            <td><%#DN.WeiAd.Business.AdPageInfoBLL.Instance.GetTitleById( Eval("AdPageId")) %></td>
                                            <td>
                                                <a target="_blank" href="<%#DN.WeiAd.Business.AdPageInfoBLL.Instance.GetAdViewUrl( Eval("PageName")) %>">
                                                    <%#Eval("PageName") %></a>
                                            </td>
                                            <td class="hidden"><%#DN.WeiAd.Business.AdUserPageBLL.Instance.GetStateNameById( Eval("IsState")) %></td>
                                            <td class="hidden"><%#Eval("FlowUserId") %></td>
                                            <td><%#Eval("CreateDate") %></td>
                                            <td>
                                                <a class="btn btn-info btn-xs" target="_blank" href="<%#DN.WeiAd.Business.AdPageInfoBLL.Instance.GetAdViewUrl( Eval("PageName")) %>">预览广告</a>
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
