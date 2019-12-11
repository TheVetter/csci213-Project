<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DoctorHome.aspx.cs" Inherits="Hospital_System.Doctor.DoctorHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        &nbsp;</p>
    <p>
        Hello Doctor</p>
    <p>
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Doctor/DoctorAppt.aspx">Manage Patient Appointments</asp:HyperLink>
</p>
<p>
    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Doctor/PatientInfo.aspx">Patient Information</asp:HyperLink>
</p>
<p>
    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Doctor/DoctorMessages.aspx">Send Message</asp:HyperLink>
</p>
<p>
    &nbsp;</p>
<p>
    &nbsp;</p>
</asp:Content>
