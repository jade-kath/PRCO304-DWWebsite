<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User_AddOB.aspx.cs" Inherits="DogWalking.User_Side.Outbreaks.User_AddOB" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Lead The Way - Report a Dog Illness</title>

    <link rel="stylesheet" href="../../Style/User_Buttons.css" />

</head>
<body>
    <form id="form1" runat="server">
        <div class ="userMain">
             <h1>Report a Dog Illness</h1>
            <br />
            <p id="required">* indicates a required field</p>
            <br />

            <label>*</label><label>Walk Location:</label><br />
            <asp:DropDownList ID="drpLocation" runat="server" DataSourceID="SqlDataSource1" DataTextField="Location" DataValueField="LocationID"></asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=socem1.uopnet.plymouth.ac.uk;Initial Catalog=PRCO304_JMarshall;Persist Security Info=True;User ID=JMarshall;Password=PRCO304_22018506" ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [Location]"></asp:SqlDataSource>
            <br />

            <label>*</label><label>Walk Name:</label><br />
            <asp:DropDownList ID="drpWalkName" runat="server"></asp:DropDownList><br />
            <br />

            <label>*</label><label>Type of Illness:</label><br />
            <asp:TextBox runat="server" ID="txtIllType"></asp:TextBox>
            <br />

            <label>*</label><label>Date of Illnesses Occurrence:</label><br />
            <asp:TextBox ID="txtIllDate" runat="server" TextMode="Date" />
            <br />
            <label>Futher Description or Notes:</label><br />
            <asp:TextBox runat="server" ID="txtIllNotes" />
            <br />

            <asp:Label runat="server" ID="lblrequired" Visible="false">Please fill all the required fields.</asp:Label>
            <br />

            <asp:Button runat="server" ID="btnCancel" Text="Cancel" OnClick="btnCancel_Click" CssClass="btn-cancel" />
            <asp:Button runat="server" ID="btnSave" Text="Send Request" OnClick="btnSave_Click" CssClass="btn-save" />
        </div>
    </form>
</body>
</html>
