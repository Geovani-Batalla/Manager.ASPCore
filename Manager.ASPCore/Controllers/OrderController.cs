using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.ASPCore.Order;
using Entities.ASPCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Manager.ASPCore.Controllers
{
    public class OrderController : BaseController
    {
        public IActionResult Index()
        {
            OrderResult result = new OrderProcess().Get_Orders(Userloged.Id);
            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(IFormCollection collection)
        {
            int.TryParse(collection["TotalOrders"].ToString(), out int TotalOrders);
            List<Order> Orders =  GetTotalOrders(collection, TotalOrders);

            OrderResult result = await new OrderProcess().AddOrders(Orders);          
            return View(result);
        }

        private List<Order> GetTotalOrders(IFormCollection collection, int TotalOrders)
        {
            List<Order> Orders = new List<Order>();
            for (int i = 0; i < TotalOrders; i++)
            {
                int.TryParse(collection["Quantity_" + i.ToString()].ToString(), out int Quantity);

                if (Quantity > 0)
                {
                    Order order = new Order()
                    {
                        Id = 0,
                        UserId = Userloged.Id,
                        StatId = 1,
                        Amount = Convert.ToDecimal(collection["Amount_" + i.ToString()]),
                        Step = 1
                    };
                    Orders.Add(order);
                }
            }
            return Orders;
        }
    }
}
