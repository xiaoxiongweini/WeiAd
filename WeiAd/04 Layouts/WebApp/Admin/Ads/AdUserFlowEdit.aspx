<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Web.Master" AutoEventWireup="true" CodeBehind="AdUserFlowEdit.aspx.cs" Inherits="WebApp.Admin.Ads.AdUserFlowEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    分配工作室
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="miniContent" runat="server">
    <asp:HiddenField runat="server" ID="hidAdId" />
    <!-- Main content -->
    <section class="content">
        <div class="row">
            <div class="col-xs-12">
                <div class="box">
                    <div class="box-header">
                        <h3 class="box-title">分配工作室</h3>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="row">
                            <div class="col-xs-2">
                                <asp:Button runat="server" ID="btnUpdate" CssClass="btn btn-info form-control" Text="保存选中" OnClick="btnUpdate_Click" />
                            </div>
                        </div>
                        <br />
                        <table id="example2" class="table table-bordered table-hover">
                            <thead>
                                <tr>
                                    <th>选择</th>
                                    <th>用户ID</th>
                                    <th>用户类型</th>
                                    <th>登录名称</th>
                                    <th>用户昵称</th>
                                    <th>手机号码</th>
                                    <th>页面地址</th>
                                    <th>页面存在</th>
                                    <th>预览地址</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater runat="server" ID="rptTable" OnItemCommand="rptTable_ItemCommand">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:CheckBox runat="server" ID="chkSelect" />
                                                <asp:HiddenField runat="server" ID="hidUserId" Value='<%#Eval("Id") %>' />
                                            </td>
                                            <td><%#Eval("Id") %></td>
                                            <td><%#DN.WeiAd.Business.AccountInfoBLL.Instance.GetUserTypeNameById(Eval("UserType")) %></td>
                                            <td><%#Eval("UserName") %></td>
                                            <td><%#Eval("NickName") %></td>
                                            <td><%#Eval("Phone") %></td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtPageName"></asp:TextBox>
                                            </td>
                                            <th><asp:Literal runat="server" ID="ltExtName"></asp:Literal></th>
                                            <td>
                                                <asp:HyperLink runat="server" ID="hyplnkPrview" Text="预览广告"></asp:HyperLink>
                                                <asp:Button runat="server" ID="btnBuilder" Text="重新生成" CssClass="btn btn-info" CommandName="mybuilder" />
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
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
