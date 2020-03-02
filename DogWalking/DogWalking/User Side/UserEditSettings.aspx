<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserEditSettings.aspx.cs" Inherits="DogWalking.User_Side.UserSettings" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Edit Profile/Settings</h2>

          
                <asp:TextBox runat="server" ID="txtFirstName" ReadOnly="True" />
                <asp:TextBox runat="server" ID="txtLastName" ReadOnly="True" />
                
        </div>
    </form>
</body>
</html>
