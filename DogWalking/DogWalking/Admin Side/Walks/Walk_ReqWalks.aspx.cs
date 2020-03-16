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
    public partial class AdminProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bindToGrid();
        }

        private void bindToGrid()
        {
            string sqlQuery = @"SELECT RequestNewWalk.WalkID, RequestNewWalk.WalkName, Location.Location, RequestNewWalk.WalkAddress, 
                                RequestNewWalk.WalkPostcode FROM RequestNewWalk JOIN Location ON 
                                Location.LocationID = RequestNewWalk.LocationID WHERE NewWalk = 'True'";

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

            this.grdViewWalks.DataSource = dt;
            this.grdViewWalks.DataBind();
        }


    }
}