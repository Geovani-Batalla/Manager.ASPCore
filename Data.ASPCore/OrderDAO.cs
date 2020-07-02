using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entities.ASPCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Data.ASPCore
{
    public class OrderDAO
    {
        public List<Order> Get_Orders(int UserId)
        {
            List<Order> result = new List<Order>();
            try
            {
                //Sp_View_Order_V
                using (Db_Context db = new Db_Context())
                {
                    SqlConnection connection = (SqlConnection)db.Database.GetDbConnection();
                    SqlCommand cmd = connection.CreateCommand();
                    connection.Open();
                    cmd.CommandText = "Sp_View_Order_V";
                    cmd.Parameters.AddWithValue("@UserId", UserId);
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

        public async Task<Order> AddAsync(Order order)
        {
            try
            {
                using (Db_Context db = new Db_Context())
                {
                    db.Order.Add(order);
                    await db.SaveChangesAsync();
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            return order;
        }

    }
}
