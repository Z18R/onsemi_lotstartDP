using System;
using System.Data;
using System.Data.SqlClient;

namespace autoLotstart_DP
{
    internal class SqlHandler
    {
        private readonly string connectionString = "Server=DESKTOP-6E9LU1F\\SQLEXPRESS;Database=MES_ATEC;User Id=sa;Password=18Bz23efBd0J;TrustServerCertificate=True;Connection Timeout=999999;";


        // Method to Execute a Query (Insert, Update, Delete)
        public int ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    return cmd.ExecuteNonQuery();
                }
            }
        }

        // Method to Retrieve Data (Select Queries)
        public DataTable GetData(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {

                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }
        public void ExecutePreLotStart(DateTime dateFrom, DateTime dateTo)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("CST_ONSEMI_PRELOTSTART_v2", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Add parameters
                        cmd.Parameters.AddWithValue("@DateFrom", dateFrom);
                        cmd.Parameters.AddWithValue("@DateTo", dateTo);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        Console.WriteLine($"Stored procedure executed successfully. Rows affected: {rowsAffected}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error executing stored procedure: " + ex.Message);
                }
            }
        }

        public void ExecuteLotStart()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("CST_ONSEMI_LOTSTART_v2", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 99999; 

                    int rowsAffected = cmd.ExecuteNonQuery();

                    Console.WriteLine($"Records inserted successfully: {rowsAffected}");
                }
            }
        }

        public void ExecuteB2BChecker()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("CST_UPDate_ONSEMI_LOTSTART_v2", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 99999;

                    int rowsAffected = cmd.ExecuteNonQuery();

                    Console.WriteLine($"Records inserted successfully: {rowsAffected}");
                }
            }
        }

    }
}
