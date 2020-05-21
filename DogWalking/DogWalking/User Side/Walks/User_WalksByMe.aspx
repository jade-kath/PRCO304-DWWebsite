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
            <asp:ListView ID="lstPending" runat="server"  DataKeyNames="WalkPostcode" OnSelectedIndexChanged="lstPending_SelectedIndexChanged">
                    <ItemTemplate>
                        <div class="list">
                            <table>
                                <tr><td><h3><%#Eval("WalkName")%> - <%#Eval("Location")%>, <%#Eval("WalkPostcode")%></h3></td></tr>
                                <tr><td><h4><%#Eval("Address")%></h4></td></tr>
                                <tr><td><p><%#Eval("Description")%></p></td></tr>
                            </table>
                        </div>
                    </ItemTemplate>
                </asp:ListView>

            <h3>Confirmed & Published</h3>
             <asp:ListView ID="lstConfirmed" runat="server"  DataKeyNames="WalkPostcode" OnSelectedIndexChanged="lstConfirmed_SelectedIndexChanged">
                    <ItemTemplate>
                        <div class="list">
                            <table>
                                <tr><td><img src="<%#Eval("ImagePath"%>" /></td></tr>
                                <tr><td><h3><%#Eval("WalkName")%> - <%#Eval("Location")%>, <%#Eval("WalkPostcode")%></h3></td></tr>
                                <tr><td><h4><%#Eval("Address")%></h4></td></tr>
                                <tr><td><p><%#Eval("Description")%></p></td></tr>
                            </table>
                        </div>
                    </ItemTemplate>
                </asp:ListView>
           </div>
    </form>
</body>
</html>
