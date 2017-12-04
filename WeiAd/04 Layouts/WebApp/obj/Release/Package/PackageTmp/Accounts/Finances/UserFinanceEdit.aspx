<%@ Page Title="" Language="C#" MasterPageFile="~/Accounts/Web.Master" AutoEventWireup="true" CodeBehind="UserFinanceEdit.aspx.cs" Inherits="WebApp.Accounts.Finances.UserFinanceEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    充值记录
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="miniContent" runat="server">
    <!-- Main content -->
    <section class="content">
        <div class="row">
            <div class="col-xs-12">
                <div class="box">
                    <div class="box-header">
                        <h3 class="box-title">帐户信息</h3>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <br />
                        <table id="example2" class="table table-bordered table-hover">
                            <thead>
                                <tr>
                                    <th>Id</th>
                                    <th>当前余额(元)</th>
                                    <th>消费金额(元)</th>
                                    <th>充值总额(元)</th>
                                    <th>更新时间</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater runat="server" ID="rptTable">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%#Eval("Id") %></td>
                                            <td><%#Eval("Money") %></td>
                                            <td><%#Eval("ConsumptionMoney") %></td>
                                            <td><%#Eval("MoneyCount") %></td>
                                            <td><%#Eval("LastMoneyDate") %></td>
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
