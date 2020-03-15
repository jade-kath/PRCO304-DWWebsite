<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserCreateAccount.aspx.cs" Inherits="DogWalking.User_Side.UserCreateAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Create Account</h2>

            <label>First Name:-</label>
            <asp:TextBox ID="txtFirstName" runat="server" Width="167px"/>
            <br />
            <label>Last Name:-</label>
            <asp:TextBox ID="txtLastName" runat="server" Width="163px"/>
            <br />
            <label>Date of Birth:-</label>
            <asp:TextBox ID="txtDOB" runat="server" TextMode="Date" Width="158px" />
            <br />
            <label>What area do you live in?-</label>
            <asp:DropDownList ID="drpLocation" runat="server" DataSourceID="SqlDataSource1" DataTextField="Location" DataValueField="LocationID">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=socem1.uopnet.plymouth.ac.uk;Initial Catalog=PRCO304_JMarshall;Persist Security Info=True;User ID=JMarshall;Password=PRCO304_22018506" ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [Location]"></asp:SqlDataSource>
            <br />
            <label>Email Address:-</label>
            <asp:TextBox ID="txtUserEmail" runat="server" TextMode="Email" Width="149px"/>
            <br />
            <label>Create a Username:-</label>
            <asp:TextBox ID="txtUserUsername" runat="server"/>
            <br />
            <label>Create a Password:-</label>
            <asp:TextBox ID="txtUserPassword" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>

            <br />
            <br />
            <asp:Button ID="btnCreateAccount" runat="server" Text="Create Account" Width="216px" OnClick="btnCreateAccount_Click" />

            

        </div>
    </form>
</body>
</html>
