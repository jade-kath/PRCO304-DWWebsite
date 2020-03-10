<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminChangeEmailPassword.aspx.cs" Inherits="DogWalking.Admin_Side.AdminChangeEmail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="changeEmail">
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
                  <asp:Button ID="SaveEmailChanges" runat="server" Text="Save Email Changes" OnClick="SaveEmailChanges_Click" />
                  <br />
                  <asp:label ID="lblEmailSaved" runat="server" Visible="false">*Your changes have been saved</asp:label>
            </div>

            <div id="changePassword">
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
                     <asp:Button ID="SavePasswordChanges" runat="server" Text="Save Changes" OnClick="SavePasswordChanges_Click" />
                     <br />
                     <asp:label ID="lblPasswordSaved" runat="server" Visible="false">*Your changes have been saved</asp:label>
            </div>
        </div>
    </form>
</body>
</html>
