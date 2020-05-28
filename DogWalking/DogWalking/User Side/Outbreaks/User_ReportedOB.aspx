<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User_ReportedOB.aspx.cs" Inherits="DogWalking.User_Side.Outbreaks.User_ReportedOB" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Lead The Way - My Reported Dog Illnesses</title>

    <link rel="stylesheet" href="../../Style/User_Buttons.css" />
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

        <div class="userMain">
            <h1>My Reported Dog Illnesses</h1>
            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" CssClass="btn-cancel" />
            <asp:Button ID="btnNewOutbreak" runat="server" Text="Report a Dog Illness" OnClick="btnNewOutbreak_Click" CssClass="btn-save" />

            <asp:GridView ID="grdRepOB" runat="server" OnSelectedIndexChanged="grdRepOB_SelectedIndexChanged">
                <Columns>      
                    <asp:ButtonField Text="View Walk..." CommandName="Select" ItemStyle-Width="100"/>
                </Columns>
            </asp:GridView> 
        </div>
    </form>
</body>
</html>
