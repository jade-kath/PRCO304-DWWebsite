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
             <!-- Walk Dropdown -->
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
             <!-- Outbreak Dropdown -->
                 <div class="dropdown">
                  <button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton-outbreak" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                    Dog Illnesses
                  </button>
                      <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                         <a href="../Outbreaks/OB_AllOB.aspx">View All Dog Illness Reports</a>
                         <a href="../Outbreaks/OB_ReqOB.aspx">View Requested Illness Reports</a>
                         <a href="../Outbreaks/OB_AddOB.aspx">Create New Illness Report</a>
                      </div>
                </div>
             <!-- User Dropdown -->
                <div class="dropdown">
                  <button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton-User" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                    Users
                  </button>
                      <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                         <a href="../User/Users_ViewUsers.aspx">View Users</a>
                         <a href="../User/Users_ViewAdminUsers.aspx">View Admin Users</a>
                         <a href="../User/Users_CreateAccount.aspx">Create a User</a>
                      </div>
                </div>
                         <asp:Button runat="server" ID="btnLogOut" Text="Sign Out" OnClick="btnLogOut_Click" />
            </div>

        <div class="main">
            <div class="controlButtons">
                <asp:Button runat="server" ID="btnBack" Text="Go Back" OnClick="btnBack_Click" />
                <asp:Button runat="server" ID="btnPost" Visible="false" Text="Post to Website" OnClick="btnPost_Click" />
                <asp:Button runat="server" ID="btnRemove" Visible="false" Text="Remove From Website" OnClick="btnRemove_Click" />
                <asp:Button runat="server" ID="btnDelete" Text="Delete" OnClick="btnDelete_Click" OnClientClick="if ( !confirm('Are you sure you want to delete this walk?')) return false;"/>
            </div>
                    <br />
            <div class="general">
                <asp:Button runat="server" ID="btnEditGeneral" Text="Edit General Details" OnClick="btnEditGeneral_Click"/>
                <br />
                <asp:Label ID="lblWalkName" runat="server"></asp:Label>
                <br />
                <asp:Label ID="lblAddr" runat="server"></asp:Label>
                <asp:Label ID="lblPostcode" runat="server" />
                <br />
                <asp:Label ID="lblLocate" runat="server"></asp:Label>
                <br />
                <asp:Label ID="lblDescribe" runat="server"></asp:Label>
                <br />

                <label>Time spent here:bel>Time spent here:</label>
                <asp:Label ID="lblTime" runat="server"/>
                    <br />
                <label>Distance of this Walk:</label>
                    <br />
                <asp:Label ID="lblDist" runat="server" ReadOnly="true"/>
                    <br />
            </div>
                    <br />

            <div class="terrain">
                <h3>Terrain:</h3>
                <asp:Button runat="server" ID="btnEditTerrain" Text="Edit Terrain" OnClick="btnEditTerrain_Click" />
                    <br />
                <asp:GridView ID="grdTerrain" runat="server"></asp:GridView>
                    <br />
            </div>

            <div class="leads">
                <asp:Button runat="server" ID="btnEditFacility" Text="Edit Facility and Lead Details" OnClick="btnEditFacility_Click" />
                <h3>Lead Information:</h3>
                <asp:Label ID="lblLeaded" runat="server" />
                    <br />
                <asp:Label ID="lblNonLead" runat="server" />
                    <br />
                <asp:Label ID="lblLeadDetail" runat="server" />
                    <br />
                    <br />
            </div>

            <div class="facilities">
                <h3>Entry Fee</h3>
                <asp:Label ID="lblEntry" runat="server" />
                    <br />
                <asp:Label ID="lblEntryDetail" runat="server" />
                    <br />
                
                <h3>Parking</h3>
                <asp:Label ID="lblPark" runat="server" />
                    <br />
                <asp:Label ID="lblParkDetail" runat="server" />
                    <br />
                
                <h3>Live Stock</h3>
                <asp:Label ID="lblLive" runat="server" />
                    <br />
                <asp:Label ID="lblLiveDetail" runat="server" />
                    <br />
                
                <h3>Toilets</h3>
                <asp:Label ID="lblToilet" runat="server" />
                    <br />
                <asp:Label ID="lblToiletDetail" runat="server" />
                    <br />

                <h3>Refreshments</h3>
                <asp:Label ID="lblRefresh" runat="server" />
                    <br />
                <asp:Label ID="lblRefreshDetail" runat="server" />

                <h3>Wheelchair Friendly</h3>
                <asp:Label ID="lblWheel" runat="server" />
                    <br />
            </div>
            <div class="creation">
                <asp:Label ID="lblCreated" runat="server" />
            </div>
        </div>
    </form>
</body>
</html>
