<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User_Walk_Add_Page1.aspx.cs" Inherits="DogWalking.User_Side.Walks.User_Walk_Add_Page1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Lead The Way - Add a Walk</title>
</head>
<body>
    <form id="form1" runat="server">

        <div class ="userMain">
            <h1>Add a Walk</h1>

                <div class="walkName">
                    <h1>Add a Walk</h1>
                    <h2>General Details</h2>

                    <p id="required">* indicates a required field</p>
                    <br />

                    <p>* Name of this walk/place:-</p>
                        <asp:TextBox ID="txtPlaceName" runat="server" Width="167px"/>
                             <br />
                    <p>* Address:-</p>
                        <asp:TextBox ID="txtAddress" runat="server" Width="167px"/>
                             <br />
                    <p>* Postcode:-</p>
                        <asp:TextBox ID="txtPostcode" runat="server" Width="163px"/>
                             <br /> 
                    <p>* Location:-</p>
                        <asp:DropDownList ID="drpLocation" runat="server" DataSourceID="SqlDataSource1" DataTextField="Location" DataValueField="LocationID"></asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=socem1.uopnet.plymouth.ac.uk;Initial Catalog=PRCO304_JMarshall;Persist Security Info=True;User ID=JMarshall;Password=PRCO304_22018506" ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [Location]"></asp:SqlDataSource>
                             <br />
                    <p>* A Description of this walk:-</p>
                        <asp:TextBox ID="txtDescript" runat="server" Width="163px"/>
                             <br /> 
                    <p>* Typically how long would you spend walking at this location?-</p>
                        <asp:TextBox ID="txtTimeLength" runat="server" Width="163px" placeholder="eg. 2 hours or 30 minutes"/>
                             <br />
                    <p>* Distance/Size of the walk or area:-</p>
                        <asp:TextBox ID="txtDuration" runat="server" Width="163px" placeholder="eg. 2km, 5 miles, 150 acres"/>
                             <br />
                </div>
                <div class="gallery">
                    <p>Upload an image to use as the cover photo</p>
                    <asp:FileUpload ID="FileUpload" runat="server" />
                    <br />
                </div>

            <asp:Label runat="server" ID="lblrequired" Visible="false">Please fill all the required fields.</asp:Label>
            <br />

            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
            <asp:Button ID="SaveChanges" runat="server" Text="Next Page" OnClick="SaveChanges_Click" />

            <!--Shows the user if they want to add the dupliacte or not -->
            <div id="clone" runat="server" Visible ="false">
                    <p>There's a walk that already exists with this postcode. Would you like to create it anyway</p>
                    <asp:Button ID="noCancel" runat="server" Text="Cancel" OnClick="noCancel_Click" />
                    <asp:Button ID="yesCont" runat="server" Text="Yes, Continue & Save" OnClick="yesCont_Click" />                  
                </div>
        </div>
    </form>
</body>
</html>
