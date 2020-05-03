<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="searchResults.aspx.cs" Inherits="DogWalking.searchResults" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="search">
                <p>Where would you like to go?</p>
                    <asp:Panel ID="Panel1" runat="server" DefaultButton="btnSearch">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                             <ContentTemplate>
                                 <asp:TextBox ID="txtSearchBar" runat="server" placeholder="eg. London"></asp:TextBox>
                                 <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                             </ContentTemplate>
                        </asp:UpdatePanel>
                    </asp:Panel>
            </div>

            <br />
            <asp:GridView ID="grdWalkResults" runat="server" OnSelectedIndexChanged="grdWalkResults_SelectedIndexChanged"></asp:GridView>
        </div>
    </form>
</body>
</html>
