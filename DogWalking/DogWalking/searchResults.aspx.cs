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
            if (Session["User"] != null)
            {
                btnLogin.Visible = false;
                btnLogout.Visible = true;
                btnProfile.Visible = true;
                btnSettings.Visible = true;
            }

            if (!IsPostBack)
            {
                checkSearch();
            }
            
        }

        private void checkSearch()
        {
            string location = Session["searchWalk"].ToString();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
            con.Open();

            string Query = @"SELECT COUNT (*) FROM Walk JOIN Location ON Location.LocationID = Walk.LocationID" + 
                            " WHERE Location.Location LIKE '%" + location + "%' OR Walk.WalkPostcode LIKE '%" + location + "%' OR Walk.WalkName LIKE '%" + location + "%' AND Walk.Published = 'True'";
            SqlCommand cmdQuery = new SqlCommand(Query, con);
            string outputQuery = cmdQuery.ExecuteScalar().ToString();

            if (outputQuery != "0")
            {
                loadSearch();
            }
            else
            {
                lblNoResults.Visible = true;
            }
        }

        private void loadSearch()
        {
            string location = Session["searchWalk"].ToString();

            string sqlQuery = @"SELECT Walk.WalkID, Walk.WalkName, Location.Location, Walk.WalkAddress, Walk.WalkPostcode," +
                               " Walk.Description FROM Walk JOIN Location ON Location.LocationID = Walk.LocationID" +
                               " JOIN Users ON Walk.UserID = Users.UserID WHERE Location.Location LIKE '%" + location + "%' OR" +
                               " Walk.Postcode LIKE '%" + location + "%' OR Walk.WalkName LIKE '%" + location + "%' AND Walk.Published = 'True'";


            ConnectionClass conn = new ConnectionClass();
            conn.retrieveData(sqlQuery);

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("WalkID", typeof(int)),
                new DataColumn("WalkName",typeof(string)),
                new DataColumn("Location", typeof(string)),
                new DataColumn("WalkAddress", typeof(string)),
                new DataColumn("WalkPostcode", typeof(string)),
                new DataColumn("Description", typeof(string))
            });

            foreach (DataRow dr in conn.SQLTable.Rows)
            {
                int WalkID = (int)dr[0];
                string WalkName = (string)dr[1];
                string Location = (string)dr[2];
                string WalkAddress = (string)dr[3];
                string WalkPostcode = (string)dr[4];
                string Description = (string)dr[5];

                dt.Rows.Add(WalkID, WalkName, Location, WalkAddress, WalkPostcode, Description);
            }

            this.grdWalks.DataSource = dt;
            this.grdWalks.DataBind();
        }

        private void checkCreator()
        {
            Session["WalkID"] = this.grdWalks.SelectedRow.Cells[1].Text;

            string walk = this.grdWalks.SelectedRow.Cells[1].Text;

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
            con.Open();

            string Query = @"SELECT COUNT (*) FROM Walk JOIN Users ON Users.UserID = Walk.UserID WHERE Walk.WalkID = '" + walk + "' AND Walk.Published = 'True'";
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

            Response.Redirect("Walks/User_WalkPreview.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Session["searchWalk"] = txtSearchBar.Text;
            Response.Redirect("searchResults.aspx");
        }

        protected void grdWalks_SelectedIndexChanged1(object sender, EventArgs e)
        {
            checkCreator();
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Session.Remove("searchWalk");
            Response.Redirect("index.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Session.Remove("searchWalk");
            Response.Redirect("LoginPage.aspx");
        }

        protected void btnProfile_Click(object sender, EventArgs e)
        {
            Session.Remove("searchWalk");
            Response.Redirect("User Side/UserProfile.aspx");
        }

        protected void btnSettings_Click(object sender, EventArgs e)
        {
            Session.Remove("searchWalk");
            Response.Redirect("User Side/CRUD User Settings/UserEditSettings.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("index.aspx");
        }
    }
}