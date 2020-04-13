using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows;

namespace DogWalking.Admin_Side.Walks
{
    public partial class Walk_WalkDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /* if (!IsPostBack)
            {
                addFacilities();
                addTerrain();
            }
            */
            
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

        private void saveWalk()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
            con.Open();
            string SaveWalk = "INSERT INTO Walk(Walk.WalkName, Walk.WalkAddress, Walk.WalkPostcode, Walk.LocationID, Walk.Description, Walk.Hours, Walk.Duration," +
                              " Walk.NewWalk) VALUES ('" + txtPlaceName.Text + "', '" + txtAddress.Text + "', '" + txtPostcode.Text + "'," +
                                 " '" + drpLocation.SelectedValue + "', '" + txtDescript.Text + "', '" + txtTimeLength.Text + "'," +
                                 " '" + txtDuration.Text + "', 'False')"; 


            SqlCommand cmd = new SqlCommand(SaveWalk, con);
            cmd.ExecuteScalar();

            if (!IsPostBack){
                addFacilities();
            }
            
        }

        private void addFacilities()
        {
            //facilities
            string entry = "";
            string parking = "";
            string live = "";
            string toilet = "";
            string refresh = "";
            string wheel = "";
            string leadOn = "";
            string leadOff = "";

                if (radEntryTrue.Checked == true)
                {
                    entry = "true";
                }
                else
                {
                    entry = "false";
                }

                if (radParkingTrue.Checked == true)
                {
                    parking = "true";
                }
                else
                {
                    parking = "false";
                }

                if (radLiveTrue.Checked == true)
                {
                    live = "true";
                }
                else
                {
                    live = "false";
                }

                if (radToiletTrue.Checked == true)
                {
                    toilet = "true";
                }
                else
                {
                    toilet = "false";
                }

                if (radRefreshTrue.Checked == true)
                {
                    refresh = "true";
                }
                else
                {
                    refresh = "false";
                }

                if (radWheelTrue.Checked == true)
                {
                    wheel = "true";
                }
                else
                {
                    wheel = "false";
                }

                if (radLeadOn.Checked == true)
                {
                    leadOn = "true";
                }
                else
                {
                    leadOn = "false";
                }

                if (radLeadOff.Checked == true)
                {
                    leadOff = "true";
                }
                else
                {
                    leadOff = "false";
                }
           
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
            con.Open();
            string addFacilities = "UPDATE Walk SET EntryFee = '" + entry + "' , EntryCost = '" + txtEntryCost.Text + "' , " +
                                   "FreeParking = '" + parking + "', ParkingDetail = '" + txtParkDetails.Text + "', Livestock = '" + live + "', " +
                                   "LivestockDetail = '" + txtLiveDetails.Text + "', Toilets = '" + toilet + "', ToiletsDetail = '" + txtToiletDetails.Text + "', " +
                                   "Refreshments = '" + refresh + "', RefreshmentDetail = '" + txtRefreshDetails + "', " +
                                   "WheelchairFriendly = '" + wheel + "', OffLead = '" + leadOff + "', OnLead = '" + leadOn + "', " +
                                   "LeadDetails = '" + txtLeadDetails.Text + "' WHERE WalkPostCode = '" + txtPostcode.Text + "'" +
                                   " AND WalkName = '" + txtPlaceName.Text + "'";
            SqlCommand cmd = new SqlCommand(addFacilities, con);
            cmd.ExecuteScalar();
            con.Close();
            addTerrain();
        }

        private void addTerrain()
        {
            if (radTerFlat.Checked == true)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
                con.Open();
                string addFlat = "INSERT INTO WalksTerrain (WalkID, TerrainID) VALUES ((SELECT WalkID FROM Walk WHERE " +
                                 "WalkPostCode = '" + txtPostcode.Text + "' AND WalkName = '" + txtPlaceName.Text + "'), 1)";
                SqlCommand cmd = new SqlCommand(addFlat, con);
                cmd.ExecuteScalar();
                con.Close();
            }

            if (radTerHill.Checked == true)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
                con.Open();
                string addHill = "INSERT INTO WalksTerrain (WalkID, TerrainID) VALUES ((SELECT WalkID FROM Walk WHERE " +
                                 "WalkPostCode = '" + txtPostcode.Text + "' AND WalkName = '" + txtPlaceName.Text + "'), 2)";
                SqlCommand cmd = new SqlCommand(addHill, con);
                cmd.ExecuteScalar();
                con.Close();
            }

            if (radTerRough.Checked == true)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
                con.Open();
                string addRough = "INSERT INTO WalksTerrain (WalkID, TerrainID) VALUES ((SELECT WalkID FROM Walk WHERE " +
                                 "WalkPostCode = '" + txtPostcode.Text + "' AND WalkName = '" + txtPlaceName.Text + "'), 3)";
                SqlCommand cmd = new SqlCommand(addRough, con);
                cmd.ExecuteScalar();
                con.Close();
            }

            if (radTerMud.Checked == true)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
                con.Open();
                string addMud = "INSERT INTO WalksTerrain (WalkID, TerrainID) VALUES ((SELECT WalkID FROM Walk WHERE " +
                                 "WalkPostCode = '" + txtPostcode.Text + "' AND WalkName = '" + txtPlaceName.Text + "'), 4)";
                SqlCommand cmd = new SqlCommand(addMud, con);
                cmd.ExecuteScalar();
                con.Close();
            }

            if (radTerMount.Checked == true)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
                con.Open();
                string addMount = "INSERT INTO WalksTerrain (WalkID, TerrainID) VALUES ((SELECT WalkID FROM Walk WHERE " +
                                 "WalkPostCode = '" + txtPostcode.Text + "' AND WalkName = '" + txtPlaceName.Text + "'), 5)";
                SqlCommand cmd = new SqlCommand(addMount, con);
                cmd.ExecuteScalar();
                con.Close();
            }

            if (radTerValley.Checked == true)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
                con.Open();
                string addValley = "INSERT INTO WalksTerrain (WalkID, TerrainID) VALUES ((SELECT WalkID FROM Walk WHERE " +
                                 "WalkPostCode = '" + txtPostcode.Text + "' AND WalkName = '" + txtPlaceName.Text + "'), 6)";
                SqlCommand cmd = new SqlCommand(addValley, con);
                cmd.ExecuteScalar();
                con.Close();
            }

            if (radTerForest.Checked == true)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
                con.Open();
                string addForest = "INSERT INTO WalksTerrain (WalkID, TerrainID) VALUES ((SELECT WalkID FROM Walk WHERE " +
                                 "WalkPostCode = '" + txtPostcode.Text + "' AND WalkName = '" + txtPlaceName.Text + "'), 7)";
                SqlCommand cmd = new SqlCommand(addForest, con);
                cmd.ExecuteScalar();
                con.Close();
            }

            if (radTerMarsh.Checked == true)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
                con.Open();
                string addMarsh = "INSERT INTO WalksTerrain (WalkID, TerrainID) VALUES ((SELECT WalkID FROM Walk WHERE " +
                                 "WalkPostCode = '" + txtPostcode.Text + "' AND WalkName = '" + txtPlaceName.Text + "'), 8)";
                SqlCommand cmd = new SqlCommand(addMarsh, con);
                cmd.ExecuteScalar();
                con.Close();
            }

            if (radTerRiver.Checked == true)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
                con.Open();
                string addRiver = "INSERT INTO WalksTerrain (WalkID, TerrainID) VALUES ((SELECT WalkID FROM Walk WHERE " +
                                 "WalkPostCode = '" + txtPostcode.Text + "' AND WalkName = '" + txtPlaceName.Text + "'), 9)";
                SqlCommand cmd = new SqlCommand(addRiver, con);
                cmd.ExecuteScalar();
                con.Close();
            }

            if (radTerBeach.Checked == true)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
                con.Open();
                string addBeach = "INSERT INTO WalksTerrain (WalkID, TerrainID) VALUES ((SELECT WalkID FROM Walk WHERE " +
                                 "WalkPostCode = '" + txtPostcode.Text + "' AND WalkName = '" + txtPlaceName.Text + "'), 10)";
                SqlCommand cmd = new SqlCommand(addBeach, con);
                cmd.ExecuteScalar();
                con.Close();
            }

            Response.Redirect("Walk_AllWalk.aspx");
        }
        

        protected void SaveChanges_Click(object sender, EventArgs e)
        {
            checkWalks();
        }

        protected void noCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Walk_AllWalks.aspx");
        }

        protected void yesCont_Click(object sender, EventArgs e)
        {
            saveWalk();
        }

        //TERRAIN CHECKED
        protected void radTerFlat_CheckedChanged(object sender, EventArgs e)
        {
            addTerrain();
        }

        protected void radTerHill_CheckedChanged(object sender, EventArgs e)
        {
            addTerrain();
        }

        protected void radTerRough_CheckedChanged(object sender, EventArgs e)
        {
            addTerrain();
        }

        protected void radTerMud_CheckedChanged(object sender, EventArgs e)
        {
            addTerrain();
        }

        protected void radTerMount_CheckedChanged(object sender, EventArgs e)
        {
            addTerrain();
        }

        protected void radTerValley_CheckedChanged(object sender, EventArgs e)
        {
            addTerrain();
        }

        protected void radTerForest_CheckedChanged(object sender, EventArgs e)
        {
            addTerrain();
        }

        protected void radTerMarsh_CheckedChanged(object sender, EventArgs e)
        {
            addTerrain();
        }

        protected void radTerRiver_CheckedChanged(object sender, EventArgs e)
        {
            addTerrain();
        }

        protected void radTerBeach_CheckedChanged(object sender, EventArgs e)
        {
            addTerrain();
        }

        //FACILITIES CHECKED
        protected void radEntryTrue_CheckedChanged(object sender, EventArgs e)
        {
            addFacilities();
        }

        protected void radEntryFalse_CheckedChanged(object sender, EventArgs e)
        {
            addFacilities();
        }

        protected void radParkingTrue_CheckedChanged(object sender, EventArgs e)
        {
            addFacilities();
        }

        protected void radParkingFalse_CheckedChanged(object sender, EventArgs e)
        {
            addFacilities();
        }

        protected void radLiveTrue_CheckedChanged(object sender, EventArgs e)
        {
            addFacilities();
        }

        protected void radLiveFalse_CheckedChanged(object sender, EventArgs e)
        {
            addFacilities();
        }

        protected void radToiletTrue_CheckedChanged(object sender, EventArgs e)
        {
            addFacilities();
        }

        protected void radToiletFalse_CheckedChanged(object sender, EventArgs e)
        {
            addFacilities();
        }

        protected void radRefreshTrue_CheckedChanged(object sender, EventArgs e)
        {
            addFacilities();
        }

        protected void radRereshFalse_CheckedChanged(object sender, EventArgs e)
        {
            addFacilities();
        }

        protected void radLeadOn_CheckedChanged(object sender, EventArgs e)
        {
            addFacilities();
        }

        protected void radLeadOff_CheckedChanged(object sender, EventArgs e)
        {
            addFacilities();
        }

        protected void radWheelTrue_CheckedChanged(object sender, EventArgs e)
        {
            addFacilities();
        }

        protected void radWheelFalse_CheckedChanged(object sender, EventArgs e)
        {
            addFacilities();

        }
    }
}