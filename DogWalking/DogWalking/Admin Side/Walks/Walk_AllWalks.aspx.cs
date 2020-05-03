using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DogWalking.Admin_Side.Walks
{
    public partial class Walk_AllWalks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] == null)
            {
                Response.Redirect("LoginPage.aspx");
            }

            bindToPublished();
            bindToUnpub();
        }

        private void bindToPublished()
        {
            string sqlQuery = @"SELECT Walk.WalkID, Walk.WalkName, Location.Location, Walk.WalkAddress, Walk.WalkPostcode FROM
                                Walk JOIN Location ON Location.LocationID = Walk.LocationID WHERE Published = 'True'";

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

            this.grdPubWalks.DataSource = dt;
            this.grdPubWalks.DataBind();
        }

        private void bindToUnpub()
        {
            string sqlQuery = @"SELECT Walk.WalkID, Walk.WalkName, Location.Location, Walk.WalkAddress, Walk.WalkPostcode FROM
                                Walk JOIN Location ON Location.LocationID = Walk.LocationID WHERE Published = 'False'";

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

            this.grdUnWalks.DataSource = dt;
            this.grdUnWalks.DataBind();
        }

        protected void grdPubWalks_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["WalkID"] = this.grdPubWalks.SelectedRow.Cells[1].Text;
            Session["Posted"] = "Posted";
            Response.Redirect("Walk_WalkPreview.aspx");
        }

        protected void grdUnWalks_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["WalkID"] = this.grdUnWalks.SelectedRow.Cells[1].Text;
            Session["notPosted"] = "notPosted";
            Response.Redirect("Walk_WalkPreview.aspx");
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("index.aspx");
        }
    }
}