using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DogWalking.User_Side.Outbreaks
{
    public partial class User_ReportedOB : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("../../index.aspx");
            }

            bindOutbreak();
        }

        private void bindOutbreak()
        {
            string user = Session["User"].ToString();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
            SqlDataAdapter sda = new SqlDataAdapter("SELECT Outbreak.OutbreakDate, Outbreak.OutbreakType, Walk.WalkName," +
                                                    " Location.Location, Walk.WalkPostcode, Outbreak.ODescription, Users.Username FROM" +
                                                    " Outbreak JOIN Walk ON Outbreak.WalkID = Walk.WalkID JOIN Location ON" +
                                                    " Walk.LocationID = Location.LocationID JOIN Users ON Users.UserID = Outbreak.UserID WHERE Users.Username = '" + user + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            lstOutbreaks.DataSource = dt;
            lstOutbreaks.DataBind();
        }

        protected void btnNewOutbreak_Click(object sender, EventArgs e)
        {
            Response.Redirect("User_AddOB.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("../UserProfile.aspx");
        }

        protected void lstOutbreaks_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = lstOutbreaks.SelectedDataKey.Value.ToString();

            string sqlQuery = @"SELECT WalkID FROM Walk WHERE WalkPostcode = '" + value + "'";
            ConnectionClass conn = new ConnectionClass();
            conn.retrieveData(sqlQuery);

            string WalkID = "";

            foreach (DataRow dr in conn.SQLTable.Rows)
            {
                WalkID = (string)dr[0];
            }

            Session["WalkID"] = WalkID;

            Response.Redirect("../User_WalkPreview.aspx");
        }
    }
}