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
    public partial class Walk_WalkDetails_TerrainFacilities : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                addWalkData();
                testing();
            }
        }

        private void testing()
        {
            string walking = Session["WalkID"].ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
            con.Open();

            string flatChk = "SELECT COUNT (*) FROM Walk JOIN WalksTerrain ON WalksTerrain.WalkID = Walk.WalkID" +
                             " JOIN Terrain ON Terrain.TerrainID = WalksTerrain.TerrainID WHERE Walk.WalkID='" + walking + "' AND TerrainType = 'Flat'";
            SqlCommand flat = new SqlCommand(flatChk, con);
            string flatOutput = flat.ExecuteScalar().ToString();

            string roughChk = "SELECT COUNT (*) FROM Walk JOIN WalksTerrain ON WalksTerrain.WalkID = Walk.WalkID" +
                             " JOIN Terrain ON Terrain.TerrainID = WalksTerrain.TerrainID WHERE Walk.WalkID='" + walking + "' AND TerrainType = 'Rough'";
            SqlCommand rough = new SqlCommand(roughChk, con);
            string roughOutput = rough.ExecuteScalar().ToString();

            if (flatOutput == "1")
            {
                radTerFlat.Checked = true;
            }

            if (roughOutput == "1")
            {
                radTerRough.Checked = true;
            }
        }

        private void addWalkData()
        {
            string walking = Session["WalkID"].ToString();

        }

        protected void btnSaveChanges_Click(object sender, EventArgs e)
        {

        }

        //TERRAINS
        protected void radTerFlat_CheckedChanged(object sender, EventArgs e)
        {
            string flat = "True";
        }

        protected void radTerHill_CheckedChanged(object sender, EventArgs e)
        {
            string hill = "True";
        }

        protected void radTerRough_CheckedChanged(object sender, EventArgs e)
        {
            string rough = "True";
        }

        protected void radTerMud_CheckedChanged(object sender, EventArgs e)
        {
            string mud = "True";
        }

        protected void radTerMount_CheckedChanged(object sender, EventArgs e)
        {
            string mount = "True";
        }

        protected void radTerValley_CheckedChanged(object sender, EventArgs e)
        {
            string valley = "True";
        }

        protected void radTerForest_CheckedChanged(object sender, EventArgs e)
        {
            string forest = "True";
        }

        protected void radTerMarsh_CheckedChanged(object sender, EventArgs e)
        {
            string marsh = "True";
        }

        protected void radTerRiver_CheckedChanged(object sender, EventArgs e)
        {
            string river = "True";
        }

        protected void radTerBeach_CheckedChanged(object sender, EventArgs e)
        {
            string beach = "True";
        }

        //FACILITIES
        protected void radEntryTrue_CheckedChanged(object sender, EventArgs e)
        {
            string entryTrue = "True";
        }

        protected void radEntryFalse_CheckedChanged(object sender, EventArgs e)
        {
            string entryFalse = "False";
        }

        protected void radParkingTrue_CheckedChanged(object sender, EventArgs e)
        {
            string parkTrue = "True";
        }

        protected void radParkingFalse_CheckedChanged(object sender, EventArgs e)
        {
            string parkFalse = "False";
        }

        protected void radLiveTrue_CheckedChanged(object sender, EventArgs e)
        {
            string liveTrue = "True";
        }

        protected void radLiveFalse_CheckedChanged(object sender, EventArgs e)
        {
            string liveFalse = "False";
        }

        protected void radRefreshTrue_CheckedChanged(object sender, EventArgs e)
        {
            string refreshTrue = "True";
        }

        protected void radRereshFalse_CheckedChanged(object sender, EventArgs e)
        {
            string refreshFalse = "False";
        }

        protected void radLeadOn_CheckedChanged(object sender, EventArgs e)
        {
            string leadOn = "True";
        }

        protected void radLeadOff_CheckedChanged(object sender, EventArgs e)
        {
            string leadOff = "True";
        }

        protected void radWheelTrue_CheckedChanged(object sender, EventArgs e)
        {
            string wheelTrue = "True";
        }

        protected void radWheelFalse_CheckedChanged(object sender, EventArgs e)
        {
            string wheelFalse = "False";
        }
    }
}