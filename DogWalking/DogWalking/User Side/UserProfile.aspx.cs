using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DogWalking
{
    public partial class UserProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("LoginPage.aspx");
            }
        }

        private void walksByMe()
        {
            string user = Session["User"].ToString();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
            SqlDataAdapter sda = new SqlDataAdapter("SELECT TOP 5 Walk.WalkName, Location.Location, Walk.WalkAddress, Walk.WalkPostcode," +
                                                    " Walk.Description, Walk.ImagePath FROM Walk JOIN Location ON Location.LocationID = Walk.LocationID" +
                                                    " JOIN Users ON Walk.UserID = Users.UserID WHERE Users.Username = '" + user + "' AND Walk.Published = 'True'", con);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            lstMyWalks.DataSource = dt;
            lstMyWalks.DataBind();

        }

        private void bindOutbreak()
        {
            string user = Session["User"].ToString();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
            SqlDataAdapter sda = new SqlDataAdapter("SELECT TOP 5 Outbreak.OutbreakDate, Outbreak.OutbreakType, Walk.WalkName," +
                                                    " Location.Location, Walk.WalkPostcode, Outbreak.ODescription, Users.Username FROM" +
                                                    " Outbreak JOIN Walk ON Outbreak.WalkID = Walk.WalkID JOIN Location ON" +
                                                    " Walk.LocationID = Location.LocationID JOIN Users ON Users.UserID = Outbreak.UserID WHERE Users.Username = '" + user + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            lstOutbreaks.DataSource = dt;
            lstOutbreaks.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("../index.aspx");
        }

        protected void btnAddWalk_Click(object sender, EventArgs e)
        {
            Response.Redirect("Walks/User_Walk_Add_Page1.aspx");
        }

        protected void btnAddOutbreak_Click(object sender, EventArgs e)
        {
            Response.Redirect("Outbreaks/User_AddOB.aspx");
        }

        protected void lstMyWalks_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = lstMyWalks.SelectedDataKey.Value.ToString();

            string sqlQuery = @"SELECT WalkID FROM Walk WHERE WalkPostcode = '" + value + "'";
            ConnectionClass conn = new ConnectionClass();
            conn.retrieveData(sqlQuery);

            string WalkID = "";

            foreach (DataRow dr in conn.SQLTable.Rows)
            {
                WalkID = (string)dr[0];
            }

            Session["WalkID"] = WalkID;
            Session["userWalk"] = "userWalk";

            Response.Redirect("../User_WalkPreview.aspx");
        }

        //navbar
        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("../index.aspx");
        }

        protected void btnProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("");
        }

        protected void btnSettings_Click(object sender, EventArgs e)
        {
            Response.Redirect("CRUD User Settings/UserEditSettings.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("../index.aspx");
        }
    }
}