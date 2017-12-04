<%@ Page Title="" Language="C#" MasterPageFile="~/Accounts/Web.Master" AutoEventWireup="true" CodeBehind="BrowseList.aspx.cs" Inherits="WebApp.Accounts.LogBrowse.BrowseList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    URL访问详情
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="/Assets/Scripts/Plugs/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript">
        
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
                        <h3 class="box-title">URL访问详情
                        </h3>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="row">
                            <div class="col-xs-2">
                                <input type="text" runat="server" id="txtTime" class="form-control " onfocus="WdatePicker({maxDate:'%y-%M-{%d}'})" />
                            </div>
                            <div class="col-xs-3">
                                <asp:DropDownList runat="server" ID="ddlAdPage" CssClass="form-control"></asp:DropDownList>
                            </div>
                            <div class="col-xs-1">
                                <asp:Button runat="server" ID="btnSearch" CssClass="btn btn-info form-control" Text="搜索" OnClick="btnSearch_Click" />
                            </div>
                        </div>
                        <br />
                        <table id="example2" class="table table-bordered table-hover">
                            <thead>
                                <tr>
                                    <th>广告ID</th>
                                    <th>访问时间</th>
                                    <th>访问地址</th>
                                    <th>UseAgent</th>
                                    <th>客户端IP</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater runat="server" ID="rptTable">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%#Eval("AdId") %></td>
                                            <td><%#Eval("CreateDate") %></td>
                                            <td><%#Eval("Url") %></td>
                                            <td><%#Eval("BrowseType") %></td>
                                            <td><%#Eval("ClientIp") %></td>
                                        </tr>
                                        <tr>
                                            <td>跳转地址</td>
                                            <td colspan="4">
                                                <%#Eval("ReferrerUrl") %>
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
