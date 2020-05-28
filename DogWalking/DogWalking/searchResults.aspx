<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="searchResults.aspx.cs" Inherits="DogWalking.searchResults" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Lead The Way</title>

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
              <asp:Button runat="server" ID="btnHome" Text="Home" OnClick="btnHome_Click" />
            </li>
            <li class="nav-item">
              <asp:Button runat="server" ID="btnLogin" Text="Sign In/Register" OnClick="btnLogin_Click"/>
            </li>
             <li class="nav-item">
              <asp:Button runat="server" ID="btnProfile" Text="My Profile" Visible="false" OnClick="btnProfile_Click" />
            </li>
             <li class="nav-item">
              <asp:Button runat="server" ID="btnSettings" Text="My Settings" Visible="false" OnClick="btnSettings_Click"/>
            </li>
            <li class="nav-item">
              <asp:Button runat="server" ID="btnLogout" Text="Logout" Visible="false" OnClick="btnLogout_Click" />
            </li>
          </ul>
        </nav>

        <div>
            <div class="search">
                <p>Where would you like to go?</p>
                <asp:TextBox ID="txtSearchBar" runat="server" placeholder="eg. London"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
            </div>

            <br />

            <div class="allWalks">
                <h2>Results</h2>

                <asp:Label runat="server" ID="lblNoResults" Visible="false">No Results Found</asp:Label>

                <asp:GridView ID="grdWalks" runat="server" OnSelectedIndexChanged="grdWalks_SelectedIndexChanged1" >
                <Columns>      
                    <asp:ButtonField Text="More Details..." CommandName="Select" ItemStyle-Width="100"/>
                </Columns>
                </asp:GridView>

               </div>
        </div>
    </form>
</body>
</html>
