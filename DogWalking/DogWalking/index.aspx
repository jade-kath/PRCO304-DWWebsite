﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="DogWalking.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p><a href="LoginPage.aspx">Log in</a></p>

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

        </div>
    </form>
</body>
</html>
