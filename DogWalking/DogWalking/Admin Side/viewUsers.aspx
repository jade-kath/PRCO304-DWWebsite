<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewUsers.aspx.cs" Inherits="DogWalking.Admin_Side.viewUsers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>View Users</h3>
              <div class="sidenav">   
                 <a href="createAccount.aspx">Create New Account</a>
                 <a href="viewUsers.aspx">Users</a>
                 <a href="viewAdminUsers.aspx">Admin Users</a>                 
              </div>

            <br />
            <asp:GridView ID="grdViewUsers" runat="server" Width="638px" OnSelectedIndexChanged="grdViewUsers_SelectedIndexChanged">
                <Columns>
                    <asp:ButtonField Text="Edit User" CommandName="Select" ItemStyle-Width="100"/>
                </Columns>
            </asp:GridView>

        </div>
    </form>
</body>
</html>
