<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Walk_NewWalk_TerrainFacilities.aspx.cs" Inherits="DogWalking.Admin_Side.Walks.Walk_WalkDetails_TerrainFacilities" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link rel="stylesheet" href="../../Style/Admin_Navbar.css" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous"/>

    <script src="https://code.jquery.com/jquery-3.4.1.slim.min.js" integrity="sha384-J6qa4849blE2+poT4WnyKhv5vZF5SrPo0iEjwBvKU7imGFAV0wwj1yYfoRSJoZ+n" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js" integrity="sha384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6" crossorigin="anonymous"></script>
   <style>
       .facilities{
           margin-top: 10px;
       }
   </style>
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
                      </div>
                 </div>
                
                         <a href="#">Oubreaks</a>

                <div class="dropdown">
                  <button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton-User" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                    Users
                  </button>
                      <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                         <a href="../User/Users_ViewUsers.aspx">View Users</a>
                         <a href="../User/Users_ViewAdminUsers.aspx">View Admin Users</a>
                         <a href="../User/Users_CreateAccount.aspx">Create New User</a>
                      </div>
                </div>
            </div>

        <div class="main">
            <div class="terrain">
                    <label>Types of terrains on this walk:- (Select all 
                        <br />
                    <asp:RadioButton ID="radTerFlat" runat="server" Text="Flat" OnCheckedChanged="radTerFlat_CheckedChanged"/>
                        <br /> 
                    <asp:RadioButton ID="radTerHill" runat="server" Text="Hilly" OnCheckedChanged="radTerHill_CheckedChanged"/>
                        <br /> 
                    <asp:RadioButton ID="radTerRough" runat="server" Text="Rough" OnCheckedChanged="radTerRough_CheckedChanged"/>
                        <br /> 
                    <asp:RadioButton ID="radTerMud" runat="server" Text="Muddy" OnCheckedChanged="radTerMud_CheckedChanged"/>
                        <br /> 
                    <asp:RadioButton ID="radTerMount" runat="server" Text="Mountain" OnCheckedChanged="radTerMount_CheckedChanged"/>
                        <br /> 
                    <asp:RadioButton ID="radTerValley" runat="server" Text="Valley" OnCheckedChanged="radTerValley_CheckedChanged"/>
                        <br /> 
                    <asp:RadioButton ID="radTerForest" runat="server" Text="Forest" OnCheckedChanged="radTerForest_CheckedChanged"/>
                        <br /> 
                    <asp:RadioButton ID="radTerMarsh" runat="server" Text="Marsh" OnCheckedChanged="radTerMarsh_CheckedChanged"/>
                        <br /> 
                    <asp:RadioButton ID="radTerRiver" runat="server" Text="River" OnCheckedChanged="radTerRiver_CheckedChanged"/>
                        <br /> 
                    <asp:RadioButton ID="radTerBeach" runat="server" Text="Beach" OnCheckedChanged="radTerBeach_CheckedChanged"/>
                        <br /> 
                </div>
                
                <div class="facilities">

                    <!--ENTRY FEE-->
                    <label>Does this walk have an entry fee?k</label>
                            <br />
                        <asp:RadioButton ID="radEntryTrue" runat="server" Text="Yes" AutoPostBack ="true"/>
                            <br /> 
                        <asp:RadioButton ID="radEntryFalse" runat="server" Text="No" OnCheckedChanged="radEntryFalse_CheckedChanged"/>
                            <br /> 

                    <asp:label ID="lblEntryTrue" runat="server" Visible="false">How much is the entry cost?</asp:label>
                    <asp:label ID="lblEntryFormat" runat="server" Visible="false">Please give format 00.00. </asp:label>
                    <asp:TextBox ID="txtEntryCost" runat="server" Width="167px" Visible="false" placeholder="Example £3 = 3.00"/>
                            <br /> 
                    <!--PARKING-->
                    <label>Does this walk have free parking?- have free parking?-</label>
                            <br />
                        <asp:RadioButton ID="radParkingTrue" runat="server" Text="Yes" OnCheckedChanged="radParkingTrue_CheckedChanged"/>
                            <br /> 
                        <asp:RadioButton ID="radParkingFalse" runat="server" Text="No" OnCheckedChanged="radParkingFalse_CheckedChanged"/>
                            <br /> 

                    <asp:label ID="lblParkingTrue" runat="server" Visible="false">Further parking details?</asp:label>
                    <asp:TextBox ID="txtParkDetails" runat="server" Width="167px" Visible="false" placeholder=" eg. Free with NT, Limited spaces."/>
                            <br /> 
                    <!-- LIVE STOCK -->
                    <label>Is there any live stock on this walk?</label>
                            <br />
                        <asp:RadioButton ID="radLiveTrue" runat="server" Text="Yes" OnCheckedChanged="radLiveTrue_CheckedChanged"/>
                            <br /> 
                        <asp:RadioButton ID="radLiveFalse" runat="server" Text="No" OnCheckedChanged="radLiveFalse_CheckedChanged"/>
                            <br /> 

                    <asp:label ID="lblLiveTrue" runat="server" Visible="false">Further live stock details?</asp:label>
                    <asp:TextBox ID="txtLiveDetails" runat="server" Width="167px" Visible="false" placeholder=" eg. Small gated area in the walk has live stock."/>
                            <br /> 
                    <!-- TOILETS -->
                    <label>Is there any toilet facilities on this walk?</label>
                            <br />
                        <asp:RadioButton ID="radToiletTrue" runat="server" Text="Yes"/>
                            <br /> 
                        <asp:RadioButton ID="radToiletFalse" runat="server" Text="No"/>
                            <br /> 

                    <asp:label ID="lblToiletTrue" runat="server" Visible="false">Further toilet facility details?</asp:label>
                    <asp:TextBox ID="txtToiletDetails" runat="server" Width="167px" Visible="false" placeholder=" eg. Toilets cost 20p, Toilets are located in the car park."/>
                            <br /> 
                    <!-- REFRESHMENTS -->
                    <label>Is there any refreshments available on this walk?-</label>
                            <br />
                        <asp:RadioButton ID="radRefreshTrue" runat="server" Text="Yes" OnCheckedChanged="radRefreshTrue_CheckedChanged"/>
                            <br /> 
                        <asp:RadioButton ID="radRereshFalse" runat="server" Text="No" OnCheckedChanged="radRereshFalse_CheckedChanged"/>
                            <br /> 

                    <asp:label ID="lblRefreshTrue" runat="server" Visible="false">Further refreshments details?</asp:label>
                    <asp:TextBox ID="txtRefreshDetails" runat="server" Width="167px" Visible="false" placeholder=" eg. Cafe is open Monday to Friday 10am-6pm."/>
                            <br /> 
                    <!-- LEAD AREAS -->
                    <label>Is this an on the lead, off the lead or both walk?-</label>
                            <br />
                        <asp:RadioButton ID="radLeadOn" runat="server" Text="On the Lead" OnCheckedChanged="radLeadOn_CheckedChanged"/>
                            <br /> 
                        <asp:RadioButton ID="radLeadOff" runat="server" Text="Off the Lead" OnCheckedChanged="radLeadOff_CheckedChanged"/>
                            <br /> 

                    <label>Further details on lead/off lead areas?lead/off lead areas?</label>
                    <asp:TextBox ID="txtLeadDetails" runat="server" Width="167px" placeholder=" eg. All dogs must be on leads on sports fields."/>
                            <br /> 
                    <!-- WHEELCHAIR ACCESSIBILITY -->
                    <label>Is this walk Wheelchair 
                            <br />
                        <asp:RadioButton ID="radWheelTrue" runat="server" Text="Yes" OnCheckedChanged="radWheelTrue_CheckedChanged"/>
                            <br /> 
                        <asp:RadioButton ID="radWheelFalse" runat="server" Text="No" OnCheckedChanged="radWheelFalse_CheckedChanged"/>
                            <br /> 
                            <br /> 

                </div>
            <asp:Button ID="btnBack" runat="server" Text="Previous Page" OnClick="btnBack_Click" />
            <asp:Button ID="btnSave" runat="server" Text="Create Walk" OnClick="btnSaveChanges_Click" />

        </div>
    </form>
</body>
</html>
