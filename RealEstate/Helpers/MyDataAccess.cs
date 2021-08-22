﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RealEstate.Helpers
{
    public class MyDataAccess
    {
        private static readonly string _connectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

        public static SqlCommand GetCommand(string commandText)
        {
            SqlConnection sqlConnection = new SqlConnection(_connectionString);
            SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection)
            {
                CommandType = CommandType.StoredProcedure
            };
            return sqlCommand;
        }
        public static int ExecuteNonQuery(SqlCommand sqlCommand)
        {
            sqlCommand.Connection.Open();
            int returnValue = sqlCommand.ExecuteNonQuery();
            sqlCommand.Connection.Close();
            return returnValue;
        }
        public static DataTable GetDataTable(SqlCommand sqlCommand)
        {
            DataTable dataTable = new DataTable();
            sqlCommand.Connection.Open();
            dataTable.Load(sqlCommand.ExecuteReader());
            sqlCommand.Connection.Close();
            return dataTable;
        }
    }
}