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
    public partial class searchResults : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadSearch();
        }

        private void loadSearch()
        {
            string location = Session["searchWalk"].ToString();

            SqlConnection con = new SqlConnection("connect");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT Walk.WalkName, Location.Location, Walk.WalkAddress, Walk.WalkPostcode," +
                                                    " Walk.Description FROM Walk JOIN Location ON Location.LocationID = Walk.LocationID" +
                                                    " JOIN Users ON Walk.UserID = Users.UserID WHERE Location.Location = '%" + location + "%' OR" +
                                                    " Walk.Postcode = '%" + location + "%' AND Walk.Published = 'True'", con);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            lstResults.DataSource = dt;
            lstResults.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Session["searchWalk"] = txtSearchBar.Text;
            Response.Redirect("searchResults.aspx");
        }


        protected void lstConfirmed_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = lstResults.SelectedDataKey.Value.ToString();

            string sqlQuery = @"SELECT WalkID FROM Walk WHERE WalkPostcode = '" + value + "'";
            ConnectionClass conn = new ConnectionClass();
            conn.retrieveData(sqlQuery);

            string WalkID = "";

            foreach (DataRow dr in conn.SQLTable.Rows)
            {
                WalkID = (string)dr[0];
            }

            Session["WalkID"] = WalkID;

            Response.Redirect("Walks/User_WalkPreview.aspx");
        }
    }
}