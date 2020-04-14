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

            Session["newWalk"] = txtPlaceName.Text;
            Response.Redirect("Walk_NewWalk_Part2.aspx");
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
    }
}