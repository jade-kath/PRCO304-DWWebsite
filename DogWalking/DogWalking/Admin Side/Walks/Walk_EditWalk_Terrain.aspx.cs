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
    public partial class Walk_EditWalk_Terrain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] == null)
            {
                Response.Redirect("LoginPage.aspx");
            }

            if (!IsPostBack)
            {
                showSavedData();
            }
        }

        //Previewing and prechecking all terrains that are already associated with the walk
        private void showSavedData()
        {
            string session = Session["WalkID"].ToString();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
            con.Open();

            string flatQuery = @"SELECT COUNT (*) FROM WalksTerrain Where WalkID = '" + session + "' AND TerrainID = 1";
            SqlCommand cmdFlat = new SqlCommand(flatQuery, con);
            string outputFlat = cmdFlat.ExecuteScalar().ToString();

            if (outputFlat == "1")
            {
                radTerFlat.Checked = true;
            }
            else
            {
                radTerFlat.Checked = false;
            }

            string hillQuery = @"SELECT COUNT (*) FROM WalksTerrain Where WalkID = '" + session + "' AND TerrainID = 2";
            SqlCommand cmdHill = new SqlCommand(hillQuery, con);
            string outputHill = cmdHill.ExecuteScalar().ToString();

            if (outputHill == "1")
            {
                radTerHill.Checked = true;
            }
            else
            {
                radTerHill.Checked = false;
            }

            string roughQuery = @"SELECT COUNT (*) FROM WalksTerrain Where WalkID = '" + session + "' AND TerrainID = 3";
            SqlCommand cmdRough = new SqlCommand(roughQuery, con);
            string outputRough = cmdRough.ExecuteScalar().ToString();

            if (outputRough == "1")
            {
                radTerRough.Checked = true;
            }
            else
            {
                radTerRough.Checked = false;
            }

            string mudQuery = @"SELECT COUNT (*) FROM WalksTerrain Where WalkID = '" + session + "' AND TerrainID = 4";
            SqlCommand cmdMud = new SqlCommand(mudQuery, con);
            string outputMud = cmdMud.ExecuteScalar().ToString();

            if (outputMud == "1")
            {
                radTerMud.Checked = true;
            }
            else
            {
                radTerMud.Checked = false;
            }

            string MountQuery = @"SELECT COUNT (*) FROM WalksTerrain Where WalkID = '" + session + "' AND TerrainID = 5";
            SqlCommand cmdMount = new SqlCommand(MountQuery, con);
            string outputMount = cmdMount.ExecuteScalar().ToString();

            if (outputMount == "1")
            {
                radTerMount.Checked = true;
            }
            else
            {
                radTerMount.Checked = false;
            }

            string ValleyQuery = @"SELECT COUNT (*) FROM WalksTerrain Where WalkID = '" + session + "' AND TerrainID = 6";
            SqlCommand cmdValley = new SqlCommand(ValleyQuery, con);
            string outputValley = cmdValley.ExecuteScalar().ToString();

            if (outputValley == "1")
            {
                radTerValley.Checked = true;
            }
            else
            {
                radTerValley.Checked = false;
            }

            string forestQuery = @"SELECT COUNT (*) FROM WalksTerrain Where WalkID = '" + session + "' AND TerrainID = 7";
            SqlCommand cmdForest = new SqlCommand(forestQuery, con);
            string outputForest = cmdForest.ExecuteScalar().ToString();

            if (outputForest == "1")
            {
                radTerForest.Checked = true;
            }
            else
            {
                radTerForest.Checked = false;
            }

            string MarshQuery = @"SELECT COUNT (*) FROM WalksTerrain Where WalkID = '" + session + "' AND TerrainID = 8";
            SqlCommand cmdMarsh = new SqlCommand(MarshQuery, con);
            string outputMarsh = cmdMarsh.ExecuteScalar().ToString();

            if (outputMarsh == "1")
            {
                radTerMarsh.Checked = true;
            }
            else
            {
                radTerMarsh.Checked = false;
            }

            string riverQuery = @"SELECT COUNT (*) FROM WalksTerrain Where WalkID = '" + session + "' AND TerrainID = 9";
            SqlCommand cmdRiver = new SqlCommand(riverQuery, con);
            string outputRiver = cmdRiver.ExecuteScalar().ToString();

            if (outputRiver == "1")
            {
                radTerRiver.Checked = true;
            }
            else
            {
                radTerRiver.Checked = false;
            }

            string beachQuery = @"SELECT COUNT (*) FROM WalksTerrain Where WalkID = '" + session + "' AND TerrainID = 10";
            SqlCommand cmdBeach = new SqlCommand(beachQuery, con);
            string outputBeach = cmdBeach.ExecuteScalar().ToString();

            if (outputBeach == "1")
            {
                radTerBeach.Checked = true;
            }
            else
            {
                radTerBeach.Checked = false;
            }

            string parkQuery = @"SELECT COUNT (*) FROM WalksTerrain Where WalkID = '" + session + "' AND TerrainID = 11";
            SqlCommand cmdPark = new SqlCommand(parkQuery, con);
            string outputPark = cmdPark.ExecuteScalar().ToString();

            if (outputPark == "1")
            {
                radTerPark.Checked = true;
            }
            else
            {
                radTerPark.Checked = false;
            }
        }

        //Checks for any saved terrains on the walk so system doesn't crash
        private void checkTerrain()
        {
            string session = Session["WalkID"].ToString();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
            con.Open();

            string terQuery = @"SELECT COUNT (*) FROM WalksTerrain Where WalkID = '" + session + "'";
            SqlCommand cmdTer = new SqlCommand(terQuery, con);
            string outputTer = cmdTer.ExecuteScalar().ToString();

            if (outputTer == "0")
            {
                addTerrain();
            }
            else
            {
                //Start by deleting all previous terrains so there's no system crash.
                string delTerrain = @"DELETE FROM WalksTerrain WHERE WalkID = '" + session + "'";
                ConnectionClass conn = new ConnectionClass();
                conn.retrieveData(delTerrain);

                addTerrain();
            }
        }

        //Then add all terrains that have been checked.
        private void addTerrain()
        {
            string session = Session["WalkID"].ToString();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
            con.Open();

            if (radTerFlat.Checked == true)
            {
                string addFlat = "INSERT INTO WalksTerrain (WalkID, TerrainID) VALUES (" + session + ", 1)";
                SqlCommand cmd = new SqlCommand(addFlat, con);
                cmd.ExecuteScalar();
            }

            if (radTerHill.Checked == true)
            {
                string addHill = "INSERT INTO WalksTerrain (WalkID, TerrainID) VALUES (" + session + ", 2)";
                SqlCommand cmd = new SqlCommand(addHill, con);
                cmd.ExecuteScalar();
            }

            if (radTerRough.Checked == true)
            {
                string addRough = "INSERT INTO WalksTerrain (WalkID, TerrainID) VALUES (" + session + ", 3)";
                SqlCommand cmd = new SqlCommand(addRough, con);
                cmd.ExecuteScalar();
            }

            if (radTerMud.Checked == true)
            {
                string addMud = "INSERT INTO WalksTerrain (WalkID, TerrainID) VALUES (" + session + ", 4)";
                SqlCommand cmd = new SqlCommand(addMud, con);
                cmd.ExecuteScalar();
            }

            if (radTerMount.Checked == true)
            {
                string addMount = "INSERT INTO WalksTerrain (WalkID, TerrainID) VALUES (" + session + ", 5)";
                SqlCommand cmd = new SqlCommand(addMount, con);
                cmd.ExecuteScalar();
            }

            if (radTerValley.Checked == true)
            {
                string addValley = "INSERT INTO WalksTerrain (WalkID, TerrainID) VALUES (" + session + ", 6)";
                SqlCommand cmd = new SqlCommand(addValley, con);
                cmd.ExecuteScalar();
            }

            if (radTerForest.Checked == true)
            {
                string addForest = "INSERT INTO WalksTerrain (WalkID, TerrainID) VALUES (" + session + ", 7)";
                SqlCommand cmd = new SqlCommand(addForest, con);
                cmd.ExecuteScalar();
            }

            if (radTerMarsh.Checked == true)
            {
                string addMarsh = "INSERT INTO WalksTerrain (WalkID, TerrainID) VALUES (" + session + ", 8)";
                SqlCommand cmd = new SqlCommand(addMarsh, con);
                cmd.ExecuteScalar();
            }

            if (radTerRiver.Checked == true)
            {
                string addRiver = "INSERT INTO WalksTerrain (WalkID, TerrainID) VALUES (" + session + ", 9)";
                SqlCommand cmd = new SqlCommand(addRiver, con);
                cmd.ExecuteScalar();
            }

            if (radTerBeach.Checked == true)
            {
                string addBeach = "INSERT INTO WalksTerrain (WalkID, TerrainID) VALUES (" + session + ", 10)";
                SqlCommand cmd = new SqlCommand(addBeach, con);
                cmd.ExecuteScalar();
            }

            if (radTerPark.Checked == true)
            {
                string addPark = "INSERT INTO WalksTerrain (WalkID, TerrainID) VALUES (" + session + ", 11)";
                SqlCommand cmd = new SqlCommand(addPark, con);
                cmd.ExecuteScalar();
            }

            con.Close();
            Response.Redirect("Walk_WalkPreview.aspx");
        }

        protected void btnClearTer_Click(object sender, EventArgs e)
        {
            radTerFlat.Checked = false;
            radTerHill.Checked = false;
            radTerMud.Checked = false;
            radTerMount.Checked = false;
            radTerMarsh.Checked = false;
            radTerForest.Checked = false;
            radTerRiver.Checked = false;
            radTerValley.Checked = false;
            radTerRough.Checked = false;
            radTerBeach.Checked = false;
            radTerPark.Checked = false;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Walk_WalkPreview.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            checkTerrain();
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("index.aspx");
        }
    }
}