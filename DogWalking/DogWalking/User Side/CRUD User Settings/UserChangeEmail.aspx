﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserChangeEmail.aspx.cs" Inherits="DogWalking.User_Side.UserChangeEmail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Lead The Way - User Settings</title>

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
            <h1>User Settings - Change Email Address</h1>

            <br />
            <asp:Button ID="btnCancel" runat="server" Text="Back" OnClick="btnCancel_Click" CssClass="btn-cancel"/>
            <br />

            <p id="required">* indicates a required field</p>
            <br />

            <label>*</label><label>Old Email Address:-</label>
            <asp:TextBox ID="txtOldEmail" runat="server" TextMode="Email"/>
            <br />
            <label>*</label><label>New Email Address:-</label>
            <asp:TextBox ID="txtNewEmail" runat="server" TextMode="Email" Width="167px"/>
            <br />
            <label>*</label><label>Enter password to confirm change:-</label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>
            <br />

            <asp:Label runat="server" ID="lblrequired" Visible="false">Please fill all the required fields.</asp:Label>
            <br />

            <asp:Button ID="SaveUserChanges" runat="server" OnClick="SvUserChanges_Click" Text="Save Changes" CssClass="btn-save" />
            <br />
            <asp:label ID="lblChangesSaved" runat="server" Visible="false">*Your changes have been saved</asp:label>
         </div>
    </form>
</body>
</html>
