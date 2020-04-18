using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DogWalking.Admin_Side.Walks
{
    public partial class Walk_WalkDetails1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PostToWebsite();
        }

        private void previewWalk()
        {
            string walk = Session["WalkID"].ToString();
            string sqlQuery = @"SELECT WalkName, WalkAddress, WalkPostcode, Loaction.Location, Description, Hours, Duration," +
                               " EntryCost, ParkingDetail, LivestockDetail, ToiletsDetail, RefreshmentDetail, LeadDetails" +
                               " FROM Walk JOIN Location ON Walk.LocationID=Location.LocationID WHERE Walk.WalkName = '" + walk + "'";
            ConnectionClass conn = new ConnectionClass();
            conn.retrieveData(sqlQuery);

            foreach (DataRow dr in conn.SQLTable.Rows)
            {
                lblPlaceName.Text = (string)dr[0];
                lblAddress.Text = (string)dr[1] + (string)dr[2];
                lblLocation.Text = (string)dr[3];
                lblDescript.Text = (string)dr[4];
                lblTime.Text = (string)dr[5];
                lblDistance.Text = (string)dr[6];
                lblEntryDetails.Text = (string)dr[7];
                lblParkDetails.Text = (string)dr[8];
                lblLiveDetails.Text = (string)dr[9];
                lblToiletDetails.Text = (string)dr[10];
                lblRefreshDetails.Text = (string)dr[11];
                lblLeadDetails.Text = (string)dr[12];
            }
        }

        private void PostToWebsite()
        {
            string notPosted = Session["notPosted"].ToString();
            string Posted = Session["Posted"].ToString();

            if (Session["notPosted"] == null)
            {
                btnRemove.Visible = true;
            }
            else if (Session["Posted"] == null)
            {
                btnPost.Visible = true;
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("");
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            string walkPost = Session["WalkID"].ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
            con.Open();
            string postWeb = "UPDATE Walk SET NewWalk = 'False' WHERE WalkName = '" + walkPost + "'";
            SqlCommand cmd = new SqlCommand(postWeb, con);
            cmd.ExecuteScalar();
            con.Close();

            Session.Remove("notPosted");
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            string walkRemove = Session["WalkID"].ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
            con.Open();
            string removeWeb = "UPDATE Walk SET NewWalk = 'True' WHERE WalkName = '" + walkRemove + "'";
            SqlCommand cmd = new SqlCommand(removeWeb, con);
            cmd.ExecuteScalar();
            con.Close();

            Session.Remove("Posted");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string walkDel = Session["WalkID"].ToString();
            string deleteWalk = @"DELETE FROM Walk WHERE WalkID = '" + walkDel + "'";
            ConnectionClass conn = new ConnectionClass();
            conn.retrieveData(deleteWalk);

            if (Session["notPosted"] == null)
            {
                Session.Remove("WalkID");
                Session.Remove("Posted");
                Response.Redirect("Walk_AllWalks.aspx");
            }
            else if (Session["Posted"] == null)
            {
                Session.Remove("WalkID");
                Session.Remove("notPosted");
                Response.Redirect("Walk_ReqWalks.aspx");
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            if (Session["notPosted"] == null)
            {
                Session.Remove("WalkID");
                Session.Remove("Posted");
                Response.Redirect("Walk_AllWalks.aspx");
            }
            else if (Session["Posted"] == null)
            {
                Session.Remove("WalkID");
                Session.Remove("notPosted");
                Response.Redirect("Walk_ReqWalks.aspx");
            }
        }
    }
}