<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="DogWalking.UserProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>User Profile</h3>
            <br />
            <h4><a href="UserEditSettings.aspx">Edit Profile</a></h4>

            <div class="newWalk">
                <asp:Button ID="btnNewWalk" runat="server" Text="Add a Walk" OnClick="btnNewWalk_Click"></asp:Button>
            </div>
        </div>
    </form>
</body>
</html>
