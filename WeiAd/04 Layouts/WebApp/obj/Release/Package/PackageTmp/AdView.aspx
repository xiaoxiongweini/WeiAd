<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdView.aspx.cs" Inherits="WebApp.AdView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <meta charset="UTF-8">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width,initial-scale=1.0,maximum-scale=1.0,user-scalable=0" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black" />
    <meta name="format-detection" content="telephone=no" />
    <script src="https://cdn.bootcss.com/jquery/1.11.3/jquery.js" type="text/javascript"></script>
    <meta name="keywords" content="@ViewBag.ArticleTitle" />
    <meta name="description" content="@ViewBag.ArticleTitle" />

    <title>广告测试页</title>
    <style type="text/css">
        .contincter {
            margin: 0 auto;
            padding: 0;
            max-width: 750px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField runat="server" ID="hidAdId" />

        <div class="contincter">
            <asp:Literal runat="server" ID="ltContent"></asp:Literal>
        </div>
        <div  style="display:none;">
            <asp:Literal runat="server" ID="ltUserCode"></asp:Literal>
            <asp:Literal runat="server" ID="ltStaticContent"></asp:Literal>
        </div>
    </form>
</body>
</html>
