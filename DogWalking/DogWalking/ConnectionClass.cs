using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DogWalking
{
    public class ConnectionClass
    {
        SqlConnection SQLCon = new SqlConnection();
        public DataTable SQLTable = new DataTable();

        public ConnectionClass()
        {
            SQLCon.ConnectionString = ConfigurationManager.ConnectionStrings["WalkDB"].ConnectionString;
        }

        public void retrieveData(string command)
        {
            try
            {
                SQLCon.Open();
                SqlDataAdapter da = new SqlDataAdapter(command, SQLCon);
                da.Fill(SQLTable);
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("<script>alert('Something went wrong connecting to db " + ex.Message + "');</script>");
            }
            finally
            {
                SQLCon.Close();
            }
        }
    }
}