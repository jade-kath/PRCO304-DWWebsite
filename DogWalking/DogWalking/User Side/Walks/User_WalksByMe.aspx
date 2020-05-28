<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User_WalksByMe.aspx.cs" Inherits="DogWalking.User_Side.Walks.User_WalksByMe" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Lead The Way - Walks By Me</title>

    <link rel="stylesheet" href="../../Style/User_Buttons.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css"/>
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">

        <nav class="navbar navbar-expand-sm bg-success navbar-dark">
          <ul class="navbar-nav">
            <li class="nav-item">
              <asp:Button runat="server" ID="btnHome" Text="Home" OnClick="btnHome_Click"/>
            </li>
             <li class="nav-item">
              <asp:Button runat="server" ID="btnProfile" Text="My Profile" OnClick="btnProfile_Click" />
            </li>
             <li class="nav-item">
              <asp:Button runat="server" ID="btnSettings" Text="My Settings" OnClick="btnSettings_Click"/>
            </li>
            <li class="nav-item">
              <asp:Button runat="server" ID="btnLogout" Text="Logout" OnClick="btnLogout_Click" />
            </li>
          </ul>
        </nav>

        <div>
            <h1>Walks By Me</h1>

            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" CssClass="btn-cancel" />
            <asp:Button ID="btnAddWalk" runat="server" Text="Add a New Walk" OnClick="btnAddWalk_Click" CssClass="btn-save" />
            <br />

            <h2>Pending Confirmation</h2>
            <asp:GridView ID="grdPending" runat="server" OnSelectedIndexChanged="grdPending_SelectedIndexChanged">
                <Columns>      
                    <asp:ButtonField Text="View Walk..." CommandName="Select" ItemStyle-Width="100"/>
                </Columns>
            </asp:GridView> 

            <h2>Confirmed & Published</h2>
             <asp:GridView ID="grdConfirmed" runat="server" OnSelectedIndexChanged="grdConfirmed_SelectedIndexChanged" >
                <Columns>      
                    <asp:ButtonField Text="View Walk..." CommandName="Select" ItemStyle-Width="100"/>
                </Columns>
            </asp:GridView> 
        </div>
    </form>
</body>
</html>
