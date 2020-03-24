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
                addWalk();
            }
        }

        private void addWalk()
        {
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

            
            string walking = Session["newWalk"].ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
            con.Open();
            string createWalk = "INSERT INTO Walk (EntryFee, EntryCost, FreeParking, ParkingDetail, Livestock, LivestockDetail, Toilets," +
                                 " ToiletsDetail, Refreshments, RefreshmentDetail, WheelchairFriendly, OffLead, OnLead, LeadDetails) VALUES" +
                                 " ('" + entry +"', '" + txtEntryCost.Text + "', '" + parking + "', '" + txtParkDetails.Text + "'," +
                                 " '" + live + "', '" + txtLiveDetails.Text + "', '" + toilet + "', '" + txtToiletDetails.Text + "'," +
                                 " '" + refresh + "', '" + txtRefreshDetails.Text + "', '" + wheel + "', '" + leadOff + "'," +
                                 " '" + leadOn + "', '" + txtLeadDetails.Text + "') WHERE WalkID = '" + walking +"'";
            SqlCommand cmd = new SqlCommand(createWalk, con);
            cmd.ExecuteScalar();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Walk_NewWalk_NamePhoto.aspx");
        }

        protected void btnSaveChanges_Click(object sender, EventArgs e)
        {
            addWalk();
        }
    }
}