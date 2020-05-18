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
    public partial class OB_EditOB : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            previewOutbreak();
        }

        private void previewOutbreak()
        {
            string outbreak = Session["OBID"].ToString();
            string sqlQuery = @"SELECT Walk.WalkName, Location.Location, Outbreak.OutbreakDate, Outbreak.OutbreakType," +
                               " FROM Outbreak JOIN Walk ON Outbreak.WalkID = Walk.WalkID JOIN Location" +
                               " ON Location.LocationID = Walk.LocationID WHERE OutbreakID = '" + outbreak + "'";
            ConnectionClass conn = new ConnectionClass();
            conn.retrieveData(sqlQuery);

            foreach (DataRow dr in conn.SQLTable.Rows)
            {
                lblName.Text = (string)dr[0] + ", ";
                lblLocation.Text = (string)dr[1];
                txtIllDate.Text = (string)dr[2];
                txtIllType.Text = (string)dr[3];
                txtIllNotes.Text = (string)dr[4];
            }
        }

        private void updateOutbreak()
        {
            string user = Session["Admin"].ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
            con.Open();
            string updateOut = "UPDATE Outbreak SET OutbreakDate = '" + txtIllDate.Text + "', OutbreakType = '" + txtIllType.Text + "'," +
                            " ODescription = '" + txtIllNotes.Text + "'";

            SqlCommand cmd = new SqlCommand(updateOut, con);
            cmd.ExecuteScalar();
            con.Close();

            Response.Redirect("OB_OBPreview.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("OB_OBPreview.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            updateOutbreak();
        }
    }
}