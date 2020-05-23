using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DogWalking.Admin_Side.Outbreaks
{
    public partial class OB_OBPreview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] == null)
            {
                Response.Redirect("../../index.aspx");
            }

            newOutbreak();
            previewOutbreak();
            Creator();
        }

        private void newOutbreak()
        {
            string outbreak = Session["OBID"].ToString();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
            con.Open();

            string Query = @"SELECT COUNT (*) FROM Outbreak WHERE OutbreakID = '" + outbreak + "' AND NewOutbreak = 'True'";
            SqlCommand cmdQuery = new SqlCommand(Query, con);
            string outputQuery = cmdQuery.ExecuteScalar().ToString();

            if (outputQuery == "1")
            {
                btnPublish.Visible = true;
            }
        }

        private void previewOutbreak()
        {
            string outbreak = Session["OBID"].ToString();
            string sqlQuery = @"SELECT Walk.WalkName, Location.Location, Outbreak.OutbreakDate, Outbreak.OutbreakType," +
                               " Outbreak.ODescription, Outbreak.WalkID FROM Outbreak JOIN Walk ON Outbreak.WalkID = Walk.WalkID JOIN Location" +
                               " ON Location.LocationID = Walk.LocationID WHERE OutbreakID = '" + outbreak + "'";
            ConnectionClass conn = new ConnectionClass();
            conn.retrieveData(sqlQuery);

            string walkID = "";

            foreach (DataRow dr in conn.SQLTable.Rows)
            {
                lblName.Text = (string)dr[0] + ", ";
                lblLocation.Text = (string)dr[1];
                lblIllDate.Text = (string)dr[2];
                lblIllType.Text = (string)dr[3];
                lblIllNotes.Text = (string)dr[4];
                walkID = (string)dr[5];
            }

            Session["WalkID"] = walkID;
        }

        private void Creator()
        {
            string outbreak = Session["OBID"].ToString();
            string creator = @"SELECT Users.Username FROM Users JOIN Outbreak ON Outbreak.UserID = Users.UserID WHERE Outbreak.OutbreakID = '" + outbreak + "'";
            ConnectionClass conn = new ConnectionClass();
            conn.retrieveData(creator);

            foreach (DataRow dr in conn.SQLTable.Rows)
            {
                lblReported.Text = "Reported by: " + (string)dr[0];
            }
        }

        private void postReport()
        {
            string outbreak = Session["OBID"].ToString();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
            con.Open();
            string updateOut = "UPDATE Outbreak SET NewOutbreak = 'False' WHERE OutbreakID = '" + outbreak + "'";

            SqlCommand cmd = new SqlCommand(updateOut, con);
            cmd.ExecuteScalar();
            con.Close();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Session.Remove("OBID");

            if (Session["reqOB"] == null)
            {
                Session.Remove("OB");
                Response.Redirect("OB_AllOB.aspx");
            }
            else if (Session["OB"] == null)
            {
                Session.Remove("reqOB");
                Response.Redirect("OB_ReqOB.aspx");
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
                Response.Redirect("OB_EditOB.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string illDel = Session["OBID"].ToString();

            string delOutbreak = @"DELETE FROM Outbreak WHERE OutbreakID = '" + illDel + "'";
            ConnectionClass con = new ConnectionClass();
            con.retrieveData(delOutbreak);

            Session.Remove("OBID");

            if (Session["reqOB"] == null)
            {
                Session.Remove("OB");
                Response.Redirect("OB_AllOB.aspx");
            }
            else if (Session["OB"] == null)
            {
                Session.Remove("reqOB");
                Response.Redirect("OB_ReqOB.aspx");
            }
        }

        protected void btnWalkPreview_Click(object sender, EventArgs e)
        {
            Session.Remove("OBID");
            Session.Remove("OB");
            Session.Remove("reqOB");

            Response.Redirect("Walk_WalkPreview.aspx");
        }

        protected void btnPublish_Click(object sender, EventArgs e)
        {
            postReport();
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("index.aspx");
        }
    }
}