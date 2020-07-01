using System;
using System.Collections.Generic;
using System.Text;
using static Entities.ASPCore.Enums;

namespace Business.ASPCore.Stats
{
    internal class StatsValidation
    {
        internal static void ValidateAdd(Entities.ASPCore.Stats stats, ref StatsResult result)
        {
            if (stats.UserId <= 0 || stats.Month <= 0 || stats.Year <= 0 || stats.TotalSales <= 0 
                || stats.TotalOrders <= 0 || stats.TotalProducts <= 0 || stats.TotalSales <= 0)
            {
                result.Message = "Please enter all fields";
                result.IsValid = false;
                result.ResultType = ResultType.Info;
            }
        }
    }
}
