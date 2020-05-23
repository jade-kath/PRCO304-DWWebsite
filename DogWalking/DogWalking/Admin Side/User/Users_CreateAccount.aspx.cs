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
            if (Session["Admin"] == null)
            {
                Response.Redirect("../../LoginPage.aspx");
            }
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

        private void requiredFields()
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
            else if (string.IsNullOrEmpty(txtUserUsername.Text))
            {
                lblrequired.Visible = true;
            }
            else if (string.IsNullOrEmpty(txtUserEmail.Text))
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

        protected void btnCreateAccount_Click(object sender, EventArgs e)
        {
            requiredFields();

            if(radIsAdmin.Checked == true)
            {
                Response.Redirect("Users_ViewAdminUsers.aspx");
            }
            else
            {
                Response.Redirect("Users_ViewUsers.aspx");
            }
        }

        protected void radIsAdmin_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("index.aspx");
        }
    }
}