<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="DogWalking.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Lead The Way - Sign In</title>
</head>
<body>
    <form id="form1" runat="server">
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
