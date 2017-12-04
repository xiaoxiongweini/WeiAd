<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="false" CodeBehind="AdView.aspx.cs" Inherits="WebApp.Comm.AdView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width,initial-scale=1.0,maximum-scale=1.0,user-scalable=0" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black" />
    <meta name="format-detection" content="telephone=no" />
    <title>广告预览页</title>
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
        <div class="contincter">
            <asp:HiddenField runat="server" ID="hidAdId" />
            <h1>
                <asp:Literal runat="server" ID="ltTitle"></asp:Literal>
            </h1>
            <br />

            <div>
                <asp:Literal runat="server" ID="ltContent"></asp:Literal>
            </div>
        </div>
        <div style="display:none">
            <asp:Literal runat="server" ID="ltStateContent"></asp:Literal>
            <asp:Literal runat="server" ID="ltStateContent1"></asp:Literal>
        </div>
    </form>
</body>
</html>
