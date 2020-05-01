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
            <asp:GridView ID="grdMyWalks" runat="server">
                <Columns>
                    <asp:ButtonField Text="Delete" CommandName="Select" ItemStyle-Width="100"/>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
