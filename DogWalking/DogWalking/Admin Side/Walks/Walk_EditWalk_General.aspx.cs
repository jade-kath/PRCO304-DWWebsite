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
    public partial class Walk_EditWalk : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            showWalk();
        }

        private void showWalk()
        {
            string load = Session["WalkID"].ToString();
            string sqlQuery = @"SELECT Walk.WalkName, Walk.WalkAddress, Walk.WalkPostcode, Walk.LocationID," +
                               " Walk.Description, Walk.Hours, Walk.Duration FROM Walk WHERE Walk.WalkName = '" + load + "'";
            ConnectionClass conn = new ConnectionClass();
            conn.retrieveData(sqlQuery);

            foreach (DataRow dr in conn.SQLTable.Rows)
            {
                txtPlaceName.Text = (string)dr[0];
                txtAddress.Text = (string)dr[1];
                txtPostcode.Text = (string)dr[2];
                drpLocation.SelectedIndex = (int)dr[3] - 1;
                txtDescript.Text = (string)dr[4];
                txtTimeLength.Text = (string)dr[5];
                txtDuration.Text = (string)dr[6];
            }
        }

        private void updateGeneral()
        {

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
            conn.Open();
            string updateWalk = "UPDATE Walk SET Walk.WalkName = '" + txtPlaceName.Text + "', Walk.WalkAddress = '" + txtAddress.Text + "'," +
                                " Walk.WalkPostcode = '" + txtPostcode.Text + "', Walk.LocationID = '" + drpLocation.SelectedValue + "'," +
                                " Walk.Description = '" + txtDescript.Text + "', Walk.Hours = '" + txtTimeLength.Text + "'," +
                                " Walk.Duration = '" + txtDuration.Text + "'";

            SqlCommand cmd = new SqlCommand(updateWalk, conn);
            cmd.ExecuteScalar();
            conn.Close();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Walk_WalkPreview.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            updateGeneral();
            Response.Redirect("Walk_WalkPreview.aspx");
        }
    }
}