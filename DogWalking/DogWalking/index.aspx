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
                    <asp:Panel ID="Panel1" runat="server" DefaultButton="btnSearch">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                             <ContentTemplate>
                                 <asp:TextBox ID="txtSearchBar" runat="server" placeholder="eg. London, Devon, Central Park"></asp:TextBox>
                                 <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                             </ContentTemplate>
                        </asp:UpdatePanel>
                    </asp:Panel>
            </div>

            <div class="randomWalks">
                <h2>All Walks</h2>
                <asp:ListView ID="lstAll" runat="server"  DataKeyNames="WalkPostcode" OnSelectedIndexChanged="lstConfirmed_SelectedIndexChanged">
                    <ItemTemplate>
                        <div class="list">
                            <table>
                                <tr><td><img src="<%#Eval("ImagePath")%>" /></td></tr>
                                <tr><td><h3><%#Eval("WalkName")%> - <%#Eval("Location")%>, <%#Eval("WalkPostcode")%></h3></td></tr>
                                <tr><td><h4><%#Eval("Address")%></h4></td></tr>
                                <tr><td><p><%#Eval("Description")%></p></td></tr>
                            </table>
                        </div>
                    </ItemTemplate>
                </asp:ListView>
            </div>


        </div>
    </form>
</body>
</html>
