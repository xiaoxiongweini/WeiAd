<%@ Page Title="" Language="C#" MasterPageFile="~/Accounts/Web.Master" AutoEventWireup="true" CodeBehind="AdVlist.aspx.cs" Inherits="WebApp.Accounts.Charts.AdVlist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    时间分析
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="miniContent" runat="server">
    <asp:HiddenField runat="server" ID="hidAdId" />
    <!-- Main content -->
    <section class="content">
        <div class="row">
            <div class="col-xs-12">
                <div class="box">
                    <div class="box-header">
                        <h3 class="box-title">
                           今日广告概览( <asp:Literal runat="server" ID="ltTime"></asp:Literal>)
                        </h3>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <table id="example2" class="table table-bordered table-hover">
                            <thead>
                                <tr>
                                    <th>广告ID</th>
                                    <th>广告标题</th>
                                    <th>浏览次数（PV）</th>
                                    <th>独立访客（UV）</th>
                                    <th>IP</th>
                                    <th>单价（元）</th>
                                    <th>金额（元）</th>
                                    <th>查看详情</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater runat="server" ID="rptTable">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%#Eval("adid") %></td>
                                            <td><%#DN.WeiAd.Business.AdPageInfoBLL.Instance.GetTitleById( Eval("adid")) %></td>
                                            <td><%#Eval("pvcount") %></td>
                                            <td><%#Eval("uvcount") %></td>
                                            <td><%#Eval("ipcount") %></td>
                                            <td><%#DN.WeiAd.Business.AdPageInfoBLL.Instance.GetTitleByMoney(Eval("adid")) %></td>
                                            <td><%#DN.WeiAd.Business.AdPageInfoBLL.Instance.GetTitleByMoney(Eval("adid"),Eval("ipcount")) %></td>
                                            <td>
                                                <a href="HourAnalysis.aspx?adid=<%#Eval("adid") %>">查看详情</a>
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
