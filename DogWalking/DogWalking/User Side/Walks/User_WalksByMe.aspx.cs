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

        private void bindToGridConfirmed()
        {
            string user = Session["User"].ToString();

            string sqlQuery = @"SELECT Walk.WalkID, Walk.WalkName, Location.Location, Walk.WalkAddress," + 
                               " Walk.WalkPostcode FROM Walk JOIN Location ON" +
                               " Location.LocationID = Walk.LocationID JOIN Users ON Walk.UserID = Users.UserID WHERE Users.Username = '" + user + "' AND Walk.Published = 'True'";

            ConnectionClass conn = new ConnectionClass();
            conn.retrieveData(sqlQuery);

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("WalkID", typeof (string)),
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

            this.grdMyWalksConfirmed.DataSource = dt;
            this.grdMyWalksConfirmed.DataBind();

        }

        private void bindToGridPending()
        {
            string user = Session["User"].ToString();

            string sqlQuery = @"SELECT Walk.WalkName, Location.Location, Walk.WalkAddress, Walk.WalkPostcode FROM Walk JOIN" +
                               " Location ON Location.LocationID = Walk.LocationID JOIN Users ON Walk.UserID = Users.UserID WHERE Users.Username = '" + user + "'" +
                               " AND Walk.NewWalk = 'False' OR Walk.Published = 'False'";

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
       

        protected void grdMyWalksPending_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void grdMyWalksConfirmed_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["WalkID"] = this.grdMyWalksConfirmed.SelectedRow.Cells[1].Text;
            Response.Redirect("");
        }

        /* Session["WalkID"] = this.grdMyWalks.SelectedRow.Cells[1].Text;
            Session["userWalk"] = "userWalk";
            Response.Redirect("User_WalkPreview.aspx");
            */
    }
}
 