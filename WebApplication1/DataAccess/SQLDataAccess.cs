using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Data.EntityClient;

namespace CodeTest.DataAccess
{
    public static class SQLDataAccess
    {
        public static string GetConnectionCodeTestDBString()
        {
            return ConfigurationManager.ConnectionStrings["CodeTestDB"].ConnectionString;
        }

        public static DataTable QueryData(string sqlQuery)
        {
            
            DataTable result = new DataTable();
            using (SqlConnection connection =
                   new SqlConnection(GetConnectionCodeTestDBString()))
            {
                SqlCommand command =
                    new SqlCommand(sqlQuery, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();


                result.Load(reader);



            }

            return result;
        }

       
    }
}