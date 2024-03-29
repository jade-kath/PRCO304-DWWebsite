﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OB_AddOB.aspx.cs" Inherits="DogWalking.Admin_Side.Outbreaks.OB_AddOB" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Lead The Way - Add Dog Illness Report</title>

    <link rel="stylesheet" href="../../Style/Admin_Navbar.css" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous">

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
            <h1>Report a Dog Illness</h1>
            <br />
            <p id="required">* indicates a required field</p>
            <br />

            <label>Walk Location:</label><br />
            <asp:DropDownList ID="drpLocation" runat="server" autoPostback="true" DataSourceID="SqlDataSource1" DataTextField="Location" DataValueField="LocationID" OnSelectedIndexChanged="drpLocation_SelectedIndexChanged"></asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=socem1.uopnet.plymouth.ac.uk;Initial Catalog=PRCO304_JMarshall;Persist Security Info=True;User ID=JMarshall;Password=PRCO304_22018506" ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [Location]"></asp:SqlDataSource>
            <br />

            <label>*</label><label>Walk Name:</label><br />
            <asp:GridView ID="grdWalkName" runat="server" OnSelectedIndexChanged="grdWalkName_SelectedIndexChanged">
                    <Columns>
                    <asp:ButtonField Text="Select" CommandName="Select" ItemStyle-Width="100"/>
                </Columns>
             </asp:GridView>

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

            <asp:Button runat="server" ID="btnCancel" Text="Cancel" OnClick="btnCancel_Click" />
            <asp:Button runat="server" ID="btnSave" Text="Save & Publish" OnClick="btnSave_Click" />
        </div>
    </form>
</body>
</html>
