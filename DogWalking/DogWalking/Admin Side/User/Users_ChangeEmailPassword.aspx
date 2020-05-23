<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Users_ChangeEmailPassword.aspx.cs" Inherits="DogWalking.Admin_Side.AdminChangeEmail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Lead The Way - Admin</title>
    
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
                         <a href="../User/Users_CreateAccount.asp
                      </div>
                </div>
                         <asp:Button runat="server" ID="btnLogOut" Text="Sign Out" OnClick="btnLogOut_Click" />
            </div>
        
      
        <div class="main">

            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />

             <div id="changeEmail">
                 <h1>Change Email    <h1>Change Email</h1>      
                  <p id="required">* indicates a required field</p>
                   <br />
                  <label>*</label><label>New Email Address:-</label>
                  <asp:TextBox ID="txtNewEmail" runat="server" TextMode="Email" Width="167px"/>
                  <br />
                  <label>*</label><label>Enter admin password to confirm change:-</label>
                  <asp:TextBox ID="txtEmailPassword" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>
                  <br />
                  <asp:Label runat="server" ID="lblrequired" Visible="false">Please fill all the required fields.</asp:Label>
                  <br />
                  <asp:Button ID="SaveEmailChanges" runat="server" Text="Save Email Changes" OnClick="SaveEmailChanges_Click" />
                  <br />
                  <asp:label ID="lblEmailSaved" runat="server" Visible="false">*Your changes have been saved</asp:label>
            </div>

            <br />

            <div id="changePassword">
                <h1>Change Password</h1>
                     <p id="required">* indicates a required field</p>
                     <br />
                      <label>*</label><label>New Password:-</label>
                     <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>
                     <br />
                      <label>*</label><label>Enter admin password to confirm changes:-</label>
                     <asp:TextBox ID="txtPassPassword" runat="server" Width="167px"/>
                     <br />
                     <asp:Label runat="server" ID="lblReqPass" Visible="false">Please fill all the required fields.</asp:Label>
                     <br />
                     <asp:Button ID="SavePasswordChanges" runat="server" Text="Save Password Changes" OnClick="SavePasswordChanges_Click" />
                     <br />
                     <asp:label ID="lblPasswordSaved" runat="server" Visible="false">*Your changes have been saved</asp:label>
             </div>
         </div>
    </form>
</body>
</html>
