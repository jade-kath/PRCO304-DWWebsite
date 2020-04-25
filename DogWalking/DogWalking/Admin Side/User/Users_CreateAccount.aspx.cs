using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DogWalking.Admin_Side
{
    public partial class createAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void CreateUser()
        {
            string True = radIsAdmin.Checked.ToString();

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
            conn.Open();
            string UserQuery = "INSERT  INTO Users (FirstName, LastName, DateOfBirth, EmailAddress, Username, Password, LocationID, isAdmin) VALUES ('" + txtFirstName.Text + "', '" + txtLastName.Text + "', '" + txtDOB.Text + "', '" + txtUserEmail.Text + "', '" + txtUserUsername.Text + "', '" + txtUserPassword.Text + "', '" + drpLocation.SelectedValue + "', '" + True + "')";
            SqlCommand cmd = new SqlCommand(UserQuery, conn);
            cmd.ExecuteScalar();
        }

        protected void btnCreateAccount_Click(object sender, EventArgs e)
        {
            CreateUser();

            // if rad == true = viewAdminUsers.aspx, else rad == false = viewUsers.aspx
            Response.Redirect("Users_ViewUsers.aspx");
        }

        protected void radIsAdmin_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}