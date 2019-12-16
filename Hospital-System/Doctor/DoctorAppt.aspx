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
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="AppointmentID" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="AppointmentID" HeaderText="AppointmentID" InsertVisible="False" ReadOnly="True" SortExpression="AppointmentID" />
            <asp:BoundField DataField="PatientID" HeaderText="PatientID" SortExpression="PatientID" />
            <asp:BoundField DataField="DoctorID" HeaderText="DoctorID" SortExpression="DoctorID" />
            <asp:BoundField DataField="Purpose" HeaderText="Purpose" SortExpression="Purpose" />
            <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" />
            <asp:BoundField DataField="Time" HeaderText="Time" SortExpression="Time" />
            <asp:BoundField DataField="VisitSummary" HeaderText="VisitSummary" SortExpression="VisitSummary" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [AppointmentsTable]"></asp:SqlDataSource>
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
    <p>
    </p>
    <p>
    </p>
</asp:Content>
