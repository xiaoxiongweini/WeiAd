<%@ Page Title="" Language="C#" MasterPageFile="~/Accounts/Web.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="WebApp.Accounts.Order.ProductList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    产品管理
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
            产品管理&nbsp;
        </div>
        <div class="panel-body">
            <div class="form-horizontal">
                <div class="form-group">
                    <div class="row">
                        <label class="col-sm-1 control-label">顶/热</label>
                        <div class="col-sm-1">
                            <asp:DropDownList runat="server" ID="ddlTop" CssClass="form-control">
                                <asp:ListItem Text="不限" Value=""></asp:ListItem>
                                <asp:ListItem Text="否" Value="0"></asp:ListItem>
                                <asp:ListItem Text="是" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-sm-1">
                            <asp:DropDownList runat="server" ID="ddlHot" CssClass="form-control">
                                <asp:ListItem Text="不限" Value=""></asp:ListItem>
                                <asp:ListItem Text="否" Value="0"></asp:ListItem>
                                <asp:ListItem Text="是" Value="1"></asp:ListItem>
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
                            <a href="ProductEdit.aspx" class="btn btn-info">添加产品</a>
                        </div>
                    </div>
                </div>
            </div>
            <div>
                <table class="table table-striped table-bordered table-hover">
                    <thead>
                        <tr>
                            <th>序号</th>
                            <th>产品名称</th>
                            <th>价格(元)</th>
                            <th>创建时间</th>
                            <th>操作</th>
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
                                        <%#Eval("Name") %>
                                    </td>
                                    <td>
                                        <%#Eval("Price") %>
                                    </td>
                                    <td>
                                        <%#Eval("CreateDate") %>
                                    </td>
                                    <td>
                                        <a href="ProductEdit.aspx?id=<%#Eval("Id")%>" class="btn btn-info btn-xs">编辑</a>
                                        <a href="ProductList.aspx?id=<%#Eval("Id")%>&isdel=1" onclick="confirm('确认删除吗？');" class="btn btn-info btn-xs">删除</a>                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                       广告标题
                                    </td>
                                    <td colspan="4">
                                        <%#Eval("AdId") %> --
                                        <%#DN.WeiAd.Business.AdPageInfoBLL.Instance.GetTitleById( Eval("AdId")) %>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
                <div>
                    <webdiyer:AspNetPager ID="apPager" runat="server" CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，总记录%RecordCount%条" PagingButtonLayoutType="UnorderedList" CurrentPageButtonClass="active" PagingButtonSpacing="0" CssClass="pagination" HorizontalAlign="Center" OnPageChanging="apPager_PageChanging"
                        Width="100%" AlwaysShow="true" ShowCustomInfoSection="Right" PagingButtonsClass="" PagingButtonsStyle="" ShowBoxThreshold="2" CustomInfoSectionWidth="30%" TextAfterPageIndexBox="&lt;/li&gt;" TextBeforePageIndexBox="&lt;li&gt;" NumericButtonCount="5">
                    </webdiyer:AspNetPager>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
