using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Week18_Lezione1_Esercitazione.Models
{
    public class Commands
    {
        public static SqlConnection ConnectToDb()
        {
            // Get connection data
            string connString = ConfigurationManager.ConnectionStrings["AgenziaSpedizioni"].ToString();
            var conn = new SqlConnection(connString);

            // Open connection to database
            conn.Open();
            return conn;
        }
    }
}