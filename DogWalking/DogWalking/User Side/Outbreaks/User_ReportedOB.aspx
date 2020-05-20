<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User_ReportedOB.aspx.cs" Inherits="DogWalking.User_Side.Outbreaks.User_ReportedOB" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="userMain">
            <h2>My Report Dog Illnesses</h2>
            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
            <asp:Button ID="btnNewOutbreak" runat="server" Text="Report a Dog Illness" OnClick="btnNewOutbreak_Click" />
                <asp:ListView ID="lstOutbreaks" runat="server">
                    <ItemTemplate>
                        <div class="list">
                            <table>
                                <tr><td><h3><%#Eval("OutbreakDate")%> - <%#Eval("OutbreakType")%></h3></td></tr>
                                <tr><td><h4><%#Eval("WalkName")%>, <%#Eval("Location")%></h4></td></tr>
                                <tr><td><p><%#Eval("ODecription")%></p></td></tr>
                                <tr><td><p><%#Eval("Username")%></p></td></tr>
                            </table>
                        </div>
                    </ItemTemplate>
                </asp:ListView>
        </div>
    </form>
</body>
</html>
