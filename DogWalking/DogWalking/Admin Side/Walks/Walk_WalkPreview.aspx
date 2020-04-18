<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Walk_WalkPreview.aspx.cs" Inherits="DogWalking.Admin_Side.Walks.Walk_WalkDetails1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

     <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous">

    <link rel="stylesheet" href="../../Style/Admin_Navbar.css" />

    <script src="https://code.jquery.com/jquery-3.4.1.slim.min.js" integrity="sha384-J6qa4849blE2+poT4WnyKhv5vZF5SrPo0iEjwBvKU7imGFAV0wwj1yYfoRSJoZ+n" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js" integrity="sha384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6" crossorigin="anonymous"></script>
    
</head>
<body>
    <form id="form1" runat="server">
        <div class="sidenav">
                <div class="dropdown">
                  <button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton-Walk" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                    Walks
                  </button>
                      <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                         <a href="Walk_AllWalks.aspx">View All Walks</a>
                         <a href="Walk_ReqWalks.aspx">Requested Walks</a>
                          <a href="Walk_NewWalk_NamePhotos.aspx">Create New Walk</a>
                      </div>
                 </div>
                
                         <a href="#">Oubreaks</a>

                <div class="dropdown">
                  <button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton-User" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                    Users
                  </button>
                      <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                         <a href="../User/Users_ViewUsers.aspx">View Users</a>
                         <a href="../User/Users_ViewAdminUsers.aspx">
                         <a href="../User/Users_CreateAccount.aspx"
                      </div>
                </div>   
            </div>

        <div class="main">
            <div class="controlButtons">
                <asp:Button runat="server" ID="btnBack" Text="Go Back" OnClick="btnBack_Click" />
                <asp:Button runat="server" ID="btnEdit" Text="Edit" OnClick="btnEdit_Click" />
                <asp:Button runat="server" ID="btnPost" Visible="false" Text="Post to Website" OnClick="btnPost_Click" />
                <asp:Button runat="server" ID="btnRemove" Visible="false" Text="Remove From Website" OnClick="btnRemove_Click" />
                <asp:Button runat="server" ID="btnDelete" Text="Delete" OnClick="btnDelete_Click" />
            </div>
                    <br />
            <div class="general">
                <asp:Label ID="lblPlaceName" runat="server"/>
                    <br />
                <asp:Label ID="lblAddress" runat="server"/>
                    <br />
                <asp:Label ID="lblLocation" runat="server"/>
                    <br />
                <asp:Label ID="lblDescript" runat="server"/>
                    <br />
                
                <label>Time spent here:bel>Time spent here:</label>
                <asp:Label ID="lblTime" runat="server"/>
                    <br />
                <label>Distance of this Walk:</label>
                <asp:Label ID="lblDistance" runat="server"/>
                    <br />
            </div>
                    <br />
            <div class="terrain">
                <asp:ListBox ID="lstTerrain" runat="server"></asp:ListBox>
            </div>
                    <br />
            <div class="leads">
                <label>Leaded Areas:</label>
                    <br />
                <asp:Label ID="lblLeaded" runat="server" />
                    <br />
                
                <label>Non-leaded Areas:</label>
                    <br />
                <asp:Label ID="lblNonLead" runat="server" />
                    <br />
                
                <label>Further Details:</label>
                    <br />
                <asp:Label ID="lblLeadDetails" runat="server" />
                    <br />
            </div>

            <div class="facilities">
                <label>Entry Fee</label>
                <asp:Label ID="lblEntry" runat="server" />
                    <br />
                <asp:Label ID="lblEntryDetails" runat="server" />
                    <br />
                
                <label>Parking</label>
                <asp:Label ID="lblPark" runat="server" />
                    <br />
                <asp:Label ID="lblParkDetails" runat="server" />
                    <br />
                
                <label>Live Stock</label>
                <asp:Label ID="lblLive" runat="server" />
                    <br />
                <asp:Label ID="lblLiveDetails" runat="server" />
                    <br />
                
                <label>Toilets</label>
                <asp:Label ID="lblToilet" runat="server" />
                    <br />
                <asp:Label ID="lblToiletDetails" runat="server" />
                    <br />

                <label>Refreshments</label>
                <asp:Label ID="lblRefresh" runat="server" />
                    <br />
                <asp:Label ID="lblRefreshDetails" runat="server" />
                    <br />
            </div>
        </div>
    </form>
</body>
</html>
