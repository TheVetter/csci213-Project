<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="patientHome.aspx.cs" Inherits="Hospital_System.Patient.patientHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Patient/PatientAppt.aspx">Manage Appointments</asp:HyperLink>
</p>
<p>
    <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Patient/TestResults.aspx">Test Results</asp:HyperLink>
</p>
<p>
    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Patient/Medications.aspx">Medication List</asp:HyperLink>
</p>
<p>
    <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Patient/PatientMessages.aspx">Send Messages</asp:HyperLink>
</p>
<p>
    &nbsp;</p>
<p>
    &nbsp;</p>
</asp:Content>
