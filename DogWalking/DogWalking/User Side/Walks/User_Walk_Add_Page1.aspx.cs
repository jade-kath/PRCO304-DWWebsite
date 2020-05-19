﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DogWalking.User_Side.Walks
{
    public partial class User_Walk_Add_Page1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("LoginPage.aspx");
            }

            loadBack();
        }

        private void loadBack()
        {
            if (Session["goBack"] == null)
            {

            }
            else
            {
                string load = Session["goBack"].ToString();
                string sqlQuery = @"SELECT Walk.WalkName, Walk.WalkAddress, Walk.WalkPostcode, Walk.LocationID, Walk.Description, Walk.Hours, Walk.Duration FROM Walk WHERE Walk.WalkName = '" + load + "'";
                ConnectionClass conn = new ConnectionClass();
                conn.retrieveData(sqlQuery);

                foreach (DataRow dr in conn.SQLTable.Rows)
                {
                    txtPlaceName.Text = (string)dr[0];
                    txtAddress.Text = (string)dr[1];
                    txtPostcode.Text = (string)dr[2];
                    drpLocation.SelectedIndex = (int)dr[3] - 1;
                    txtDescript.Text = (string)dr[4];
                    txtTimeLength.Text = (string)dr[5];
                    txtDuration.Text = (string)dr[6];
                }
            }

        }

        private void checkWalks()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
            con.Open();


            //Check if there's another walk with the same postcode - so there's no duplicates.
            string walkQuery = "SELECT Count (*) FROM Walk WHERE WalkPostcode='" + txtPostcode.Text + "'";
            SqlCommand AdCommand = new SqlCommand(walkQuery, con);
            string outputWalkQuery = AdCommand.ExecuteScalar().ToString();


            if (outputWalkQuery == "0")
            {
                saveWalk();
            }
            else
            {
                clone.Visible = true;
            }

        }

        //if the user goes back from the second page, the original version saved gets deleted first to avoid a system crash
        private void saveWalk()
        {
            if (Session["goBack"] == null)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
                con.Open();
                string SaveWalk = "INSERT INTO Walk(Walk.WalkName, Walk.WalkAddress, Walk.WalkPostcode, Walk.LocationID, Walk.Description, Walk.Hours, Walk.Duration," +
                                  " Walk.NewWalk) VALUES ('" + txtPlaceName.Text + "', '" + txtAddress.Text + "', '" + txtPostcode.Text + "'," +
                                     " '" + drpLocation.SelectedValue + "', '" + txtDescript.Text + "', '" + txtTimeLength.Text + "'," +
                                     " '" + txtDuration.Text + "', 'True')";

                SqlCommand cmd = new SqlCommand(SaveWalk, con);
                cmd.ExecuteScalar();
                con.Close();
            }
            else
            {
                string name = Session["goBack"].ToString();
                string delWalk = @"DELETE FROM Walk WHERE WalkID = '(SELECT WalkID FROM Walk WHERE WalkName = '" + name + "')'";
                ConnectionClass con = new ConnectionClass();
                con.retrieveData(delWalk);

                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
                conn.Open();
                string SaveWalk = "INSERT INTO Walk(Walk.WalkName, Walk.WalkAddress, Walk.WalkPostcode, Walk.LocationID, Walk.Description, Walk.Hours, Walk.Duration," +
                                  " Walk.NewWalk) VALUES ('" + txtPlaceName.Text + "', '" + txtAddress.Text + "', '" + txtPostcode.Text + "'," +
                                     " '" + drpLocation.SelectedValue + "', '" + txtDescript.Text + "', '" + txtTimeLength.Text + "'," +
                                     " '" + txtDuration.Text + "', 'True')";

                SqlCommand cmd = new SqlCommand(SaveWalk, conn);
                cmd.ExecuteScalar();
                conn.Close();

                Session.Remove("goBack");
            }

            //Sessions allow for adding to the new walk created, have to match with the two incase there's multiple walks around the country with the same name - that will cause a system crash
            Session["newWalk"] = txtPlaceName.Text;
            Session["postcode"] = txtPostcode.Text;
            Response.Redirect("User_Walk_Add_Page2.aspx");
        }

        protected void SaveChanges_Click(object sender, EventArgs e)
        {
            if (Session["goBack"] == null)
            {
                checkWalks();
            }
            else
            {
                saveWalk();
            }
        }

        protected void noCancel_Click(object sender, EventArgs e)
        {
            Session.Remove("goBack");
            Session.Remove("newWalk");
            Session.Remove("postcode");
            Response.Redirect("UserProfile.aspx");
        }

        protected void yesCont_Click(object sender, EventArgs e)
        {
            saveWalk();
        }
    }
}