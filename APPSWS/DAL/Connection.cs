using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace APPSWS.DAL
{
    public static class Connection
    {
        static string Conecections = ConfigurationManager.ConnectionStrings["Contrs"].ConnectionString;

        public static string GetConnection
        {
            get
            {
                return Conecections;
            }
        }
        public static void openConection(SqlConnection con)
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
        }

        public static void AddParam(SqlCommand cmd, SqlParameter[] para)
        {
            if (para != null)
            {
                for (int i = 0; i < para.Length; i++)
                {
                    cmd.Parameters.Add(para[i]);
                }
            }
        }


    }
}