<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User_AddOB.aspx.cs" Inherits="DogWalking.User_Side.Outbreaks.User_AddOB" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Lead The Way - Report a Dog Illness</title>

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

        <div class ="userMain">
             <h1>Report a Dog Illness</h1>
            <br />
            <p id="required">* indicates a required field</p>
            <br />

            <label>*</label><label>Walk Location:</label><br />
            <asp:DropDownList ID="drpLocation" runat="server" autoPostback="true" DataSourceID="SqlDataSource1" DataTextField="Location" DataValueField="LocationID" OnSelectedIndexChanged="drpLocation_SelectedIndexChanged"></asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=socem1.uopnet.plymouth.ac.uk;Initial Catalog=PRCO304_JMarshall;Persist Security Info=True;User ID=JMarshall;Password=PRCO304_22018506" ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [Location]"></asp:SqlDataSource>
            <br />

            <label>*</label><label>Walk Name:</label><br />
            <asp:GridView ID="grdWalkName" runat="server" OnSelectedIndexChanged="grdWalkName_SelectedIndexChanged">
                    <Columns>
                    <asp:ButtonField Text="Select" CommandName="Select" ItemStyle-Width="100"/>
                </Columns>
             </asp:GridView>
            <br />

            <label>*</label><label>Type of Illness:</label><br />
            <asp:TextBox runat="server" ID="txtIllType"></asp:TextBox>
            <br />

            <label>*</label><label>Date of Illnesses Occurrence:</label><br />
            <asp:TextBox ID="txtIllDate" runat="server" TextMode="Date" />
            <br />
            <label>Futher Description or Notes:</label><br />
            <asp:TextBox runat="server" ID="txtIllNotes" />
            <br />

            <asp:Label runat="server" ID="lblrequired" Visible="false">Please fill all the required fields.</asp:Label>
            <br />

            <asp:Button runat="server" ID="btnCancel" Text="Cancel" OnClick="btnCancel_Click" CssClass="btn-cancel" />
            <asp:Button runat="server" ID="btnSave" Text="Send Request" OnClick="btnSave_Click" CssClass="btn-save" />
        </div>
    </form>
</body>
</html>
