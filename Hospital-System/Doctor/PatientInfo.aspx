<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PatientInfo.aspx.cs" Inherits="Hospital_System.Doctor.PatientInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Doctor/DoctorHome.aspx">Doctor Home</asp:HyperLink>
    </p>
    <p>
        <asp:Label ID="Label2" runat="server" Text="Patient List"></asp:Label>
    </p>
    <p>
        Search for patient by PatientID or Last and First Name:
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Search_Button" runat="server" OnClick="Search_Button_Click" Text="Search" />
    </p>
    <p style="margin-left: 720px">
        <asp:Label ID="Label4" runat="server"></asp:Label>
    </p>
    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateSelectButton="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Label ID="Label3" runat="server" Text="View selected patient's information: "></asp:Label>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="View" />
    </p>
    <p>
        <asp:Label ID="Name" runat="server" Text="Name"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Email" runat="server" Text="Email"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Tests" runat="server" Text="Tests"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Medications" runat="server" Text="Medications"></asp:Label>
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
