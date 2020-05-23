﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DogWalking.User_Side.Outbreaks
{
    public partial class User_AddOB : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("../../index.aspx");
            }

            LoadWalkName();
        }

        private void LoadWalkName()
        {
            DataTable walkName = new DataTable();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString()))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT WalkID, WalkName FROM Walk WHERE LocationID = '" + drpLocation.SelectedIndex + "'", con);
                    adapter.Fill(walkName);

                    drpWalkName.DataSource = walkName;
                    drpWalkName.DataTextField = "WalkName";
                    drpWalkName.DataValueField = "WalkID";
                    drpWalkName.DataBind();
                }
                catch
                {
                    throw;
                }
            }

            if (Session["WalkID"] != null)
            {
                string walk = Session["WalkID"].ToString();
                string sqlQuery = @"SELECT Walk.WalkName, Location.Location FROM Walk JOIN Location ON Location.LocationID = Walk.LocationID WHERE WalkID = '" + walk + "'";
                ConnectionClass conn = new ConnectionClass();
                conn.retrieveData(sqlQuery);

                foreach (DataRow dr in conn.SQLTable.Rows)
                {
                    drpWalkName.SelectedIndex = (int)dr[0] - 1;
                    drpLocation.SelectedIndex = (int)dr[1] - 1;
                }
            }
        }

        private void required()
        {
            if (string.IsNullOrEmpty(txtIllDate.Text))
            {
                lblrequired.Visible = true;
            }
            else
            {
                if (string.IsNullOrEmpty(txtIllType.Text))
                {
                    lblrequired.Visible = true;
                }
                else
                {
                    addOutbreak();
                }
            }
        }

        private void addOutbreak()
        {
            if (String.IsNullOrEmpty(txtIllNotes.Text))
            {
                string description = "No further information available.";
                string user = Session["User"].ToString();

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
                con.Open();
                string newOut = "INSERT INTO Outbreak(OutbreakDate, OutbreakType, ODescription, WalkID, UserID, NewOutbreak)" +
                                " VALUES ('" + txtIllDate.Text + "', '" + txtIllType.Text + "', '" + description + "'," +
                                " '" + drpWalkName.SelectedValue + "', '(SELECT UserID FROM Users WHERE Username = '" + user + "')', 'True')";

                SqlCommand cmd = new SqlCommand(newOut, con);
                cmd.ExecuteScalar();
                con.Close();
            }
            else
            {
                string user = Session["User"].ToString();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
                con.Open();
                string newOut = "INSERT INTO Outbreak(OutbreakDate, OutbreakType, ODescription, WalkID, UserID, NewOutbreak)" +
                                " VALUES ('" + txtIllDate.Text + "', '" + txtIllType.Text + "', '" + txtIllNotes.Text + "'," +
                                " '" + drpWalkName.SelectedValue + "', '(SELECT UserID FROM Users WHERE Username = '" + user + "')', 'True')";

                SqlCommand cmd = new SqlCommand(newOut, con);
                cmd.ExecuteScalar();
                con.Close();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (Session["walkView"] == null)
            {
                Response.Redirect("../UserProfile.aspx");
            }
            else
            {
                Response.Redirect("../User_WalkPreview.aspx");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            required();
            Response.Redirect("User_ReportedOB.aspx");
        }
    }
}