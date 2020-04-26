<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Walk_NewWalk_Part2.aspx.cs" Inherits="DogWalking.Admin_Side.Walks.Walk_NewWalk_Part2" %>

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
        <div>
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
                         <a href="../User/Users_ViewAdminUsers.aspx">View Admin Users</a>
                         <a href="../User/Users_CreateAccount.aspx">Create New User</a>
                      </div>
                </div>
                
            </div>

            <div class ="main">
                <div class="terrain">
                 <h2>Terrain</h2>
                    <p>Types of terrains on this walk:- (Select all that apply)</p>
                    <asp:RadioButton ID="radTerFlat" runat="server" Text="Flat" OnCheckedChanged="radTerFlat_CheckedChanged" />
                        <br /> 
                    <asp:RadioButton ID="radTerHill" runat="server" Text="Hilly" OnCheckedChanged="radTerHill_CheckedChanged" />
                        <br /> 
                    <asp:RadioButton ID="radTerRough" runat="server" Text="Rough" OnCheckedChanged="radTerRough_CheckedChanged" />
                        <br /> 
                    <asp:RadioButton ID="radTerMud" runat="server" Text="Muddy" OnCheckedChanged="radTerMud_CheckedChanged" />
                        <br /> 
                    <asp:RadioButton ID="radTerMount" runat="server" Text="Mountain" OnCheckedChanged="radTerMount_CheckedChanged" />
                        <br /> 
                    <asp:RadioButton ID="radTerValley" runat="server" Text="Valley" OnCheckedChanged="radTerValley_CheckedChanged" />
                        <br /> 
                    <asp:RadioButton ID="radTerForest" runat="server" Text="Forest" OnCheckedChanged="radTerForest_CheckedChanged" />
                        <br /> 
                    <asp:RadioButton ID="radTerMarsh" runat="server" Text="Marsh" OnCheckedChanged="radTerMarsh_CheckedChanged" />
                        <br /> 
                    <asp:RadioButton ID="radTerRiver" runat="server" Text="River" OnCheckedChanged="radTerRiver_CheckedChanged" />
                        <br /> 
                    <asp:RadioButton ID="radTerBeach" runat="server" Text="Beach" OnCheckedChanged="radTerBeach_CheckedChanged" />
                        <br />
                        <br /> 
                    <asp:Button ID="btnClearTer" runat="server" Text="Clear Terrain" OnClick="btnClearTer_Click" />
                    <br />
                </div>
                
                <div class="facilities">
                    <h2>Facility Details</h2>
                    <!--ENTRY FEE-->
                    <p>Does this walk have an entry fee?</p>
                        <asp:RadioButton ID="radEntryTrue" runat="server" Text="Yes" GroupName="Entry" OnCheckedChanged="radEntryTrue_CheckedChanged" />
                            <br /> 
                        <asp:RadioButton ID="radEntryFalse" runat="server" Text="No" GroupName="Entry" OnCheckedChanged="radEntryFalse_CheckedChanged" />
                            <br /> 

                    <asp:label ID="lblEntryTrue" runat="server">If yes, How much is the entry cost?</asp:label>
                    <asp:label ID="lblEntryFormat" runat="server">Please give format 00.00. </asp:label>
                    <asp:TextBox ID="txtEntryCost" runat="server" Width="167px" placeholder="Example £3 = 3.00"/>
                            <br /> 
                    <!--PARKING-->
                    <p>Does this walk have free parking?-</p>
                        <asp:RadioButton ID="radParkingTrue" runat="server" Text="Yes" GroupName="Park" OnCheckedChanged="radParkingTrue_CheckedChanged" />
                            <br /> 
                        <asp:RadioButton ID="radParkingFalse" runat="server" Text="No" GroupName="Park" OnCheckedChanged="radParkingFalse_CheckedChanged" />
                            <br /> 

                    <asp:label ID="lblParkingTrue" runat="server">If yes, any further parking details?</asp:label>
                    <asp:TextBox ID="txtParkDetails" runat="server" Width="167px" placeholder=" eg. Free with NT, Limited spaces."/>
                            <br /> 
                    <!-- LIVE STOCK -->
                    <p>Is there any live stock on this walk?</p>
                        <asp:RadioButton ID="radLiveTrue" runat="server" Text="Yes" GroupName="Live" OnCheckedChanged="radLiveTrue_CheckedChanged" />
                            <br /> 
                        <asp:RadioButton ID="radLiveFalse" runat="server" Text="No" GroupName="Live" OnCheckedChanged="radLiveFalse_CheckedChanged" />
                            <br /> 

                    <asp:label ID="lblLiveTrue" runat="server">If yes, any further live stock details?</asp:label>
                    <asp:TextBox ID="txtLiveDetails" runat="server" Width="167px" placeholder=" eg. Small gated area in the walk has live stock."/>
                            <br /> 
                    <!-- TOILETS -->
                    <p>Is there any toilet facilities on this walk?</p>
                        <asp:RadioButton ID="radToiletTrue" runat="server" Text="Yes" GroupName="Toilet" OnCheckedChanged="radToiletTrue_CheckedChanged"/>
                            <br /> 
                        <asp:RadioButton ID="radToiletFalse" runat="server" Text="No" GroupName="Toilet" OnCheckedChanged="radToiletFalse_CheckedChanged"/>
                            <br /> 

                    <asp:label ID="lblToiletTrue" runat="server">If yes, any further toilet facility details?</asp:label>
                    <asp:TextBox ID="txtToiletDetails" runat="server" Width="167px" placeholder=" eg. Toilets cost 20p, Toilets are located in the car park."/>
                            <br /> 
                    <!-- REFRESHMENTS -->
                    <p>Is there any refreshments available on this walk?-</p>
                        <asp:RadioButton ID="radRefreshTrue" runat="server" Text="Yes" GroupName="Refresh" OnCheckedChanged="radRefreshTrue_CheckedChanged" />
                            <br /> 
                        <asp:RadioButton ID="radRereshFalse" runat="server" Text="No" GroupName="Refresh" OnCheckedChanged="radRereshFalse_CheckedChanged" />
                            <br /> 

                    <asp:label ID="lblRefreshTrue" runat="server">If yes, any further refreshments details?</asp:label>
                    <asp:TextBox ID="txtRefreshDetails" runat="server" Width="167px" placeholder=" eg. Cafe is open Monday to Friday 10am-6pm."/>
                            <br /> 
                    <!-- LEAD AREAS -->
                    <p>Is this an on the lead, off the lead or both walk?-</p>
                        <asp:RadioButton ID="radLeadOn" runat="server" Text="On the Lead" OnCheckedChanged="radLeadOn_CheckedChanged" />
                            <br /> 
                        <asp:RadioButton ID="radLeadOff" runat="server" Text="Off the Lead" OnCheckedChanged="radLeadOff_CheckedChanged" />
                            <br />
                            <br />
                        <asp:Button ID="btnClearLead" runat="server" Text="Clear Lead Options" OnClick="btnClearLead_Click" />
                            <br /> 

                    <p>Further details on lead/off lead areas?lead/off lead areas?lead/off lead areas?lead/off lead areas?lead/off lead areas?</p>
                    <asp:TextBox ID="txtLeadDetails" runat="server" Width="167px" placeholder=" eg. All dogs must be on leads on sports fields."/>
                            <br /> 
                    <!-- WHEELCHAIR ACCESSIBILITY -->
   Is this walk Wheelchair friendly?</p>
                        <asp:RadioButton ID="radWheelTrue" runat="server" Text="Yes" GroupName="Wheel" OnCheckedChanged="radWheelTrue_CheckedChanged" />
                            <br /> 
                        <asp:RadioButton ID="radWheelFalse" runat="server" Text="No" GroupName="Wheel" OnCheckedChanged="radWheelFalse_CheckedChanged" />
                            <br /> 
                            <br /> 
                </div>

                <asp:Button ID="Back" runat="server" Text="Back" OnClick="Back_Click" />
                <asp:Button ID="Save" runat="server" Text="Save" OnClick="Save_Click" />
                <asp:Button ID="SavePublish" runat="server" Text="Save & Publish" OnClick="SavePublish_Click" />
                <br />
                <asp:Button ID="Cancel" runat="server" Text="Cancel" OnClick="Cancel_Click" />
            </div>
        </div>
    </form>
</body>
</html>
