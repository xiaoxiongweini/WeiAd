<%@ Page Title="" Language="C#" MasterPageFile="~/AccAnalysis/Web.Master" AutoEventWireup="true" CodeBehind="AdSummerList.aspx.cs" Inherits="WebApp.AccAnalysis.AdSummerList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    广告总量统计
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
  
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
                        广告总量统计
                    </div>
                    <div class="panel-body">
                         <table id="example2" class="table table-bordered table-hover">
                            <thead>
                                <tr>
                                    <th>广告ID</th>
                                    <th>广告名称</th>
                                    <th>IP</th>
                                    <th>操作</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater runat="server" ID="rptTable">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%#Eval("AdId") %></td>
                                            <td><%#DN.WeiAd.Business.AdPageInfoBLL.Instance.GetTitleById(Eval("AdId")) %></td>
                                            <td><%#Eval("ipcount") %></td>
                                            <td>
                                                <a class="btn btn-info btn-xs" target="_blank" href="#">查看明细</a>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                        <div>
                            <webdiyer:aspnetpager id="apPager" runat="server" custominfohtml="第%CurrentPageIndex%页，共%PageCount%页，总记录%RecordCount%条" pagingbuttonlayouttype="UnorderedList" currentpagebuttonclass="active" pagingbuttonspacing="0" cssclass="pagination" horizontalalign="Center"  
                                width="100%" alwaysshow="true" showcustominfosection="Right" pagingbuttonsclass="" pagingbuttonsstyle="">
                            </webdiyer:aspnetpager>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
