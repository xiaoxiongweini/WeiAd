<%@ Page Title="" Language="C#" MasterPageFile="~/Accounts/Web.Master" AutoEventWireup="true" CodeBehind="OrderList.aspx.cs" Inherits="WebApp.Accounts.Order.OrderList" %>

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
    <script type="text/javascript">
        $(function () {
            var url = "<%=hidUrl.Value%>";
            if(url != "")
            {
                window.open(url, "", "", false);
                $("#<%=hidUrl.ClientID%>").val("");
            }
        })
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="miniContent" runat="server">
    <asp:HiddenField runat="server" ID="hidTypeId" />
    <asp:HiddenField runat="server" ID="hidUrl" />
    <div class="panel panel-default">
        <div class="panel-heading">
            客户管理&nbsp;
        </div>
        <div class="panel-body">
            <div class="form-horizontal">
                <div class="form-group">
                    <div class="row">
                        <label class="col-sm-1 control-label">关键字</label>
                        <div class="col-sm-2">
                            <asp:TextBox runat="server" ID="txtSerchTitle" ClientIDMode="Static" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-sm-1">
                            <asp:Button runat="server" ID="btnSearch" CssClass="btn btn-info" Text=" 搜 索 " OnClick="btnSearch_Click" />
                        </div>
                        <div class="col-sm-1">
                            <asp:Button runat="server" ID="btnExport" CssClass="btn btn-info" Text="导出" OnClick="btnExport_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <div>
                <table class="table table-striped table-bordered table-hover">
                    <thead>
                        <tr>
                            <th>序号</th>
                            <th>用户信息</th>
                            <th>用户选项</th>
                            <th>区域信息</th>
                            <th>用户备注</th>
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
                                        <%#Eval("RealName") %>
                                        <br />
                                        <%#Eval("Phone")%>
                                    </td>
                                    <td>
                                        <%#Eval("Color")%>
                                        <br />
                                        <%#Eval("Size")%>
                                    </td>
                                    <td><%#Eval("UserRegion") %>-<%#Eval("UserCity") %>-<%#Eval("UserCountry") %>
                                        <br />
                                        <%#Eval("Address") %>
                                    </td>
                                    <td>
                                        <%#Eval("Remark") %>
                                    </td>
                                    <td>
                                        <%#Eval("CreateDate") %>
                                    </td>
                                    <td>
                                        <a href="OrderList.aspx?id=<%#Eval("Id")%>&isdel=1" onclick="confirm('确认删除吗？');" class="btn btn-info btn-xs">删除</a>

                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <%#DN.WeiAd.Business.AccountInfoBLL.Instance.GetNickNameByUserId( Eval("AdUserId")) %>-<%#DN.WeiAd.Business.AdSiteInfoBLL.Instance.GetNameByAdId(Eval("AdId")) %>
                                    </td>
                                    <td colspan="6">
                                       【<%#Eval("AdId") %>】- <%#Eval("AdUrl") %>
                                        <br />
                                        <%#Eval("ClientIp") %>
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
