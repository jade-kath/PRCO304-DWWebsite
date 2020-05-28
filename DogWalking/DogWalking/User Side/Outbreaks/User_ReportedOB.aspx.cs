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

            string query = @"SELECT Outbreak.OutbreakID, Outbreak.OutbreakDate, Outbreak.OutbreakType, Walk.WalkName," +
                           " Location.Location, Walk.WalkPostcode, Outbreak.ODescription FROM" +
                           " Outbreak JOIN Walk ON Outbreak.WalkID = Walk.WalkID JOIN Location ON" +
                           " Walk.LocationID = Location.LocationID JOIN Users ON Users.UserID = Outbreak.UserID WHERE Users.Username = '" + user + "'";

            ConnectionClass conn = new ConnectionClass();
            conn.retrieveData(query);

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("OutbreakID", typeof(int)),
                new DataColumn("OutbreakDate",typeof(DateTime)),
                new DataColumn("OutbreakType", typeof(string)),
                new DataColumn("WalkName", typeof(string)),
                new DataColumn("Location", typeof(string)),
                new DataColumn("WalkPostcode", typeof(string)),
                new DataColumn("ODescription", typeof(string))
            });

            foreach (DataRow dr in conn.SQLTable.Rows)
            {
                int OutbreakID = (int)dr[0];
                string OutbreakDate = ((DateTime)dr[1]).ToShortDateString();
                string OutbreakType = (string)dr[2];
                string WalkName = (string)dr[3];
                string Location = (string)dr[4];
                string WalkPostcode = (string)dr[5];
                string ODescription = (string)dr[6];

                dt.Rows.Add(OutbreakID, OutbreakDate, OutbreakType, WalkName, Location, WalkPostcode, ODescription);
            }

            this.grdRepOB.DataSource = dt;
            this.grdRepOB.DataBind();

        }

        protected void btnNewOutbreak_Click(object sender, EventArgs e)
        {
            Response.Redirect("User_AddOB.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("../UserProfile.aspx");
        }

        protected void grdRepOB_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = this.grdRepOB.SelectedRow.Cells[1].ToString();

            string sqlQuery = @"SELECT WalkID FROM Walk JOIN Outbreak ON Outbreak.WalkID = Walk.WalkID WHERE OutbreakID = '" + value + "'";
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

        //navbar
        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("../../index.aspx");
        }

        protected void btnProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("../UserProfile.aspx");
        }

        protected void btnSettings_Click(object sender, EventArgs e)
        {
            Response.Redirect("../CRUD User Settings/UserEditSettings.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("../../index.aspx");
        }
    }
}