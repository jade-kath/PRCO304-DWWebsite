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
    public partial class UserDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                addUserData();
            }
        }

        private void addUserData()
        {
            string user = Session["updateUser"].ToString();
            string sqlQuery = @"SELECT Users.FirstName, Users.LastName, Users.Username, Users.LocationID 
                              FROM Users WHERE Users.UserID = '" + user + "'";
            ConnectionClass conn = new ConnectionClass();
            conn.retrieveData(sqlQuery);

            foreach (DataRow dr in conn.SQLTable.Rows)
            {
                txtFirstName.Text = (string)dr[0];
                txtLastName.Text = (string)dr[1];
                txtUsername.Text = (string)dr[2];
                drpLocation.SelectedIndex = (int)dr[3] - 1;
            }
        }

        protected void SaveChanges_Click(object sender, EventArgs e)
        {
            string FName = txtFirstName.Text;
            string LName = txtLastName.Text;
            string UName = txtUsername.Text;

            string UpdateUser = Session["updateUser"].ToString();

            SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
            connect.Open();
            string UpdateUserQuery = @"UPDATE Users SET FirstName = '" + FName + "', " + "LastName = '" + LName + "', " +
                               "Username = '" + UName + "', " + "LocationID = '" + drpLocation.SelectedValue + "'" + "WHERE UserID = '" + UpdateUser + "'";
            SqlCommand cmd = new SqlCommand(UpdateUserQuery, connect);
            cmd.ExecuteScalar();

            connect.Close();

            Response.Redirect("UserDetails.aspx");
        }

        protected void ChangeEmail_Click(object sender, EventArgs e)
        {

        }

        protected void ChangePassword_Click(object sender, EventArgs e)
        {

        }

        protected void DeleteAccount_Click(object sender, EventArgs e)
        {
            string user = Session["updateUser"].ToString();
            string sqlDeleteQuery = @"DELETE FROM Users WHERE UserID = '" + user + "'";
            ConnectionClass conn = new ConnectionClass();
            conn.retrieveData(sqlDeleteQuery);

            Session.Remove("updateUser");
            Response.Redirect("viewUsers.aspx");
        }
    }
}