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
            previewOutbreak();
            Creator();
        }

        private void previewOutbreak()
        {
            string outbreak = Session["OBID"].ToString();
            string sqlQuery = @"SELECT Walk.WalkName, Location.Location, Outbreak.OutbreakDate, Outbreak.OutbreakType," +
                               " Outbreak.WalkID FROM Outbreak JOIN Walk ON Outbreak.WalkID = Walk.WalkID JOIN Location" +
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
                walkID = (string)dr[4];
            }

            Session["WalkID"] = walkID;
            
            //if description is null
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
            con.Open();

            string DescriptQuery = @"SELECT COUNT (*) FROM Outbreak Where OutbreakID = '" + outbreak + "' AND ODescription IS NULL";
            SqlCommand cmdDescript = new SqlCommand(DescriptQuery, con);
            string outputDescript = cmdDescript.ExecuteScalar().ToString();

            if (outputDescript == "1")
            {
                lblIllNotes.Text = "No information available.";
            }
            else
            {
                string Query = @"SELECT ODescription FROM Outbreak WHERE OutbreakID = '" + outbreak + "'";
                ConnectionClass connect = new ConnectionClass();
                connect.retrieveData(Query);

                foreach (DataRow d in connect.SQLTable.Rows)
                {
                    lblIllNotes.Text = (string)d[0];
                }   
            }
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

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("index.aspx");
        }
    }
}