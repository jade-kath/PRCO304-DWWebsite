using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DogWalking.User_Side
{
    public partial class UserCreateAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void CreateUser()
        {
            string UserQuery = "INSERT  INTO Users (FirstName, LastName, DateOfBirth, EmailAddress, Username, Password, LocationID, isAdmin) VALUES ('" + txtFirstName + "', '" + surname + "', '" + dob + "', '" + gender + "'); ""
        }

        protected void btnCreateAccount_Click(object sender, EventArgs e)
        {

        }
    }
}