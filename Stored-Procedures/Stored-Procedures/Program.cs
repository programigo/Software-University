using System;
using System.Data;
using System.Data.SqlClient;

namespace Stored_Procedures
{
    public class Program
    {
        public static void Main(string[] args)
        {
            OrdinaryExecuteStoredProcedures();
            //AdapterExecuteStoredProcedures();
        }

        public static void OrdinaryExecuteStoredProcedures()
        {
            using (SqlConnection con = new SqlConnection("Server=localhost\\SQLEXPRESS; Database=Bet; Integrated Security=true;"))
            {
                //InsertEvent(con, "dbo.InsertEvent", "2018-06-17", "BG vs Portugal", true);
                //InsertMarket(con, "dbo.InsertMarket", 3, "Some market", false);
                //UpdateEvent(con, "dbo.UpdateEvent", 2, "2018-06-25", "BG vs spain", true);
                //Delete(con, "dbo.DeleteMarket", "MarketId", 4);
            }            
        }

        //private static void UpdateEvent(SqlConnection con, string deleteProcedureName, int eventId, string startDate, string eventName, bool isActive)
        //{
        //    SqlCommand cmd = new SqlCommand(deleteProcedureName, con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //
        //    SqlParameter eId = new SqlParameter();
        //    eId.ParameterName = "@Id";
        //    cmd.Parameters.AddWithValue("@StartingDate", startDate);
        //    cmd.Parameters.AddWithValue("@Name", eventName);
        //    cmd.Parameters.AddWithValue("@IsActive", isActive);
        //
        //    con.Open();
        //    cmd.ExecuteNonQuery();
        //}

        public static void AdapterExecuteStoredProcedures()
        {

        }

        private static void InsertEvent(SqlConnection con, string insertProcedureName, string startDate, string eventName, bool isActive)
        {
            SqlCommand cmd = new SqlCommand(insertProcedureName, con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@StartingDate", startDate);
            cmd.Parameters.AddWithValue("@Name", eventName);
            cmd.Parameters.AddWithValue("@IsActive", isActive);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        private static void InsertMarket(SqlConnection con, string insertProcedureName, int existingEventId, string marketName, bool isActive)
        {
            SqlCommand cmd = new SqlCommand(insertProcedureName, con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@EventId", existingEventId);
            cmd.Parameters.AddWithValue("@Name", marketName);
            cmd.Parameters.AddWithValue("@IsActive", isActive);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        private static void InsertSelection(SqlConnection con, string insertProcedureName, int existingMarkettId, int odds, string selectionName, bool isActive)
        {
            SqlCommand cmd = new SqlCommand(insertProcedureName, con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@MarketId", existingMarkettId);
            cmd.Parameters.AddWithValue("@Odds", odds);
            cmd.Parameters.AddWithValue("@Name", selectionName);
            cmd.Parameters.AddWithValue("@IsActive", isActive);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        private static void Delete(SqlConnection con, string deleteProcedureName, string idParameterName, int eventId)
        {
            SqlCommand cmd = new SqlCommand(deleteProcedureName, con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue(idParameterName, eventId);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        //public static void ExecuteProcedure(string procedureName, SqlConnection connection)
        //{
        //
        //}
    }
}
