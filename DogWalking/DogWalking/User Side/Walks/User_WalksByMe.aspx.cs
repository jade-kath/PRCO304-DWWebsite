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

            string sqlQuery = @"SELECT Walk.WalkName, Location.Location, Walk.WalkAddress, Walk.WalkPostcode FROM Walk JOIN" +
                               " Location ON Location.LocationID = Walk.LocationID JOIN Users ON Walk.UserID = Users.UserID WHERE Users.Username = '" + user + "'" +
                               " AND Walk.NewWalk = 'True' OR Walk.Published = 'False'";

            ConnectionClass conn = new ConnectionClass();
            conn.retrieveData(sqlQuery);

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("WalkName",typeof(string)),
                new DataColumn("Location", typeof(string)),
                new DataColumn("WalkAddress", typeof(string)),
                new DataColumn("WalkPostcode", typeof(string))
            });

            foreach (DataRow dr in conn.SQLTable.Rows)
            {
                string WalkName = (string)dr[0];
                string Location = (string)dr[1];
                string WalkAddress = (string)dr[2];
                string WalkPostcode = (string)dr[3];

                dt.Rows.Add(WalkName, Location, WalkAddress, WalkPostcode);
            }

            this.grdMyWalksPending.DataSource = dt;
            this.grdMyWalksPending.DataBind();
        }

        private void bindToGridConfirmed()
        {
            string user = Session["User"].ToString();

            string sqlQuery = @"SELECT Walk.WalkName, Location.Location, Walk.WalkAddress," + 
                               " Walk.WalkPostcode FROM Walk JOIN Location ON" +
                               " Location.LocationID = Walk.LocationID JOIN Users ON Walk.UserID = Users.UserID WHERE Users.Username = '" + user + "' AND Walk.Published = 'True'";

            ConnectionClass conn = new ConnectionClass();
            conn.retrieveData(sqlQuery);

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("WalkName",typeof(string)),
                new DataColumn("Location", typeof(string)),
                new DataColumn("WalkAddress", typeof(string)),
                new DataColumn("WalkPostcode", typeof(string))
            });

            foreach (DataRow dr in conn.SQLTable.Rows)
            {
                string WalkName = (string)dr[0];
                string Location = (string)dr[1];
                string WalkAddress = (string)dr[2];
                string WalkPostcode = (string)dr[3];

                dt.Rows.Add(WalkName, Location, WalkAddress, WalkPostcode);
            }

            this.grdMyWalksConfirmed.DataSource = dt;
            this.grdMyWalksConfirmed.DataBind();

        }

        protected void grdMyWalksPending_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = grdMyWalksPending.SelectedDataKey.Value.ToString();

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

        protected void grdMyWalksConfirmed_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = grdMyWalksConfirmed.SelectedDataKey.Value.ToString();

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
    }
}
 