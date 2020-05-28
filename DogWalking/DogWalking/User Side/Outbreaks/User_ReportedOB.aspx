<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User_ReportedOB.aspx.cs" Inherits="DogWalking.User_Side.Outbreaks.User_ReportedOB" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Lead The Way - My Reported Dog Illnesses</title>

    <link rel="stylesheet" href="../../Style/User_Buttons.css" />

</head>
<body>
    <form id="form1" runat="server">
        <div class="userMain">
            <h1>My Reported Dog Illnesses</h1>
            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" CssClass="btn-cancel" />
            <asp:Button ID="btnNewOutbreak" runat="server" Text="Report a Dog Illness" OnClick="btnNewOutbreak_Click" />

            <asp:GridView ID="grdRepOB" runat="server" OnSelectedIndexChanged="grdRepOB_SelectedIndexChanged">
                <Columns>      
                    <asp:ButtonField Text="View Walk..." CommandName="Select" ItemStyle-Width="100"/>
                </Columns>
            </asp:GridView> 
        </div>
    </form>
</body>
</html>
