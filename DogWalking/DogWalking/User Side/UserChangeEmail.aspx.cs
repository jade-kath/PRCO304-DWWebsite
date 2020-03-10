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
    public partial class UserChangeEmail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        private void saveChanges()
        {
            string user = Session["User"].ToString();
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
        conn.Open();

            string sqlQuery = "SELECT Count (*) FROM Users WHERE Username='" + user + "' AND Password='" + txtPassword.Text + "' AND EmailAddress ='" + txtOldEmail.Text + "'";
        SqlCommand comms = new SqlCommand(sqlQuery, conn);
        string outputQuery = comms.ExecuteScalar().ToString();
        conn.Close();
                                 

            if (outputQuery == "1")
            {
                SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
                connect.Open();
                string UpdateUserQuery = @"UPDATE Users SET EmailAddress = '" + txtNewEmail.Text + "'WHERE Username = '" + user + "'";
                SqlCommand cmd = new SqlCommand(UpdateUserQuery, connect);
                cmd.ExecuteScalar();
                connect.Close();
                lblChangesSaved.Visible = true;
            }
            else
            {
                Response.Write("These credentials do not match our records");
            }
            
            txtOldEmail.Text = "";
            txtNewEmail.Text = "";
        }

        protected void SvUserChanges_Click(object sender, EventArgs e)
        {
            saveChanges();
        }
    }
}