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
    public partial class OB_AddOB : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] == null)
            {
                Response.Redirect("LoginPage.aspx");
            }

                bindToGrid();
                       
        }

        private void bindToGrid()
        {
            string sqlQuery = @"SELECT WalkID, WalkName FROM Walk JOIN Location ON Walk.LocationID = Location.LocationID WHERE Location.LocationID = '" + drpLocation.SelectedValue + "'";

            ConnectionClass conn = new ConnectionClass();
            conn.retrieveData(sqlQuery);

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("WalkID", typeof(int)),
                new DataColumn("WalkName",typeof(string))
            });

            foreach (DataRow dr in conn.SQLTable.Rows)
            {
                int WalkID = (int)dr[0];
                string WalkName = (string)dr[1];

                dt.Rows.Add(WalkID, WalkName);
            }

            this.grdWalkName.DataSource = dt;
            this.grdWalkName.DataBind();
        }


        private void required()
        {
            if (string.IsNullOrEmpty(txtIllDate.Text))
            {
                lblrequired.Visible = true;
            }
            else
            {
                if (string.IsNullOrEmpty(txtIllType.Text))
                {
                    lblrequired.Visible = true;
                }
                else
                {
                    addOutbreak();
                }
            }   
        }

        private void addOutbreak()
        {
            string walk =  this.grdWalkName.SelectedRow.Cells[1].Text;

            if (String.IsNullOrEmpty(txtIllNotes.Text))
            {
                string description = "No further information available.";

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
                con.Open();
                string newOut = "INSERT INTO Outbreak (OutbreakDate, OutbreakType, ODescription, WalkID, UserID, NewOutbreak)" +
                                " VALUES ('" + txtIllDate.Text + "', '" + txtIllType.Text + "', '" + description + "'," +
                                " '" + walk + "', 2, 'False')";

                SqlCommand cmd = new SqlCommand(newOut, con);
                cmd.ExecuteScalar();
                con.Close();
            }
            else
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
                con.Open();
                string newOut = "INSERT INTO Outbreak (OutbreakDate, OutbreakType, ODescription, WalkID, UserID, NewOutbreak)" +
                                " VALUES ('" + txtIllDate.Text + "', '" + txtIllType.Text + "', '" + txtIllNotes.Text + "'," +
                                " '" + walk + "', 2, 'False')";

                SqlCommand cmd = new SqlCommand(newOut, con);
                cmd.ExecuteScalar();
                con.Close();
            }   
        }

        protected void grdWalkName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string walk = this.grdWalkName.SelectedRow.Cells[1].Text;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("OB_AllOB.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            required();
            Response.Redirect("OB_AllOB.aspx");
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("index.aspx");
        }

        protected void drpLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindToGrid();
        }
    }
}