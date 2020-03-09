<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewAdminUsers.aspx.cs" Inherits="DogWalking.Admin_Side.viewAdminUsers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="sidenav">              
                 <a href="createAccount.aspx">Create New Account</a>
                 <a href="viewUsers.aspx">Users</a>
                 <a href="viewAdminUsers.aspx">Admin Users</a>
            </div>
                <asp:GridView ID="grdViewUserAdmin" runat="server" OnSelectedIndexChanged="grdViewUserAdmin_SelectedIndexChanged">
                    <Columns>
                         <asp:ButtonField Text="Edit User" CommandName="Select" ItemStyle-Width="100"/>
                    </Columns>
                </asp:GridView>
        </div>
    </form>
</body>
</html>
