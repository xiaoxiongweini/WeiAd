<%@ Page Title="" Language="C#" MasterPageFile="~/Accounts/WebEmp.Master" AutoEventWireup="true" CodeBehind="CheckMyDomain.aspx.cs" Inherits="WebApp.Accounts.CheckMyDomain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .frmbox{}
        .ifrmain{width:100%;height:100px;}
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="miniContent" runat="server">
    <asp:HiddenField runat="server" ID="hidUserId" />
    <asp:Repeater runat="server" ID="rptDomain">
        <ItemTemplate>
            <div class="frmbox">
                <p><%#Eval("Url") %></p>
                <iframe src="http://<%#Eval("Url") %>" class="ifrmain"></iframe>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
