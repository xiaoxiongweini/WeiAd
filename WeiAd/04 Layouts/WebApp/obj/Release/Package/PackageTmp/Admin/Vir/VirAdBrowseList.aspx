<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Web.Master" AutoEventWireup="true" CodeBehind="VirAdBrowseList.aspx.cs" Inherits="WebApp.Admin.Vir.VirAdBrowseList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    虚拟数据管理
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
      
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="miniContent" runat="server">
    <!-- Main content -->
    <section class="content">
        <div class="row">
            <div class="col-xs-12">
                <div class="box">
                    <div class="box-header">
                        <h3 class="box-title">虚拟数据管理</h3>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="row">
                            <div class="col-xs-2">
                                <asp:DropDownList runat="server" ID="ddlAd" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                            <div class="col-xs-1">
                                <asp:Button runat="server" ID="btnSearch" CssClass="btn btn-info form-control" Text="搜索" OnClick="btnSearch_Click" />
                            </div>
                            <div class="col-xs-2">
                                <a class="btn btn-info form-control" href="VirAdBrowseEdit.aspx">新增</a>
                            </div>
                        </div>
                        <br />
                        <table id="example2" class="table table-bordered table-hover">
                            <thead>
                                <tr>
                                    <th>广告ID</th>
                                    <th>广告标题</th>
                                    <th>IpCount</th>
                                    <th>PvCount</th>
                                    <th>UvCount</th>
                                    <th>创建时间</th>
                                    <th>操作</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater runat="server" ID="rptTable">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%#Eval("AdId") %></td>
                                            <td><%#DN.WeiAd.Business.AdPageInfoBLL.Instance.GetTitleById(Eval("AdId")) %></td>
                                            <td><%#Eval("IpCount") %></td>
                                            <td><%#Eval("PvCount") %></td>
                                            <td><%#Eval("UvCount") %></td>
                                            <td><%#Eval("CreateDate") %></td>
                                            <td>
                                                <a class="btn btn-danger btn-xs" onclick="return confirm('确认删除吗？');" href="VirAdBrowseList.aspx?id=<%#Eval("Id") %>&isdel=1">删除</a>
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
