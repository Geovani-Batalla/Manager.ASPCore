using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.ASPCore.Order;
using Microsoft.AspNetCore.Mvc;

namespace Manager.ASPCore.Controllers
{
    public class OrderController : BaseController
    {
        public IActionResult Index()
        {
            OrderProcess orderProcess = new OrderProcess();
            OrderResult result = orderProcess.Get_Orders(Userloged.Id);
            return View(result);
        }
    }
}