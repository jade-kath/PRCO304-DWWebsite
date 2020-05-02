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
            bindToGrid();
        }

        private void bindToGrid()
        {
            string user = Session["User"].ToString();

            string sqlQuery = @"SELECT WalkName, Location.Location, WalkAddress, 
                                WalkPostcode FROM Walk JOIN Location ON 
                                Location.LocationID = Walk.LocationID WHERE Walk.UserID = '" + user + "'";

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

            this.grdMyWalks.DataSource = dt;
            this.grdMyWalks.DataBind();
        }

        protected void grdMyWalks_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["WalkID"] = this.grdMyWalks.SelectedRow.Cells[1].Text;
            Session["userWalk"] = "userWalk";
            Response.Redirect("User_WalkPreview.aspx");
        }
    }
}