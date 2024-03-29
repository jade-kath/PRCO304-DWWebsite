﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserCreateAccount.aspx.cs" Inherits="DogWalking.User_Side.UserCreateAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Lead The Way - Sign Up</title>

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
              <asp:Button runat="server" ID="btnLogin" Text="Sign In/Register" OnClick="btnLogin_Click"/>
            </li>
          </ul>
        </nav>

        <div>
            <h1>Create an Account</h1>

            <p id="required">* indicates a required field</p>
            <br />

            <label>*</label><label>First Name:-</label>
            <asp:TextBox ID="txtFirstName" runat="server" Width="167px"/>
            <br />
            <label>*</label><label>Last Name:-</label>
            <asp:TextBox ID="txtLastName" runat="server" Width="163px"/>
            <br />
            <label>*</label><label>Date of Birth:-</label>
            <asp:TextBox ID="txtDOB" runat="server" TextMode="Date" Width="158px" />
            <br />
            <label>*</label><label>What area do you live in?-</label>
            <asp:DropDownList ID="drpLocation" runat="server" DataSourceID="SqlDataSource1" DataTextField="Location" DataValueField="LocationID">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=socem1.uopnet.plymouth.ac.uk;Initial Catalog=PRCO304_JMarshall;Persist Security Info=True;User ID=JMarshall;Password=PRCO304_22018506" ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [Location]"></asp:SqlDataSource>
            <br />
            <label>*</label><label>Email Address:-</label>
            <asp:TextBox ID="txtUserEmail" runat="server" TextMode="Email" Width="149px"/>
            <br />
            <label>*</label><label>Create a Username:-</label>
            <asp:TextBox ID="txtUserUsername" runat="server"/>
            <br />
            <label>*</label><label>Create a Password:-</label>
            <asp:TextBox ID="txtUserPassword" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>

            <br />

            <asp:Label runat="server" ID="lblrequired" Visible="false">Please fill all the required fields.</asp:Label>

            <br />
            <br />
            <asp:Button ID="btnCreateAccount" runat="server" Text="Create Account" Width="216px" OnClick="btnCreateAccount_Click" CssClass="btn-save" />

            

        </div>
    </form>
</body>
</html>
