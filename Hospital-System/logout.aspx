<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="logout.aspx.cs" Inherits="Hospital_System.logout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style1 {
        font-size: x-large;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
    <br class="auto-style1" />
    <span class="auto-style1">you are now logged out </span>
</p>
<p>
    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Logon.aspx">Login </asp:HyperLink>
</p>
<p>
</p>
</asp:Content>
