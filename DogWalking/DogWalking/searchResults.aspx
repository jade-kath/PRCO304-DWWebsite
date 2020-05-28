<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="searchResults.aspx.cs" Inherits="DogWalking.searchResults" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Lead The Way</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="search">
                <p>Where would you like to go?</p>
                <asp:TextBox ID="txtSearchBar" runat="server" placeholder="eg. London"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
            </div>

            <br />

            <div class="allWalks">
                <h2>Results</h2>

                <asp:Label runat="server" ID="lblNoResults" Visible="false">No Results Found</asp:Label>

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
