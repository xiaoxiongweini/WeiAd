<%@ Page Title="" Language="C#" MasterPageFile="~/Accounts/Web.Master" AutoEventWireup="true" CodeBehind="HourDetails.aspx.cs" Inherits="WebApp.Accounts.Charts.His.HourDetails" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    访问详情
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="/Assets/Scripts/Plugs/My97DatePicker/WdatePicker.js"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="miniContent" runat="server">
    <asp:HiddenField runat="server" ID="hidFlowUserId" />
    <!-- Main content -->
    <section class="content">
        <div class="row">
            <div class="col-xs-12">
                <div class="box">
                    <div class="box-header">
                        <h3 class="box-title">访问详情</h3>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="row">
                            <div class="col-xs-2">
                                <input type="text" runat="server" id="txtTime" class="form-control " onfocus="WdatePicker({maxDate:'%y-%M-{%d-1}'})" />
                            </div>
                            <div class="col-xs-2">
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
                                    <th>工作室</th>
                                    <th>访问地址</th>
                                    <th>访问IP</th>
                                    <th>访问时间</th>
                                    <th>移动端</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater runat="server" ID="rptTable">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <a href="HourDetails.aspx?flowuserid=<%#Eval("FlowUserId") %>" target="_blank">
                                                    <%# DN.WeiAd.Business.AccountInfoBLL.Instance.GetNickNameByUserId( Eval("FlowUserId")) %>
                                                </a>
                                            </td>
                                            <td>
                                                <a href="<%#Eval("AdUrl") %>" target="_blank"><%#Eval("AdUrl") %></a>
                                            </td>
                                            <td><%#Eval("ClientIp") %></td>
                                            <td><%#Eval("CreateDate") %></td>
                                            <td><%#Eval("IsMobile").ToString()=="1"?"是":"否" %></td>
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
