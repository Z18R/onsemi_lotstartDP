using System;
using System.Data;

namespace autoLotstart_DP
{
    class Program
    {
        static void Main(string[] args)
        {

            //date time range for testing
            DateTime dateFrom = new DateTime(2024, 3, 1, 0, 0, 0);  // March 1st, 2024 00:00:00
            DateTime dateTo = new DateTime(2024, 3, 31, 23, 59, 59); // March 31st, 2024 23:59:59

            SqlHandler sqlHandler = new SqlHandler();

            //FUNCTION FOR INSERTING DATA FOR LOTSTART DP
            sqlHandler.ExecutePreLotStart(dateFrom, dateTo);

            //INSERT VALUES to cst_onsemi_lotstart
            sqlHandler.ExecuteLotStart();

            //B2B CHECKER
            sqlHandler.ExecuteB2BChecker();

            Environment.Exit(0);


        }
    }
    
}
