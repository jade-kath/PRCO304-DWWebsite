﻿using System;
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
    public partial class Walk_NewWalk_Part2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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

            string session = Session["newWalk"].ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
            con.Open();
            string addFacilities = "UPDATE Walk SET EntryFee = '" + entry + "' , EntryCost = '" + txtEntryCost.Text + "' , " +
                                   "FreeParking = '" + parking + "', ParkingDetail = '" + txtParkDetails.Text + "', Livestock = '" + live + "', " +
                                   "LivestockDetail = '" + txtLiveDetails.Text + "', Toilets = '" + toilet + "', ToiletsDetail = '" + txtToiletDetails.Text + "', " +
                                   "Refreshments = '" + refresh + "', RefreshmentDetail = '" + txtRefreshDetails + "', " +
                                   "WheelchairFriendly = '" + wheel + "', OffLead = '" + leadOff + "', OnLead = '" + leadOn + "', " +
                                   "LeadDetails = '" + txtLeadDetails.Text + "' WHERE WalkName = '" + session + "'";
            SqlCommand cmd = new SqlCommand(addFacilities, con);
            cmd.ExecuteScalar();
            con.Close();
        }

        private void addTerrain()
        {
            string session = Session["newWalk"].ToString();

            if (radTerFlat.Checked == true)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
                con.Open();
                string addFlat = "INSERT INTO WalksTerrain (WalkID, TerrainID) VALUES ((SELECT WalkID FROM Walk WHERE " +
                                 "WalkName = '" + session + "'), 1)";
                SqlCommand cmd = new SqlCommand(addFlat, con);
                cmd.ExecuteScalar();
                con.Close();
            }

            if (radTerHill.Checked == true)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
                con.Open();
                string addHill = "INSERT INTO WalksTerrain (WalkID, TerrainID) VALUES ((SELECT WalkID FROM Walk WHERE " +
                                 "WalkName = '" + session + "'), 2)";
                SqlCommand cmd = new SqlCommand(addHill, con);
                cmd.ExecuteScalar();
                con.Close();
            }

            if (radTerRough.Checked == true)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
                con.Open();
                string addRough = "INSERT INTO WalksTerrain (WalkID, TerrainID) VALUES ((SELECT WalkID FROM Walk WHERE " +
                                 "WalkName = '" + session + "'), 3)";
                SqlCommand cmd = new SqlCommand(addRough, con);
                cmd.ExecuteScalar();
                con.Close();
            }

            if (radTerMud.Checked == true)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
                con.Open();
                string addMud = "INSERT INTO WalksTerrain (WalkID, TerrainID) VALUES ((SELECT WalkID FROM Walk WHERE " +
                                 "WalkName = '" + session + "'), 4)";
                SqlCommand cmd = new SqlCommand(addMud, con);
                cmd.ExecuteScalar();
                con.Close();
            }

            if (radTerMount.Checked == true)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
                con.Open();
                string addMount = "INSERT INTO WalksTerrain (WalkID, TerrainID) VALUES ((SELECT WalkID FROM Walk WHERE " +
                                 "WalkName = '" + session + "'), 5)";
                SqlCommand cmd = new SqlCommand(addMount, con);
                cmd.ExecuteScalar();
                con.Close();
            }

            if (radTerValley.Checked == true)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
                con.Open();
                string addValley = "INSERT INTO WalksTerrain (WalkID, TerrainID) VALUES ((SELECT WalkID FROM Walk WHERE " +
                                 "WalkName = '" + session + "'), 6)";
                SqlCommand cmd = new SqlCommand(addValley, con);
                cmd.ExecuteScalar();
                con.Close();
            }

            if (radTerForest.Checked == true)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
                con.Open();
                string addForest = "INSERT INTO WalksTerrain (WalkID, TerrainID) VALUES ((SELECT WalkID FROM Walk WHERE " +
                                 "WalkName = '" + session + "'), 7)";
                SqlCommand cmd = new SqlCommand(addForest, con);
                cmd.ExecuteScalar();
                con.Close();
            }

            if (radTerMarsh.Checked == true)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
                con.Open();
                string addMarsh = "INSERT INTO WalksTerrain (WalkID, TerrainID) VALUES ((SELECT WalkID FROM Walk WHERE " +
                                 "WalkName = '" + session + "'), 8)";
                SqlCommand cmd = new SqlCommand(addMarsh, con);
                cmd.ExecuteScalar();
                con.Close();
            }

            if (radTerRiver.Checked == true)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
                con.Open();
                string addRiver = "INSERT INTO WalksTerrain (WalkID, TerrainID) VALUES ((SELECT WalkID FROM Walk WHERE " +
                                 "WalkName = '" + session + "'), 9)";
                SqlCommand cmd = new SqlCommand(addRiver, con);
                cmd.ExecuteScalar();
                con.Close();
            }

            if (radTerBeach.Checked == true)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
                con.Open();
                string addBeach = "INSERT INTO WalksTerrain (WalkID, TerrainID) VALUES ((SELECT WalkID FROM Walk WHERE " +
                                 "WalkName = '" + session + "'), 10)";
                SqlCommand cmd = new SqlCommand(addBeach, con);
                cmd.ExecuteScalar();
                con.Close();
            }

            Response.Redirect("Walk_AllWalks.aspx");
        }

        private void Clear()
        {
            radTerFlat.Checked = false;
            radTerHill.Checked = false;
            radTerRough.Checked = false;
            radTerMud.Checked = false;
            radTerMount.Checked = false;
            radTerMarsh.Checked = false;
            radTerRiver.Checked = false;
            radTerValley.Checked = false;
            radTerForest.Checked = false;
            radTerBeach.Checked = false;
        }

        protected void btnClearTer_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void clearLead()
        {
            radLeadOff.Checked = false;
            radLeadOn.Checked = false;
        }

        protected void btnClearLead_Click(object sender, EventArgs e)
        {
            clearLead();
        }

        protected void Back_Click(object sender, EventArgs e)
        { 
            Session["goBack"] = Session["newWalk"];
            Response.Redirect("Walk_NewWalk_NamePhotos.aspx");
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            addFacilities();
            addTerrain();
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            string session = Session["newWalk"].ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
            con.Open();
            string deleteWalk = "DELETE FROM Walk WHERE WalkName = '" + session + "'";
            SqlCommand cmd = new SqlCommand(deleteWalk, con);
            cmd.ExecuteScalar();
            con.Close();

            Session.Remove("newWalk");
            Response.Redirect("Walk_AllWalks.aspx");
        }

        //TERRAIN
        protected void radTerFlat_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void radTerHill_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void radTerRough_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void radTerMud_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void radTerMount_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void radTerValley_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void radTerForest_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void radTerMarsh_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void radTerRiver_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void radTerBeach_CheckedChanged(object sender, EventArgs e)
        {

        }

        //FACILITIES
        protected void radEntryTrue_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void radEntryFalse_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void radParkingTrue_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void radParkingFalse_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void radLiveTrue_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void radLiveFalse_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void radToiletTrue_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void radToiletFalse_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void radRefreshTrue_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void radRereshFalse_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void radLeadOn_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void radLeadOff_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void radWheelTrue_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void radWheelFalse_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}