using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Business.ASPCore;
using Bussines.ASPCore.Session;
using Entities.ASPCore;

namespace Manager.ASPCore.Controllers
{
    public class SessionController : Controller
    {      
        public IActionResult Session()
        {
            UserResult result = new UserResult();
            HttpContext.Session.Remove("phone");
            HttpContext.Session.Remove("Id");
            HttpContext.Session.Remove("idrol");         
            return View(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> Session(IFormCollection collecion)
        {
            UserResult result = await new UserProcess().GetUser(collecion["PhoneNumber"].ToString(), collecion["password"].ToString());
            if (result.IsValid)
            {
                UserResult updateResult = await new UserProcess().UpdateLastLoginDate(result.User.Id);
                if (updateResult.IsValid)
                {
                    HttpContext.Session.SetString("Phone", result.User.PhoneNumber);
                    HttpContext.Session.SetInt32("Id", result.User.Id);
                    HttpContext.Session.SetInt32("Rol_Id", result.User.RolId);
                    HttpContext.Session.SetInt32("Company_Id", result.User.CompanyId);
                    return RedirectToAction("Index", "Order");                   
                }
            }
            TempData["Message"] = result.Message; return RedirectToAction("Session");
        }
    }
}
