using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DogWalking.Admin_Side
{
    public partial class viewUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bindToGrid();
        }

        private void bindToGrid()
        {
            string sqlQuery = @"SELECT Users.UserID, Users.Username, Users.FirstName, Users.LastName, Users.DateOfBirth, Users.EmailAddress, 
                                Location.Location, Users.isAdmin FROM Users JOIN Location ON 
                                Users.LocationID = Location.LocationID WHERE isAdmin = 'False'";

            ConnectionClass conn = new ConnectionClass();
            conn.retrieveData(sqlQuery);

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[8]
            {
                new DataColumn("UserID", typeof(int)),
                new DataColumn("Username",typeof(string)),
                new DataColumn("FirstName", typeof(string)),
                new DataColumn("LastName", typeof(string)),
                new DataColumn("DateOfBirth", typeof(DateTime)),
                new DataColumn("EmailAddress", typeof(string)),                
                new DataColumn("Location", typeof(string)),
                new DataColumn("isAdmin", typeof(Boolean))
            });

            foreach (DataRow dr in conn.SQLTable.Rows)
            {
                int UserID = (int)dr[0];
                string Username = (string)dr[1];
                string FirstName = (string)dr[2];
                string LastName = (string)dr[3];
                string DateOfBirth = ((DateTime)dr[4]).ToShortDateString();
                string EmailAddress = (string)dr[5];
                string Location = (string)dr[6];
                Boolean isAdmin = (Boolean)dr[7];

                dt.Rows.Add(UserID, Username, FirstName, LastName, DateOfBirth, EmailAddress, Location, isAdmin);
            }

            this.grdViewUsers.DataSource = dt;
            this.grdViewUsers.DataBind();
        }

        protected void grdViewUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["updateUser"] = this.grdViewUsers.SelectedRow.Cells[1].Text;
            Response.Redirect("UserDetails.aspx");
        }
    }
}