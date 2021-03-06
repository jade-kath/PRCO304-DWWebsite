﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace DogWalking.Admin_Side.Walks
{
    public partial class Walk_EditWalk : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] == null)
            {
                Response.Redirect("../../LoginPage.aspx");
            }

            if (!IsPostBack)
            {
                showWalk();
                viewImage();
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

        private void showWalk()
        {
            string load = Session["WalkID"].ToString();
            string sqlQuery = @"SELECT Walk.WalkName, Walk.WalkAddress, Walk.WalkPostcode, Walk.LocationID," +
                               " Walk.Description, Walk.Hours, Walk.Duration FROM Walk WHERE Walk.WalkID = '" + load + "'";
            ConnectionClass conn = new ConnectionClass();
            conn.retrieveData(sqlQuery);

            foreach (DataRow dr in conn.SQLTable.Rows)
            {
                txtPlaceName.Text = (string)dr[0];
                txtAddress.Text = (string)dr[1];
                txtPostcode.Text = (string)dr[2];
                drpLocation.SelectedIndex = (int)dr[3] - 1;
                txtDescript.Text = (string)dr[4];
                txtTimeLength.Text = (string)dr[5];
                txtDuration.Text = (string)dr[6];
            }
        }

        private void updateGeneral()
        {
            string session = Session["WalkID"].ToString();

            if (FileUpload != null)
            {
                string fileName = Path.GetFileName(FileUpload.PostedFile.FileName);
                string filePath = "../../Images/" + fileName;

                FileUpload.PostedFile.SaveAs(Server.MapPath(filePath));

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
                con.Open();

                string updateWalk = "UPDATE Walk SET Walk.WalkName = '" + txtPlaceName.Text + "', Walk.WalkAddress = '" + txtAddress.Text + "'," +
                                    " Walk.WalkPostcode = '" + txtPostcode.Text + "', Walk.LocationID = '" + drpLocation.SelectedValue + "'," +
                                    " Walk.Description = '" + txtDescript.Text + "', Walk.Hours = '" + txtTimeLength.Text + "'," +
                                    " Walk.Duration = '" + txtDuration.Text + "', Walk.ImageName = '" + fileName + "'," +
                                    " Walk.ImagePath = '" + filePath + "' WHERE WalkID = '" + session + "'";

                SqlCommand cmd = new SqlCommand(updateWalk, con);
                cmd.ExecuteScalar();
                con.Close();
            }
            else
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
                con.Open();

                string updateWalk = "UPDATE Walk SET Walk.WalkName = '" + txtPlaceName.Text + "', Walk.WalkAddress = '" + txtAddress.Text + "'," +
                                    " Walk.WalkPostcode = '" + txtPostcode.Text + "', Walk.LocationID = '" + drpLocation.SelectedValue + "'," +
                                    " Walk.Description = '" + txtDescript.Text + "', Walk.Hours = '" + txtTimeLength.Text + "'," +
                                    " Walk.Duration = '" + txtDuration.Text + "' WHERE WalkID = '" + session + "'";

                SqlCommand cmd = new SqlCommand(updateWalk, con);
                cmd.ExecuteScalar();
                con.Close();
            }

            Response.Redirect("Walk_WalkPreview.aspx");

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Walk_WalkPreview.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            updateGeneral();
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("index.aspx");
        }
    }
}