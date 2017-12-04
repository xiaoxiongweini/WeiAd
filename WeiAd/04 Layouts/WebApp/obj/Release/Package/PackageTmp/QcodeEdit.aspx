<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QcodeEdit.aspx.cs" Inherits="WebApp.QcodeEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>二维码生成</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox runat="server" ID="txtQcode"></asp:TextBox>
            <asp:Button runat="server" ID="btnCreate" Text="生成二维码" OnClick="btnCreate_Click" />
        </div>
        <asp:Panel runat="server" ID="plImgs">

        </asp:Panel>
    </form>
</body>
</html>
