<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="false" EnableEventValidation="false" EnableSessionState="False" EnableViewStateMac="false" Inherits="DN.WeiAd.Business.Pages.AdBasePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width,initial-scale=1.0,maximum-scale=1.0,user-scalable=0" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black" />
    <meta name="format-detection" content="telephone=no" />
    <title>
        <asp:Literal runat="server" ID="ltPageTitle"></asp:Literal></title>
    <link href="/Assets/webv1/adcss/wx.css" rel="stylesheet" />

    <script type="text/javascript" src="/Assets/Scripts/jquery-1.11.3.min.js"></script>
    <script type="text/javascript" src="/Assets/Scripts/HtmlBrowse.js"></script>

</head>
<body id="activity-detail" class="zh_CN mm_appmsg">
    <form id="form1" runat="server">
        <div id="js_article" class="rich_media">
            <div id="js_top_ad_area" class="top_banner">
            </div>
            <div class="rich_media_inner">
                <div id="page-content">
                    <div id="img-content" class="rich_media_area_primary">
                        <h2 class="rich_media_title" id="activity-name">
                            <asp:Literal runat="server" ID="ltTitle"></asp:Literal>
                        </h2>
                        <div class="rich_media_content " id="js_content">
                            <asp:Literal runat="server" ID="ltContent"></asp:Literal>
                            <div class="ct_mpda_wrp" id="js_sponsor_ad_area" style="display: none;">
                            </div>
                        </div>

                        <div class="rich_media_area_primary sougou" id="sg_tj" style="display: none">
                        </div>

                        <div class="rich_media_area_extra">


                            <div class="mpda_bottom_container" id="js_bottom_ad_area">
                            </div>

                            <div id="js_iframetest" style="display: none;">
                                <asp:Literal runat="server" ID="ltUserCode"></asp:Literal>
                            </div>

                        </div>

                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

