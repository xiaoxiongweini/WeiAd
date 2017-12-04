<%@ Page Title="" Language="C#" MasterPageFile="~/Accounts/Web.Master" AutoEventWireup="true" CodeBehind="AllAdAnalysis.aspx.cs" Inherits="WebApp.Accounts.Charts.AllAdAnalysis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    按广告分析
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <script src="/Assets/Scripts/Plugs/echarts3/echarts.js"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="miniContent" runat="server">
    <asp:HiddenField runat="server" ID="hidDataJson" Value="[]" />
    <!-- Main content -->
    <section class="content">
        <div class="row">
            <div class="col-xs-12">
                <div class="box">
                    <div class="box-header">
                        <h3 class="box-title">按广告分析 (<asp:Literal runat="server" ID="ltStime" Text=""></asp:Literal>至<asp:Literal runat="server" ID="ltEtime" Text=""></asp:Literal>) </h3>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
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
                        <div id="divChart" style="width: 100%; height: 400px;display:none;"></div>
                        <br />
                        <div class="panel panel-default">
                            <div class="panel-heading">详情记录</div>
                            <div class="panel-body">
                                <table class="table table-bordered table-hover">
                                    <thead>
                                        <tr>
                                            <th>广告名称</th>
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
                                                    <td><%#DN.WeiAd.Business.AdPageInfoBLL.Instance.GetTitleById( Eval("AdId")) %></td>
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
    <script type="text/javascript">
        // 基于准备好的dom，初始化echarts实例
        var myChart = echarts.init(document.getElementById('divChart'));

        var json = $("#<%=hidDataJson.ClientID%>").val();
        var data = JSON.parse(json);

        // 指定图表的配置项和数据
        option = {
            title: {
                text: '今日浏览量'
            },
            tooltip: {
                trigger: 'axis'
            },
            legend: {
                data: data.legend
            },
            grid: {
                left: '3%',
                right: '4%',
                bottom: '3%',
                containLabel: true
            },
            toolbox: {
                feature: {
                    saveAsImage: {}
                }
            },
            xAxis: {
                type: 'category',
                boundaryGap: false,
                data: data.xAxis
            },
            yAxis: {
                type: 'value'
            },
            series: data.series
        };
        // 使用刚指定的配置项和数据显示图表。
        myChart.setOption(option);

    </script>
</asp:Content>
