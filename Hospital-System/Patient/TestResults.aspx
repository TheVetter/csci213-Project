<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TestResults.aspx.cs" Inherits="Hospital_System.Patient.TestResults" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Patient/patientHome.aspx">Patient Home</asp:HyperLink>
    </p>
    <p>
    </p>
    <p>
        Hello,&nbsp;
        <asp:LoginName ID="LoginName2" runat="server" />
    </p>
    <p>
        Here are your test results</p>
    <p>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
</asp:Content>
