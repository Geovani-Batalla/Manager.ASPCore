using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Entities.ASPCore;
using Microsoft.AspNetCore.Http;
using Business.ASPCore.UserProcess;

namespace Manager.ASPCore.Controllers
{
    public class BaseController : Controller
    {
        public User Userloged
        {
            get
            {
                string PhoneNumber = HttpContext.Session.GetString("phone");
                return GetUser(PhoneNumber);
            }
        }

        private User GetUser(string PhoneNumber)
        {
            UserProcess UserProcess = new UserProcess();
            UserResult result = UserProcess.Get(PhoneNumber);
            if (result.IsValid)
            {
                return result.User;
            }
            else
            {
                return new User();
            }
        }
    }
}