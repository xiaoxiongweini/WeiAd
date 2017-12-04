<%@ Page Title="" Language="C#" MasterPageFile="~/AccVir/Web.Master" AutoEventWireup="true" CodeBehind="AdList.aspx.cs" Inherits="WebApp.AccVir.AdList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    广告链接管理
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="miniContent" runat="server">
    <!-- Main content -->
    <div class="content animate-panel">
        <div class="row">
            <div class="col-lg-12">
                <div class="hpanel">
                    <div class="panel-heading">
                        <div class="panel-tools">
                            <a class="showhide"><i class="fa fa-chevron-up"></i></a>
                            <a class="closebox"><i class="fa fa-times"></i></a>
                        </div>
                        <div>广告链接列表</div>
                    </div>
                    <div class="panel-body">
                        <table id="example2" class="table table-bordered table-hover">
                            <thead>
                                <tr>
                                    <th>广告Id</th>
                                    <th>广告名称</th>
                                    <th>广告地址</th>
                                    <th>状态</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater runat="server" ID="rptTable">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%#Eval("Id") %></td>
                                            <td><%#Eval("Title") %></td>
                                            <td><%#Eval("DomainList") %></td>
                                            <td><%#DN.WeiAd.Business.AdPageInfoBLL.Instance.GetStateNameById( Eval("IsState")) %></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                        <div>
                            <webdiyer:AspNetPager ID="apPager" runat="server" CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，总记录%RecordCount%条" PagingButtonLayoutType="UnorderedList" CurrentPageButtonClass="active" PagingButtonSpacing="0" CssClass="pagination" HorizontalAlign="Center" UrlPaging="true"
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
    </div>
</asp:Content>
