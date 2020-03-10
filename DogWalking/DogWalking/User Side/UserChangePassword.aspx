<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserChangePassword.aspx.cs" Inherits="DogWalking.User_Side.UserChangePassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Change Password</h2>
            <label>Old password:-</label>
            <asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>
            <br />            
            <label>New Password:-</label>
            <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>
            <br />
            <label>Enter your Email Address to confirm changes:-</label>
            <asp:TextBox ID="txtEmailAddress" runat="server" Width="167px"/>
            <br />
            <asp:Button ID="SaveUserChanges" runat="server" Text="Save Changes" OnClick="SaveUserChanges_Click" />
            <br />
            <asp:label ID="lblChangesSaved" runat="server" Visible="false">*Your changes have been saved</asp:label>
        </div>
    </form>
</body>
</html>
