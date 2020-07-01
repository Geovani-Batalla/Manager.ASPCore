using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.ASPCore.Stats;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Manager.ASPCore.Controllers
{
    public class StatsController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormCollection collection)
        {
            int.TryParse(collection["TotalOrders"].ToString(), out int TotalOrders);
            int.TryParse(collection["TotalProducts"].ToString(), out int TotalProducts);

            decimal TotalSales = Convert.ToDecimal(collection["TotalSales"]);
            decimal TotalExpenses = Convert.ToDecimal(collection["TotalExpenses"]);

            StatsProcess statsProcess = new StatsProcess();
            StatsResult result = statsProcess.Add(Userloged.Id, TotalSales, TotalOrders, TotalProducts,
                TotalExpenses);
            if (!result.IsValid)
            {
                TempData["Message"] = result.Message;
            }
            return View(result);
        }
    }
}