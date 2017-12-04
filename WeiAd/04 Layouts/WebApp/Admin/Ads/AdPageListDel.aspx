<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Web.Master" AutoEventWireup="true" CodeBehind="AdPageListDel.aspx.cs" Inherits="WebApp.Admin.Ads.AdPageListDel" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    广告管理
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function onshowpage(id)
        {
            layer.open({
                type: 2,
                title: '创建广告页面',
                shadeClose: true,
                shade: 0.8,
                area: ['680px', '480px'],
                content: '/Accounts/Pages/UserPageEdit.aspx?adid='+id //iframe的url
            });
        }
        function onshowcopy(id) {
            layer.open({
                type: 2,
                title: '复制广告',
                shadeClose: true,
                shade: 0.8,
                area: ['680px', '480px'],
                content: '/Admin/Ads/AdPageCopy.aspx?adid=' + id //iframe的url
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
                            <div class="col-xs-2">
                                <asp:DropDownList runat="server" ID="ddlAdUser" CssClass="form-control"></asp:DropDownList>
                            </div>
                             <div class="col-xs-2">
                                <asp:DropDownList runat="server" ID="ddlUserAdType" CssClass="form-control"></asp:DropDownList>
                            </div>
                            <div class="col-xs-2">
                                <asp:DropDownList runat="server" ID="ddlSiteType" CssClass="form-control"></asp:DropDownList>
                            </div>
                            <div class="col-xs-2">
                                <input type="text" runat="server" id="txtDesc" class="form-control" placeholder="请输入备注..." />
                            </div>
                            <div class="col-xs-1">
                                <asp:Button runat="server" ID="btnSearch" CssClass="btn btn-info form-control" Text="搜索" OnClick="btnSearch_Click" />
                            </div>
                            <div class="col-xs-2">
                                <a class="btn btn-info" href="AdPageEdit.aspx">添加广告</a>
                            </div>
                        </div>
                        <br />
                        <table id="example2" class="table table-bordered table-hover">
                            <thead>
                                <tr>
                                    <th>Id</th>
                                    <th>用户名</th>
                                    <th>广告状态</th>
                                    <th>广告分类</th>
                                    <th>用户投放平台</th>
                                    <th>终端平台</th>
                                    <th>二维码</th>
                                    <th>页面</th>
                                    <th>单价(元)</th>
                                    <th>充值(元)</th>
                                    <th>消费(元)</th>
                                    <th>计划IP</th>
                                    <th>操作</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater runat="server" ID="rptTable">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%#Eval("Id") %></td>
                                            <td><%#DN.WeiAd.Business.AccountInfoBLL.Instance.GetUserNameByUserId(Eval("UserId")) %></td>
                                            <td><%#DN.WeiAd.Business.AdPageInfoBLL.Instance.GetStateNameById( Eval("IsState")) %></td>
                                            <td><%#DN.WeiAd.Business.AdTypeInfoBLL.Instance.GetNameById( Eval("UserAdTypeId")) %></td>
                                            <td><%#DN.WeiAd.Business.AdSiteInfoBLL.Instance.GetNameById( Eval("SiteTypeId")) %></td>
                                            <td><%#Eval("PlatformType") %></td>
                                            <td><%#Eval("QcodeCount") %></td>
                                            <td><%#Eval("PageCount") %></td>
                                            <td><%#DN.Framework.Utility.DbConvert.GetDecimal(Eval("Money")).ToString("0.00") %></td>
                                            <td><%#DN.Framework.Utility.DbConvert.GetDecimal(Eval("MoneyCount")).ToString("0.00") %></td>
                                            <td><%#DN.Framework.Utility.DbConvert.GetDecimal(Eval("BuyMoney")).ToString("0.00") %></td>
                                            <td><%#Eval("PlanIp") %></td>
                                            <td rowspan="2">
                                                <a class="btn btn-info btn-xs" href="AdPageListDel.aspx?id=<%#Eval("Id") %>&isdel=0">还源</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="12">标题：<a target="_blank" href="<%#DN.WeiAd.Business.AdPageInfoBLL.Instance.GetAdViewUrl( Eval("ViewPage")) %>">
                                                <%#Eval("Title") %></a>
                                                <br />
                                                预览页：<a target="_blank" href="<%#DN.WeiAd.Business.AdPageInfoBLL.Instance.GetAdViewUrl( Eval("ViewPage")) %>">
                                                    <%#DN.WeiAd.Business.AdPageInfoBLL.Instance.GetAdViewUrl( Eval("ViewPage")) %></a>
                                                <br />
                                                投放页： <a target="_blank" href="<%#DN.WeiAd.Business.AdPageInfoBLL.Instance.GetMiddlePage(Eval("MiddlePage")) %>">
                                                    <%#DN.WeiAd.Business.AdPageInfoBLL.Instance.GetMiddlePage(Eval("MiddlePage"))  %></a>
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
