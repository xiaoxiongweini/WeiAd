<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Web.Master" AutoEventWireup="true" CodeBehind="FlowUserAnalysis.aspx.cs" Inherits="WebApp.Admin.Analysis.FlowUserAnalysis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    流量主统计分析
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="/Assets/Scripts/Plugs/My97DatePicker/WdatePicker.js"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="miniContent" runat="server">
    <asp:HiddenField runat="server" ID="hidDataJson" />
    <asp:HiddenField runat="server" ID="hidAdId" />
    <!-- Main content -->
    <section class="content">
        <div class="row">
            <div class="col-xs-12">
                <div class="box">
                    <div class="box-header">
                        <h3 class="box-title">
                            <asp:Literal runat="server" ID="ltStime" Text=""></asp:Literal>---<asp:Literal runat="server" ID="ltAdTitle"></asp:Literal>
                        </h3>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <asp:Panel runat="server" ID="plSearch">
                            <div class="row">
                                <div class="col-xs-2">
                                    <input type="text" runat="server" id="txtTime" class="form-control " onfocus="WdatePicker({maxDate:'%y-%M-{%d}'})" />
                                </div>
                                <div class="col-xs-3">
                                    <asp:DropDownList runat="server" ID="ddlAdPage" CssClass="form-control"></asp:DropDownList>
                                </div>
                                <div class="col-xs-1">
                                    <asp:Button runat="server" ID="btnSearch" CssClass="btn btn-info form-control" Text="搜索" OnClick="btnSearch_Click" />
                                </div>
                            </div>
                            <br />
                        </asp:Panel>
                        <div class="panel panel-default">
                            <div class="panel-heading">趋势分析</div>
                            <div class="panel-body">
                                <table class="table table-bordered table-hover">
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
                            </div>
                        </div>
                        <div class="panel panel-default">
                            <div class="panel-heading">详情记录</div>
                            <div class="panel-body">
                                <table class="table table-bordered table-hover">
                                    <thead>
                                        <tr>
                                            <th>流量主</th>
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
                                                    <td><%#DN.WeiAd.Business.AccountInfoBLL.Instance.GetNickNameByUserId( Eval("FlowUserId")) %></td>
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
