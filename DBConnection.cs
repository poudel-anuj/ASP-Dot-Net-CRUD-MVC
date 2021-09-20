using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Customer
{
    public class DBConnection
    {
        public static string sqlstring = ConfigurationManager.ConnectionStrings["CusCon"].ToString();
        public SqlConnection con;

        public void Connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["CusCon"].ToString();
            con = new SqlConnection(constr);

        }
    }
}