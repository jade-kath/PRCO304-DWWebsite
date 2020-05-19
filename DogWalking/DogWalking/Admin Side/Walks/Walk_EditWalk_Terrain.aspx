<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Walk_EditWalk_Terrain.aspx.cs" Inherits="DogWalking.Admin_Side.Walks.Walk_EditWalk_Terrain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link rel="stylesheet" href="../../Style/Admin_Navbar.css" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous"/>

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
            <div class="terrain">
                 <h2>Terrain:</h2>
                    <p>Types of terrains on this walk:- (Select all that apply)</p>
                    <asp:RadioButton ID="radTerFlat" runat="server" Text="Flat" />
                        <br /> 
                    <asp:RadioButton ID="radTerHill" runat="server" Text="Hilly" />
                        <br /> 
                    <asp:RadioButton ID="radTerRough" runat="server" Text="Rough" />
                        <br /> 
                    <asp:RadioButton ID="radTerMud" runat="server" Text="Muddy" />
                        <br /> 
                    <asp:RadioButton ID="radTerMount" runat="server" Text="Mountain" />
                        <br /> 
                    <asp:RadioButton ID="radTerValley" runat="server" Text="Valley" />
                        <br /> 
                    <asp:RadioButton ID="radTerForest" runat="server" Text="Forest" />
                        <br /> 
                    <asp:RadioButton ID="radTerMarsh" runat="server" Text="Marsh" />
                        <br /> 
                    <asp:RadioButton ID="radTerRiver" runat="server" Text="River" />
                        <br /> 
                    <asp:RadioButton ID="radTerBeach" runat="server" Text="Beach" />
                        <br />
                     <asp:RadioButton ID="radTerPark" runat="server" Text="Park" />
                        <br />
                        <br /> 
                    <asp:Button ID="btnClearTer" runat="server" Text="Clear Terrain" OnClick="btnClearTer_Click" />

                <asp:Button runat="server" ID="btnCancel" Text="Cancel" OnClick="btnCancel_Click" />
                <asp:Button runat="server" ID="btnSave" Text="Save Changes" OnClick="btnSave_Click" />
                    <br />
                </div>
        </div>
    </form>
</body>
</html>
