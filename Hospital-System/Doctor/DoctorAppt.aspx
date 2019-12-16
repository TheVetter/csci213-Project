<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DoctorAppt.aspx.cs" Inherits="Hospital_System.Doctor.DoctorAppt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Doctor/DoctorHome.aspx">Doctor Home</asp:HyperLink>
        <br />
    </p>
    <p>
    </p>
    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateSelectButton="True">
        </asp:GridView>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Delete Appointment" />
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
</asp:Content>
