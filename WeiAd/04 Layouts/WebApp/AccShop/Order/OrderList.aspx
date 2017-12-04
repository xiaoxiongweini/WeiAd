<%@ Page Title="" Language="C#" MasterPageFile="~/AccShop/Web.Master" AutoEventWireup="true" CodeBehind="OrderList.aspx.cs" Inherits="WebApp.AccShop.Order.OrderList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    客户管理
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .pagination input {
            float: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="miniContent" runat="server">
    <asp:HiddenField runat="server" ID="hidTypeId" />
    <div class="panel panel-default">
        <div class="panel-heading">
            客户管理&nbsp;
        </div>
        <div class="panel-body">
            <div class="form-horizontal">
                <div class="form-group ">
                    <div class="row">
                        <div class="col-sm-2">
                            <asp:DropDownList runat="server" ID="ddlAd" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <div class="col-sm-2">
                            <asp:DropDownList runat="server" ID="ddlExport" CssClass="form-control">
                                <asp:ListItem Text="不限导出类型" Value=""></asp:ListItem>
                                <asp:ListItem Text="未导出" Value="0"></asp:ListItem>
                                <asp:ListItem Text="己导出" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <label class="col-sm-1 control-label">关键字</label>
                        <div class="col-sm-2">
                            <asp:TextBox runat="server" ID="txtSerchTitle" ClientIDMode="Static" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-sm-1">
                            <asp:Button runat="server" ID="btnSearch" CssClass="btn btn-info" Text=" 搜 索 " OnClick="btnSearch_Click" />
                        </div>
                        <div class="col-sm-1">
                            <asp:Button runat="server" ID="btnExport" CssClass="btn btn-info" Text=" 导出" OnClick="btnExport_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <div>
                <table class="table table-striped table-bordered table-hover">
                    <thead>
                        <tr>
                            <th>序号</th>
                            <th>用户选项</th>
                            <th>用户姓名</th>
                            <th>手机号码</th>
                            <th>区域信息</th>
                            <th>用户备注</th>
                            <th>IP地址</th>
                            <th>创建时间</th>
                            <th>导出</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater runat="server" ID="rptTables">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <%#Eval("Id") %>
                                    </td>
                                    <td>
                                        <%#Eval("Color")%>
                                        <br />
                                        <%#Eval("Size")%>
                                    </td>
                                    <td>
                                        <%#Eval("RealName")%>
                                    </td>
                                    <td>
                                        <%#Eval("Phone")%>
                                    </td>
                                    <td><%#Eval("UserRegion") %>-<%#Eval("UserCity") %>-<%#Eval("UserCountry") %></td>

                                    <td>
                                        <%#Eval("Remark")%>
                                    </td>
                                    <td>
                                        <%#Eval("ClientIp") %>
                                    </td>
                                    <td>
                                        <%#Eval("CreateDate") %>
                                    </td>
                                    <td>
                                        <%#Eval("IsExport").ToString() =="1"?"己导出":"未导出" %>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
                <div>
                    <webdiyer:AspNetPager ID="apPager" runat="server" CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，总记录%RecordCount%条" PagingButtonLayoutType="UnorderedList" CurrentPageButtonClass="active" PagingButtonSpacing="0" CssClass="pagination" HorizontalAlign="Center"  OnPageChanged="apPager_PageChanged"
                        Width="100%" AlwaysShow="true" ShowCustomInfoSection="Right" PagingButtonsClass="" PagingButtonsStyle="" ShowBoxThreshold="2" CustomInfoSectionWidth="30%" TextAfterPageIndexBox="&lt;/li&gt;" TextBeforePageIndexBox="&lt;li&gt;" NumericButtonCount="5">
                    </webdiyer:AspNetPager>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
