﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="DogWalking.UserProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Lead The Way - My Profile</title>

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

        <div class="userMain">
            <h1>My Profile</h1>

            <br />
            <br />

            <p><a href="CRUD User Settings/UserEditSettings.aspx">Edit My Profile</a></p>

            <div class="collection">
                <div class="searchWalk">
                    <h2>Where would you like to go?</h2>
                    <p>There's so many to choose from for every type of furry friend. Search by County or Postcode to find walks in your area.</p>
                    <asp:Button runat="server" ID="btnSearch" Text="Search for a Walk" OnClick="btnSearch_Click" CssClass="btn-save" />
                </div>

                <div class="addWalk">
                    <h2>Can't see a dog walk that you know of?</h2>
                    <p>Please add it to our database for others to enjoy!</p>
                    <asp:Button runat="server" ID="btnAddWalk" Text="Add a Walk" OnClick="btnAddWalk_Click" CssClass="btn-save" />
                </div>

                <div class="addOutbreak">
                    <h2>Keep your dog safe!<br />Have you heard of a dog illness related to a walk?</h2>
                    <p>Seasonal Canine Illnesses (SCI), Kennel Cough and so on can make your dog seriously ill, most of which are spread through dogs socialising. Report illnesses to protect all dogs.</p>
                    <asp:Button runat="server" ID="btnAddOutbreak" Text="Report an Illness" OnClick="btnAddOutbreak_Click" CssClass="btn-save" />
                </div>
            </div>

            <div class="myWalks">
                <h2>Walks By Me</h2>
                <asp:ListView ID="lstMyWalks" runat="server"  DataKeyNames="WalkPostcode" OnSelectedIndexChanged="lstMyWalks_SelectedIndexChanged" >
                    <ItemTemplate>
                        <div class="list">
                            <table>
                                <tr><td><img src="<%#Eval("ImagePath")%>" /></td></tr>
                                <tr><td><h3><%#Eval("WalkName")%> - <%#Eval("Location")%>, <%#Eval("WalkPostcode")%></h3></td></tr>
                                <tr><td><h4><%#Eval("Address")%></h4></td></tr>
                                <tr><td><p><%#Eval("Description")%></p></td></tr>
                            </table>
                        </div>
                    </ItemTemplate>
                </asp:ListView>
                <p><a href="Walks/User_WalksByMe.aspx">View All...</a></p>
            </div>

            <div class="myReportedIllness">
                <h2>My Reported Dog Illnesses</h2>
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
                <p><a href="Outbreaks/User_ReportedOB.aspx">View All...</a></p>
            </div>

        </div>
    </form>
</body>
</html>
