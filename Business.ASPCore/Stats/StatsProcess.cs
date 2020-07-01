using Data.ASPCore;
using System;
using static Entities.ASPCore.Enums;

namespace Business.ASPCore.Stats
{
    public class StatsProcess
    {
        public  StatsResult Add(int UserId, decimal TotalSales, int TotalOrders, int TotalProducts, decimal TotalExpenses)
        {
            StatsResult result = new StatsResult()
            {
                IsValid = true,
                Title = "",
                Message = "",
                ResultType = ResultType.Success
            };
            try
            {
                Entities.ASPCore.Stats stats = new Entities.ASPCore.Stats()
                {
                    UserId = UserId,
                    Month = DateTime.Now.Month,
                    Year = DateTime.Now.Year,
                    TotalSales = TotalSales,
                    TotalOrders = TotalOrders,
                    TotalProducts = TotalProducts,
                    TotalExpenses = TotalExpenses
                };

                StatsValidation.ValidateAdd(stats, ref result);
                if (!result.IsValid)
                {
                    return result;
                }
                StatsDAO statsDAO = new StatsDAO();
                statsDAO.AddStats(stats, "Sp_Insert_Stats");          
            }
            catch (Exception ex)
            {
                result.IsValid = false;
                result.Message = ex.Message;
                result.ResultType = ResultType.Error;

            }
            return result;
        }
    }
}
