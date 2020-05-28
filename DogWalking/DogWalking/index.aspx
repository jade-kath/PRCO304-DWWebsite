<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="DogWalking.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Lead The Way</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="userMain">

            <p><a href="LoginPage.aspx">Log in</a></p>

            <div class="search">
                <p>Where would you like to go?</p>
                <asp:TextBox ID="txtSearchBar" runat="server" placeholder="eg. London, Devon, Central Park"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
            </div>

            <div class="randomWalks">
                <h2>All Walks</h2>
                <asp:GridView ID="grdWalks" runat="server" OnSelectedIndexChanged="grdWalks_SelectedIndexChanged1" >
                <Columns>      
                    <asp:ButtonField Text="More Details..." CommandName="Select" ItemStyle-Width="100"/>
                </Columns>
                </asp:GridView>
            </div>


        </div>
    </form>
</body>
</html>
