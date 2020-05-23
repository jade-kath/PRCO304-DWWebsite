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
    public partial class Walk_EditWalk_Facility : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] == null)
            {
                Response.Redirect("../../LoginPage.aspx");
            }

            if (!IsPostBack)
            {
                showWalkData();
            }
        }

        private void showWalkData()
        {
            string load = Session["WalkID"].ToString();
            string sqlQuery = @"SELECT EntryCost, ParkingDetail, LivestockDetail, ToiletsDetail, RefreshmentDetail," +
                               " LeadDetail FROM Walk WHERE WalkID = '" + load + "'";
            ConnectionClass conn = new ConnectionClass();
            conn.retrieveData(sqlQuery);

            foreach (DataRow dr in conn.SQLTable.Rows)
            {
                txtEntryCost.Text = (string)dr[0];
                txtParkDetails.Text = (string)dr[1];
                txtLiveDetails.Text = (string)dr[2];
                txtToiletDetails.Text = (string)dr[3];
                txtRefreshDetails.Text = (string)dr[4];
                txtLeadDetails.Text = (string)dr[5];
            }

            string session = Session["WalkID"].ToString();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
            con.Open();

            string entry = @"SELECT COUNT (*) FROM Walk Where WalkID = '" + session + "' AND EntryFee = 'True'";
            SqlCommand cmdEntry = new SqlCommand(entry, con);
            string outputEntry = cmdEntry.ExecuteScalar().ToString();

            if (outputEntry == "1")
            {
                radEntryTrue.Checked = true;
                radEntryFalse.Checked = false;
            }
            else
            {
                radEntryTrue.Checked = false;
                radEntryFalse.Checked = true;
            }

            string park = @"SELECT COUNT (*) FROM Walk Where WalkID = '" + session + "' AND FreeParking = 'True'";
            SqlCommand cmdPark = new SqlCommand(park, con);
            string outputPark = cmdPark.ExecuteScalar().ToString();

            if (outputPark == "1")
            {
                radParkingTrue.Checked = true;
                radParkingFalse.Checked = false;
            }
            else
            {
                radParkingTrue.Checked = false;
                radParkingFalse.Checked = true;
            }

            string livestock = @"SELECT COUNT (*) FROM Walk Where WalkID = '" + session + "' AND Livestock = 'True'";
            SqlCommand cmdLive = new SqlCommand(livestock, con);
            string outputLive = cmdLive.ExecuteScalar().ToString();

            if (outputLive == "1")
            {
                radLiveTrue.Checked = true;
                radLiveFalse.Checked = false;
            }
            else
            {
                radLiveTrue.Checked = false;
                radLiveFalse.Checked = true;
            }

            string toilets = @"SELECT COUNT (*) FROM Walk Where WalkID = '" + session + "' AND Toilets = 'True'";
            SqlCommand cmdToilet = new SqlCommand(toilets, con);
            string outputToilet = cmdToilet.ExecuteScalar().ToString();

            if (outputToilet == "1")
            {
                radToiletTrue.Checked = true;
                radToiletFalse.Checked = false;
            }
            else
            {
                radToiletTrue.Checked = false;
                radToiletFalse.Checked = true;
            }

            string refreshments = @"SELECT COUNT (*) FROM Walk Where WalkID = '" + session + "' AND Refreshments = 'True'";
            SqlCommand cmdRefresh = new SqlCommand(refreshments, con);
            string outputRefresh = cmdRefresh.ExecuteScalar().ToString();

            if (outputRefresh == "1")
            {
                radRefreshTrue.Checked = true;
                radRefreshFalse.Checked = false;
            }
            else
            {
                radRefreshTrue.Checked = false;
                radRefreshFalse.Checked = true;
            }

            string wheelchair = @"SELECT COUNT (*) FROM Walk Where WalkID = '" + session + "' AND WheelchairFriendly = 'True'";
            SqlCommand cmdWheel = new SqlCommand(wheelchair, con);
            string outputWheel = cmdWheel.ExecuteScalar().ToString();

            if (outputWheel == "1")
            {
                radWheelTrue.Checked = true;
                radWheelFalse.Checked = false;
            }
            else
            {
                radWheelTrue.Checked = false;
                radWheelFalse.Checked = true;
            }

            string onLead = @"SELECT COUNT (*) FROM Walk Where WalkID = '" + session + "' AND OnLead = 'True'";
            SqlCommand cmdOn = new SqlCommand(onLead, con);
            string outputOn = cmdOn.ExecuteScalar().ToString();

            if (outputOn == "1")
            {
                radLeadOn.Checked = true;
            }
            else
            {
                radLeadOn.Checked = false;
            }

            string offLead = @"SELECT COUNT (*) FROM Walk Where WalkID = '" + session + "' AND OffLead = 'True'";
            SqlCommand cmdOff = new SqlCommand(offLead, con);
            string outputOff = cmdOff.ExecuteScalar().ToString();
      
            if (outputOff == "1")
            {
                radLeadOff.Checked = true;
            }
            else
            {
                radLeadOff.Checked = false;
            }
            
            con.Close();
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

            string session = Session["WalkID"].ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
            con.Open();
            string addFacilities = "UPDATE Walk SET EntryFee = '" + entry + "' , EntryCost = '" + txtEntryCost.Text + "' , " +
                                   "FreeParking = '" + parking + "', ParkingDetail = '" + txtParkDetails.Text + "', Livestock = '" + live + "', " +
                                   "LivestockDetail = '" + txtLiveDetails.Text + "', Toilets = '" + toilet + "', ToiletsDetail = '" + txtToiletDetails.Text + "', " +
                                   "Refreshments = '" + refresh + "', RefreshmentDetail = '" + txtRefreshDetails.Text + "', " +
                                   "WheelchairFriendly = '" + wheel + "', OffLead = '" + leadOff + "', OnLead = '" + leadOn + "', " +
                                   "LeadDetails = '" + txtLeadDetails.Text + "' WHERE WalkID = '" + session + "'";
            SqlCommand cmd = new SqlCommand(addFacilities, con);
            cmd.ExecuteScalar();
            con.Close();
            Response.Redirect("Walk_WalkPreview.aspx");
        }

        protected void btnClearLead_Click(object sender, EventArgs e)
        {
            radLeadOn.Checked = false;
            radLeadOff.Checked = false;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Walk_WalkPreview.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            addFacilities();
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("../../index.aspx");
        }
    }
}