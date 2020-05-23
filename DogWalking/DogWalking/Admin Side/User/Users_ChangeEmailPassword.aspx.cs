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
    public partial class AdminChangeEmail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] == null)
            {
                Response.Redirect("../../LoginPage.aspx");
            }

            if (!IsPostBack)
            {
                ChangePassword();
            }
        }

        private void checkEmailBoxes()
        {
            if (string.IsNullOrEmpty(txtNewEmail.Text))
            {
                lblrequired.Visible = true;
            }
            else if (string.IsNullOrEmpty(txtEmailPassword.Text))
            {
                lblrequired.Visible = true;
            }
            else
            {
                ChangeEmail();
            }
        }

        private void checkPassBoxes()
        {
            if (string.IsNullOrEmpty(txtNewPassword.Text))
            {
                lblReqPass.Visible = true;
            }
            else if (string.IsNullOrEmpty(txtPassPassword.Text))
            {
                lblReqPass.Visible = true;
            }
            else
            {
                ChangePassword();
            }
        }

        private void ChangeEmail()
        {
            string user = Session["updateUser"].ToString();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
            conn.Open();

            string pass = txtEmailPassword.Text;


            if (pass == "admin")
            {
                SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
                connect.Open();
                string UpdateUserQuery = @"UPDATE Users SET EmailAddress = '" + txtNewEmail.Text + "'WHERE UserID = '" + user + "'";
                SqlCommand cmd = new SqlCommand(UpdateUserQuery, connect);
                cmd.ExecuteScalar();
                connect.Close();
                lblEmailSaved.Visible = true;
            }
            else
            {
                Response.Write("These credentials do not match our records");
            }

            txtNewEmail.Text = "";
        }

        private void ChangePassword()
        {
            string user = Session["updateUser"].ToString();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
            conn.Open();

            string psw = txtPassPassword.Text;


            if (psw == "admin")
            {
                SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
                connect.Open();
                string UpdateUserQuery = @"UPDATE Users SET Password = '" + txtNewPassword.Text + "'WHERE UserID = '" + user + "'";
                SqlCommand cmd = new SqlCommand(UpdateUserQuery, connect);
                cmd.ExecuteScalar();
                connect.Close();
                lblPasswordSaved.Visible = true;
            }
            else
            {
                Response.Write("These credentials do not match our records");
            }
        }

        protected void SaveEmailChanges_Click(object sender, EventArgs e)
        {
            checkEmailBoxes();
        }

        protected void SavePasswordChanges_Click(object sender, EventArgs e)
        {
            checkPassBoxes();
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("../..index.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Users_ChangeUserDetails.aspx");
        }
    }
}