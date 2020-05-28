<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="DogWalking.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Lead The Way - Sign In</title>

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
              <asp:Button runat="server" ID="btnHome" Text="Home" OnClick="btnHome_Click" />
            </li>
            <li class="nav-item">
              <asp:Button runat="server" ID="btnSignIn" Text="Sign In/Register" OnClick="btnSignIn_Click"/>
            </li>
             <li class="nav-item">
              <asp:Button runat="server" ID="btnProfile" Text="My Profile" Visible="false" OnClick="btnProfile_Click" />
            </li>
             <li class="nav-item">
              <asp:Button runat="server" ID="btnSettings" Text="My Settings" Visible="false" OnClick="btnSettings_Click" />
            </li>
            <li class="nav-item">
              <asp:Button runat="server" ID="btnLogout" Text="Logout" Visible="false" OnClick="btnLogout_Click" />
            </li>
          </ul>
        </nav>

        <div>
            <h1>Log In</h1>
                <div class="signIn">
                    <asp:Label ID="lblUser" runat="server" Text="Username:"></asp:Label> <br />
                    <asp:TextBox ID="txtusernameInsert" runat="server" placeholder="Username"></asp:TextBox> 
                    <br />
                    <asp:Label ID="lblPass" runat="server" Text="Password:"></asp:Label> <br />
                    <asp:TextBox ID="txtpasswordInsert" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox> 
                    <br />
                    <asp:Button ID="btnLogin" runat="server" onclick="btnLogin_Click" Text="Sign In"></asp:Button>
                </div>

                <p><a href="User Side/UserCreateAccount.aspx">Don't  have an account? Sign up here!</a></p>
        </div>
    </form>
</body>
</html>
