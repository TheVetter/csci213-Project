<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PatientAppt.aspx.cs" Inherits="Hospital_System.Patient.PatientAppt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            font-size: x-large;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Patient/patientHome.aspx">Patient Home</asp:HyperLink>
    </p>
    <h2 class="auto-style1">
        <strong>Your appointments:</strong></h2>
    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateSelectButton="True" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" Height="215px" Width="564px">
            <AlternatingRowStyle BackColor="White" />
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button_delete" runat="server" Height="35px" OnClick="Button_delete_Click" Text="Delete Selected Appointment" Width="215px" />
    </p>
    <h2>
        Create Appointments:</h2>
    <p>
        Select Department:
        <asp:DropDownList ID="DropDownListDepartment" runat="server" Height="22px" OnSelectedIndexChanged="DropDownListDepartment_SelectedIndexChanged" Width="182px" AutoPostBack="True">
            <asp:ListItem>Family Care</asp:ListItem>
            <asp:ListItem>ICU</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        Select a Doctor: <asp:DropDownList ID="DropDownList_doctor" runat="server" Height="16px" Width="199px">
        </asp:DropDownList>
    </p>
    <p>
        Select Date For appointment: <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px">
            <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
            <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <SelectedDayStyle BackColor="#333399" ForeColor="White" />
            <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
            <TodayDayStyle BackColor="#CCCCCC" />
        </asp:Calendar>
    </p>
    <p>
        Select Time:
        <asp:TextBox ID="TextBox_time" runat="server" TextMode="Time"></asp:TextBox>
    </p>
    <p>
        What is the Purpose of the Appointment:  <p>
        <asp:TextBox ID="TextBox_purpose" runat="server" Height="78px" TextMode="MultiLine" Width="349px"></asp:TextBox>
    </p>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Create Appointment" />
    <p>
    </p>
    <p>
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
    </p>
</asp:Content>
