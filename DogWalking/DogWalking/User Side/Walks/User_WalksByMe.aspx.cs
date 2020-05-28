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
                Response.Redirect("../../LoginPage.aspx");
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

            string pending = @"SELECT Walk.WalkID, Walk.WalkName, Location.Location, Walk.WalkAddress, Walk.WalkPostcode FROM Walk JOIN" +
                               " Location ON Location.LocationID = Walk.LocationID JOIN Users ON Walk.UserID = Users.UserID WHERE Users.Username = '" + user + "'" +
                               " AND Walk.NewWalk = 'True' OR Walk.Published = 'False'";

            ConnectionClass conn = new ConnectionClass();
            conn.retrieveData(pending);

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

            this.grdPending.DataSource = dt;
            this.grdPending.DataBind();
        }

        private void bindToGridConfirmed()
        {
            string user = Session["User"].ToString();

            string confirmed = @"SELECT Walk.WalkID, Walk.WalkName, Location.Location, Walk.WalkAddress, Walk.WalkPostcode," +
                                                    " Walk.Description, Walk.ImagePath FROM Walk JOIN Location ON Location.LocationID = Walk.LocationID" +
                                                    " JOIN Users ON Walk.UserID = Users.UserID WHERE Users.Username = '" + user + "' AND Walk.Published = 'True'";

            ConnectionClass conn = new ConnectionClass();
            conn.retrieveData(confirmed);

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

            this.grdConfirmed.DataSource = dt;
            this.grdConfirmed.DataBind();

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("../UserProfile.aspx");
        }

        protected void btnAddWalk_Click(object sender, EventArgs e)
        {
            Response.Redirect("User_Walk_Add_Page1.aspx");
        }

        protected void grdPending_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["WalkID"] = this.grdPending.SelectedRow.Cells[1].ToString();
            Session["userWalk"] = "userWalk";

            Response.Redirect("../User_WalkPreview.aspx");
        }

        protected void grdConfirmed_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["WalkID"] = this.grdConfirmed.SelectedRow.Cells[1].ToString();
            Session["userWalk"] = "userWalk";

            Response.Redirect("../User_WalkPreview.aspx");
        }
    }
}
 