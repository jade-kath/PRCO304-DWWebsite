<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Walk_AllWalks.aspx.cs" Inherits="DogWalking.Admin_Side.Walks.Walk_AllWalks" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link rel="stylesheet" href="../../Style/Admin_Navbar.css" />

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="sidenav">
                <a href="Walk_AllWalks.aspx">View All Walks</a>
                <a href="Walk_ReqWalks.aspx">Requested Walks</a>
                <a href="#">Oubreaks</a>
                <a href="../User/Users_ViewUsers.aspx">View Users</a>
                <a href="../User/Users_ViewAdminUsers.aspx">View Admin Users</a>
                <a href="../User/Users_CreateAccount.aspx">Create New User</a>                
            </div>

            <h3>All Walks</h3>
            <br />
            <asp:GridView ID="grdViewWalks" runat="server">
                <Columns>
                    <asp:ButtonField Text="Edit Walk" CommandName="Select" ItemStyle-Width="100"/>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
