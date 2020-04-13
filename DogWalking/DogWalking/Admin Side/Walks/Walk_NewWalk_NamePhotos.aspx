<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Walk_NewWalk_NamePhotos.aspx.cs" Inherits="DogWalking.Admin_Side.Walks.Walk_WalkDetails" %>

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
        
        <div class="main">

            <h2>Walk</h2>

                <div class="walkName">
                    <h2>General Details</h2>
                    <p>Name of this walk/place:-</p>
                        <asp:TextBox ID="txtPlaceName" runat="server" Width="167px"/>
                             <br />
                    <p>Address:-</p>
                        <asp:TextBox ID="txtAddress" runat="server" Width="167px"/>
                             <br />
                    <p>Postcode:-</p>
                        <asp:TextBox ID="txtPostcode" runat="server" Width="163px"/>
                             <br /> 
                    <p>Location:-</p>
                        <asp:DropDownList ID="drpLocation" runat="server" DataSourceID="SqlDataSource1" DataTextField="Location" DataValueField="LocationID"></asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=socem1.uopnet.plymouth.ac.uk;Initial Catalog=PRCO304_JMarshall;Persist Security Info=True;User ID=JMarshall;Password=PRCO304_22018506" ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [Location]"></asp:SqlDataSource>
                             <br />
                    <p>A Description of this walk:-</p>
                        <asp:TextBox ID="txtDescript" runat="server" Width="163px"/>
                             <br /> 
                    <p>Typically how long would you spend walking at this location?-</p>
                        <asp:TextBox ID="txtTimeLength" runat="server" Width="163px" placeholder="eg. 2 hours or 30 minutes"/>
                             <br />
                    <p>Distance/Size of the walk or area:-</p>
                        <asp:TextBox ID="txtDuration" runat="server" Width="163px" placeholder="eg. 2km, 5 miles, 150 acres"/>
                             <br />
                </div>
                <div class="gallery">
                    <p>Upload an image to use as the cover photo</p>
                    <asp:TextBox ID="txtCoverImg" runat="server" Width="163px"/>

                    <br />

                </div>

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
                </div>
                
                <div class="facilities">
                    <h2>Facility Details</h2>
                    <!--ENTRY FEE-->
                    <p>Does this walk have an entry fee?</p>
                        <asp:RadioButton ID="radEntryTrue" runat="server" Text="Yes" OnCheckedChanged="radEntryTrue_CheckedChanged" />
                            <br /> 
                        <asp:RadioButton ID="radEntryFalse" runat="server" Text="No" OnCheckedChanged="radEntryFalse_CheckedChanged" />
                            <br /> 

                    <asp:label ID="lblEntryTrue" runat="server" Visible="false">How much is the entry cost?</asp:label>
                    <asp:label ID="lblEntryFormat" runat="server" Visible="false">Please give format 00.00. </asp:label>
                    <asp:TextBox ID="txtEntryCost" runat="server" Width="167px" Visible="false" placeholder="Example £3 = 3.00"/>
                            <br /> 
                    <!--PARKING-->
                    <p>Does this walk have free parking?- have free parking?-</p>
                        <asp:RadioButton ID="radParkingTrue" runat="server" Text="Yes" OnCheckedChanged="radParkingTrue_CheckedChanged" />
                            <br /> 
                        <asp:RadioButton ID="radParkingFalse" runat="server" Text="No" OnCheckedChanged="radParkingFalse_CheckedChanged" />
                            <br /> 

                    <asp:label ID="lblParkingTrue" runat="server" Visible="false">Further parking details?</asp:label>
                    <asp:TextBox ID="txtParkDetails" runat="server" Width="167px" Visible="false" placeholder=" eg. Free with NT, Limited spaces."/>
                            <br /> 
                    <!-- LIVE STOCK -->
                    <p>Is there any live stock on this walk?</p>
                        <asp:RadioButton ID="radLiveTrue" runat="server" Text="Yes" OnCheckedChanged="radLiveTrue_CheckedChanged" />
                            <br /> 
                        <asp:RadioButton ID="radLiveFalse" runat="server" Text="No" OnCheckedChanged="radLiveFalse_CheckedChanged" />
                            <br /> 

                    <asp:label ID="lblLiveTrue" runat="server" Visible="false">Further live stock details?</asp:label>
                    <asp:TextBox ID="txtLiveDetails" runat="server" Width="167px" Visible="false" placeholder=" eg. Small gated area in the walk has live stock."/>
                            <br /> 
                    <!-- TOILETS -->
                    <p>Is there any toilet facilities on this walk?</p>
                        <asp:RadioButton ID="radToiletTrue" runat="server" Text="Yes" OnCheckedChanged="radToiletTrue_CheckedChanged"/>
                            <br /> 
                        <asp:RadioButton ID="radToiletFalse" runat="server" Text="No" OnCheckedChanged="radToiletFalse_CheckedChanged"/>
                            <br /> 

                    <asp:label ID="lblToiletTrue" runat="server" Visible="false">Further toilet facility details?</asp:label>
                    <asp:TextBox ID="txtToiletDetails" runat="server" Width="167px" Visible="false" placeholder=" eg. Toilets cost 20p, Toilets are located in the car park."/>
                            <br /> 
                    <!-- REFRESHMENTS -->
                    <p>Is there any refreshments available on this walk?-</p>
                        <asp:RadioButton ID="radRefreshTrue" runat="server" Text="Yes" OnCheckedChanged="radRefreshTrue_CheckedChanged" />
                            <br /> 
                        <asp:RadioButton ID="radRereshFalse" runat="server" Text="No" OnCheckedChanged="radRereshFalse_CheckedChanged" />
                            <br /> 

                    <asp:label ID="lblRefreshTrue" runat="server" Visible="false">Further refreshments details?</asp:label>
                    <asp:TextBox ID="txtRefreshDetails" runat="server" Width="167px" Visible="false" placeholder=" eg. Cafe is open Monday to Friday 10am-6pm."/>
                            <br /> 
                    <!-- LEAD AREAS -->
                    <p>Is this an on the lead, off the lead or both walk?-</p>
                        <asp:RadioButton ID="radLeadOn" runat="server" Text="On the Lead" OnCheckedChanged="radLeadOn_CheckedChanged" />
                            <br /> 
                        <asp:RadioButton ID="radLeadOff" runat="server" Text="Off the Lead" OnCheckedChanged="radLeadOff_CheckedChanged" />
                            <br /> 

                    <p>Further details on lead/off lead areas?lead/off lead areas?lead/off lead areas?</p>
                    <asp:TextBox ID="txtLeadDetails" runat="server" Width="167px" placeholder=" eg. All dogs must be on leads on sports fields."/>
                            <br /> 
                    <!-- WHEELCHAIR ACCESSIBILITY -->
                    <p>Is this walk Wheelchair friendly?</p>
                        <asp:RadioButton ID="radWheelTrue" runat="server" Text="Yes" OnCheckedChanged="radWheelTrue_CheckedChanged" />
                            <br /> 
                        <asp:RadioButton ID="radWheelFalse" runat="server" Text="No" OnCheckedChanged="radWheelFalse_CheckedChanged" />
                            <br /> 
                            <br /> 

                </div>

            <asp:Button ID="SaveChanges" runat="server" Text="Save Walk" OnClick="SaveChanges_Click" />

            <br />

            <br />
                <div id="clone" runat="server" Visible ="false">
                    <p>There's a walk that already exists with this postcode. Would you like to create it anyway?to create it anyway?to create it anyway?</p>
                    <asp:Button ID="noCancel" runat="server" Text="Cancel" />
                    <asp:Button ID="yesCont" runat="server" Text="Yes - Save" />                  
                </div>

           </div>
        </div>
    </form>
</body>
</html>
