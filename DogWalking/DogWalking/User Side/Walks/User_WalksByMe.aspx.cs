using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DogWalking.User_Side.Walks
{
    public partial class User_WalksByMe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("LoginPage.aspx");
            }

            if (!IsPostBack)
            {
                bindToGridConfirmed();
                bindToGridPending();
            }         
        }

        private void bindToGridPending()
        {
            string user = Session["User"].ToString();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
            SqlDataAdapter sda = new SqlDataAdapter("SELECT Walk.WalkName, Location.Location, Walk.WalkAddress, Walk.WalkPostcode, Walk.Description FROM Walk JOIN" +
                               " Location ON Location.LocationID = Walk.LocationID JOIN Users ON Walk.UserID = Users.UserID WHERE Users.Username = '" + user + "'" +
                               " AND Walk.NewWalk = 'True' OR Walk.Published = 'False'", con);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            lstPending.DataSource = dt;
            lstPending.DataBind();
        }

        private void bindToGridConfirmed()
        {
            string user = Session["User"].ToString();

            SqlConnection con = new SqlConnection("connect");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT Walk.WalkName, Location.Location, Walk.WalkAddress, Walk.WalkPostcode," +
                                                    " Walk.Description, Walk.ImagePath FROM Walk JOIN Location ON Location.LocationID = Walk.LocationID" +
                                                    " JOIN Users ON Walk.UserID = Users.UserID WHERE Users.Username = '" + user + "' AND Walk.Published = 'True'", con);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            lstConfirmed.DataSource = dt;
            lstConfirmed.DataBind();

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Session.Remove("WalkID");
            Session.Remove("userWalk");
            Response.Redirect("../UserProfile.aspx");
        }

        protected void btnAddWalk_Click(object sender, EventArgs e)
        {
            Session.Remove("WalkID");
            Session.Remove("userWalk");
            Response.Redirect("User_Walk_Add_Page1.aspx");
        }

        protected void lstPending_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = lstPending.SelectedDataKey.Value.ToString();

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

        protected void lstConfirmed_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = lstConfirmed.SelectedDataKey.Value.ToString();

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
    }
}
 