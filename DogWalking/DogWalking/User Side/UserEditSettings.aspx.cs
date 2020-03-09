﻿using System;
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
    public partial class UserSettings : System.Web.UI.Page
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
            string user = Session["User"].ToString();
            string sqlQuery = @"SELECT Users.FirstName, Users.LastName, Users.Username, Users.LocationID 
                              FROM Users WHERE Users.Username = '" + user + "'";
            ConnectionClass conn = new ConnectionClass();
            conn.retrieveData(sqlQuery);

            foreach (DataRow dr in conn.SQLTable.Rows)
            {
                txtFirstName.Text = (string)dr[0];
                txtLastName.Text = (string)dr[1];
                txtUserUsername.Text = (string)dr[2];
                drpLocation.SelectedIndex = (int)dr[3]-1;                   
            }
        }

        protected void SvUserChanges_Click(object sender, EventArgs e)
        {
            string FName = txtFirstName.Text;
            string LName = txtLastName.Text;
            string UName = txtUserUsername.Text;
            
            string UpdateUser = Session["User"].ToString();

            SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
            connect.Open();
            string UpdateUserQuery = @"UPDATE Users SET FirstName = '" + FName + "', " + "LastName = '" + LName + "', " + 
                               "Username = '" + UName + "', " + "LocationID = '" + drpLocation.SelectedValue + "'" + "WHERE Username = '" + UpdateUser + "'";
            SqlCommand cmd = new SqlCommand(UpdateUserQuery, connect);
            cmd.ExecuteScalar();

            connect.Close();
            
            Response.Redirect("UserEditSettings.aspx");
        }

        protected void UserChangeEmail_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserChangeEmail.aspx");
        }

        protected void UserChangePassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserChangePassword.aspx");
        }

        protected void UserDeleteAccount_Click(object sender, EventArgs e)
        {
            string user = Session["User"].ToString();
            string sqlDeleteQuery = @"DELETE FROM Users WHERE Username = '" + user + "'";
            ConnectionClass conn = new ConnectionClass();
            conn.retrieveData(sqlDeleteQuery);

            Session.Remove("User");
            Response.Redirect("~/index.aspx");
        }
    }
}