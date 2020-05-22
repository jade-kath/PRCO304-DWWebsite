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
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            allWalks();
        }

        private void allWalks()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
            SqlDataAdapter sda = new SqlDataAdapter("SELECT Walk.WalkName, Location.Location, Walk.WalkAddress, Walk.WalkPostcode," +
                                                    " Walk.Description, Walk.ImagePath FROM Walk JOIN Location ON Location.LocationID = Walk.LocationID" +
                                                    " WHERE Walk.Published = 'True' ORDER BY Walk.WalkName, Location.Location", con);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            lstAll.DataSource = dt;
            lstAll.DataBind();

        }

        private void checkCreator()
        {
            string value = lstAll.SelectedDataKey.Value.ToString();

            string sqlQuery = @"SELECT WalkID FROM Walk WHERE WalkPostcode = '" + value + "'";
            ConnectionClass conn = new ConnectionClass();
            conn.retrieveData(sqlQuery);

            string WalkID = "";

            foreach (DataRow dr in conn.SQLTable.Rows)
            {
                WalkID = (string)dr[0];
            }

            Session["WalkID"] = WalkID;
            
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
            con.Open();

            string Query = @"SELECT COUNT (*) FROM Walk JOIN Users ON Users.UserID = Walk.UserID WHERE Walk.WalkID = '" + WalkID + "' AND Walk.Published = 'True'";
            SqlCommand cmdQuery = new SqlCommand(Query, con);
            string outputQuery = cmdQuery.ExecuteScalar().ToString();

            if (outputQuery == "1")
            {
                if (Session["User"] != null)
                {
                    Session["userWalk"] = "userWalk";
                }
            }

            con.Close();

            Response.Redirect("../User_WalkPreview.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Session["searchWalk"] = txtSearchBar.Text;
            Response.Redirect("searchResults.aspx");
        }

        protected void lstConfirmed_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkCreator();
        }
    }
}