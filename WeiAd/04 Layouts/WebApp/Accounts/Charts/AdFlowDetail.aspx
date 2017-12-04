﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Accounts/Web.Master" AutoEventWireup="true" CodeBehind="AdFlowDetail.aspx.cs" Inherits="WebApp.Accounts.Charts.AdFlowDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    工作室分析
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
                        <h3 class="box-title">工作室分析 (<asp:Literal runat="server" ID="ltStime" Text=""></asp:Literal>至<asp:Literal runat="server" ID="ltEtime" Text=""></asp:Literal>) </h3>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="row">
                            <div class="col-xs-2">
                                <asp:DropDownList runat="server" ID="ddlAdPage" CssClass="form-control"></asp:DropDownList>
                            </div>
                            <div class="col-xs-1">
                                <asp:Button runat="server" ID="btnSearch" CssClass="btn btn-info form-control" Text="搜索" OnClick="btnSearch_Click" />
                            </div>
                        </div>
                        <br />
                        <div class="panel panel-default">
                            <div class="panel-heading">工作室分析</div>
                            <div class="panel-body">
                                <table class="table table-bordered table-hover">
                                    <thead>
                                        <tr>
                                            <th>工作室名称</th>
                                            <th>浏览次数(PV)</th>
                                            <th>独立访客(UV)</th>
                                            <th>IP</th>
                                            <th>人均浏览页数</th>
                                            <th>输出PV</th>
                                            <th>页面平均停留时长</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater runat="server" ID="rptTable">
                                            <ItemTemplate>
                                                <tr>
                                                    <td>
                                                        <a target="_blank" href="AdSignFlowDetail.aspx?adid=<%=ddlAdPage.SelectedValue %>&flowuserid=<%#Eval("FlowUserId") %>">
                                                            <%#DN.WeiAd.Business.AccountInfoBLL.Instance.GetNickNameByUserId(Eval("FlowUserId")) %>
                                                        </a>
                                                    </td>
                                                    <td><%#Eval("pvcount") %></td>
                                                    <td><%#Eval("uvcount") %></td>
                                                    <td><%#Eval("ipcount") %></td>
                                                    <td><%#Eval("useravg") %></td>
                                                    <td>-</td>
                                                    <td>-</td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>

                                    </tbody>
                                </table>
                            </div>
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
