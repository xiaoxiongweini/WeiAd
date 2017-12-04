<%@ Page Title="" Language="C#" MasterPageFile="~/AccAnalysis/Web.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebApp.AccAnalysis.Vir.Index" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">今日广告概览
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(function () {
            onloadData();
        })
        function onloadData()
        {
            var userid = "<%=Account.UserId%>";
            var url = "/Services/GetAdData.ashx";
            
            $(".dataitem").each(function () {
                var tdArr = $(this).children();
                var adid = tdArr.eq(0).text();
                var purl = "uid=" + userid + "&adid=" + adid;
                $.ajax({
                    type: "POST",
                    url: url,
                    data: purl,
                    success: function (msg) {
                        var ipcount = "ad_" + adid + "_ip";
                        var ipm = "ad_" + adid + "_money";
                        var ipam = "ad_" + adid + "_allmoney";
                        var price = $("#" + ipm).text();
                        $("#" + ipcount).text(msg);
                        $("#" + ipam).text(parseInt(parseFloat(price) * parseInt(msg)));
                    }
                });
            })
        }

    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="miniContent" runat="server">
    <div class="content animate-panel">
        <div class="row">
            <div class="col-lg-12">
                <div class="hpanel">
                    <div class="panel-heading">
                        <div class="panel-tools">
                            <a class="showhide"><i class="fa fa-chevron-up"></i></a>
                            <a class="closebox"><i class="fa fa-times"></i></a>
                        </div>
                        今日广告概览（<%=DateTime.Now.ToString("yyyy-MM-dd") %> <%=DN.Framework.Utility.DateTimeHelper.GetWeek() %>）
                    </div>
                    <div class="panel-body">
                         <table id="example2" class="table table-bordered table-hover">
                            <thead>
                                <tr>
                                    <th>广告ID</th>
                                    <th>广告名称</th>
                                    <th>IP</th>
                                    <th>单价（元）</th>
                                    <th>金额（元）</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater runat="server" ID="rptTable">
                                    <ItemTemplate>
                                        <tr class="dataitem">
                                            <td><%#Eval("Id") %></td>
                                            <td><%#Eval("Title") %></td>
                                            <td id="ad_<%#Eval("Id") %>_ip">0</td>
                                            <td id="ad_<%#Eval("Id") %>_money"><%#Eval("Money") %></td>
                                            <td id="ad_<%#Eval("Id") %>_allmoney">0</td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                        <div>
                            <webdiyer:aspnetpager id="apPager" runat="server" custominfohtml="第%CurrentPageIndex%页，共%PageCount%页，总记录%RecordCount%条" pagingbuttonlayouttype="UnorderedList" currentpagebuttonclass="active" pagingbuttonspacing="0" cssclass="pagination" horizontalalign="Center"  UrlPaging="true"
                                width="100%" alwaysshow="true" showcustominfosection="Right" pagingbuttonsclass="" pagingbuttonsstyle="">
                            </webdiyer:aspnetpager>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
