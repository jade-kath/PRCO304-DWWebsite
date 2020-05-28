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
            if (Session["User"] != null)
            {
                btnLogin.Visible = false;
                btnLogout.Visible = true;
                btnProfile.Visible = true;
                btnSettings.Visible = true;
            }

            allWalks();
        }

        private void allWalks()
        {
            string sqlQuery = @"SELECT Walk.WalkID, Walk.WalkName, Location.Location, Walk.WalkAddress, Walk.WalkPostcode," +
                               " Walk.Description, Walk.ImagePath FROM Walk JOIN Location ON Location.LocationID = Walk.LocationID" +
                               " WHERE Walk.Published = 'True' ORDER BY Walk.WalkName, Location.Location";

            ConnectionClass conn = new ConnectionClass();
            conn.retrieveData(sqlQuery);

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("WalkID", typeof(int)),
                new DataColumn("WalkName",typeof(string)),
                new DataColumn("Location", typeof(string)),
                new DataColumn("WalkAddress", typeof(string)),
                new DataColumn("WalkPostcode", typeof(string))
            });

            foreach (DataRow dr in conn.SQLTable.Rows)
            {
                int WalkID = (int)dr[0];
                string WalkName = (string)dr[1];
                string Location = (string)dr[2];
                string WalkAddress = (string)dr[3];
                string WalkPostcode = (string)dr[4];

                dt.Rows.Add(WalkID, WalkName, Location, WalkAddress, WalkPostcode);
            }

            this.grdWalks.DataSource = dt;
            this.grdWalks.DataBind();

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Session["searchWalk"] = txtSearchBar.Text;
            Response.Redirect("searchResults.aspx");
        }

        protected void grdWalks_SelectedIndexChanged1(object sender, EventArgs e)
        {
            Session["WalkID"] = this.grdWalks.SelectedRow.Cells[1].ToString();
            Response.Redirect("User Side/User_WalkPreview.aspx");
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx");
        }

        protected void btnProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("User Side/UserProfile.aspx");
        }

        protected void btnSettings_Click(object sender, EventArgs e)
        {
            Response.Redirect("User Side/CRUD User Settings/UserEditSettings.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("");
        }
    }
}