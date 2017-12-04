<%@ Page Title="" Language="C#" MasterPageFile="~/AccFlow/Web.Master" AutoEventWireup="true" CodeBehind="DayHisAnalaysis.aspx.cs" Inherits="WebApp.AccFlow.Analysis.DayHisAnalaysis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    时间分析
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
   
    <script type="text/javascript" src="/Assets/Scripts/Plugs/My97DatePicker/WdatePicker.js"></script>
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
                            <asp:Literal runat="server" ID="ltAdTitle"></asp:Literal>
                        </h3>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                            <div class="row">
                            <div class="col-xs-2">
                                <input type="text" runat="server" id="txtTime" class="form-control " onfocus="WdatePicker({maxDate:'%y-%M-{%d}'})" />
                            </div>
                            <div class="col-xs-2">
                                <asp:DropDownList runat="server" ID="ddlAdPage" CssClass="form-control"></asp:DropDownList>
                            </div>
                            <div class="col-xs-1">
                                <asp:Button runat="server" ID="btnSearch" CssClass="btn btn-info form-control" Text="搜索" OnClick="btnSearch_Click" />
                            </div>
                        </div>
                        <br />
                        <table id="example2" class="table table-bordered table-hover">
                            <thead>
                                <tr>
                                    <th>时间</th>
                                    <th>广告ID</th>
                                    <th>广告标题</th>
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
                                            <td><%#Eval("AdId") %></td>
                                            <td><%#DN.WeiAd.Business.AdPageInfoBLL.Instance.GetTitleById(Eval("AdId")) %></td>
                                            <td><%#Eval("pvcount") %></td>
                                            <td><%#Eval("uvcount") %></td>
                                            <td><%#Eval("ipcount") %></td>
                                            <td>
                                                <a class="btn btn-info btn-xs" href="HourAnalysis.aspx?adid=<%#Eval("AdId") %>&time=<%=txtTime.Value %>">详情</a>
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
