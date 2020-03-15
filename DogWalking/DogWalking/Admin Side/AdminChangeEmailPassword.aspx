﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminChangeEmailPassword.aspx.cs" Inherits="DogWalking.Admin_Side.AdminChangeEmail" %>

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
                  <label>New Email Address:-</label>
                  <asp:TextBox ID="txtNewEmail" runat="server" TextMode="Email" Width="167px"/>
                  <br />
                  <label>Enter admin password to confirm change:-</label>
                  <asp:TextBox ID="txtEmailPassword" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>
                  <br />
                  <asp:Button ID="SaveEmailChanges" runat="server" Text="Save Email Changes" OnClick="SaveEmailChanges_Click" />
                  <br />
                  <asp:label ID="lblEmailSaved" runat="server" Visible="false">*Your changes have been saved</asp:label>
            </div>
            <br />
            <div id="changePassword">
                <h2>Change Password</h2>                              
                     <label>New Password:-</label>
                     <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>
                     <br />
                     <label>Enter admin password to confirm changes:-</label>
                     <asp:TextBox ID="txtPassPassword" runat="server" Width="167px"/>
                     <br />
                     <asp:Button ID="SavePasswordChanges" runat="server" Text="Save Password Changes" OnClick="SavePasswordChanges_Click" />
                     <br />
                     <asp:label ID="lblPasswordSaved" runat="server" Visible="false">*Your changes have been saved</asp:label>
            </div>
        </div>
    </form>
</body>
</html>
