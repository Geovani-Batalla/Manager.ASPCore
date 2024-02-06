using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Business.ASPCore.Referred;

namespace Manager.ASPCore.Controllers
{
    public class ReferredController : BaseController
    {
        public IActionResult Index()
        {
            ReferredUserResult result = new ReferredUserProcess().GetReferralsByUser(Userloged.Id);
            return View(result);
        }
    
        [HttpPost]
        public async Task<IActionResult> Index(IFormCollection collection)
        {
            string Name = collection["ReferredName"].ToString();
            string PhoneNumber = collection["ReferredPhoneNumber"].ToString();
            string Email = collection["ReferredEmail"].ToString();

            int.TryParse(collection["CompanySize"].ToString(), out int CompanySize);
            int.TryParse(collection["WebPage"].ToString(), out int WebPage);
            int.TryParse(collection["UserSource"].ToString(), out int UserSource);
            int.TryParse(collection["Country"].ToString(), out int Country);

            ReferredUserResult result = await new ReferredUserProcess().Add(Name, PhoneNumber, Email, CompanySize, WebPage, UserSource,
                Country, Userloged.Id);
            if (!result.IsValid)
            {
                TempData["Message"] = result.Message;
            }
            return RedirectToAction("Index");
        }
    }
}
