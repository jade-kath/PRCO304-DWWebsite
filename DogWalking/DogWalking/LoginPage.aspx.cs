using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DogWalking
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection(@"Data Source=socem1.uopnet.plymouth.ac.uk;Initial Catalog=PRCO304_JMarshall;Integrated Security=False;User ID=JMarshall;Password=********;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
            con.Open();
            

            //Admin
            string adminLoginQuery = "SELECT Count (*) FROM Users WHERE Username='" + txtusernameInsert.Text + "' AND Password='" + txtpasswordInsert.Text + "' AND isAdmin='True'";
            SqlCommand AdCommand = new SqlCommand(adminLoginQuery, con);
            string outputAdminLogin = AdCommand.ExecuteScalar().ToString();

            //User
            string userLoginQuery = "SELECT Count (*) FROM Users WHERE Username='" + txtusernameInsert.Text + "' AND Password='" + txtpasswordInsert.Text + "' AND isAdmin='False'";
            SqlCommand UseCommand = new SqlCommand(userLoginQuery, con);
            string outputUserLogin = UseCommand.ExecuteScalar().ToString();

            if (outputAdminLogin == "1")
            {
                Session["Admin"] = txtusernameInsert.Text;
                Response.Redirect("~/Admin Side/AdminIndex.aspx");
            }
            else if (outputUserLogin == "1")
            {
                Session["User"] = txtusernameInsert.Text;
                Response.Redirect("~/User Side/UserProfile.aspx");
            }
            else
            {
                Response.Write("These credentials do not match our records");
            }

            con.Close();
        }
    }
}