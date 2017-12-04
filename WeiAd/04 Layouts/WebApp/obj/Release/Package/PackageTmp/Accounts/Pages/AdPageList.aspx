<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/Accounts/Web.Master" AutoEventWireup="true" CodeBehind="AdPageList.aspx.cs" Inherits="WebApp.Accounts.Pages.AdPageList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    广告管理
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function onshowpage(id) {
            layer.open({
                type: 2,
                title: '创建广告页面',
                shadeClose: true,
                shade: 0.8,
                area: ['680px', '480px'],
                content: '/Accounts/Pages/UserPageEdit.aspx?adid=' + id //iframe的url
            });
        }
        $(function () {
           
        })
    </script>
    <style type="text/css">
        .hiddenpreview {
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="miniContent" runat="server">
    <asp:HiddenField runat="server" ID="hidOp" Value="" />

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
                                    <th>广告Id</th>
                                    <th>计划时间：开始-结束</th>
                                    <th>广告分类</th>
                                    <th>投放平台</th>
                                    <th>二维码数量</th>
                                    <th>页面数量</th>
                                    <th>状态</th>
                                    <th class="opclass" style="width: 140px;">操作</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater runat="server" ID="rptTable">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%#Eval("Id") %></td>
                                            <td><%#Eval("AdTimeStart") %>--<%#Eval("AdTimeEnd") %></td>
                                            <td><%#DN.WeiAd.Business.AdTypeInfoBLL.Instance.GetNameById( Eval("UserAdTypeId")) %></td>
                                            <td><%#DN.WeiAd.Business.AdSiteInfoBLL.Instance.GetNameById( Eval("SiteTypeId")) %></td>
                                            <td><%#Eval("QcodeCount") %></td>
                                            <td><%#Eval("PageCount") %></td>
                                            <td><%#DN.WeiAd.Business.AdPageInfoBLL.Instance.GetStateNameById( Eval("IsState")) %></td>
                                            <td class="opclass " rowspan="2">
                                                <a class="btn btn-info btn-xs" href="AdPageEdit.aspx?id=<%#Eval("Id") %>">修改</a>
                                                <a class="btn btn-info btn-xs" href="UserPageList.aspx?adid=<%#Eval("Id") %>">查看工作室</a>
                                                <a class="btn btn-info btn-xs" href="UrlList.aspx?adid=<%#Eval("Id") %>">查看地址</a>
                                                <a class="btn btn-info btn-xs hidden" href="ChangAdHtml.aspx?adid=<%#Eval("Id") %>">生成文件</a>
                                                <a class="btn btn-info btn-xs" href="QcodeList.aspx?adid=<%#Eval("Id") %>">二维码</a>
                                                <a class="btn btn-danger btn-xs" onclick="return confirm('确认删除吗？');" href="AdPageList.aspx?adid=<%#Eval("Id") %>&isdel=1">删除</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="8">标题： <a href="/Comm/AdView.aspx?adid=<%#Eval("Id") %>" target="_blank"><%#Eval("Title") %></a> 
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
