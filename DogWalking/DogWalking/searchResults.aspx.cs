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

            string sqlQuery = @"SELECT WalkName, Location.Location, WalkAddress, WalkPostcode FROM Walk JOIN" +
                               " Location ON Location.LocationID = Walk.LocationID WHERE Location.Location = " +
                               "'%" + location + "%' OR Walk.Postcode = '%" + location + "%'";

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

            this.grdWalkResults.DataSource = dt;
            this.grdWalkResults.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Session["searchWalk"] = txtSearchBar.Text;
            Response.Redirect("searchResults.aspx");
        }

        protected void grdWalkResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["WalkID"] = this.grdWalkResults.SelectedRow.Cells[1].Text;
            Response.Redirect("Walks/User_WalkPreview.aspx");
        }
    }
}