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

        }

        private void showSavedData()
        {
            string session = Session["WalkID"].ToString();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
            con.Open();

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
        }

        private void addTerrain()
        {
            string session = Session["WalkID"].ToString();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
            con.Open();

            //Start by deleting all previous terrains so there's no system crash.
            string delTerrain = @"DELETE FROM WalksTerrain WHERE WalkID = '" + session + "'";
            ConnectionClass conn = new ConnectionClass();
            conn.retrieveData(delTerrain);


            //Then add all terrains that have been checked.
            if (radTerFlat.Checked == true)
            {
                string addFlat = "INSERT INTO WalksTerrain (WalkID, TerrainID) VALUES (" + session + ", 1)";
                SqlCommand cmd = new SqlCommand(addFlat, con);
                cmd.ExecuteScalar();
                con.Close();
            }

            if (radTerHill.Checked == true)
            {
                string addHill = "INSERT INTO WalksTerrain (WalkID, TerrainID) VALUES (" + session + ", 2)";
                SqlCommand cmd = new SqlCommand(addHill, con);
                cmd.ExecuteScalar();
                con.Close();
            }

            if (radTerRough.Checked == true)
            {
                string addRough = "INSERT INTO WalksTerrain (WalkID, TerrainID) VALUES (" + session + ", 3)";
                SqlCommand cmd = new SqlCommand(addRough, con);
                cmd.ExecuteScalar();
                con.Close();
            }

            if (radTerMud.Checked == true)
            {
                string addMud = "INSERT INTO WalksTerrain (WalkID, TerrainID) VALUES (" + session + ", 4)";
                SqlCommand cmd = new SqlCommand(addMud, con);
                cmd.ExecuteScalar();
                con.Close();
            }

            if (radTerMount.Checked == true)
            {
                string addMount = "INSERT INTO WalksTerrain (WalkID, TerrainID) VALUES (" + session + ", 5)";
                SqlCommand cmd = new SqlCommand(addMount, con);
                cmd.ExecuteScalar();
                con.Close();
            }

            if (radTerValley.Checked == true)
            {
                string addValley = "INSERT INTO WalksTerrain (WalkID, TerrainID) VALUES (" + session + ", 6)";
                SqlCommand cmd = new SqlCommand(addValley, con);
                cmd.ExecuteScalar();
                con.Close();
            }

            if (radTerForest.Checked == true)
            {
                string addForest = "INSERT INTO WalksTerrain (WalkID, TerrainID) VALUES (" + session + ", 7)";
                SqlCommand cmd = new SqlCommand(addForest, con);
                cmd.ExecuteScalar();
                con.Close();
            }

            if (radTerMarsh.Checked == true)
            {
                string addMarsh = "INSERT INTO WalksTerrain (WalkID, TerrainID) VALUES (" + session + ", 8)";
                SqlCommand cmd = new SqlCommand(addMarsh, con);
                cmd.ExecuteScalar();
                con.Close();
            }

            if (radTerRiver.Checked == true)
            {
                string addRiver = "INSERT INTO WalksTerrain (WalkID, TerrainID) VALUES (" + session + ", 9)";
                SqlCommand cmd = new SqlCommand(addRiver, con);
                cmd.ExecuteScalar();
                con.Close();
            }

            if (radTerBeach.Checked == true)
            {
                string addBeach = "INSERT INTO WalksTerrain (WalkID, TerrainID) VALUES (" + session + ", 10)";
                SqlCommand cmd = new SqlCommand(addBeach, con);
                cmd.ExecuteScalar();
                con.Close();
            }

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
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Walk_WalkPreview.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}