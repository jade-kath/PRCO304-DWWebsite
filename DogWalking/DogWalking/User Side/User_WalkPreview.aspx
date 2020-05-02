<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User_WalkPreview.aspx.cs" Inherits="DogWalking.User_Side.User_WalkPreview" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            
            <asp:Button runat="server" ID="btnBack" Text="Back" OnClick="btnBack_Click" />
            <br />
            <asp:Label runat="server" ID="lblStatus" Visible="false"></asp:Label>
            <asp:Button runat="server" ID="btnDel" Text="Delete Walk Request" Visible="false" OnClick="btnDel_Click" OnClientClick="if ( !confirm('Are you sure you want to delete this user?')) return false;"/>
            <br />
            <div class="general">
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
                    <br />
                <asp:Label ID="lblDist" runat="server" ReadOnly="true"/>
                    <br />
            </div>
                    <br />

            <div class="terrain">
                <h3>Terrain:</h3>
                <asp:GridView ID="grdTerrain" runat="server"></asp:GridView>
                    <br />
            </div>

            <div class="leads">
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
        </div>
    </form>
</body>
</html>
