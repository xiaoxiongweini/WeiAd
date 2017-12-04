<%@ Page Title="" Language="C#" MasterPageFile="~/Accounts/Web.Master" AutoEventWireup="true" CodeBehind="PageAnalysis.aspx.cs" Inherits="WebApp.Accounts.Charts.PageAnalysis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    受访页面
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
                        <h3 class="box-title">受访页面</h3>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <table id="example2" class="table table-bordered table-hover">
                            <thead>
                                <tr>
                                    <th>浏览次数(PV)</th>
                                    <th>独立访客(UV)</th>
                                    <th>IP</th>
                                    <th>人均浏览页数</th>
                                    <th>输出PV</th>
                                    <th>页面平均停留时长</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>
                                        <asp:Literal runat="server" ID="ltPv" Text="0"></asp:Literal></td>
                                    <td>
                                        <asp:Literal runat="server" ID="ltUv" Text="0"></asp:Literal></td>
                                    <td>
                                        <asp:Literal runat="server" ID="ltIp" Text="0"></asp:Literal></td>
                                    <td>
                                        <asp:Literal runat="server" ID="ltUserAvg" Text="0"></asp:Literal></td>
                                    <td>-</td>
                                    <td>-</td>
                                </tr>
                            </tbody>
                        </table>
                        <br />
                        <div class="panel panel-default">
                            <div class="panel-heading">详情记录</div>
                            <div class="panel-body">
                                <table class="table table-bordered table-hover">
                                    <thead>
                                        <tr>
                                            <th>受访页面</th>
                                            <th>浏览次数(PV)</th>
                                            <th>独立访客(UV)</th>
                                            <th>IP</th>
                                            <th>人均浏览页数</th>
                                            <th>输出PV</th>
                                            <th>页面平均停留时长</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td>全站统计</td>
                                            <td>
                                                <asp:Literal runat="server" ID="ltPv1" Text="0"></asp:Literal></td>
                                            <td>
                                                <asp:Literal runat="server" ID="ltUv1" Text="0"></asp:Literal></td>
                                            <td>
                                                <asp:Literal runat="server" ID="ltIp1" Text="0"></asp:Literal></td>
                                            <td>
                                                <asp:Literal runat="server" ID="ltUserAvg1" Text="0"></asp:Literal></td>
                                            <td>-</td>
                                            <td>-</td>
                                        </tr>
                                        <asp:Repeater runat="server" ID="rptTable">
                                            <ItemTemplate>
                                                <tr>
                                                    <td><%#Eval("adurl") %></td>
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
