<%@ Page Title="" Language="C#" MasterPageFile="~/Accounts/Web.Master" AutoEventWireup="true" CodeBehind="AdDayChart.aspx.cs" Inherits="WebApp.Accounts.Ads.AdDayChart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    今日广告点击统计
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <script src="/Assets/Scripts/Plugs/echarts3/echarts.js"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="miniContent" runat="server">
    <asp:HiddenField runat="server" ID="hidDataJson" />
    <!-- Main content -->
    <section class="content">
        <div class="row">
            <div class="col-xs-12">
                <div class="box">
                    <div class="box-header">
                        <h3 class="box-title">今日广告点击统计</h3>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div id="divChart" style="width: 100%; height: 400px;"></div>
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
