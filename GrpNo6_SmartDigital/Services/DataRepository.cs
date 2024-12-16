//Group Name: GrpNo6
//Student Number:
//	1.Neerak Jassi: 8965459
//  2.Saipraneeth Kumar Kandepu: 8964643
//  3.Ramadeep Kaur: 8961688
//  4.Ashok Sudbedi: 8972276

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace GrpNo6_SmartDigital.DataService
{
    //Class that is used to execute the query in the database
    public class DataRepository
    {
        private static readonly string _connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        // Execute a SELECT query and return the results as a DataTable
        public DataTable ExecuteSelectQuery(string query)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    return dataTable;
                }
            }
            catch (Exception ex)
            {
                //Logging the expection error in console.
                Console.WriteLine("Error executing select query: " + ex.Message);
                throw;
            }
        }

        // Execute a non-SELECT query (INSERT, UPDATE, DELETE) and return the number of affected rows
        public int ExecuteNonQuery(string query)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                //Logging the expection error in console.
                Console.WriteLine("Error executing non-query: " + ex.Message);
                throw;
            }
        }

        // Execute a non-SELECT query with parameters and return the number of affected rows
        public int ExecuteNonQueryWithParams(string query, Dictionary<string, object> parameters)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddRange(CreateParameters(parameters));

                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                //Logging the expection error in console.
                Console.WriteLine("Error executing non-query with parameters: " + ex.Message);
                throw;
            }
        }

        // Execute a SELECT query with parameters and return the results as a DataTable
        public DataTable ExecuteSelectQueryWithParams(string query, Dictionary<string, object> parameters)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);

                    SqlParameter[] sqlParameters = CreateParameters(parameters);
                    foreach (var param in sqlParameters)
                    {
                        dataAdapter.SelectCommand.Parameters.Add(param);
                    }

                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    return dataTable;
                }
            }
            catch (Exception ex)
            {
                //Logging the expection error in console.
                Console.WriteLine("Error executing select query with parameters: " + ex.Message);
                throw;
            }
        }

        // Method to create SQL parameters dynamically from a dictionary of parameter names and values
        private SqlParameter[] CreateParameters(Dictionary<string, object> parameters)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            foreach (var param in parameters)
            {
                SqlParameter sqlParameter = new SqlParameter(param.Key, param.Value ?? DBNull.Value);
                sqlParameters.Add(sqlParameter);
            }

            return sqlParameters.ToArray();
        }
    }
}
