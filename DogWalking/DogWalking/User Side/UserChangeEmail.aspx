<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserChangeEmail.aspx.cs" Inherits="DogWalking.User_Side.UserChangeEmail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Change Email</h2>

            <label>Old Email Adress:-</label>
            <asp:TextBox ID="txtOldEmail" runat="server"/>
            <br />
            <label>New Email Address:-</label>
            <asp:TextBox ID="txtNewEmail" runat="server" Width="167px"/>
            <br />
            <label>Enter password to confirm change:-</label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>
            <br />
            <asp:Button ID="SaveUserChanges" runat="server" OnClick="SvUserChanges_Click" Text="Save Changes" />
            <br />
            <asp:label ID="lblChangesSaved" runat="server" Visible="false">*Your changes have been saved</asp:label>
         </div>
    </form>
</body>
</html>
