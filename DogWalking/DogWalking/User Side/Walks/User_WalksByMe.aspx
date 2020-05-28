<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User_WalksByMe.aspx.cs" Inherits="DogWalking.User_Side.Walks.User_WalksByMe" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Lead The Way - Walks By Me</title>

    <link rel="stylesheet" href="../../Style/User_Buttons.css" />

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Walks By Me</h1>

            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" CssClass="btn-cancel" />
            <asp:Button ID="btnAddWalk" runat="server" Text="Add a New Walk" OnClick="btnAddWalk_Click" CssClass="btn-save" />
            <br />

            <h2>Pending Confirmation</h2>
            <asp:GridView ID="grdPending" runat="server" OnSelectedIndexChanged="grdPending_SelectedIndexChanged">
                <Columns>      
                    <asp:ButtonField Text="View Walk..." CommandName="Select" ItemStyle-Width="100"/>
                </Columns>
            </asp:GridView> 

            <h2>Confirmed & Published</h2>
             <asp:GridView ID="grdConfirmed" runat="server" OnSelectedIndexChanged="grdConfirmed_SelectedIndexChanged" >
                <Columns>      
                    <asp:ButtonField Text="View Walk..." CommandName="Select" ItemStyle-Width="100"/>
                </Columns>
            </asp:GridView> 
        </div>
    </form>
</body>
</html>
