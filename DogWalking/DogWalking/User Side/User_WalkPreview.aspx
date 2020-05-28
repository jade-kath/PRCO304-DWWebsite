<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User_WalkPreview.aspx.cs" Inherits="DogWalking.User_Side.User_WalkPreview" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Lead The Way</title>

    <link rel="stylesheet" href="../Style/User_Buttons.css" />
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
            <asp:Button runat="server" ID="btnBack" Text="Back" OnClick="btnBack_Click" CssClass="btn-cancel" />
            <br />

            <div class="userCreated">
                <asp:Label runat="server" ID="lblStatus"></asp:Label>
                <asp:Button runat="server" ID="btnDel" Text="Delete Walk Request" Visible="false" OnClick="btnDel_Click" OnClientClick="if ( !confirm('Are you sure you want to delete this user?')) return false;" CssClass="btn-delete" />
            </div>
            <br />

            <div class="general">
                <asp:ListView ID="lstImage" runat="server">
                    <ItemTemplate>
                        <div>
                            <table>
                                <tr><td><img src="<%#Eval("ImagePath") %>" /></td></tr>
                            </table>
                        </div>
                    </ItemTemplate>
                </asp:ListView>
                
                <asp:Label ID="lblWalkName" runat="server"></asp:Label>
                <br />
                <asp:Label ID="lblAddr" runat="server"></asp:Label>
                <asp:Label ID="lblPostcode" runat="server" />
                <br />
                <asp:Label ID="lblLocate" runat="server"></asp:Label>
                <br />
                <asp:Label ID="lblDescribe" runat="server"></asp:Label>
                <br />

                <label>Time spent here:</label>
                <asp:Label ID="lblTime" runat="server"/>
                    <br />
                <label>Distance of this Walk:</label>
                <asp:Label ID="lblDist" runat="server"/>
                    <br />
            </div>
                    <br />

            <div class="terrain">
                <h2>Terrain</h2>
                <asp:GridView ID="grdTerrain" runat="server"></asp:GridView>
                    <br />
            </div>

            <div class="leads">
              <h2>Lead Information</h2>
                <asp:Label ID="lblLeaded" runat="server" />
                    <br />
                <asp:Label ID="lblNonLead" runat="server" />
                    <br />
                <asp:Label ID="lblLeadDetail" runat="server" />
                    <br />
                    <br />
            </div>

             <div class="facilities">
                 <h2>Facilities</h2>
                <div class="entry">
                    <h3>Entry Fee</h3>
                    <asp:Label ID="lblEntry" runat="server" />
                    <br />
                    <asp:Label ID="lblEntryDetail" runat="server" />
                    <br />
                </div>
                
                <div class="parking">
                    <h3>Parking</h3>
                    <asp:Label ID="lblPark" runat="server" />
                    <br />
                    <asp:Label ID="lblParkDetail" runat="server" />
                    <br />
                </div>

                <div class="livestock">
                    <h3>Live Stock</h3>
                    <asp:Label ID="lblLive" runat="server" />
                    <br />
                    <asp:Label ID="lblLiveDetail" runat="server" />
                    <br />
                </div>

                <div class="toilets">
                    <h3>Toilets</h3>
                    <asp:Label ID="lblToilet" runat="server" />
                    <br />
                    <asp:Label ID="lblToiletDetail" runat="server" />
                    <br />
                </div>

                <div class="refreshments">
                    <h3>Refreshments</h3>
                    <asp:Label ID="lblRefresh" runat="server" />
                    <br />
                    <asp:Label ID="lblRefreshDetail" runat="server" />
                </div>

                <div class="wheelchair">
                    <h3>Wheelchair Friendly</h3>
                    <asp:Label ID="lblWheel" runat="server" />
                    <br />
                </div>

            </div>

            <br />
            <div class="creation">
                <asp:Label ID="lblCreated" runat="server" />
            </div>
            <br />

            <div class="outbreaks">      
                <h2>Dog Illness Reported</h2>
                <asp:ListView ID="lstOutbreaks" runat="server" DataKeyNames="WalkPostcode">
                    <ItemTemplate>
                        <div class="list">
                            <table>
                                <tr><td><h3><%#Eval("OutbreakDate")%> - <%#Eval("OutbreakType")%></h3></td></tr>
                                <tr><td><h4><%#Eval("WalkName")%>, <%#Eval("Location")%>, <%#Eval("WalkPostcode")%></h4></td></tr>
                                <tr><td><p><%#Eval("ODecription")%></p></td></tr>
                                <tr><td><p><%#Eval("Username")%></p></td></tr>
                            </table>
                        </div>
                    </ItemTemplate>
                </asp:ListView>
            </div>
            
        </div>
    </form>
</body>
</html>
