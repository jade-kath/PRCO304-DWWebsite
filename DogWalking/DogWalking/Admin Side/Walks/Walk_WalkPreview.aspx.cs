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
            if (Session["Admin"] == null)
            {
                Response.Redirect("../../LoginPage.aspx");
            }

            PostToWebsite();

            if (!IsPostBack)
            {
                Creator();
                previewWalk();
                viewImage();
                terrainList();
                facilityDetails();
                facilityBoolValues();
                bindToOutbreak();
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

        //View the Outbreaks for that walk
        private void bindToOutbreak()
        {
            string walk = Session["WalkID"].ToString();

            string sqlQuery = @"SELECT Outbreak.OutbreakID, Outbreak.OutbreakDate, Outbreak.OutbreakType," +
                               " Outbreak.ODescription, Users.Username FROM Outbreak JOIN Users" +
                               " ON Outbreak.UserID = Users.UserID WHERE Outbreak.WalkID = '" + walk +"' and NewOutbreak = 'False'";
            ConnectionClass conn = new ConnectionClass();
            conn.retrieveData(sqlQuery);

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("OutbreakID", typeof(int)),
                new DataColumn("OutbreakDate", typeof(DateTime)),
                new DataColumn("OutbreakType",typeof(string)),
                new DataColumn("ODescription", typeof(string)),
                new DataColumn("Username", typeof(string))
            });

            foreach (DataRow dr in conn.SQLTable.Rows)
            {
                int OutbreakID = (int)dr[0];
                string OutbreakDate = ((DateTime)dr[1]).ToShortDateString();
                string OutbreakType = (string)dr[2];
                string ODescription = (string)dr[3];
                string Username = (string)dr[4]; 

                dt.Rows.Add(OutbreakID, OutbreakDate, OutbreakType, ODescription, Username);
            }

            this.grdWalkOutbreaks.DataSource = dt;
            this.grdWalkOutbreaks.DataBind();
        }

        //Views who created the walk
        private void Creator()
        {
            string walk = Session["WalkID"].ToString();
            string creator = @"SELECT Users.Username FROM Users JOIN Walk ON Walk.UserID = Users.UserID WHERE Walk.WalkID = '" + walk + "'";
            ConnectionClass conn = new ConnectionClass();
            conn.retrieveData(creator);

            foreach (DataRow dr in conn.SQLTable.Rows)
            {
                lblCreated.Text = "Created by: " + (string)dr[0];
            }
        }

        //checks the session of whether the walk has been published or not, the appropriate button will show
        private void PostToWebsite()
        {
            if (Session["notPosted"] == null)
            {
                btnRemove.Visible = true;
            }
            else if (Session["Posted"] == null)
            {
                btnPost.Visible = true;
            }
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            string walkPost = Session["WalkID"].ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
            con.Open();
            string postWeb = "UPDATE Walk SET Published = 'True', NewWalk = 'False' WHERE WalkID = '" + walkPost + "'";
            SqlCommand cmd = new SqlCommand(postWeb, con);
            cmd.ExecuteScalar();
            con.Close();

            Session["Posted"] = "Posted";
            Session.Remove("notPosted");
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            string walkRemove = Session["WalkID"].ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
            con.Open();
            string removeWeb = "UPDATE Walk SET Published = 'False', NewWalk = 'False' WHERE WalkID = '" + walkRemove + "'";
            SqlCommand cmd = new SqlCommand(removeWeb, con);
            cmd.ExecuteScalar();
            con.Close();

            Session["notPosted"] = "notPosted";
            Session.Remove("Posted");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string walkDel = Session["WalkID"].ToString();

            string delTerrain = @"DELETE FROM WalksTerrain WHERE WalkID = '" + walkDel + "'";
            ConnectionClass con = new ConnectionClass();
            con.retrieveData(delTerrain);

            string delWalk = @"DELETE FROM Walk WHERE WalkID = '" + walkDel + "'";
            ConnectionClass conn = new ConnectionClass();
            conn.retrieveData(delWalk);

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

        protected void btnEditGeneral_Click(object sender, EventArgs e)
        {
            Response.Redirect("Walk_EditWalk_General.aspx");
        }

        protected void btnEditTerrain_Click(object sender, EventArgs e)
        {
            Response.Redirect("Walk_EditWalk_Terrain.aspx");
        }

        protected void btnEditFacility_Click(object sender, EventArgs e)
        {
            Response.Redirect("Walk_EditWalk_Facility.aspx");
        }

        protected void grdWalkOutbreaks_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["OBID"] = this.grdWalkOutbreaks.SelectedRow.Cells[1].Text;
            Response.Redirect("../Outbreaks/OB_OBPreview.aspx");
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("../../index.aspx");
        }
    }
}