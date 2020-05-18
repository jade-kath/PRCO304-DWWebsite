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
    public partial class OB_AllOB : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["Admin"] == null)
            {
                Response.Redirect("LoginPage.aspx");
            }

            bindToGrid();
        }

        private void bindToGrid()
        {
            string sqlQuery = @"SELECT Outbreak.OutbreakID, Outbreak.OutbreakType, Outbreak.OutbreakDate, Walk.WalkName," + 
                               " Location.Location FROM Outbreak JOIN Walk ON Outbreak.WalkID = Walk.WalkID JOIN" +
                               " Location ON Walk.LocationID = Location.LocationID WHERE NewOutbreak = 'False'";

            ConnectionClass conn = new ConnectionClass();
            conn.retrieveData(sqlQuery);

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("OutbreakID", typeof(int)),
                new DataColumn("OutbreakType",typeof(string)),
                new DataColumn("OutbreakDate", typeof(DateTime)),
                new DataColumn("WalkName", typeof(string)),
                new DataColumn("Location", typeof(string))
            });

            foreach (DataRow dr in conn.SQLTable.Rows)
            {
                int OutbreakID = (int)dr[0];
                string OutbreakType = (string)dr[1];
                string OutbreakDate = ((DateTime)dr[2]).ToShortDateString();
                string WalkName = (string)dr[3];
                string Location = (string)dr[4];

                dt.Rows.Add(OutbreakID, OutbreakType, OutbreakDate, WalkName, Location);
            }

            this.grdOutbreaks.DataSource = dt;
            this.grdOutbreaks.DataBind();
        }

        protected void grdOutbreaks_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["OBID"] = this.grdOutbreaks.SelectedRow.Cells[1].Text;
            Session["OB"] = "OB";
            Response.Redirect("OB_OBPreview.aspx");
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("index.aspx");
        }
    }
}