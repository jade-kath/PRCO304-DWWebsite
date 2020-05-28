<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserChangePassword.aspx.cs" Inherits="DogWalking.User_Side.UserChangePassword" %>

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
            <h1>User Settings - Change Password</h1>

            <br />
            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" CssClass="btn-cancel" />
            <br />

            <p id="required">* indicates a required field</p>
            <br />

            <label>*</label><label>Old password:-</label>
            <asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>
            <br />            
            <label>*</label><label>New Password:-</label>
            <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>
            <br />
            <label>*</label><label>Enter your Email Address to confirm changes:-</label>
            <asp:TextBox ID="txtEmailAddress" runat="server" TextMode="Email" Width="167px"/>
            <br />

            <asp:Label runat="server" ID="lblrequired" Visible="false">Please fill all the required fields.</asp:Label>
            <br />

            <asp:Button ID="SaveUserChanges" runat="server" Text="Save Changes" OnClick="SaveUserChanges_Click" CssClass="btn-save" />
            <br />
            <asp:label ID="lblChangesSaved" runat="server" Visible="false">*Your changes have been saved</asp:label>
        </div>
    </form>
</body>
</html>
