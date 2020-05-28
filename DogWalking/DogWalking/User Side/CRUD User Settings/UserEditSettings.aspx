<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserEditSettings.aspx.cs" Inherits="DogWalking.User_Side.UserSettings" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Lead The Way - User Settings</title>

    <link rel="stylesheet" href="../../Style/User_Buttons.css" />
    <link rel="stylesheet" href="../../Style/User_Buttons.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css"/>
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">

        <nav class="navbar navbar-expand-sm bg-success navbar-dark">
          <ul class="navbar-nav">
            <li class="nav-item">
              <asp:Button runat="server" ID="btnHome" Text="Home" OnClick="btnHome_Click"/>
            </li>
             <li class="nav-item">
              <asp:Button runat="server" ID="btnProfile" Text="My Profile" OnClick="btnProfile_Click" />
            </li>
             <li class="nav-item">
              <asp:Button runat="server" ID="btnSettings" Text="My Settings" OnClick="btnSettings_Click"/>
            </li>
            <li class="nav-item">
              <asp:Button runat="server" ID="btnLogout" Text="Logout" OnClick="btnLogout_Click" />
            </li>
          </ul>
        </nav>

        <div>
            <h1>User Settings</h1>

            <br />
            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" CssClass="btn-cancel" />
            <br />

            <label>Username:-</label>
            <asp:TextBox ID="txtUserUsername" runat="server" ReadOnly="true"/>
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
            <asp:Button ID="SaveUserChanges" runat="server" OnClick="SvUserChanges_Click" Text="Save Changes" CssClass="btn-save" />
            <br />
            <asp:label ID="lblChangesSaved" runat="server" Visible="false">*Your changes have been saved</asp:label>
            <br />
            <br />
            <asp:Button ID="UserChangeEmail" runat="server" Text="Change Email Address" OnClick="UserChangeEmail_Click" CssClass="btn-select" />
            <asp:Button ID="UserChangePassword" runat="server" Text="Change Password" OnClick="UserChangePassword_Click" CssClass="btn-select" />
            <br />

            <asp:Button ID="UserDeleteAccount" runat="server" Text="Delete My Account" OnClick="UserDeleteAccount_Click" OnClientClick="if ( !confirm('Are you sure you want to delete this user?')) return false;" CssClass="btn-delete" />
            <br />
                
        </div>
    </form>
</body>
</html>
