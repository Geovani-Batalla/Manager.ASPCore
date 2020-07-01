using Entities.ASPCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data.ASPCore
{
    public class StatsDAO
    {
        public Stats AddStats(Stats stats, string NameProcedure)
        {
            Stats result = new Stats();
            try
            {
                //Sp_Insert_Stats
                //Sp_Update_Stats
                //Sp_Delete_Stats
                using (Db_Context db = new Db_Context())
                {
                    SqlConnection connection = (SqlConnection)db.Database.GetDbConnection();
                    SqlCommand cmd = connection.CreateCommand();
                    connection.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = ""+NameProcedure+"";
                    cmd.Parameters.AddWithValue("@Id", stats.Id);
                    cmd.Parameters.AddWithValue("@UserId", stats.UserId);
                    cmd.Parameters.AddWithValue("@Month", stats.Month);
                    cmd.Parameters.AddWithValue("@Year", stats.Year);
                    cmd.Parameters.AddWithValue("@TotalSales", stats.TotalSales);
                    cmd.Parameters.AddWithValue("@TotalOrders", stats.TotalOrders);
                    cmd.Parameters.AddWithValue("@TotalProducts", stats.TotalProducts);
                    cmd.Parameters.AddWithValue("@TotalExpenses", stats.TotalExpenses);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}
