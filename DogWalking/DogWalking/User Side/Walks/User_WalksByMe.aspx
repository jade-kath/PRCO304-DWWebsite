<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User_WalksByMe.aspx.cs" Inherits="DogWalking.User_Side.Walks.User_WalksByMe" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Walks By Me</h2>

            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
            <asp:Button ID="btnAddWalk" runat="server" Text="Add a New Walk" OnClick="btnAddWalk_Click" />
            <br />

            <h3>Pending Confirmation</h3>
            <asp:GridView ID="grdMyWalksPending" runat="server" datakeynames="WalkPostcode" OnSelectedIndexChanged="grdMyWalksPending_SelectedIndexChanged">
                <Columns>
                    <asp:ButtonField Text="Select" CommandName="Select" ItemStyle-Width="100" />
                </Columns>
            </asp:GridView>

            <h3>Published</h3>
            <asp:GridView ID="grdMyWalksConfirmed" runat="server" datakeysnames="WalkPostcode" OnSelectedIndexChanged="grdMyWalksConfirmed_SelectedIndexChanged">
                <Columns>
                    <asp:ButtonField Text="Select" CommandName="Select" ItemStyle-Width="100"/>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
