<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Web.Master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="WebApp.Admin.Users.UserList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    帐户管理
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function onchongzhi(userid) {
            var url = "/Admin/Users/UserFinanceAdd.aspx?uid=" + userid;
            layer.open({
                type: 2,
                title: '用户充值',
                shadeClose: true,
                shade: 0.8,
                area: ['480px', '300px'],
                content: url //iframe的url
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
                        <h3 class="box-title">帐户管理</h3>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="row">
                            <div class="col-xs-2">
                                <asp:DropDownList runat="server" ID="ddlUserType" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                            <div class="col-xs-1">
                                <asp:Button runat="server" ID="btnSearch" CssClass="btn btn-info form-control" Text="搜索" OnClick="btnSearch_Click" />
                            </div>
                            <div class="col-xs-2">
                                <a class="btn btn-info form-control" href="UserEdit.aspx">新增</a>
                            </div>
                        </div>
                        <br />
                        <table id="example2" class="table table-bordered table-hover">
                            <thead>
                                <tr>
                                    <th>用户ID</th>
                                    <th>用户类型</th>
                                    <th>登录名称</th>
                                    <th>用户昵称</th>
                                    <th>手机号码</th>
                                    <th>创建时间</th>
                                    <th>操作</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater runat="server" ID="rptTable">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%#Eval("Id") %></td>
                                            <td><%#DN.WeiAd.Business.AccountInfoBLL.Instance.GetUserTypeNameById(Eval("UserType")) %></td>
                                            <td><%#Eval("UserName") %></td>
                                            <td><%#Eval("NickName") %></td>
                                            <td><%#Eval("Phone") %></td>
                                            <td><%#Eval("RegDate") %></td>
                                            <td>
                                                <button type="button" class="btn btn-info btn-xs hidden" onclick="onchongzhi('<%#Eval("Id") %>');">充值</button>
                                                <a class="btn btn-info btn-xs"  href="UserEdit.aspx?userid=<%#Eval("Id") %>">修改</a>
                                                <a class="btn btn-danger btn-xs" onclick="return confirm('确认删除吗？');" href="AdList.aspx?id=<%#Eval("Id") %>">删除</a>
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
