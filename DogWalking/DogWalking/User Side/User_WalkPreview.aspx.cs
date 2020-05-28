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
    public partial class User_WalkPreview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userWalk"] != null)
            {
                checkStatus();
            }

            if (!IsPostBack)
            {
                Creator();
                viewImage();
                previewWalk();
                terrainList();
                facilityDetails();
                facilityBoolValues();
                walkOutbreakReports();
            }
        }

        //making delete button available to non published walks
        private void checkStatus()
        {
            string walk = Session["WalkID"].ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
            con.Open();

            string statusDeleteQuery = @"SELECT COUNT (*) FROM Walk Where WalkID = '" + walk + "' AND NewWalk = 'True'";
            SqlCommand cmdStatusDelete = new SqlCommand(statusDeleteQuery, con);
            string outputStatusDelete = cmdStatusDelete.ExecuteScalar().ToString();

            if (outputStatusDelete == "1")
            {
                btnDel.Visible = true;
                lblStatus.Text = "This walk is pending confirmation.";
            }
            else
            {
                btnDel.Visible = false;
            }

            string notPub = @"SELECT COUNT (*) FROM Walk WHERE WalkID = '" + walk + "' AND Published = 'False' AND NewWalk = 'False'";
            SqlCommand cmdNotPubState = new SqlCommand(notPub, con);
            string outputNotPub = cmdNotPubState.ExecuteScalar().ToString();

            if (outputNotPub == "1")
            {
                lblStatus.Text = "This walk is pending confirmation.";
            }
        }

        private void viewImage()
        {
            string walk = Session["WalkID"].ToString();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
            SqlDataAdapter sda = new SqlDataAdapter("SELECT ImagePath FROM Walk WHERE WalkID = '" + walk + "'", con);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            lstImage.DataSource = dt;
            lstImage.DataBind();
        }

        private void previewWalk()
        {
            string walk = Session["WalkID"].ToString();
            string sqlQuery = @"SELECT WalkName, WalkAddress, WalkPostcode, Location.Location, Description FROM Walk JOIN Location ON Location.LocationID = Walk.LocationID WHERE WalkID = '" + walk + "'";
            ConnectionClass conn = new ConnectionClass();
            conn.retrieveData(sqlQuery);

            foreach (DataRow dr in conn.SQLTable.Rows)
            {
                lblWalkName.Text = (string)dr[0];
                lblAddr.Text = (string)dr[1];
                lblPostcode.Text = (string)dr[2];
                lblLocate.Text = (string)dr[3];
                lblDescribe.Text = (string)dr[4];
            }
        }

        private void terrainList()
        {
            string walk = Session["WalkID"].ToString();
            string terrainQuery = @"SELECT Terrain.TerrainType FROM Terrain JOIN WalksTerrain ON" +
                                   " WalksTerrain.TerrainID = Terrain.TerrainID WHERE WalkID = '" + walk + "'";

            ConnectionClass conn = new ConnectionClass();
            conn.retrieveData(terrainQuery);

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("Terrain",typeof(string)),
            });

            foreach (DataRow dr in conn.SQLTable.Rows)
            {
                string Terrain = (string)dr[0];

                dt.Rows.Add(Terrain);
            }

            this.grdTerrain.DataSource = dt;
            this.grdTerrain.DataBind();
        }

        private void facilityBoolValues()
        {
            string walk = Session["WalkID"].ToString();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
            con.Open();

            //Lead Details
            string onLeadQuery = @"SELECT COUNT (*) FROM Walk Where WalkID = '" + walk + "' AND OnLead = 'True'";
            SqlCommand cmdOnLead = new SqlCommand(onLeadQuery, con);
            string outputOnLead = cmdOnLead.ExecuteScalar().ToString();

            string offLeadQuery = @"SELECT COUNT (*) FROM Walk Where WalkID = '" + walk + "' AND OffLead = 'True'";
            SqlCommand cmdOffLead = new SqlCommand(offLeadQuery, con);
            string outputOffLead = cmdOffLead.ExecuteScalar().ToString();

            if (outputOnLead == "1")
            {
                lblLeaded.Text = "Dogs should be kept on a lead for part or all of this walk.";
            }
            else if (outputOffLead == "1")
            {
                lblNonLead.Text = "Dogs can come off the lead for a part or all of this walk.";
            }

            //EntryFee
            string entryQuery = @"SELECT COUNT (*) FROM Walk Where WalkID = '" + walk + "' AND EntryFee = 'True'";
            SqlCommand cmdEntry = new SqlCommand(entryQuery, con);
            string outputEntryTrue = cmdEntry.ExecuteScalar().ToString();

            string entryFalseQuery = @"SELECT COUNT (*) FROM Walk Where WalkID = '" + walk + "' AND EntryFee = 'False'";
            SqlCommand cmdFalseEntry = new SqlCommand(entryFalseQuery, con);
            string outputFalseEntry = cmdFalseEntry.ExecuteScalar().ToString();

            if (outputEntryTrue == "1")
            {
                lblEntry.Text = "Entry costs apply";
            }
            else if (outputFalseEntry == "1")
            {
                lblEntry.Text = "Free entry";
            }
            else
            {
                lblEntry.Text = "No information available";
            }

            //FreeParking
            string parkQuery = @"SELECT COUNT (*) FROM Walk Where WalkID = '" + walk + "' AND FreeParking = 'True'";
            SqlCommand cmdpark = new SqlCommand(parkQuery, con);
            string outputParkTrue = cmdpark.ExecuteScalar().ToString();

            string parkFalseQuery = @"SELECT COUNT (*) FROM Walk Where WalkID = '" + walk + "' AND FreeParking = 'False'";
            SqlCommand cmdFalsePark = new SqlCommand(parkFalseQuery, con);
            string outputFalsePark = cmdFalsePark.ExecuteScalar().ToString();

            if (outputParkTrue == "1")
            {
                lblPark.Text = "Free parking available here.";
            }
            else if (outputFalsePark == "1")
            {
                lblPark.Text = "Charges for parking here.";
            }
            else
            {
                lblPark.Text = "No information available";
            }

            //Livestock
            string liveQuery = @"SELECT COUNT (*) FROM Walk Where WalkID = '" + walk + "' AND Livestock = 'True'";
            SqlCommand cmdLive = new SqlCommand(liveQuery, con);
            string outputLiveTrue = cmdLive.ExecuteScalar().ToString();

            string liveFalseQuery = @"SELECT COUNT (*) FROM Walk Where WalkID = '" + walk + "' AND Livestock = 'False'";
            SqlCommand cmdFalseLive = new SqlCommand(liveFalseQuery, con);
            string outputFalseLive = cmdFalseLive.ExecuteScalar().ToString();

            if (outputLiveTrue == "1")
            {
                lblLive.Text = "There is livestock on this walk.";
            }
            else if (outputFalseLive == "1")
            {
                lblLive.Text = "There's no livestock on this walk.";
            }
            else
            {
                lblLive.Text = "No information available";
            }

            //Toilets
            string toiletQuery = @"SELECT COUNT (*) FROM Walk Where WalkID = '" + walk + "' AND Toilets = 'True'";
            SqlCommand cmdToilet = new SqlCommand(toiletQuery, con);
            string outputToiletTrue = cmdToilet.ExecuteScalar().ToString();

            string toiletFalseQuery = @"SELECT COUNT (*) FROM Walk Where WalkID = '" + walk + "' AND Toilets = 'False'";
            SqlCommand cmdFalseToilet = new SqlCommand(toiletFalseQuery, con);
            string outputFalseToilet = cmdFalseToilet.ExecuteScalar().ToString();

            if (outputToiletTrue == "1")
            {
                lblToilet.Text = "Toilet facilities available.";
            }
            else if (outputFalseToilet == "1")
            {
                lblToilet.Text = "Toilet facilities are not available.";
            }
            else
            {
                lblToilet.Text = "No information available";
            }

            //Refreshments
            string refreshQuery = @"SELECT COUNT (*) FROM Walk Where WalkID = '" + walk + "' AND Refreshments = 'True'";
            SqlCommand cmdRefresh = new SqlCommand(refreshQuery, con);
            string outputRefreshTrue = cmdRefresh.ExecuteScalar().ToString();

            string refreshFalseQuery = @"SELECT COUNT (*) FROM Walk Where WalkID = '" + walk + "' AND Refreshments = 'False'";
            SqlCommand cmdFalseRefresh = new SqlCommand(refreshFalseQuery, con);
            string outputFalseRefresh = cmdFalseRefresh.ExecuteScalar().ToString();

            if (outputRefreshTrue == "1")
            {
                lblRefresh.Text = "Refreshments available here.";
            }
            else if (outputFalseRefresh == "1")
            {
                lblRefresh.Text = "Refreshments are not available.";
            }
            else
            {
                lblRefresh.Text = "No information available";
            }

            //WheelchairFriendly
            string wheelQuery = @"SELECT COUNT (*) FROM Walk Where WalkID = '" + walk + "' AND WheelchairFriendly = 'True'";
            SqlCommand cmdWheel = new SqlCommand(wheelQuery, con);
            string outputWheelTrue = cmdWheel.ExecuteScalar().ToString();

            string wheelFalseQuery = @"SELECT COUNT (*) FROM Walk Where WalkID = '" + walk + "' AND WheelchairFriendly = 'False'";
            SqlCommand cmdFalseWheel = new SqlCommand(wheelFalseQuery, con);
            string outputFalseWheel = cmdFalseWheel.ExecuteScalar().ToString();

            if (outputWheelTrue == "1")
            {
                lblWheel.Text = "This walk is wheelchair friendly.";
            }
            else if (outputFalseWheel == "1")
            {
                lblWheel.Text = "Unfortunately, this walk is not wheelchair friendly.";
            }
            else
            {
                lblWheel.Text = "No information available.";
            }

        }


        //FacilityDetails() is a method that is checking if the value in the DB is 'NULL', if it is 'NULL' it wont do anything, overwise if it has a value it'll show the value in the label
        private void facilityDetails()
        {
            string walk = Session["WalkID"].ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
            con.Open();

            //Time Details
            string timeQuery = @"SELECT COUNT (*) FROM Walk Where WalkID = '" + walk + "' AND Hours IS NULL";
            SqlCommand cmdTime = new SqlCommand(timeQuery, con);
            string outputTime = cmdTime.ExecuteScalar().ToString();

            if (outputTime != "1")
            {
                string timeOutput = @"SELECT Hours FROM Walk WHERE WalkID = '" + walk + "'";
                ConnectionClass conn = new ConnectionClass();
                conn.retrieveData(timeOutput);

                foreach (DataRow dr in conn.SQLTable.Rows)
                {
                    lblTime.Text = (string)dr[0];
                }
            }
            else
            {
                lblTime.Text = "Information not available.";
            }

            //Distance Details
            string DistQuery = @"SELECT COUNT (*) FROM Walk Where WalkID = '" + walk + "' AND Duration IS NULL";
            SqlCommand cmdDist = new SqlCommand(DistQuery, con);
            string outputDist = cmdDist.ExecuteScalar().ToString();

            if (outputDist != "1")
            {
                string distOutput = @"SELECT Duration FROM Walk WHERE WalkID = '" + walk + "'";
                ConnectionClass conn = new ConnectionClass();
                conn.retrieveData(distOutput);

                foreach (DataRow dr in conn.SQLTable.Rows)
                {
                    lblDist.Text = (string)dr[0];
                }
            }
            else
            {
                lblDist.Text = "Information not available.";
            }

            //Entry
            string entryQuery = @"SELECT COUNT (*) FROM Walk Where WalkID = '" + walk + "' AND EntryCost IS NULL";
            SqlCommand cmdEntry = new SqlCommand(entryQuery, con);
            string outputEntry = cmdEntry.ExecuteScalar().ToString();

            if (outputEntry != "1")
            {
                string entryOutput = @"SELECT EntryCost FROM Walk WHERE WalkID = '" + walk + "'";
                ConnectionClass conn = new ConnectionClass();
                conn.retrieveData(entryOutput);

                foreach (DataRow dr in conn.SQLTable.Rows)
                {
                    lblEntryDetail.Text = (string)dr[0];
                }
            }
            else
            {
                lblEntryDetail.Text = "Information not available.";
            }

            //Parking
            string ParkQuery = @"SELECT COUNT (*) FROM Walk Where WalkID = '" + walk + "' AND ParkingDetail IS NULL";
            SqlCommand cmdPark = new SqlCommand(ParkQuery, con);
            string outputPark = cmdPark.ExecuteScalar().ToString();

            if (outputPark != "1")
            {
                string parkOutput = @"SELECT ParkingDetail FROM Walk WHERE WalkID = '" + walk + "'";
                ConnectionClass conn = new ConnectionClass();
                conn.retrieveData(parkOutput);

                foreach (DataRow dr in conn.SQLTable.Rows)
                {
                    lblParkDetail.Text = (string)dr[0];
                }
            }

            //Livestock
            string LiveQuery = @"SELECT COUNT (*) FROM Walk Where WalkID = '" + walk + "' AND LivestockDetail IS NULL";
            SqlCommand cmdLive = new SqlCommand(LiveQuery, con);
            string outputLive = cmdLive.ExecuteScalar().ToString();

            if (outputLive != "1")
            {
                string liveOutput = @"SELECT LivestockDetail FROM Walk WHERE WalkID = '" + walk + "'";
                ConnectionClass conn = new ConnectionClass();
                conn.retrieveData(liveOutput);

                foreach (DataRow dr in conn.SQLTable.Rows)
                {
                    lblLiveDetail.Text = (string)dr[0];
                }
            }

            //Toilet
            string ToiletQuery = @"SELECT COUNT (*) FROM Walk Where WalkID = '" + walk + "' AND ToiletsDetail IS NULL";
            SqlCommand cmdToilet = new SqlCommand(ToiletQuery, con);
            string outputToilet = cmdToilet.ExecuteScalar().ToString();

            if (outputToilet != "1")
            {
                string toiletOutput = @"SELECT ToiletsDetail FROM Walk WHERE WalkID = '" + walk + "'";
                ConnectionClass conn = new ConnectionClass();
                conn.retrieveData(toiletOutput);

                foreach (DataRow dr in conn.SQLTable.Rows)
                {
                    lblToiletDetail.Text = (string)dr[0];
                }
            }

            //Refreshments
            string RefreshQuery = @"SELECT COUNT (*) FROM Walk Where WalkID = '" + walk + "' AND RefreshmentDetail IS NULL";
            SqlCommand cmdRefresh = new SqlCommand(RefreshQuery, con);
            string outputRefresh = cmdRefresh.ExecuteScalar().ToString();

            if (outputRefresh != "1")
            {
                string refreshOutput = @"SELECT RefreshmentDetail FROM Walk WHERE WalkID = '" + walk + "'";
                ConnectionClass conn = new ConnectionClass();
                conn.retrieveData(refreshOutput);

                foreach (DataRow dr in conn.SQLTable.Rows)
                {
                    lblRefreshDetail.Text = (string)dr[0];
                }
            }

            //Lead
            string LeadQuery = @"SELECT COUNT (*) FROM Walk Where WalkID = '" + walk + "' AND LeadDetails IS NULL";
            SqlCommand cmdLead = new SqlCommand(LeadQuery, con);
            string outputLead = cmdLead.ExecuteScalar().ToString();

            if (outputLead != "1")
            {
                string leadOutput = @"SELECT LeadDetails FROM Walk WHERE WalkID = '" + walk + "'";
                ConnectionClass conn = new ConnectionClass();
                conn.retrieveData(leadOutput);

                foreach (DataRow dr in conn.SQLTable.Rows)
                {
                    lblLeadDetail.Text = (string)dr[0];
                }
            }
        }

        private void walkOutbreakReports()
        {
            string user = Session["User"].ToString();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
            SqlDataAdapter sda = new SqlDataAdapter("SELECT Outbreak.OutbreakDate, Outbreak.OutbreakType, Walk.WalkName," +
                                                    " Location.Location, Walk.WalkPostcode, Outbreak.ODescription, Users.Username FROM" +
                                                    " Outbreak JOIN Walk ON Outbreak.WalkID = Walk.WalkID JOIN Location ON" +
                                                    " Walk.LocationID = Location.LocationID JOIN Users ON Users.UserID = Outbreak.UserID WHERE Users.Username = '" + user + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            lstOutbreaks.DataSource = dt;
            lstOutbreaks.DataBind();
        }

        //created by user
        private void Creator()
        {
            string walk = Session["WalkID"].ToString();
            string creator = @"SELECT Users.Username FROM Users JOIN Walk ON Walk.UserID = Users.UserID WHERE Walk.WalkID = '" + walk +"'";
            ConnectionClass conn = new ConnectionClass();
            conn.retrieveData(creator);

            foreach (DataRow dr in conn.SQLTable.Rows)
            {
                lblCreated.Text = "Created by: " + (string)dr[0];
            }
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            string walkDel = Session["WalkID"].ToString();

            string delTerrain = @"DELETE FROM WalksTerrain WHERE WalkID = '" + walkDel + "'";
            ConnectionClass con = new ConnectionClass();
            con.retrieveData(delTerrain);

            string delWalk = @"DELETE FROM Walk WHERE WalkID = '" + walkDel + "'";
            ConnectionClass conn = new ConnectionClass();
            conn.retrieveData(delWalk);

            Session.Remove("WalkID");
            Session.Remove("userWalk");
            Response.Redirect("Walks/User_WalksByMe.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            if (Session["userWalk"] == null)
            {
                Session.Remove("WalkID");
                Response.Redirect("../searchResults.aspx");
            }
            else
            {
                Session.Remove("WalkID");
                Session.Remove("userWalk");
                Response.Redirect("Walks/Users_WalksByMe.aspx");
            }
        }

        protected void btnAddOutbreak_Click(object sender, EventArgs e)
        {
            Session.Remove("userWalk");
            Session["WalkView"] = "walk";
            Response.Redirect("Outbreaks/User_AddOB.aspx");
        }

        //navbar
        protected void btnHome_Click(object sender, EventArgs e)
        {
            if (Session["userWalk"] != null)
            {
                Session.Remove("userWalk");
            }
            Session.Remove("WalkID");
            Response.Redirect("../index.aspx");
        }

        protected void btnProfile_Click(object sender, EventArgs e)
        {
            if (Session["userWalk"] != null)
            {
                Session.Remove("userWalk");
            }
            Session.Remove("WalkID");
            Response.Redirect("UserProfile.aspx");
        }

        protected void btnSettings_Click(object sender, EventArgs e)
        {
            if (Session["userWalk"] != null)
            {
                Session.Remove("userWalk");
            }
            Session.Remove("WalkID");
            Response.Redirect("/CRUD User Settings/UserEditSettings.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("../../index.aspx");
        }
    }
}