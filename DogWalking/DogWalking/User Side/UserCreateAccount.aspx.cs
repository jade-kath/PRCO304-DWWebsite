using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DogWalking.User_Side
{
    public partial class UserCreateAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        private void CreateUser()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
            conn.Open();
            string UserQuery = "INSERT  INTO Users (FirstName, LastName, DateOfBirth, EmailAddress, Username, Password, LocationID, isAdmin) VALUES ('" + txtFirstName.Text + "', '" + txtLastName.Text + "', '" + txtDOB.Text + "', '" + txtUserEmail.Text + "', '" + txtUserUsername.Text + "', '" + txtUserPassword.Text + "', '" + drpLocation.SelectedValue + "', 'False')";
            SqlCommand cmd = new SqlCommand(UserQuery, conn);
            cmd.ExecuteScalar();
        }

        protected void btnCreateAccount_Click(object sender, EventArgs e)
        {
            CreateUser();
            Session["User"] = txtUserUsername.Text;
            Response.Redirect("UserProfile.aspx");
        }
    }
}