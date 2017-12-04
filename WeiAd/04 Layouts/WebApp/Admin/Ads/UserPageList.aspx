<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Web.Master" AutoEventWireup="true" CodeBehind="UserPageList.aspx.cs" Inherits="WebApp.Admin.Ads.UserPageList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    广告页面管理
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">

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
                        <div class="row hidden">
                            <div class="col-xs-1">
                                <asp:Button runat="server" ID="btnSearch" CssClass="btn btn-info form-control" Text="搜索" OnClick="btnSearch_Click" />
                            </div>
                        </div>
                        <br />
                        <table id="example2" class="table table-bordered table-hover">
                            <thead>
                                <tr>
                                    <th>Id</th>
                                    <th>工作室名称</th>
                                    <th>广告名称</th>
                                    <th>今日PV</th>
                                    <th>今日UV</th>
                                    <th>今日IP</th>
                                    <th>状态</th>
                                    <th>操作</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater runat="server" ID="rptTable">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%#Eval("Id") %>
                                                <asp:HiddenField runat="server" ID="hidFlowUserId" Value='<%#Eval("FlowUserId") %>' />
                                            </td>
                                            <td><%#GetUserName(Eval("FlowUserId")) %></td>                                            
                                            <td>
                                                <a target="_blank" href="<%#DN.WeiAd.Business.AdPageInfoBLL.Instance.GetAdViewUrl( Eval("PageName")) %>"><%#DN.WeiAd.Business.AdPageInfoBLL.Instance.GetTitleById( Eval("AdPageId")) %></a>
                                            </td>
                                            <td>
                                                <asp:Literal runat="server" ID="ltPv" Text="0"></asp:Literal>
                                            </td>
                                            <td><asp:Literal runat="server" ID="ltUv" Text="0"></asp:Literal>
                                                </td>
                                            <td><asp:Literal runat="server" ID="ltIp" Text="0"></asp:Literal>
                                                </td>
                                            <td><%#DN.WeiAd.Business.AdUserPageBLL.Instance.GetStateNameById( Eval("IsState")) %></td>                                            
                                            <td>
                                                <a class="btn btn-info btn-xs" target="_blank" href="HourAnalaysis.aspx?flowuserid=<%#Eval("FlowUserId") %>&adid=<%#Eval("AdPageId") %>">今日流量</a>
                                                <a class="btn btn-info btn-xs" target="_blank" href="MonthDayAnalysis.aspx?flowuserid=<%#Eval("FlowUserId") %>&adid=<%#Eval("AdPageId") %>">趋势分析</a>
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
