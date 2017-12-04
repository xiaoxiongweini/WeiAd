<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Web.Master" AutoEventWireup="true" CodeBehind="DayAnalysis.aspx.cs" Inherits="WebApp.Admin.LogBrowse.DayAnalysis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    天粒度数据统计
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
                            <asp:Literal runat="server" ID="ltAdTitle" Text="当前月的第一天到当前天"></asp:Literal>
                        </h3>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <table id="example2" class="table table-bordered table-hover">
                            <thead>
                                <tr>
                                    <th>时间</th>
                                    <th>浏览次数（PV）</th>
                                    <th>独立访客（UV）</th>
                                    <th>IP</th>
                                    <th>操作</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater runat="server" ID="rptTable">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%#Eval("Time") %></td>
                                            <td><%#Eval("pvcount") %></td>
                                            <td><%#Eval("uvcount") %></td>
                                            <td><%#Eval("ipcount") %></td>
                                            <th>
                                                <a class="btn btn-info btn-xs" target="_blank"  href="HourAnalysis.aspx?time=<%#Eval("Time") %>">分时段分析</a>
                                            </th>
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
