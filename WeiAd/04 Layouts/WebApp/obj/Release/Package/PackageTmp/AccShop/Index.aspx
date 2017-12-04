<%@ Page Title="" Language="C#" MasterPageFile="~/AccShop/Web.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebApp.AccShop.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        document.location.href = "/AccShop/Order/OrderList.aspx";
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="miniContent" runat="server">
</asp:Content>
