using System;
using System.Data;

namespace autoLotstart_DP
{
    class Program
    {
        static void Main(string[] args)
        {

            //date time range for testing
            //DateTime dateFrom = new DateTime(2024, 2, 1, 0, 0, 0);  // March 1st, 2024 00:00:00
            //DateTime dateTo = new DateTime(2024, 2, 29, 23, 59, 59); // March 31st, 2024 23:59:59

            //LIVE
            DateTime dateFrom = DateTime.Now.AddDays(-7).Date;  // 7 days ago, start of the day
            DateTime dateTo = DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59); // End of today
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
