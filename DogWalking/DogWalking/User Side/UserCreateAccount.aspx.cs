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

        private void required()
        {
            if (string.IsNullOrEmpty(txtFirstName.Text))
            {
                lblrequired.Visible = true;
            }
            else if (string.IsNullOrEmpty(txtLastName.Text))
            {
                lblrequired.Visible = true;
            }
            else if (string.IsNullOrEmpty(txtDOB.Text))
            {
                lblrequired.Visible = true;
            }
            else if (string.IsNullOrEmpty(txtUserEmail.Text))
            {
                lblrequired.Visible = true;
            }
            else if (string.IsNullOrEmpty(txtUserUsername.Text))
            {
                lblrequired.Visible = true;
            }
            else if (string.IsNullOrEmpty(txtUserPassword.Text))
            {
                lblrequired.Visible = true;
            }
            else
            {
                CreateUser();
            }
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
            required();
            Session["User"] = txtUserUsername.Text;
            Response.Redirect("UserProfile.aspx");
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("../index.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("");
        }
    }
}