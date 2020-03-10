<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserDetails.aspx.cs" Inherits="DogWalking.Admin_Side.UserDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="sidenav">           
                <a href="createAccount.aspx">Create New Account</a>
                 <a href="viewUsers.aspx">Users</a>
                 <a href="viewAdminUsers.aspx">Admin Users</a>
            </div>

            <label>Username:-</label>
            <asp:TextBox ID="txtUsername" runat="server" Width="167px"/>
            <br />
            <label>First Name:-</label>
            <asp:TextBox ID="txtFirstName" runat="server" Width="167px"/>
            <br />
            <label>Last Name:-</label>
            <asp:TextBox ID="txtLastName" runat="server" Width="163px"/>
            <br />          
            <label>Location:-</label>
            <asp:DropDownList ID="drpLocation" runat="server" DataSourceID="SqlDataSource1" DataTextField="Location" DataValueField="LocationID">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=socem1.uopnet.plymouth.ac.uk;Initial Catalog=PRCO304_JMarshall;Persist Security Info=True;User ID=JMarshall;Password=PRCO304_22018506" ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [Location]"></asp:SqlDataSource>
            <br />
            <asp:Button ID="SaveChanges" runat="server" Text="Save Changes" OnClick="SaveChanges_Click" />
            <br />
            <br />
            <br />
            <asp:Button ID="ChangeEmail" runat="server" Text="Change Email Address/Password" OnClick="ChangeEmail_Click" />
            <asp:Button ID="DeleteAccount" runat="server" Text="Delete This Account" OnClientClick="if ( !confirm('Are you sure you want to delete this user?')) return false;" OnClick="DeleteAccount_Click" />
        </div>
    </form>
</body>
</html>
